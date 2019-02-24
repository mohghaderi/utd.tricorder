using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IAppFileService : IServiceBaseT<AppFile, vAppFile>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        AppFileAmazonS3DirectHttpUploadData AmazonUploadRequest(AppFileAmazonUploadRequestSP p);

        AppFileUploadToS3CompletedResponseSP UploadToS3Completed(AppFileUploadToS3CompletedSP p);

        string GetUserProfileImageUrl(long userId);

        AppFileGetDownloadUrlSR GetDownloadUrl(AppFileGetDownloadUrlSP p);

		#endregion
    }
}

