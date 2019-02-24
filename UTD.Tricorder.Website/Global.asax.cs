using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UTD.Tricorder.Service.NotificationSystem;
using UTD.Tricorder.Website.Controllers;
using UTD.Tricorder.Website.Helpers;

namespace UTD.Tricorder.Website
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        // no singleton, just on instance of this
        public static NotificationSenderAgent notificationAgent = new NotificationSenderAgent();


        protected void Application_Start()
        {
            //this.BeginRequest += WebApiApplication_BeginRequest;
            this.Error += Application_Error;
            PublishDatabase();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var appSettings = FWUtils.ConfigUtils.GetAppSettings();

            //Register our customer view engine to customize all views based on tenants
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new FWViewEngine());
            //this.BeginRequest += WebApiApplication_BeginRequest;

            // overriding Api selector since it has a bug that doesn't work with underscore
            // for urls like Doctor_Patient-MyDoctors
            GlobalConfiguration.Configuration.Services.Replace(typeof(System.Web.Http.Dispatcher.IHttpControllerSelector),
            new ApiControllerSelector(GlobalConfiguration.Configuration));

            i18nLib.InitAlli18nTexts();
            MobilePushMessageNotificationSender.InitGoogleCloudMessagingService();

            notificationAgent.StartAgent();
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            //http://www.digitallycreated.net/Blog/57/getting-the-correct-http-status-codes-out-of-asp.net-custom-error-pages
            //if (Context.IsCustomErrorEnabled)
                ShowCustomErrorPage(Server.GetLastError());
        }

        private void ShowCustomErrorPage(Exception exception)
        {
            try
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(Server.GetLastError(), null);

                if (FWUtils.WebUIUtils.IsAjaxRequest() == false &&
                    IsStaticFileRequest() == false)
                {

                    HttpException httpException = exception as HttpException;
                    if (httpException == null)
                        httpException = new HttpException(500, "Internal Server Error", exception);

                    Response.Clear();
                    RouteData routeData = new RouteData();
                    routeData.Values.Add("culture", UIText.CultureName());
                    routeData.Values.Add("controller", "Error");
                    routeData.Values.Add("fromAppErrorEvent", true);

                    switch (httpException.GetHttpCode())
                    {
                        case 403:
                            routeData.Values.Add("action", "AccessDenied403");
                            break;

                        case 404:
                            routeData.Values.Add("action", "NotFound404");
                            break;

                        case 500:
                            routeData.Values.Add("action", "ServerError500");
                            break;

                        default:
                            routeData.Values.Add("action", "GenericHttpError");
                            //routeData.Values.Add("httpStatusCode", httpException.GetHttpCode());
                            break;
                    }

                    Server.ClearError();

                    IController controller = new ErrorController();
                    controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                }

            }
            catch (Exception)
            {
                // this is the last part of the project that we can catch errors
                // if it didn't work, we can't do anything else
            }

        }

        private bool IsStaticFileRequest()
        {
            try
            {
                return Request.CurrentExecutionFilePathExtension != "";
            }
            catch (Exception)
            {
                return false;
            }
        }


        //void WebApiApplication_Error(object sender, EventArgs e)
        //{

        //    FWUtils.ExpLogUtils.ExceptionLogger.LogError(Server.GetLastError(), null);

        //    // TODO: Check if AJAX request returns internal error code 500 or not
        //    Server.ClearError();

        //    try
        //    {
        //        if (Response != null)
        //        {
        //            // Possible that a partially rendered page has already been written to response buffer before encountering error, so clear it.
        //            Response.Clear();

        //            // Finally redirect, transfer, or render a error view
        //            Response.Redirect("~/" + UIText.CultureName() + "/Default/Error", true);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //    }
        //}



        private void PublishDatabase()
        {
            // We don't do publish database because we will have several app servers,
            // and they may start to publish database at the same time causing unexpected results
            // So, DB update should be done manually.

            //FWUtils.ConfigUtils.GetAppSettings().DatabaseContexts[0].
            //UTD.Tricorder.DatabasePublisher.SQLPublisher.PublishDatabase()
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            notificationAgent.Dispose();
        }




    }
}
