using Framework.Common;
using Framework.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using UTD.Tricorder.Website.Base.SignalR;
using UTD.Tricorder.Website.Providers;

// it doesn't work if Microsoft.Owin.Host.SystemWeb Assembly is not available, 

[assembly: OwinStartup(typeof(UTD.Tricorder.Website.Startup))]

namespace UTD.Tricorder.Website
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //http://www.asp.net/aspnet/overview/owin-and-katana/owin-oauth-20-authorization-server


            //HttpConfiguration config = new HttpConfiguration();

            //ConfigureOAuth(app);

            //WebApiConfig.Register(config);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);
            ////Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, AngularJSAuthentication.API.Migrations.Configuration>());
            // Enable the Application Sign In Cookie.

            //// Enable the External Sign In Cookie.
            //app.SetDefaultSignInAsAuthenticationType("External");
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = "External",
            //    AuthenticationMode = AuthenticationMode.Passive,
            //    CookieName = CookieAuthenticationDefaults.CookiePrefix + "External",
            //    ExpireTimeSpan = TimeSpan.FromMinutes(5),
            //});


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //AuthenticationMode = AuthenticationMode.Passive,
                LoginPath = new PathString("/Default/Login/"),
                LogoutPath = new PathString("/Default/Signout/"),
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            HttpConfiguration config = GlobalConfiguration.Configuration;

            ConfigureOAuth(app);

            //WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, AngularJSAuthentication.API.Migrations.Configuration>());

            // Any connection or hub wire up and configuration should go here
            MapSignalR(app);
        }


        public void MapSignalR(IAppBuilder app)
        {
            string sqlConnectionString = NHibernateSessionContext.GetNHibernateConnectionString("default");
            // Any connection or hub wire up and configuration should go here

            //http://www.asp.net/signalr/overview/guide-to-the-api/handling-connection-lifetime-events#timeoutkeepalive

            // Make long polling connections wait a maximum of 110 seconds for a
            // response. When that time expires, trigger a timeout command and
            // make the client reconnect.
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(110);

            // Wait a maximum of 30 seconds after a transport connection is lost
            // before raising the Disconnected event to terminate the SignalR connection.
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(10);

            // For transports other than long polling, send a keepalive packet every
            // 10 seconds. 
            // This value must be no more than 1/3 of the DisconnectTimeout value.
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(3);
            
            
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule()); 
            //GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);

            app.MapSignalR();
        }




        public void ConfigureOAuth(IAppBuilder app)
        {
            // TODO: Complete authentication with this guide 
            // http://www.asp.net/aspnet/overview/owin-and-katana/owin-oauth-20-authorization-server

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
            
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
                //AuthorizationCodeProvider = new SimpleAuthorizationCodeProvider()
            };
            

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            //HttpConfiguration config = GlobalConfiguration.Configuration;
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthServerOptions.AuthenticationType));





        }
    }

}