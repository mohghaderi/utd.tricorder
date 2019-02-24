using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UTD.Tricorder.Common.EntityInfos;

namespace AngularJSAuthentication.API.Controllers
{
    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : ApiController
    {

        public RefreshTokensController()
        {

        }

        //[Authorize(Users="Admin")]
        //[Route("")]
        //public IHttpActionResult Get()
        //{
        //    return Ok(_repo.GetAllRefreshTokens());
        //}

        //[Authorize(Users = "Admin")]
        [AllowAnonymous]
        [Route("")]
        public IHttpActionResult Delete(string tokenId)
        {

            var service = WebApiTokenEN.GetService("");
            var token = service.GetByIDT(tokenId, new Framework.Common.GetByIDParameters());
            if (token != null)
            {
                service.Delete(token, new Framework.Common.DeleteParameters());
                return Ok();
            }
            return BadRequest("Token Id does not exist");
        }

    }
}
