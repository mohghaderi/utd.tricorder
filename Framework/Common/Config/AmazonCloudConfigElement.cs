using System.Configuration;

namespace Framework.Common.Config
{
    public class AmazonCloudConfigElement : ConfigurationElement
    {
        public AmazonCloudConfigElement() { }

        [ConfigurationProperty("s3")]
        public S3ConfigElement S3
        {
            get { return (S3ConfigElement)this["s3"]; }
            set { this["s3"] = value; }
        }



    }
}
