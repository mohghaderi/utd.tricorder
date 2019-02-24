using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTD.Tricorder.Common.EntityInfos;

namespace UTD.Tricorder.Website.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Person()
        {
            ViewBag.PersonID = FWUtils.SecurityUtils.GetCurrentUserIDString();
            return View();
        }

        public ActionResult UserPaymentInfo()
        {
            var service = UserEN.GetService("");
            var user = service.GetByIDT(FWUtils.SecurityUtils.GetCurrentUserIDLong(), new GetByIDParameters());
            ViewBag.UserPaymentInfoPayPalEmail = user.Email;
            return View();
        }

        public ActionResult Doctor()
        {
            return View(); 
        }

        public ActionResult Doctor_Specialty()
        {
            return View();
        }

        public ActionResult Doctor_Insurance()
        {
            return View();
        }

        public ActionResult Doctor_USState()
        {
            return View();
        }

        public ActionResult User_Language()
        {
            return View();
        }

        public ActionResult DoctorScheduleAddBatch()
        {
            return View();
        }

        public ActionResult DoctorScheduleWeekViewSelect()
        {
            return View();
        }

        public ActionResult DoctorScheduleList()
        {
            return View();
        }

        public ActionResult DoctorScheduleEdit()
        {
            return View();
        }

        public ActionResult DoctorScheduleWeekView()
        {
            return View();
        }

        public ActionResult MyDoctors()
        {
            return View();
        }

        public ActionResult MyPatients()
        {
            return View();
        }
	}
}