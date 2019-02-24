using Framework.Common;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Security;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;
using UTD.Tricorder.Website.Base;

namespace UTD.Tricorder.Website.Providers
{

    [Serializable]
    public sealed class CustomIdentity : IIdentity
    {

        private readonly string _name;
        private readonly string _email;
        // and other stuffs

        public CustomIdentity(string name, string email) {
        _name = name.Trim();
        if(string.IsNullOrWhiteSpace(name))
            return;
        _email = email;
    }

        public string Name
        {
            get { return _name; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string AuthenticationType
        {
            get { return "CustomIdentity"; }
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrWhiteSpace(_name); }
        }

    }



    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                string clientId = string.Empty;
                string clientSecret = string.Empty;
                vWebApiClient client = null;

                if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
                {
                    context.TryGetFormCredentials(out clientId, out clientSecret);
                }

                if (context.ClientId == null)
                {
                    //Remove the comments from the below line context.SetError, and invalidate context 
                    //if you want to force sending clientId/secrects once obtain access tokens. 
                    context.Validated();
                    context.SetError("invalid_clientId", "ClientId should be sent.");
                    return Task.FromResult<object>(null);
                }

                client = WebApiClientEN.GetService("").GetByClientCode(clientId);

                if (client == null)
                {
                    context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                    return Task.FromResult<object>(null);
                }

                if (client.CheckSecret)
                {
                    if (string.IsNullOrWhiteSpace(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Client secret should be sent.");
                        return Task.FromResult<object>(null);
                    }
                    else
                    {
                        if (client.SecretKey != clientSecret)
                        {
                            context.SetError("invalid_clientId", "Client secret is invalid.");
                            return Task.FromResult<object>(null);
                        }
                    }
                }

                if (!client.IsActive)
                {
                    context.SetError("invalid_clientId", "Client is inactive.");
                    return Task.FromResult<object>(null);
                }

                if (client.UserApprovalStatusID != (byte)EntityEnums.UserApprovalStatusEnum.Approved)
                {
                    context.SetError("invalid_clientId", "Client is locked or cancelled.");
                    return Task.FromResult<object>(null);
                }

                if (client.SiteID != 0) // if the access was not to the top root of all xecare sites
                if (FWUtils.SecurityUtils.GetCurrentSiteID() != client.SiteID)
                {
                    context.SetError("invalid_clientId", "Client doesn't access to API of this current site.");
                    return Task.FromResult<object>(null);
                }

                context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
                context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshLifeTimeMinutes.ToString());

                context.Validated();
                return Task.FromResult<object>(null);
            }
            catch (Exception ex)
            {
                var msg = FWUtils.ExpLogUtils.ExceptionTranslator.TryToTranslate(ex).Message;
                context.SetError("error", msg);
                return Task.FromResult<object>(null);
            }
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {

                var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

                if (allowedOrigin == null) allowedOrigin = "*";

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

                User user = null;
                try
                {
                    if (context.UserName == "loginwithsinglesignontoken#")
                    {
                        var userId = UserEN.GetService("").LoginWithLoginToken(context.Password);
                        if (userId != null)
                        {
                            user = UserEN.GetService().GetByIDT(userId.Value, new GetByIDParameters());
                        }
                    }
                    else if (context.UserName == "loginwithregistertoken#")
                    {
                        user = UserEN.GetService("").LoginWithRegisterOffsiteInfo(context.Password);
                    }
                    else
                    {
                        UserValidateUserNamePasswordSP p = new UserValidateUserNamePasswordSP();
                        p.UserName = context.UserName;
                        p.Password = context.Password;
                        p.ThrowIfError = true;
                        user = (User)UserEN.GetService("").ValidateUserNamePassword(p);
                    }
                }
                catch (UserException ex)
                {
                    context.SetError("invalid_grant", ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    context.SetError("invalid_grant", ex.Message);
                    return;
                }

                if (user != null)
                {
                    var roleIds = UserInRoleEN.GetService("").GetRolesIDUserID(user.UserID.ToString());
                    string roleIdCommaSeparated = FWUtils.EntityUtils.ConvertObjectToString(roleIds);

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserID.ToString()));
                    identity.AddClaim(new Claim("sub", user.UserID.ToString()));
                    //identity.AddClaim(new Claim("role", "user"));
                    identity.AddClaim(new Claim("roleIds", roleIdCommaSeparated));
                    identity.AddClaim(new Claim("siteId", FWUtils.SecurityUtils.GetCurrentSiteID().ToString()));

                    var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        { 
                            "as:client_id", (context.ClientId == null) ? string.Empty : context.ClientId
                        },
                        { 
                            "userName", user.UserID.ToString()
                        }
                    });

                    var ticket = new AuthenticationTicket(identity, props);
                    var validationResult = context.Validated(ticket);
                    if (validationResult == false)
                        context.SetError("invalid_grant", "Ticket is not valid. Try again.");

                    // setting cookies for authentication in ASP.NET MVC
                //    ClaimsIdentity cookiesIdentity = await userManager.CreateIdentityAsync(user,
                //CookieAuthenticationDefaults.AuthenticationType);

                    //CustomIdentity cidentity = new CustomIdentity(user.UserID.ToString(), user.Email.ToString());
                    ////ClaimsIdentity cookiesIdentity = new ClaimsIdentity(identity.Claims, CookieAuthenticationDefaults.AuthenticationType);
                    //ClaimsIdentity cookiesIdentity = new ClaimsIdentity(cidentity, identity.Claims, CookieAuthenticationDefaults.AuthenticationType, null, null);
                    //context.Request.Context.Authentication.SignIn(cookiesIdentity);

                    //FormsAuthentication.SetAuthCookie(user.UserID.ToString(), true);
                }
            }
            catch (Exception ex)
            {
                var msg = FWUtils.ExpLogUtils.ExceptionTranslator.TryToTranslate(ex).Message;
                context.SetError("error", msg);
            }

        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            try
            {
                var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
                var currentClient = context.ClientId;

                if (originalClient != currentClient)
                {
                    context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                    return Task.FromResult<object>(null);
                }

                // Change auth ticket for refresh token requests
                var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
                newIdentity.AddClaim(new Claim("newClaim", "newValue"));

                var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
                context.Validated(newTicket);

                return Task.FromResult<object>(null);
            }
            catch (Exception ex)
            {
                var msg = FWUtils.ExpLogUtils.ExceptionTranslator.TryToTranslate(ex).Message;
                context.SetError("error", msg);
                return Task.FromResult<object>(null);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            try
            {
                foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
                {
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
                }

                return Task.FromResult<object>(null);
            }
            catch (Exception ex)
            {
                var msg = FWUtils.ExpLogUtils.ExceptionTranslator.TryToTranslate(ex).Message;
                //context.Response. .SetError("error", msg);
                return Task.FromResult<object>(msg);
            }
        }

    }
}