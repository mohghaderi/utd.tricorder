using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    public enum DetailEntityTabViewEnum
    {
        /// <summary>
        /// uses EntityInfo.ListingUrlTemplate
        /// </summary>
        Default = 0,
        /// <summary>
        /// uses any provided url
        /// Templates can be created by FWUtils.UrlTemplateUtils.TemplateName
        /// </summary>
        CustomUrlTemplate = 1,

        /// <summary>
        /// The edit form
        /// </summary>
        EditForm = 2
    }
}
