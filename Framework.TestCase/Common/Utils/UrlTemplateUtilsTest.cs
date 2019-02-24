#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Common.Utils;
using System.Linq;
#endregion

///////////////////////////////////////////////////////////////////////////////
// Copyright 2014 (c) by Framework All Rights Reserved.
//  
// Project:      Common
// Module:       UrlTemplateUtilsTest.cs
// Description:  Tests for the Url Template Utils class in the Framework assembly.
//  
// Date:       Author:           Comments:
// 1/4/2014 10:42 PM  moh     Module created.
///////////////////////////////////////////////////////////////////////////////
namespace Framework.TestCase.Common.Utils
{

    /// <summary>
    /// Tests for the Url Template Utils Class
    /// Documentation: 
    /// </summary>
    [TestClass()]
    public class UrlTemplateUtilsTest
    {
        #region Class Variables
        private TestContext testContextInstance;
        private UrlTemplateUtils _urlTemplateUtils;
        #endregion

        #region Setup/Teardown

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        /// Code that is run before each test
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            //New instance of Url Template Utils
            _urlTemplateUtils = new UrlTemplateUtils();
        }

        /// <summary>
        /// Code that is run after each test
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            //TODO:  Put dispose in here for _urlTemplateUtils or delete this line
        }
        #endregion

        #region Property Tests

// No public properties were found. No tests are generated for non-public scoped properties.

        #endregion

        #region Method Tests

        /// <summary>
        /// Build Grid Url Method Test
        /// Documentation   :  Builds the grid URL.
        /// Method Signature:  string BuildGridUrl(string entityName, string additionalDataKey, string masterRecordID, bool isReadOnly)
        /// </summary>
        [TestMethod()]
        public void BuildGridUrlTest()
        {
            string expected = "~/FW/ExtGrid.aspx?Entity=testEN&AdditionalDataKey=testAD&MasterRecordID=testMR&MasterEntity=testMRE&MasterAdditionalDataKey=testMAD&RO=true";

            //Parameters
            const string entityName = "testEN";
            const string additionalDataKey = "testAD";
            const string masterRecordID = "testMR";
            const string masterEntityName = "testMRE";
            const string masterAdditionalDataKey = "testMAD";
            const bool isReadOnly = true;

            string results = _urlTemplateUtils.BuildGridUrl(entityName, additionalDataKey, masterRecordID, masterEntityName, masterAdditionalDataKey, isReadOnly);
            Assert.AreEqual(expected, results);
        }

        /// <summary>
        /// Build Edit Url Method Test
        /// Documentation   :  Builds the edit URL.
        /// Method Signature:  string BuildEditUrl(string entityName, string additionalDataKey, string masterRecordID, bool isReadOnly, string parentIDInTree, string recordID)
        /// </summary>
        [TestMethod()]
        public void BuildEditUrlTest()
        {
            string expected = "~/FW/ExtEdit.aspx?Entity=testEN&AdditionalDataKey=testAD&MasterRecordID=testMR&MasterEntity=testMRE&MasterAdditionalDataKey=testMAD&ParentIDInTree=testPI&RO=false&RecordID=1111";

            //Parameters
            const string entityName = "testEN";
            const string additionalDataKey = "testAD";
            const string masterRecordID = "testMR";
            const string masterEntityName = "testMRE";
            const string masterAdditionalDataKey = "testMAD";
            const bool isReadOnly = false;
            const string parentIDInTree = "testPI";
            const string recordID = "1111";

            string results = _urlTemplateUtils.BuildEditUrl(entityName, additionalDataKey, masterRecordID, masterEntityName, masterAdditionalDataKey, isReadOnly, parentIDInTree, recordID);
            Assert.AreEqual(expected, results);
        }

        /// <summary>
        /// Build Insert Url Method Test
        /// Documentation   :  Builds the insert URL.
        /// Method Signature:  string BuildInsertUrl(string entityName, string additionalDataKey, string masterRecordID, string parentIDInTree)
        /// </summary>
        [TestMethod()]
        public void BuildInsertUrlTest()
        {
            string expected = "~/FW/ExtEdit.aspx?Entity=testEN&AdditionalDataKey=testAD&MasterRecordID=testMR&MasterEntity=testMRE&MasterAdditionalDataKey=testMAD&ParentIDInTree=testPI";

            //Parameters
            const string entityName = "testEN";
            const string additionalDataKey = "testAD";
            const string masterRecordID = "testMR";
            const string masterEntityName = "testMRE";
            const string masterAdditionalDataKey = "testMAD";
            const string parentIDInTree = "testPI";

            string results = _urlTemplateUtils.BuildInsertUrl(entityName, additionalDataKey, masterRecordID, masterEntityName, masterAdditionalDataKey, parentIDInTree);
            Assert.AreEqual(expected, results);
        }

        /// <summary>
        /// Build Tree Url Method Test
        /// Documentation   :  Builds the tree URL.
        /// Method Signature:  string BuildTreeUrl(string entityName, string additionalDataKey, string masterRecordID, bool isReadOnly)
        /// </summary>
        [TestMethod()]
        public void BuildTreeUrlTest()
        {
            string expected = "~/FW/ExtTree.aspx?Entity=testEN&AdditionalDataKey=testAD&MasterRecordID=testMR&MasterEntity=testMRE&MasterAdditionalDataKey=testMAD&RO=true";

            //Parameters
            const string entityName = "testEN";
            const string additionalDataKey = "testAD";
            const string masterRecordID = "testMR";
            const string masterEntityName = "testMRE";
            const string masterAdditionalDataKey = "testMAD";
            const bool isReadOnly = true;

            string results = _urlTemplateUtils.BuildTreeUrl(entityName, additionalDataKey, masterRecordID, masterEntityName, masterAdditionalDataKey, isReadOnly);
            Assert.AreEqual(expected, results);
        }

        /// <summary>
        /// Build TreeGrid Url Method Test
        /// Documentation   :  Builds the TreeGrid URL.
        /// Method Signature:  string BuildTreeGridUrl(string entityName, string additionalDataKey, string masterRecordID, bool isReadOnly)
        /// </summary>
        [TestMethod()]
        public void BuildTreeGridUrlTest()
        {
            string expected = "~/FW/ExtTreeGrid.aspx?Entity=testEN&AdditionalDataKey=testAD&MasterRecordID=testMR&MasterEntity=testMRE&MasterAdditionalDataKey=testMAD&RO=true";

            //Parameters
            const string entityName = "testEN";
            const string additionalDataKey = "testAD";
            const string masterRecordID = "testMR";
            const string masterEntityName = "testMRE";
            const string masterAdditionalDataKey = "testMAD";
            const bool isReadOnly = true;

            string results = _urlTemplateUtils.BuildTreeGridUrl(entityName, additionalDataKey, masterRecordID, masterEntityName, masterAdditionalDataKey, isReadOnly);
            Assert.AreEqual(expected, results);
        }


        /// <summary>
        /// Build Edit User Control Url Method Test
        /// Documentation   :  Builds the edit user control URL.
        /// Method Signature:  string BuildEditUserControlUrl(string schema, string entityName)
        /// </summary>
        [TestMethod()]
        public void BuildEditUserControlUrlTest()
        {
            string expected = "~/UC/testSchema/testEntityNameUC.ascx";

            //Parameters
            const string schema = "testSchema";
            const string entityName = "testEntityName";

            string results = _urlTemplateUtils.BuildEditUserControlUrl(schema, entityName);
            Assert.AreEqual(expected, results);
        }


        /// <summary>
        /// Build Entity Script File Url Method Test
        /// Documentation   :  Builds the entity script file URL.
        /// Method Signature:  string BuildEntityScriptFileUrl(string schema, string entityName)
        /// </summary>
        [TestMethod()]
        public void BuildEntityScriptFileUrlTest()
        {
            string expected = "~/UC/testSchema/js/testEntityName.js";

            //Parameters
            const string schema = "testSchema";
            const string entityName = "testEntityName";

            string results = _urlTemplateUtils.BuildEntityScriptFileUrl(schema, entityName);
            Assert.AreEqual(expected, results);
        }



        /// <summary>
        /// Replace Param Method Test
        /// Documentation   :  Replaces the parameter.
        /// Method Signature:  string ReplaceParam(string template, string paramName, string paramValue)
        /// </summary>
        [TestMethod()]
        public void ReplaceParamTest()
        {
            string expected = "Param=ParamValue";

            //Parameters
            const string template = "Param={ParamValue}";
            const string paramName = "{ParamValue}";
            const string paramValue = "ParamValue";

            string results = _urlTemplateUtils.ReplaceParam(template, paramName, paramValue);
            Assert.AreEqual(expected, results);
        }

        /// <summary>
        /// Replace Param Method Test
        /// Documentation   :  Replaces the parameter.
        /// Method Signature:  string ReplaceParam(string template, string paramName, bool paramValue)
        /// </summary>
        [TestMethod()]
        public void ReplaceParam1Test()
        {
            string expected = "Param=true";

            //Parameters
            const string template = "Param={ParamValue}";
            const string paramName = "{ParamValue}";
            const bool paramValue = true;

            string results = _urlTemplateUtils.ReplaceParam(template, paramName, paramValue);
            Assert.AreEqual(expected, results);
        }


        #endregion

    }
}
