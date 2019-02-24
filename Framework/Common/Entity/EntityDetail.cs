using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{

    /// <summary>
    /// Details of an Entity. This details will be shown as tabs in edit forms
    /// </summary>
    public class EntityDetail
    {
        public string EntityName { get; set; }
        public string AdditionalData { get; set; }
        public string TabTitle { get; set; }
        public string TabCustomUrl { get; set; }
        public bool TabHidden { get; set; }
        public DetailEntityTabViewEnum EditType { get; set; }
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Defines the related column name to the master entity
        /// for example RelatedColumnName=PersonID when Person is detail of User
        /// </summary>
        public string RelatedColumnName { get; set; }

        public EntityDetail()
        {
        }

        public EntityDetail(string entityName, string additionalData, string relatedColumnName)
        {
            Check.Require(string.IsNullOrEmpty(entityName) == false);
            if (additionalData == null)
                additionalData = "";
            Check.Require(string.IsNullOrEmpty(relatedColumnName) == false);

            this.EntityName = entityName;
            this.AdditionalData = additionalData;
            this.RelatedColumnName = relatedColumnName;
            this.EditType = DetailEntityTabViewEnum.Default;
        }


        public bool IsValidInfo()
        {
            bool isValid = true;
            if (this.EditType == DetailEntityTabViewEnum.CustomUrlTemplate)
                if (string.IsNullOrEmpty(this.TabCustomUrl) == true)
                    isValid = false;
            return isValid;
        }

    }
}
