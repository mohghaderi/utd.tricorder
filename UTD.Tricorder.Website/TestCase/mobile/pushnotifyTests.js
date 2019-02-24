var mobileAppCallBack = {};

var mobileTests = {

    StartTest: function () {

        // initializing tests (sync this part by app.js in cordova app)
        TestPage.mobileApp = window.mobileApp; 
        TestPage.cordovaAppVersion = window.cordovaAppVersion;
        TestPage.openExternal = window.openExternal;
        TestPage.angularRouteChangeSuccess = window.angularRouteChangeSuccess;
        window.mobileAppCallBack = TestPage.mobileAppCallBack;

        describe("mobile app sanity", function () {
            it('passes if it mobile app is there', function () {
                expect(TestPage.mobileApp).toBeDefined();
            });
        });

        describe("registerPushNotify", function () {
            it('passes if it registers a push is defined', function () {
                expect(TestPage.mobileApp.registerPushNotify).toBeDefined();
            });

            it('passes if registers a push notification', function (done) {
                TestPage.mobileApp.registerPushNotify();

                setTimeout(function () {
                    expect(TestPage.mobileApp.pushNotificationToken !== "").toBeTruthy();
                    done();
                }, 5000);
            });

            it('passes if inits mobile callback and push notification calls PushTokenRecieved in mobileAppCallBack', function (done) {

                TestPage.mobileAppCallBack.callback("init");

                spyOn(TestPage.mobileAppCallBack.scope, 'PushTokenRecieved');

                setTimeout(function () {
                    expect(TestPage.mobileAppCallBack.scope.PushTokenRecieved).toHaveBeenCalled();
                    done();
                }, 7000);
            });


        });

        describe("setBadge", function () {
            it('passes if it setBadge has no error', function (done) {
                expect(TestPage.mobileApp.setBadge).toBeDefined();
                TestPage.mobileApp.setBadge(5);
                done();
            });
        });

        describe("getDeviceUUID", function () {
            it('passes if it getDeviceUUID returns a value', function () {
                expect(TestPage.mobileApp.getDeviceUUID).toBeDefined();
                var id = TestPage.mobileApp.getDeviceUUID();
                if (!id) {
                    fail("UUID is not defined for this device");
                }
            });
        });

        describe("getGeneratedUUID", function () {
            it('passes if it getGeneratedUUID returns a value', function () {
                expect(TestPage.mobileApp.getGeneratedUUID).toBeDefined();
                var id = TestPage.mobileApp.getGeneratedUUID();
                if (!id) {
                    fail("UUID is not defined for this device");
                }
            });
        });

        describe("getDeviceInfoString", function () {
            it('passes if it getDeviceInfoString returns a value', function () {
                expect(TestPage.mobileApp.getDeviceInfoString).toBeDefined();
                var info = TestPage.mobileApp.getDeviceInfoString();
                if (!info) {
                    fail("getDeviceInfoString doesn't have information of this device");
                }
            });
        });

        describe("Test push sanity", function () {
            it('passes if it sends a push message to the client and client gets it',
                function (done) {

                    //TestPage.mobileAppCallBack.callback("init");
                    // it is initialized in another test case, so ignore it

                    if (!TestPage.mobileApp.pushNotificationToken)
                        fail("This device is not registered. Please register the device before sending push notify");

                    spyOn(TestPage.mobileAppCallBack.scope, 'pushNotifyRecieved');

                    var scope = TestPage.angular.element("#UserDeviceSettingSendPushSanityControllerDiv").scope();
                    scope.SendPushSanity();

                    setTimeout(function () {
                        expect(TestPage.mobileAppCallBack.scope.pushNotifyRecieved).toHaveBeenCalled();
                        done();
                    }, 5000);


            });
        });

        

        


    }
}


// loads the test page and start testing
LoadTestPage({
    pageUrl: "/en/TestCase/MobileTests?TestMode=True",
    startTestFunction: mobileTests.StartTest
});
