using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public interface IFWStringTextTranObj
    {


        /// <summary>
        /// identifier
        /// </summary>
        Guid StringTextID { get; }

        /// <summary>
        /// translation value
        /// </summary>
        string TranValue { get; }


        /// <summary>
        /// CultureName
        /// </summary>
        string CultureName { get; }


        /// <summary>
        /// Language ID
        /// </summary>
        short LanguageID { get; }

    }
}
