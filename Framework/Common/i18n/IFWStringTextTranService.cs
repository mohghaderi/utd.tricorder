using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public interface IFWStringTextTranService
    {
        IList<IFWStringTextTranObj> GetAllAcceptedTranslations();
    }
}
