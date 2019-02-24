using Framework.Common;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Website.Base;

namespace UTD.Tricorder.Website.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            //try
            //{
                var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

                if (string.IsNullOrEmpty(clientid))
                {
                    return;
                }

                //TODO: I removed hashed tokens to reduce database size

                //var refreshTokenId = Guid.NewGuid().ToString("n");

                var service = WebApiTokenEN.GetService("");


                var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

                WebApiToken token = WebApiTokenEN.GetEntityObjectT();
                token.WebApiTokenID = Guid.NewGuid();
                token.WebApiClientID = WebApiClientEN.GetService().GetByClientCode(clientid).WebApiClientID;
                token.UserID = Convert.ToInt64(context.Ticket.Identity.Name);
                token.IssuedUtc = DateTime.UtcNow;
                token.ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime));
                token.ProtectedTicket = context.SerializeTicket();

                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

                service.AddToken(token);

                context.SetToken(token.WebApiTokenID.ToString("n"));
            //}
            //catch (Exception ex)
            //{
            //    var result = UIUtils.GetExceptionActionResult(ex);
            //    context.Response.
            //}

        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string tokenString = context.Token;
            //string tokenString = FWUtils.SecurityUtils.CreateHashString(context.Token);
            Guid tokenId = new Guid(tokenString);

            var service = WebApiTokenEN.GetService("");
            var refreshToken = service.GetByIDT(tokenId, new GetByIDParameters());

            //string hashedTokenId = FWUtils.SecurityUtils.CreateHashString(context.Token);

            //using (AuthRepository _repo = new AuthRepository())
            //{
            //    var refreshToken = await _repo.FindRefreshToken(hashedTokenId);

            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                service.Delete(refreshToken, new DeleteParameters());
            }
            //}
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}