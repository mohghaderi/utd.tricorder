using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public interface IFWSiteDomainService
    {
        int? GetSiteIDByHostName(string hostName);
    }
}
