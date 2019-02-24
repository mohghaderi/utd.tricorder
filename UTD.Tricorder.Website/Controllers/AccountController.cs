//using AngularJSAuthentication.API.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using UTD.Tricorder.Common.EntityInfos;
//using UTD.Tricorder.Common.SP;

//namespace AngularJSAuthentication.API.Controllers
//{
//    [RoutePrefix("api/Account")]
//    public class AccountController : ApiController
//    {

//        public AccountController()
//        {
//        }


//        // POST api/Account/Register
//        [AllowAnonymous]
//        [Route("Register")]
//        public async Task<IHttpActionResult> Register(UserModel userModel)
//        {
//             if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//             var service = UserEN.GetService("").Register(new UserRegisterSP()
//                 {
//                     userName = userModel.UserName,
//                     password = userModel.Password,
//                     email = userModel.UserName + "@" + userModel.UserName,
//                 });

//             //IdentityResult result = await _repo.RegisterUser(userModel);

//             //IHttpActionResult errorResult = GetErrorResult(result);

//             //if (errorResult != null)
//             //{
//             //    return errorResult;
//             //}

//             return Ok();
//        }

//        //public IHttpActionResult Get() {

//        //    var result =  new
//        //    {
//        //        IP = HttpContext.Current.Request.UserHostAddress,
//        //        HostName =    HttpContext.Current.Request.UserHostName,
//        //        Url = HttpContext.Current.Request.Url.Host,
//        //        XOriginalURL = HttpContext.Current.Request.Headers.GetValues("X-Original-URL"),
//        //        HeaderKeys = HttpContext.Current.Request.Headers.AllKeys,
//        //        Origin = HttpContext.Current.Request.Headers.GetValues("Origin")
//        //    };

//        //    return Ok(result);

//        //}

//        //private IHttpActionResult GetErrorResult(IdentityResult result)
//        //{
//        //    if (result == null)
//        //    {
//        //        return InternalServerError();
//        //    }

//        //    if (!result.Succeeded)
//        //    {
//        //        if (result.Errors != null)
//        //        {
//        //            foreach (string error in result.Errors)
//        //            {
//        //                ModelState.AddModelError("", error);
//        //            }
//        //        }

//        //        if (ModelState.IsValid)
//        //        {
//        //            // No ModelState errors are available to send, so just return an empty BadRequest.
//        //            return BadRequest();
//        //        }

//        //        return BadRequest(ModelState);
//        //    }

//        //    return null;
//        //}
//    }
//}
