using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class AppFileBR : BusinessRuleBase<AppFile, vAppFile>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        public void AmazonUploadRequestPre(AppFileAmazonUploadRequestSP p)
        {
            if (p.AppFileTypeID == 0)
                throw new Exception("File type is not specified AmazonUploadRequestPre.");
            if (string.IsNullOrEmpty(p.FileName))
                throw new Exception("File name is not specified AmazonUploadRequestPre.");
            if (p.AppEntityRecordIDValue == 0)
                throw new Exception("RecordID is not specified for AmazonUploadRequestPre.");
        }

        public void AmazonUploadRequest(AppFileType type, AppFileAmazonUploadRequestSP p)
        {
            if (type == null)
                throw new Exception("File type is not specified AmazonUploadRequest.");

            // checking file size
            if (string.IsNullOrEmpty(p.FileSize) == false)
            {
                int size = 0;
                if (int.TryParse(p.FileSize, out size))
                {
                    if (size < type.MinFileSize || size > type.MaxFileSize)
                        throw new BRException(
                            string.Format(BusinessErrorStrings.AppFile.InvalidFileSize_MinMax, 
                            FWUtils.MiscUtils.GetReadableFileSize(type.MinFileSize),
                            FWUtils.MiscUtils.GetReadableFileSize(type.MaxFileSize)
                            ));
                }
            }

            // checking file type
            string fileType = FWUtils.MiscUtils.GetFileTypeByFileName(p.FileName);
            if (string.IsNullOrEmpty(p.FileName) == false
                && string.IsNullOrEmpty(type.AcceptableFormatsCommaSeparated) == false)
            {
                if (string.IsNullOrEmpty(fileType))
                    throw new BRException(BusinessErrorStrings.AppFile.FileTypeEmpty);

                string[] acceptableFileTypeArray = type.AcceptableFormatsCommaSeparated.Split(',');
                bool isAcceptable = false;
                foreach(string s in acceptableFileTypeArray)
                    if (s.ToLower() == fileType)
                    {
                        isAcceptable = true;
                        break;
                    }
                if (isAcceptable == false)
                            throw new BRException(string.Format(BusinessErrorStrings.AppFile.InvalidFileType, 
                            fileType,
                            type.AcceptableFormatsCommaSeparated
                            ));
            }


        }


		

		#endregion

    }
}

