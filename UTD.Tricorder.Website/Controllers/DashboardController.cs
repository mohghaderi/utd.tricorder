using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTD.Tricorder.Service.PreRequisite;
using UTD.Tricorder.Website.Base;
using UTD.Tricorder.Website.Helpers;

namespace UTD.Tricorder.Website.Controllers
{
    public class DashboardController : ViewControllerBase
    {
        [RequiresSSL]
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            //PreRequisiteInfoChecker checker = new PreRequisiteInfoChecker();

            //var userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            //string redirectUrl = checker.CheckAndReturnNextForm(userId);
            //if (string.IsNullOrEmpty(redirectUrl) == false)
            //{
            //    redirectUrl = redirectUrl.Replace(".aspx", "");
            //    //redirectUrl = redirectUrl.Replace("~/Pages/Pages/PersonInsert.aspx", "Register/PersonInfo");

            //    return new RedirectResult(redirectUrl);
            //}
            //else
            //    return View();

            return View();
        }

        [RequiresSSL]
        public ActionResult AjaxView(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new EmptyResult();

            if (id.ToLower() == "index")
                return new EmptyResult(); // don't let recursive index loading

            //if (id == "MainMenu") // this is the only difference because main menu is diffrernt for different users
            //{
            //    // Developer Note: Don't cache main menu view 
            //    if (UserIsDoctor())
            //        id = "DoctorMenu";
            //    else
            //        id = "PatientMenu";
            //}
            id = id.Replace("-", "/");
            return PartialView("~/Views/Dashboard/" + id + ".cshtml");
        }

        private bool UserIsDoctor()
        {
            try
            {
                return FWUtils.SecurityUtils.HasRole("Doctor");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ActionResult ShowRelatedView()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            else
                return View();
        }


	}
}