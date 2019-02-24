using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Config
{
    /// <summary>
    /// configuration for Amazon S3 file management
    /// </summary>
    public class S3ConfigElement : ConfigurationElement
    {
        public S3ConfigElement() { }

        [ConfigurationProperty("mainAccount", DefaultValue = "", IsRequired = true)]
        public string MainAccount
        {
            get { return (string)this["mainAccount"]; }
            set { this["mainAccount"] = value; }
        }

        [ConfigurationProperty("accessKeyID", DefaultValue = "", IsRequired = true)]
        public string AccessKeyID
        {
            get { return (string)this["accessKeyID"]; }
            set { this["accessKeyID"] = value; }
        }

        [ConfigurationProperty("secretAccessKey", DefaultValue = "", IsRequired = true)]
        public string SecretAccessKey
        {
            get { return (string)this["secretAccessKey"]; }
            set { this["secretAccessKey"] = value; }
        }

        /// <summary>
        /// region end point system name like us-west-2
        /// </summary>
        [ConfigurationProperty("regionEndpoint", DefaultValue = "us-west-2", IsRequired = true)]
        public string RegionEndpoint
        {
            get { return (string)this["regionEndpoint"]; }
            set { this["regionEndpoint"] = value; }
        }


        [ConfigurationProperty("bucketName", DefaultValue = "", IsRequired = true)]
        public string BucketName
        {
            get { return (string)this["bucketName"]; }
            set { this["bucketName"] = value; }
        }

        [ConfigurationProperty("successRedirectUrl", DefaultValue = "", IsRequired = true)]
        public string SuccessRedirectUrl
        {
            get { return (string)this["successRedirectUrl"]; }
            set { this["successRedirectUrl"] = value; }
        }

        [ConfigurationProperty("defaultUploadAcl", DefaultValue = "private", IsRequired = true)]
        public string DefaultUploadAcl
        {
            get { return (string)this["defaultUploadAcl"]; }
            set { this["defaultUploadAcl"] = value; }
        }

        [ConfigurationProperty("defaultSignedUrlExpirationMinutes", DefaultValue = 5, IsRequired = true)]
        public int DefaultSignedUrlExpirationMinutes
        {
            get { return (int)this["defaultSignedUrlExpirationMinutes"]; }
            set { this["defaultSignedUrlExpirationMinutes"] = value; }
        }

        [ConfigurationProperty("defaultServerSideEncryption", DefaultValue = "", IsRequired = true)]
        public string DefaultServerSideEncryption
        {
            get { return (string)this["defaultServerSideEncryption"]; }
            set { this["defaultServerSideEncryption"] = value; }
        }

    }
}
