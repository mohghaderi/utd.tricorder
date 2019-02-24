/// <reference path="../../FW/js/Common.js" />

var fwTests = {

    StartTest : function()
    {
        describe("Framework Sanity", function () {
            it('passes if all variables are defined', function () {
                expect(TestPage.Framework).toBeDefined();
            });
        });

        describe("Framework.getMainWindow", function () {
            it('passes if getMainWindow returns the TestPage', function () {
                var mainWindow = TestPage.Framework.getMainWindow();
                expect(mainWindow).toBeDefined();
                expect(mainWindow.Title).toEqual(TestPage.Title);
            });
        });

        describe("Framework.getRandomInt", function () {
            it('passes if getMainWindow returns the TestPage', function () {
                var allNumbersInRange = true;
                // generating 100 random numbers
                for (var i = 0; i < 100; i++)
                {
                    var rndNumber = TestPage.Framework.getRandomInt(1, 10);
                    if (allNumbersInRange <= 0 || allNumbersInRange >= 10) {
                        allNumbersInRange = false;
                        break;
                    }
                }
                expect(allNumbersInRange).toEqual(true);
            });
        });

        describe("Framework.getQueryString(TestMode)", function () {
            it("passes if test mode was True", function () {
                var expected = TestPage.Framework.getQueryString("TestMode");
                expect(expected).toContain("True");
            });
        });

        describe("Framework.addQueryString(Page.aspx, Param, PValue)", function () {
            it("passes if addQueryString add QS using ?", function () {
                var expected = TestPage.Framework.addQueryString("Page.aspx", "Param", "PValue");
                expect(expected).toContain("Page.aspx?Param=PValue");
            });
        });

        describe("Framework.addQueryString(Page.aspx?A=B, Param, PValue)", function () {
            it("passes if addQueryString add QS using &", function () {
                var expected = TestPage.Framework.addQueryString("Page.aspx?A=B", "Param", "PValue");
                expect(expected).toContain("Page.aspx?A=B&Param=PValue");
            });
        });

        describe("Framework.addQueryString(Page.aspx?A=B, Param, '')", function () {
            it("passes if addQueryString return Url itself", function () {
                var expected = TestPage.Framework.addQueryString("Page.aspx?A=B", "Param", '');
                expect(expected).toContain("Page.aspx?A=B");
            });
        });


        describe("Framework.privateGetBaseClientPath", function () {
            it('passes if it got the path correctly', function () {
                var url = TestPage.Framework.privateGetBaseClientPath();
                expect(url).toBeDefined();
                expect(url + "en/").toEqual(fwTests.getCurrentUrl()); // since it is main page, no path is needed.
                // another test case maybe needed to test inside an internal frame
            });
        });

        describe("Framework.concatUrl", function () {
            it('passes if it concat two urls correctly', function () {
                var url = TestPage.Framework.concatUrl("http://SimpleUrl/", "JS/Common.js");
                expect(url).toEqual("http://SimpleUrl/JS/Common.js")

                var url = TestPage.Framework.concatUrl("http://SimpleUrl", "JS/Common.js");
                expect(url).toEqual("http://SimpleUrl/JS/Common.js")
            });
        });

        describe("Framework.privateReplaceParam", function () {
            it('passes if it replaced parameter correctly', function () {
                var testUrl = "FW/ExtEdit.aspx?Entity={EntityName}&AdditionalDataKey={AdditionalDataKey}&MasterRecordID={MasterRecordID}&MasterEntity={MasterEntityName}&MasterAdditionalDataKey={MasterAdditionalDataKey}&ParentIDInTree={ParentIDInTree}&RO={IsReadOnly}&RecordID={RecordID}";
                var url = testUrl;
                url = TestPage.Framework.privateReplaceParam(url, "{EntityName}", "testEntityName");
                url = TestPage.Framework.privateReplaceParam(url, "{AdditionalDataKey}", "testADK");
                url = TestPage.Framework.privateReplaceParam(url, "{MasterEntityName}", "testMEN");
                url = TestPage.Framework.privateReplaceParam(url, "{MasterAdditionalDataKey}", "testMAD");
                url = TestPage.Framework.privateReplaceParam(url, "{MasterRecordID}", "testMRID");
                url = TestPage.Framework.privateReplaceParam(url, "{ParentIDInTree}", "testPIDInTree");
                url = TestPage.Framework.privateReplaceParam(url, "{IsReadOnly}", "true");
                url = TestPage.Framework.privateReplaceParam(url, "{RecordID}", "testRID");
                expect(url).toEqual("FW/ExtEdit.aspx?Entity=testEntityName&AdditionalDataKey=testADK&MasterRecordID=testMRID&MasterEntity=testMEN&MasterAdditionalDataKey=testMAD&ParentIDInTree=testPIDInTree&RO=true&RecordID=testRID");
            });
        });

        describe("Framework.privateReplaceParam(all undefined)", function () {
            it('passes if it replaced parameter correctly', function () {
                var testUrl = "FW/ExtEdit.aspx?Entity={EntityName}&AdditionalDataKey={AdditionalDataKey}&MasterRecordID={MasterRecordID}&MasterEntity={MasterEntityName}&MasterAdditionalDataKey={MasterAdditionalDataKey}&ParentIDInTree={ParentIDInTree}&RO={IsReadOnly}&RecordID={RecordID}";
                var url = testUrl;
                url = TestPage.Framework.privateReplaceParam(url, "{EntityName}", undefined);
                url = TestPage.Framework.privateReplaceParam(url, "{AdditionalDataKey}", undefined);
                url = TestPage.Framework.privateReplaceParam(url, "{MasterEntityName}", undefined);
                url = TestPage.Framework.privateReplaceParam(url, "{MasterAdditionalDataKey}", undefined);
                url = TestPage.Framework.privateReplaceParam(url, "{MasterRecordID}", undefined);
                url = TestPage.Framework.privateReplaceParam(url, "{ParentIDInTree}", "");
                url = TestPage.Framework.privateReplaceParam(url, "{RecordID}", null);
                url = TestPage.Framework.privateReplaceParam(url, "{IsReadOnly}", null);
                expect(url).toEqual("FW/ExtEdit.aspx?Entity=&AdditionalDataKey=&MasterRecordID=&MasterEntity=&MasterAdditionalDataKey=&ParentIDInTree=&RO=&RecordID=");
            });
        });



        describe("Framework.addQueryString(Page.aspx?A=B, Param, '')", function () {
            it("passes if addQueryString return Url itself", function () {
                var expected = TestPage.Framework.addQueryString("Page.aspx?A=B", "Param", '');
                expect(expected).toContain("Page.aspx?A=B");
            });
        });


        //describe("Framework.confirmDelete(yes)", function () {
        //    it("passes when it doesn't calls delete function successfully",
        //        function (done) { // magic. If you add done here it can handle async :)

        //        spyOn(fwTests, 'deleteFunction');

        //        var msgWindow = TestPage.Framework.confirmDelete(fwTests.deleteFunction);
        //        setTimeout(function () { // wait for msg to be created
        //            var btn = ExtTestUtils.messageBoxButtonClick(msgWindow, "yes");
        //        }, 100);

        //        setTimeout(function () {
        //            expect(fwTests.deleteFunction).toHaveBeenCalled();
        //            done();
        //        }, 1000);

        //    });
        //});

        //describe("Framework.confirmDelete(no)", function () {
        //    it("passes when it doesn't call delete function",
        //        function (done) { // magic. If you add done here it can handle async :)

        //            spyOn(fwTests, 'deleteFunction');

        //            var msgWindow = TestPage.Framework.confirmDelete(fwTests.deleteFunction);
        //            setTimeout(function () { // wait for msg to be created
        //                var btn = ExtTestUtils.messageBoxButtonClick(msgWindow, "no");
        //            }, 100);

        //            setTimeout(function () {
        //                expect(fwTests.deleteFunction.calls.count()).toEqual(0);
        //                done();
        //            }, 1000);

        //        });
        //});


        describe("Framework.redirect()", function () {
            it("passes if it is redirected correctly", function (done) {
                TestPage.Framework.redirectTo('/en/Default/Login?TestMode=True&IsRedirected=true', TestPage);
                setTimeout(function () {
                    expect(TestPage.Framework.getQueryString("IsRedirected")).toEqual("true");
                    done();
                }, 1000);
            });
        });


    },


    deleteFunction : function() {
        fwTests.isDeleteFunctionCalled = true;
    },

    getCurrentUrl: function () {
        var testPage = "TestCase/JSTest";
        var i = document.URL.indexOf(testPage);
        return document.URL.substring(0, i);
    }


}



// loads the test page and start testing
LoadTestPage({
    pageUrl: "/en/Default/Login?TestMode=True",
    startTestFunction: fwTests.StartTest
});
