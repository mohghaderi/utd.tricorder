using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{
    //public struct AppFileAmazonUploadRequestReturnSP
    //{
    //    public string AmazonPolicy;
    //    public string AmazonSignature;
    //    public string AmazonKey;
    //    public long AppFileID;
    //}

    public struct AppFileAmazonS3DirectHttpUploadData
    {
        public long AppFileID;
        public string UploadUrl;
        public string Key;
        public string Acl;
        public string PolicyBase64;
        public string SignatureBase64;
        public string AppFileUUID;
        public string ServerSideEncryption;
        public string AccessKeyID;
    }

    public struct AppFileAmazonUploadRequestSP
    {
        public int AppFileTypeID;
        public long AppEntityRecordIDValue;
        public string FileName;
        public string FileSize;
        public string ContentType;
        public string FileDate;
    }

    public struct AppFileS3RequestReplaceFileSP
    {
        public long AppFileID;
    }

    public struct AppFileUploadToS3CompletedSP
    {
        public long AppFileID;
        public string FileSize;
        public string FileDate;
        public string ContentType;
    }

    public struct AppFileUploadToS3CompletedResponseSP
    {
        public string DownloadUrl;
    }

    public struct AppFileCompleteRequestSP
    {
        public long AppFileID;
    }

    public struct AppFileGetDownloadUrlSR
    {
        public string DownloadUrl;
    }

    public struct AppFileGetDownloadUrlSP
    {
        public long AppFileID;
    }

    public struct AppFileDeleteFileSP
    {
        public long AppFileID;
    }

}
