using System.Web;
using System.Web.Mvc;
using UTD.Tricorder.Website.Base.Attributes;
using UTD.Tricorder.Website.Base.i18n;

namespace UTD.Tricorder.Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CulturalAuthorizeAttribute());
            filters.Add(new SetCultureByRequestMvcAttribute());
        }
    }
}
