using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class AppFileService : ServiceBase<AppFile, vAppFile>, IAppFileService
    {


        #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        public static Amazon.S3.AmazonS3Client s3Client = null;
        public static Framework.Common.Config.S3ConfigElement s3Settings = null;

        public override void OnAfterInitialize()
        {
            base.OnAfterInitialize();

            if (s3Settings == null)
                s3Settings = FWUtils.ConfigUtils.GetAppSettings().AmazonCloud.S3;
            if (s3Client == null)
                s3Client = new Amazon.S3.AmazonS3Client(s3Settings.AccessKeyID, s3Settings.SecretAccessKey, Amazon.RegionEndpoint.GetBySystemName(s3Settings.RegionEndpoint));
        }


        /// <summary>
        /// Amazons the upload request information of for Amazon S3
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        public AppFileAmazonS3DirectHttpUploadData AmazonUploadRequest(AppFileAmazonUploadRequestSP p)
        {
            Check.Require(string.IsNullOrEmpty(p.FileName) == false);
            Check.Require(p.AppFileTypeID > 0);
            Check.Require(p.AppEntityRecordIDValue > 0);

            var biz = (AppFileBR)BusinessLogicObject;
            biz.AmazonUploadRequestPre(p);

            vAppFile appFile = null;
            AppFileType fileType = (AppFileType)AppFileTypeEN.GetService().GetByID(p.AppFileTypeID, new GetByIDParameters());

            // checking business rules at first
            biz.AmazonUploadRequest(fileType, p);

            if (fileType.HasSecurityCheck == true)
                CheckUploadRequestSecurity((EntityEnums.AppEntityFileTypeEnum)fileType.AppFileTypeID, p);

            if (fileType.MaxNumberOfFiles == 1) // single file upload
            {
                FilterExpression filter = new FilterExpression();
                filter.AddFilter(vAppFile.ColumnNames.AppFileTypeID, p.AppFileTypeID);
                filter.AddFilter(vAppFile.ColumnNames.AppEntityRecordIDValue, p.AppEntityRecordIDValue);
                IList<vAppFile> list = GetByFilterV(new GetByFilterParameters(filter));
                if (list.Count == 0) // create a record
                {
                    appFile = InsertNewFile(p.FileName, p.AppFileTypeID, p.AppEntityRecordIDValue);
                }
                else
                {
                    appFile = list[0];
                }
            }
            else  // multiple file upload
            {
                appFile = InsertNewFile(p.FileName, p.AppFileTypeID, p.AppEntityRecordIDValue);
            }

            long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            var result = GetAmazonUploadData(fileType, appFile);

            return result;
        }

        /// <summary>
        /// Sends a request to replace a file in Amazon S3
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        public AppFileAmazonS3DirectHttpUploadData S3RequestReplaceFile(AppFileS3RequestReplaceFileSP p)
        {
            var file = GetByIDV(p.AppFileID);
            if (file != null)
            {
                //string key = GetFileKeyByFileInfo(file);
                //DeleteFromS3(key); // deletes the file from S3 to make sure that the old file doesn't exists

                AppFileType fileType = (AppFileType)AppFileTypeEN.GetService().GetByID(file.AppFileTypeID, new GetByIDParameters());
                long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
                var result = GetAmazonUploadData(fileType, file);
                result.AppFileID = file.AppFileID;
                return result;
            }
            else
                throw new UserException(StringMsgs.BusinessErrors.RecordIsNotAvailable);

        }

        /// <summary>
        /// Client will call this function when upload of the file completed in S3
        /// </summary>
        /// <param name="p">parameters</param>
        public AppFileUploadToS3CompletedResponseSP UploadToS3Completed(AppFileUploadToS3CompletedSP p)
        {
            var response = new AppFileUploadToS3CompletedResponseSP();
            var file = GetByIDV(p.AppFileID);
            if (file != null)
            {
                if (FileExistsS3(GetFileKeyByFileInfo(file)))
                {
                    file.AppFileUploadStatusID = (short)EntityEnums.AppEntityFileUploadStatus.Completed;

                    // file size
                    int fileSize = 0;
                    if (int.TryParse(p.FileSize, out fileSize))
                        file.FileSize = fileSize;
                    else
                        file.FileSize = null;

                    // file date
                    DateTime dt;
                    if (DateTime.TryParse(p.FileDate, out dt))
                        file.FileDate = dt;
                    else
                        file.FileDate = null;

                    // we ignore content type storing at this time to reduce storge costs

                    Update(file);
                    response.DownloadUrl = GetS3SignedUrlByFileID(p.AppFileID);
                }
            }
            else
                throw new UserException(StringMsgs.BusinessErrors.RecordIsNotAvailable);

            return response;
        }

        /// <summary>
        /// Inserts the new file into the database
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileTypeId">The file type identifier.</param>
        /// <param name="appEntityRecordIDValue">The application entity record identifier value.</param>
        /// <returns></returns>
        public vAppFile InsertNewFile(string fileName, int fileTypeId, long appEntityRecordIDValue)
        {
            AppFile appFile = new AppFile();
            appFile.AppFileTypeID = fileTypeId;
            appFile.AppEntityRecordIDValue = appEntityRecordIDValue;
            appFile.FileName = fileName;
            appFile.FileType = FWUtils.MiscUtils.GetFileTypeByFileName(fileName);
            appFile.FileUUID = Guid.NewGuid();
            appFile.AppFileUploadStatusID = (short)EntityEnums.AppEntityFileUploadStatus.Incomplete;
            Insert(appFile);
            return GetByIDV(appFile.AppFileID); // get the data again from the database to have all relations data
        }


        /// <summary>
        /// Checks the upload request security.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="p">The p.</param>
        /// <exception cref="ServiceSecurityException">
        /// You can't change profile picture of other users.
        /// or
        /// You can't upload medical documents for other users.
        /// or
        /// Only doctor of a visit can attach a file to a visit
        /// </exception>
        /// <exception cref="System.NotImplementedException"></exception>
        private void CheckUploadRequestSecurity(EntityEnums.AppEntityFileTypeEnum fileType, AppFileAmazonUploadRequestSP p)
        {
            long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            switch (fileType)
            {
                case EntityEnums.AppEntityFileTypeEnum.Test_Picture_Upload:
                    // this is for test purposes so no security!
                    break;
                case EntityEnums.AppEntityFileTypeEnum.User_Profile_Picture:
                    if (p.AppEntityRecordIDValue != userId)
                        throw new ServiceSecurityException("You can't change profile picture of other users.");
                    break;
                case EntityEnums.AppEntityFileTypeEnum.User_MedicalDocuments:
                    if (p.AppEntityRecordIDValue != userId)
                        if (FWUtils.SecurityUtils.HasRole("Doctor") == false)
                            throw new ServiceSecurityException("You can't upload medical documents for other users. Only the patient and doctors can upload medical documents");
                    break;
                case EntityEnums.AppEntityFileTypeEnum.Visit_Attachments:
                    var visit = VisitEN.GetService().GetByIDV(p.AppEntityRecordIDValue, new GetByIDParameters());
                    if (visit.DoctorID != userId)
                        throw new ServiceSecurityException("Only doctor of a visit can attach a file to a visit");
                    break;
                default:
                    throw new NotImplementedException(); //KEEP this line. This is to know if a new type added and how to check security for it.
            }

        }

        /// <summary>
        /// Gets the amazon upload data.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="selectedFileName">Name of the selected file.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="recordId">The record identifier.</param>
        /// <returns></returns>
        private AppFileAmazonS3DirectHttpUploadData GetAmazonUploadData(AppFileType type, vAppFile file)
        {
            Check.Require(file != null);
            Check.Require(type != null);

            var encoding = new System.Text.UTF8Encoding();

            AppFileAmazonS3DirectHttpUploadData result = new AppFileAmazonS3DirectHttpUploadData();

            string uuid = file.FileUUID.ToString("N");

            //result.AppFileID = file.AppFileID;
            result.UploadUrl = GetFileServerHttp();
            result.AccessKeyID = FWUtils.ConfigUtils.GetAppSettings().AmazonCloud.S3.AccessKeyID;
            result.Key = GetFileKeyByFileInfo(file);
            result.Acl = s3Settings.DefaultUploadAcl;
            string policyText = GetAmazonPolicyText(type, result.Key, result.Acl, uuid);
            result.PolicyBase64 = Convert.ToBase64String(encoding.GetBytes(policyText));
            result.SignatureBase64 = GetAmazonSignatureBase64(policyText);

            result.ServerSideEncryption = s3Settings.DefaultServerSideEncryption;
            result.AppFileUUID = uuid;
            result.AppFileID = file.AppFileID;

            return result;
        }

        public string GetFileServerHttp()
        {
            return "https://" + FWUtils.ConfigUtils.GetAppSettings().AmazonCloud.S3.BucketName + ".s3.amazonaws.com/";
        }

        /// <summary>
        /// Gets the file key by file information.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        private string GetFileKeyByFileInfo(vAppFile file)
        {
            return GetFileKeyByPathTemplate(file.VirtualPathTemplate, file.FileName, file.InsertUserID, file.AppEntityRecordIDValue.ToString());
        }

        /// <summary>
        /// Gets the file key by path template.
        /// </summary>
        /// <param name="virtualPathTemplate">The virtual path template.</param>
        /// <param name="selectedFileName">Name of the selected file.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="recordid">The recordid.</param>
        /// <returns></returns>
        public string GetFileKeyByPathTemplate(string virtualPathTemplate, string selectedFileName, long userId, string recordid)
        {
            Check.Require(string.IsNullOrEmpty(selectedFileName) == false);
            if (string.IsNullOrEmpty(recordid) == false)
                Check.Require(recordid.IndexOf('/') == -1); // no slash in recordid because of key

            string filetype = FWUtils.MiscUtils.GetFileTypeByFileName(selectedFileName);

            string fileName = virtualPathTemplate;
            fileName = fileName.Replace("{userid}", userId.ToString());
            fileName = fileName.Replace("{filetype}", filetype);
            fileName = fileName.Replace("{filename}", selectedFileName);
            fileName = fileName.Replace("{recordid}", recordid);

            return fileName;
        }

        /// <summary>
        /// returns policy text for a selected filetype
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        private string GetAmazonPolicyText(AppFileType fileType, string key, string acl, string uuid)
        {
            const string AWS_ISO_FORMAT = "yyyy-MM-ddTHH:mm:ss.fffZ";
            string bucketName = s3Settings.BucketName;
            string expirationDate = DateTime.Now.AddHours(10).ToUniversalTime().ToString(AWS_ISO_FORMAT, System.Globalization.CultureInfo.InvariantCulture);
            string serversideEncryption = s3Settings.DefaultServerSideEncryption;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("{ \"expiration\": \"").Append(expirationDate).Append("\",");
            sb.Append("  \"conditions\": [");
            sb.Append("    {\"bucket\": \"").Append(bucketName).Append("\"},");
            sb.Append("    [\"starts-with\", \"$key\", \"").Append(key).Append("\"],");
            sb.Append("    {\"acl\": \"").Append(acl).Append("\"},");
            sb.Append("    [\"content-length-range\", \"").Append(fileType.MinFileSize).Append("\", \"").Append(fileType.MaxFileSize).Append("\"],");
            sb.Append("    {\"success_action_status\": \"").Append(200).Append("\"},");
            //sb.Append("    {\"success_action_redirect\": \"").Append(successRedirectUrl).Append("\"},");
            //sb.Append("    [\"starts-with\", \"$Content-Type\", \"image/\"],");
            sb.Append("    {\"x-amz-meta-uuid\": \"").Append(uuid).Append("\"},");
            // we shouldn't have redirect here because it's a UI thing. We may add redirect later as a parameter coming from UI.
            //sb.Append("    {\"redirect\": \"").Append(FWUtils.ConfigUtils.GetAppSettings().Project.WebsiteUrl).Append("Scripts/jquery-fileupload/cors/result.html?a=1").Append("\"},");
            if (serversideEncryption != "None") // having None as a value will cause an exception in Amazon Post
                sb.Append("    {\"x-amz-server-side-encryption\": \"").Append(s3Settings.DefaultServerSideEncryption).Append("\"},");
            sb.Append("  ]");
            sb.Append("}");


            //var policy =
            //new
            //{
            //    // one hour policy
            //    expiration = DateTime.Now.AddHours(10).ToUniversalTime().ToString(AWS_ISO_FORMAT, System.Globalization.CultureInfo.InvariantCulture),
            //    conditions = new object[]
            //            {
            //                new { bucket = bucketName },
            //                new [] { "starts-with", "$key", key },
            //                new { acl = acl },
            //                new { success_action_status = "200" },
            //                new object[] { "content-length-range", fileType.MinFileSize, fileType.MaxFileSize },
            //                //new [] { "starts-with", "$Content-Type", "" }
            //                new [] { "x-amz-meta-uuid", uuid},
            //                new [] { "x-amz-server-side-encryption", s3Settings.DefaultServerSideEncryption}
            //            }
            //};

            //var serializedPolicy = FWUtils.EntityUtils.JsonSerializeObject(policy);
            //String serializedPolicy = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(policy);
            String serializedPolicy = sb.ToString();
            return serializedPolicy;
        }


        /// <summary>
        /// returns the signature produced by the provided policy
        /// </summary>
        /// <param name="policy">amazon policy</param>
        /// <returns></returns>
        private string GetAmazonSignatureBase64(string policy)
        {
            string secretKey = s3Settings.SecretAccessKey;

            var encoding = new System.Text.ASCIIEncoding();
            var policyBytes = encoding.GetBytes(policy);
            var base64Policy = Convert.ToBase64String(policyBytes);

            var secretKeyBytes = encoding.GetBytes(secretKey);
            var hmacsha1 = new System.Security.Cryptography.HMACSHA1(secretKeyBytes);

            var base64PolicyBytes = encoding.GetBytes(base64Policy);
            var signatureBytes = hmacsha1.ComputeHash(base64PolicyBytes);

            return Convert.ToBase64String(signatureBytes);
        }

        /// <summary>
        /// Gets the s3 signed URL (https) by file identifier.
        /// </summary>
        /// <param name="fileId">The file identifier.</param>
        /// <returns></returns>
        public string GetS3SignedUrlByFileID(long fileId)
        {
            var file = GetByIDV(fileId);
            if (file == null)
                return "";
            else
            {
                string key = GetFileKeyByFileInfo(file);
                return GetS3SignedUrlAccess(key, s3Settings.DefaultSignedUrlExpirationMinutes);
            }

        }

        /// <summary>
        /// Gets the s3 signed URL access (for https access).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expirationMinutes">The expiration minutes.</param>
        /// <returns></returns>
        public string GetS3SignedUrlAccess(string key, int expirationMinutes)
        {
            Amazon.S3.Model.GetPreSignedUrlRequest request1 = new Amazon.S3.Model.GetPreSignedUrlRequest()
            {
                BucketName = s3Settings.BucketName,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                Protocol = Amazon.S3.Protocol.HTTPS
            };

            string url = s3Client.GetPreSignedURL(request1);
            return url;
        }

        /// <summary>
        /// Gets the s3 signed URL access (for https access).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetS3SignedUrlAccessByHour(string key)
        {
            var utcNow = DateTime.UtcNow;

            Amazon.S3.Model.GetPreSignedUrlRequest request1 = new Amazon.S3.Model.GetPreSignedUrlRequest()
            {
                BucketName = s3Settings.BucketName,
                Key = key,
                Expires = DateTime.UtcNow.Date.AddHours(utcNow.Hour + 1),
                Protocol = Amazon.S3.Protocol.HTTPS
            };

            string url = s3Client.GetPreSignedURL(request1);
            return url;
        }

        public string GetUserProfileImageUrl(long userId)
        {
            var appFileType = AppFileTypeEN.GetService().GetByIDT((int)EntityEnums.AppFileTypeEnum.ProfilePicture);
            var key = GetFileKeyByPathTemplate(appFileType.VirtualPathTemplate, "profile.jpg", userId, userId.ToString());
            return GetS3SignedUrlAccessByHour(key);
        }


        /// <summary>
        /// Uploads a file to s3.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="fileBytes">The file bytes.</param>
        /// <param name="contentType">Type of the content.</param>
        public void UploadFileToS3(string key, byte[] fileBytes, string contentType, Guid fileUUID)
        {
            //http://docs.aws.amazon.com/AmazonS3/latest/dev/UploadObjSingleOpNET.html
            //http://stackoverflow.com/questions/18635963/asp-net-uploading-a-file-to-amazon-s3

            var stream = new System.IO.MemoryStream(fileBytes);
            stream.Position = 0;

            var putRequest1 = new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = s3Settings.BucketName,
                Key = key,
                InputStream = stream,
                ContentType = contentType,
                CannedACL = new Amazon.S3.S3CannedACL(s3Settings.DefaultUploadAcl),
                ServerSideEncryptionMethod = Amazon.S3.ServerSideEncryptionMethod.None
            };
            // DEVELOPER NOTE: this this function with appfile.js file
            putRequest1.Metadata.Add("uuid", fileUUID.ToString("N"));
            Amazon.S3.Model.PutObjectResponse response1 = s3Client.PutObject(putRequest1);
        }

        /// <summary>
        /// Deletes a file from s3.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        public void DeleteFromS3(string keyName)
        {
            var deleteObjectRequest =
            new Amazon.S3.Model.DeleteObjectRequest
            {
                BucketName = s3Settings.BucketName,
                Key = keyName
            };

            s3Client.DeleteObject(deleteObjectRequest);
        }


        /// <summary>
        /// Check if a files exists on s3.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        public bool FileExistsS3(string keyName)
        {
            //http://stackoverflow.com/questions/3526585/determine-if-an-object-exists-in-a-s3-bucket-based-on-wildcard
            try
            {
                S3GetObjectMetaData(keyName);
                return true;
            }

            catch (Amazon.S3.AmazonS3Exception ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;

                //status wasn't not found, so throw the exception
                throw;
            }
        }

        /// <summary>
        /// Gets meta data of a file on S3. 
        /// It throws AmazonS3Exception if any error happens
        /// </summary>
        /// <param name="keyName">key name</param>
        /// <returns></returns>
        private Amazon.S3.Model.GetObjectMetadataResponse S3GetObjectMetaData(string keyName)
        {
            var request = new Amazon.S3.Model.GetObjectMetadataRequest();
            request.BucketName = s3Settings.BucketName;
            request.Key = keyName;
            var objectMetaData = s3Client.GetObjectMetadata(request);
            return objectMetaData;
        }


        public AppFileGetDownloadUrlSR GetDownloadUrl(AppFileGetDownloadUrlSP p)
        {
            return new AppFileGetDownloadUrlSR()
            {
                DownloadUrl = GetS3SignedUrlByFileID(p.AppFileID)
            };
               
        }

        /// <summary>
        /// Deletes a file from the database and from Amazon S3
        /// </summary>
        /// <param name="p"></param>
        public void DeleteFile(AppFileDeleteFileSP p)
        {
            var file = GetByIDV(p.AppFileID);
            if (file != null)
            {
                var filet = GetByIDT(p.AppFileID);
                Delete(filet);
                // delete from database

                string key = GetFileKeyByFileInfo(file);
                DeleteFromS3(key); // deletes the file from S3 to make sure that the old file doesn't exists
            }

        }


        #endregion

    }
}

