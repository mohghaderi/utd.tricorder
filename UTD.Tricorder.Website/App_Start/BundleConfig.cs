using System.Web;
using System.Web.Optimization;

namespace UTD.Tricorder.Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            ////bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            ////            "~/Scripts/jquery-ui-{version}.js"));

            ////bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            ////            "~/Scripts/jquery.unobtrusive-ajax.min.js",
            ////            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/basescripts").Include(
            //           "~/Scripts/nav.js",
            //           "~/Scripts/scripts.js"
            //    ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //           "~/Content/Styles/reset.css",
            //           "~/Content/Styles/base.css",
            //           "~/Content/Styles/font-awesome.min.css",
            //           "~/Content/Styles/webiox.css",
            //           "~/Content/Styles/main.css",
            //           "~/Content/Styles/layout.css"));

            bundles.Add(new ScriptBundle("~/jsbundles/bootstrap").Include(
                       "~/Scripts/jquery-2.1.1.min.js",
                       "~/Scripts/jquery-cookie/jquery.cookie.js",
                       "~/Scripts/jquery-loadmask/jquery.loadmask.js",
                       "~/Scripts/bootstrap-3.2.0-dist/js/bootstrap.min.js",
                       "~/Scripts/bootstrapvalidator-dist-0.5.0/dist/js/bootstrapValidator.js"
                       ));

            bundles.Add(new ScriptBundle("~/jsbundles/angularjs").Include(
            "~/Scripts/angularjs/angular.min.js",
            "~/Scripts/angularjs/angular-animate.min.js",
            "~/Scripts/angularjs/angular-route.min.js",
            "~/Scripts/angular-local-storage.min.js",
            "~/Scripts/angularjs/angular-loader.min.js",
            "~/Scripts/loading-bar.min.js",
            "~/Scripts/angular-file-upload/angular-file-upload.min.js"
            ));

            bundles.Add(new Bundle("~/jsbundles/appcommon").Include(
                "~/app/app.js",
                "~/app/services/authInterceptorService.js",
                "~/app/services/errorHandlerInterceptorService.js",
                "~/app/services/authService.js",
                "~/app/services/tokensManagerService.js",
                "~/app/services/entityService.js",
                "~/app/controllers/indexController.js",
                "~/app/controllers/loginController.js",
                "~/app/controllers/refreshController.js",
                "~/app/controllers/tokensManagerController.js",
                "~/app/controllers/entityController.js",
                "~/app/entitycontrollers/User.js",
                "~/app/window.js"
            ));

            bundles.Add(new ScriptBundle("~/jsbundles/uicomponents").Include(
                "~/Scripts/moment/moment.min.js",
                "~/Scripts/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
                "~/Scripts/iCheck/icheck.min.js",
                //"~/Scripts/select2/js/select2.min.js",
                "~/Scripts/selectize/js/standalone/selectize.min.js",
                "~/Scripts/bootstrap-notify/bootstrap-notify.min.js",
                "~/Scripts/int-tel-input/js/intlTelInput.min.js",
                "~/Scripts/int-tel-input/js/utils.js",
                "~/Scripts/int-tel-input/international-phone-number.js"
            ));


            bundles.Add(new Bundle("~/jsbundles/entitycontrollers").Include(
                "~/app/entitycontrollers/*.js"
            ));

            bundles.Add(new ScriptBundle("~/jsbundles/signalr").Include(
                "~/Scripts/jquery.signalR-2.2.0.js",
                //"~/signalr/hubs",
                "~/app/signalr_mainhub.js"
                ));

            bundles.Add(new Bundle("~/jsbundles/webrtc").Include(
                "~/app/webrtc/adapter.js",
                "~/app/webrtc/connectionManager.js",
                "~/app/webrtc/webRtcVideoCall.js"
                //"~/app/webrtc/phoneRtcVideoCall.js"
                ));

            bundles.Add(new ScriptBundle("~/jsbundles/voicecommand").Include(
                "~/app/voicecommand.js",
                "~/Scripts/bililiteRange/bililiteRange_jQuerysendkeys.js",
                "~/Scripts/jquery-tabbale/jquery.tabbable.js"
                ));

            bundles.Add(new ScriptBundle("~/jsbundles/specialcomponents").Include(
                "~/Scripts/jquert-raty/jquery.raty.min.js", //Raty for rating things
                "~/Scripts/highstock/js/highstock.js"  // High stock
                ));

            bundles.Add(new Bundle("~/jsbundles/deltacompress").Include(
                "~/FW/js/DeltaCompress.js"
                ));


            bundles.Add(new Bundle("~/jsbundles/startup").Include(
                "~/app/startup.js"
                ));

            bundles.Add(new Bundle("~/jsbundles/framework").Include(
                "~/FW/js/Common.js"
                ));

            // *************************** CSS ****************************


            bundles.Add(new StyleBundle("~/Content/cssbundles/bootstrapcss").Include(
                "~/Content/Styles/font-awesome.min.css",
                //"~/Scripts/bootstrap-3.2.0-dist/css/bootstrap.min.css",
                //"~/Scripts/bootstrapvalidator-dist-0.5.0/dist/css/bootstrapValidator.min.css",
                "~/Content/Styles/loading-bar.css",
                //"~/Scripts/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css",
                "~/Content/Styles/animate.min.css"
            ));

            // bundles.Add(new StyleBundle("~/Content/cssbundles/uicomponentscss").Include(
            //     "~/Scripts/iCheck/skins/square/blue.css", // DEVELOPER NOTE: Dont Change skin unless you change app.js code file as well
            //     "~/Scripts/selectize/css/selectize.bootstrap3.css",
            //     "~/Scripts/int-tel-input/css/intlTelInput.css"
            //));


            BundleTable.EnableOptimizations = true;

        }
    }
}
