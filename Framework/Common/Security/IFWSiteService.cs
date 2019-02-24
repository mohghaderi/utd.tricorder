using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public interface IFWSiteService
    {
        /// <summary>
        /// Gets site identifier by its code
        /// </summary>
        /// <param name="code">site code</param>
        /// <returns>site id and if it was not found null</returns>
        int? GetSiteIDBySiteCode(string code);
    }
}
