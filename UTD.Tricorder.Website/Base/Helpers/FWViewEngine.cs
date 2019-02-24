using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Helpers
{
    public class FWViewEngine : RazorViewEngine
    {
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (string.IsNullOrEmpty(partialViewName) == false &&
                partialViewName.StartsWith("~/"))
            {
                string viewPath = SiteUI.GetViewPath(partialViewName);
                return base.FindPartialView(controllerContext, viewPath, useCache);
            }
            else
                return base.FindPartialView(controllerContext, partialViewName, useCache);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (string.IsNullOrEmpty(viewName) == false &&
                viewName.StartsWith("~/"))
            {
                string viewPath = SiteUI.GetViewPath(viewName);
                return base.FindView(controllerContext, viewPath, masterName, useCache);
            }
            else
                return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return base.CreateView(controllerContext, SiteUI.GetViewPath(viewPath), masterPath);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return base.CreatePartialView(controllerContext, SiteUI.GetViewPath(partialPath));
        }

    }



    //// http://stackoverflow.com/questions/9838766/implementing-a-custom-razorviewengine
    //public class FWViewEngine : RazorViewEngine
    //{
    //    private string[] _newAreaViewLocations = new string[] {
    //        "~/Areas/{2}/%1Views/{1}/{0}.cshtml",
    //        "~/Areas/{2}/%1Views/{1}/{0}.vbhtml",
    //        "~/Areas/{2}/%1Views//Shared/{0}.cshtml",
    //        "~/Areas/{2}/%1Views//Shared/{0}.vbhtml"
    //    };

    //    private string[] _newAreaMasterLocations = new string[] {
    //        "~/Areas/{2}/%1Views/{1}/{0}.cshtml",
    //        "~/Areas/{2}/%1Views/{1}/{0}.vbhtml",
    //        "~/Areas/{2}/%1Views/Shared/{0}.cshtml",
    //        "~/Areas/{2}/%1Views/Shared/{0}.vbhtml"
    //    };

    //    private string[] _newAreaPartialViewLocations = new string[] {
    //        "~/Areas/{2}/%1Views/{1}/{0}.cshtml",
    //        "~/Areas/{2}/%1Views/{1}/{0}.vbhtml",
    //        "~/Areas/{2}/%1Views/Shared/{0}.cshtml",
    //        "~/Areas/{2}/%1Views/Shared/{0}.vbhtml"
    //    };

    //    private string[] _newViewLocations = new string[] {
    //        "~/%1Views/{1}/{0}.cshtml",
    //        "~/%1Views/{1}/{0}.vbhtml",
    //        "~/%1Views/Shared/{0}.cshtml",
    //        "~/%1Views/Shared/{0}.vbhtml"
    //    };

    //    private string[] _newMasterLocations = new string[] {
    //        "~/%1Views/{1}/{0}.cshtml",
    //        "~/%1Views/{1}/{0}.vbhtml",
    //        "~/%1Views/Shared/{0}.cshtml",
    //        "~/%1Views/Shared/{0}.vbhtml"
    //    };

    //    private string[] _newPartialViewLocations = new string[] {
    //        "~/%1Views/{1}/{0}.cshtml",
    //        "~/%1Views/{1}/{0}.vbhtml",
    //        "~/%1Views/Shared/{0}.cshtml",
    //        "~/%1Views/Shared/{0}.vbhtml"
    //    };

    //    public FWViewEngine()
    //        : base()
    //    {
    //        //Enum.TryParse<BrandNameEnum>(Travel2.WebUI.Properties.Settings.Default.BrandName, out BrandName);

    //        AreaViewLocationFormats = AppendLocationFormats(_newAreaViewLocations, AreaViewLocationFormats);

    //        AreaMasterLocationFormats = AppendLocationFormats(_newAreaMasterLocations, AreaMasterLocationFormats);

    //        AreaPartialViewLocationFormats = AppendLocationFormats(_newAreaPartialViewLocations, AreaPartialViewLocationFormats);

    //        ViewLocationFormats = AppendLocationFormats(_newViewLocations, ViewLocationFormats);

    //        MasterLocationFormats = AppendLocationFormats(_newMasterLocations, MasterLocationFormats);

    //        PartialViewLocationFormats = AppendLocationFormats(_newPartialViewLocations, PartialViewLocationFormats);
    //    }

    //    private string[] AppendLocationFormats(string[] newLocations, string[] defaultLocations)
    //    {
    //        List<string> viewLocations = new List<string>();
    //        viewLocations.AddRange(newLocations);
    //        viewLocations.AddRange(defaultLocations);
    //        return viewLocations.ToArray();
    //    }

    //    protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
    //    {
    //        Tenant.GetTenant()

    //        return base.CreateView(controllerContext, viewPath.Replace("%1", BrandName.ToString()), masterPath);
    //    }

    //    protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
    //    {
    //        return base.CreatePartialView(controllerContext, partialPath.Replace("%1", BrandName.ToString()));
    //    }

    //    protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
    //    {
    //        return base.FileExists(controllerContext, virtualPath.Replace("%1", BrandName.ToString()));
    //    }
    //}
}