/*
  Keeps information about test case files
*/
var TestFilesInfo = {
    /*
      returns a list of test case files
    */
    GetTestList: function () {

        if (TestFilesInfo.TestList)
            return TestFilesInfo.TestList;
        else
        {
            var list = [];

            list.push("Framework/fwTests.js");
            list.push("common/DeltaCompressTests.js");
            list.push("mobile/pushnotifyTests.js");

            TestFilesInfo.TestList = list;
            return TestFilesInfo.TestList;
        }

    }


}