
entityControllerFactory.create("AppFile", "UploadSingle", function ($scope, sParams) {
    $scope.S3UploadData = {};

    if ($scope.AppFileTypeID === undefined)
        $scope.AppFileTypeID = sParams.$routeParams.AppFileTypeID;
    if ($scope.AppEntityRecordIDValue === undefined)
        $scope.AppEntityRecordIDValue = sParams.$routeParams.MasterID;

    $scope.validate = function($file) {
        return true;
    }

    $scope.fileSelected = function ($files, $event) {
        $.each($files, function (index, file) {
            $scope.ExecInline('AmazonUploadRequest', {
                AppFileTypeID: $scope.AppFileTypeID,
                AppEntityRecordIDValue: $scope.AppEntityRecordIDValue,
                FileName: file.name
                , FileSize: file.size
                //,FileDate: file.lastModifiedDate
                , ContentType: file.type
            }, function (e) {
                $scope.S3UploadData = e.response.data;
                file.AppFileID = $scope.S3UploadData.AppFileID;
                var uData = $scope.S3UploadData;

                var angularUpload = sParams.$upload.upload({
                    url: uData.UploadUrl, //S3 upload url including bucket name
                    method: 'POST',
                    fields : {
                        key: uData.Key, // the key to store the file on S3, could be file name or customized
                        AWSAccessKeyId: uData.AccessKeyID,
                        acl: uData.Acl, // sets the access to the uploaded file in the bucket: private or public 
                        policy: uData.PolicyBase64, // base64-encoded json policy (see article below)
                        signature: uData.SignatureBase64, // base64-encoded signature based on policy string (see article below)
                        //"Content-Type": file.type != '' ? file.type : 'application/octet-stream', // content type of the file (NotEmpty)
                        success_action_status: 200,
                        "x-amz-meta-uuid": uData.AppFileUUID,
                        "x-amz-server-side-encryption": "AES256",
                        //filename: file.name // this is needed for Flash polyfill IE8-9
                    },
                    file: file
                }); // upload

                var notify = sParams.$window.ShowProgress("Uploading "  + file.name + " ...");
                angularUpload.progress(function (evt) {
                    //console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
                    notify.update({ 'progress': parseInt(100.0 * evt.loaded / evt.total) })
                }).success(function (data, status, headers, config) {
                    $scope.ExecInline('UploadToS3Completed', {
                        AppFileID: file.AppFileID
                        , FileSize: file.size
                        , FileDate: file.lastModifiedDate ? moment.utc(file.lastModifiedDate).format('YYYY-MM-DDTHH:mm:ss' + "Z") : ''
                        , ContentType: file.type
                    }, function (e) {
                        file.DownloadUrl = e.response.data.DownloadUrl; // returns access to the file on Amazon server
                        $scope.FileUploadSuccess(file);
                    });
                    notify.close();
                }).error(function (err) {
                    sParams.$window.ShowError("An error happened while uploading " + file.name + "." + err);
                    notify.close();
                });

            }); // Exec AmazonUploadRequest
        }); // for each
    }; //fileSelected
    if ($scope.FileUploadSuccess === undefined)
    {
        $scope.FileUploadSuccess = function () {
            sParams.$window.ShowMessage("Upload of " + file.name + " completed successfully!", false);
            if (sParams.$location.path() == "/AppFile-UploadSingle")
                $scope.GoBack();
        }
    }

    $scope.init = function () {

    }


});

entityControllerFactory.create("AppFile", "Grid", function ($scope, sParams) {
    BaseControllers.AddGridFunctions($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "File list is empty.";

    if ($scope.AppFileTypeID === undefined)
        $scope.AppFileTypeID = sParams.$routeParams.AppFileTypeID;
    if ($scope.AppEntityRecordIDValue === undefined)
        $scope.AppEntityRecordIDValue = sParams.$routeParams.MasterID;

    $scope.HumanFileSize = function (bytes) {
        //http://stackoverflow.com/questions/10420352/converting-file-size-in-bytes-to-human-readable
        if (bytes == 0) { return "0.00 B"; }
        var e = Math.floor(Math.log(bytes) / Math.log(1024));
        return (bytes / Math.pow(1024, e)).toFixed(2) + ' ' + ' KMGTP'.charAt(e) + 'B';
    }

    $scope.ListFilter = {
        "FiltersList":
        [
            { "ColumnName": "AppEntityRecordIDValue", "Value": $scope.AppEntityRecordIDValue },
            { "ColumnName": "AppFileTypeID", "Value": $scope.AppFileTypeID }
        ]
    };

    $scope.GetDownloadUrl = function (file) {
        $scope.ExecInline('GetDownloadUrl', {
            AppFileID: file.AppFileID
        }, function (e) {
            file.DownloadUrl = e.response.data.DownloadUrl;
        });
    };

    $scope.Download = function (file) {
        sParams.$window.openExternal(file.DownloadUrl);
    }

    $scope.DeleteFile = function (id) {
        if (id) {
            $scope.Confirm("Are you sure that you want to delete this item?", function () {
                $scope.ExecInline('DeleteFile',
                    { AppFileID: id }
                 , function () {
                     $scope.RefreshList();
                     sParams.$window.ShowMessage("File deleted successfully!");
                });
            });
        }
    }

});
