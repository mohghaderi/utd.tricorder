using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property

    /// <summary>
    /// Managing General Web Urls in one place
    /// </summary>
    public class UrlTemplateUtils
    {
        private static string _GridUrlTemplate = "~/FW/ExtGrid.aspx?Entity={EntityName}&AdditionalDataKey={AdditionalDataKey}&MasterRecordID={MasterRecordID}&MasterEntity={MasterEntityName}&MasterAdditionalDataKey={MasterAdditionalDataKey}&RO={IsReadOnly}";
        /// <summary>
        /// Gets the grid URL template.
        /// </summary>
        /// <value>
        /// The grid URL template.
        /// </value>
        public string GridUrlTemplate { get { return _GridUrlTemplate; } }

        private static string _EditUrlTemplate = "~/FW/ExtEdit.aspx?Entity={EntityName}&AdditionalDataKey={AdditionalDataKey}&MasterRecordID={MasterRecordID}&MasterEntity={MasterEntityName}&MasterAdditionalDataKey={MasterAdditionalDataKey}&ParentIDInTree={ParentIDInTree}&RO={IsReadOnly}&RecordID={RecordID}";
        /// <summary>
        /// Gets the edit URL template.
        /// </summary>
        /// <value>
        /// The edit URL template.
        /// </value>
        public string EditUrlTemplate { get { return _EditUrlTemplate; } }


        private static string _InsertUrlTemplate = "~/FW/ExtEdit.aspx?Entity={EntityName}&AdditionalDataKey={AdditionalDataKey}&MasterRecordID={MasterRecordID}&MasterEntity={MasterEntityName}&MasterAdditionalDataKey={MasterAdditionalDataKey}&ParentIDInTree={ParentIDInTree}";

        /// <summary>
        /// Gets the insert URL template.
        /// </summary>
        /// <value>
        /// The insert URL template.
        /// </value>
        public string InsertUrlTemplate { get { return _InsertUrlTemplate; } }


        private static string _TreeUrlTemplate = "~/FW/ExtTree.aspx?Entity={EntityName}&AdditionalDataKey={AdditionalDataKey}&MasterRecordID={MasterRecordID}&MasterEntity={MasterEntityName}&MasterAdditionalDataKey={MasterAdditionalDataKey}&RO={IsReadOnly}";

        /// <summary>
        /// Gets the tree URL template.
        /// </summary>
        /// <value>
        /// The tree URL template.
        /// </value>
        public string TreeUrlTemplate { get { return _TreeUrlTemplate; } }

        private static string _TreeGridUrlTemplate = "~/FW/ExtTreeGrid.aspx?Entity={EntityName}&AdditionalDataKey={AdditionalDataKey}&MasterRecordID={MasterRecordID}&MasterEntity={MasterEntityName}&MasterAdditionalDataKey={MasterAdditionalDataKey}&RO={IsReadOnly}";


        /// <summary>
        /// Gets the tree grid URL template.
        /// </summary>
        /// <value>
        /// The tree grid URL template.
        /// </value>
        public string TreeGridUrlTemplate { get { return _TreeGridUrlTemplate; } }


        private static string _EditUserControlUrlTemplate = "~/UC/{Schema}/{EntityName}UC.ascx";
        /// <summary>
        /// Gets the edit user control URL template.
        /// </summary>
        /// <value>
        /// The edit user control URL template.
        /// </value>
        public string EditUserControlUrlTemplate { get { return _EditUserControlUrlTemplate; } }


        private static string _EntityScriptFileUrlTemplate = "~/UC/{Schema}/js/{EntityName}.js";
        /// <summary>
        /// Gets the edit user control URL template.
        /// </summary>
        /// <value>
        /// The edit user control URL template.
        /// </value>
        public string EntityScriptFileUrlTemplate { get { return _EntityScriptFileUrlTemplate; } }




        /// <summary>
        /// Builds the grid URL.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <param name="masterRecordID">The master record identifier.</param>
        /// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
        /// <returns></returns>
        public string BuildGridUrl(string entityName, string additionalDataKey, string masterRecordID, string masterEntityName, string masterAdditionalDataKey, bool isReadOnly)
        {
            string s = GridUrlTemplate;
            s = ReplaceParam(s, "{EntityName}", entityName);
            s = ReplaceParam(s, "{AdditionalDataKey}", additionalDataKey);
            s = ReplaceParam(s, "{MasterRecordID}", masterRecordID);
            s = ReplaceParam(s, "{MasterEntityName}", masterEntityName);
            s = ReplaceParam(s, "{MasterAdditionalDataKey}", masterAdditionalDataKey);
            s = ReplaceParam(s, "{IsReadOnly}", isReadOnly.ToString().ToLower());
            return s;
        }

        /// <summary>
        /// Builds the edit URL.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <param name="masterRecordID">The master record identifier.</param>
        /// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
        /// <param name="parentIDInTree">The parent identifier in tree.</param>
        /// <param name="recordID">The record identifier.</param>
        /// <returns></returns>
        public string BuildEditUrl(string entityName, string additionalDataKey, string masterRecordID, string masterEntityName, string masterAdditionalDataKey, bool isReadOnly, string parentIDInTree, string recordID)
        {
            string s = EditUrlTemplate;
            s = ReplaceParam(s, "{EntityName}", entityName);
            s = ReplaceParam(s, "{AdditionalDataKey}", additionalDataKey);
            s = ReplaceParam(s, "{MasterRecordID}", masterRecordID);
            s = ReplaceParam(s, "{MasterEntityName}", masterEntityName);
            s = ReplaceParam(s, "{MasterAdditionalDataKey}", masterAdditionalDataKey);
            s = ReplaceParam(s, "{ParentIDInTree}", parentIDInTree);
            s = ReplaceParam(s, "{IsReadOnly}", isReadOnly.ToString().ToLower());
            s = ReplaceParam(s, "{RecordID}", recordID);
            return s;
        }

        /// <summary>
        /// Builds the insert URL.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <param name="masterRecordID">The master record identifier.</param>
        /// <param name="parentIDInTree">The parent identifier in tree.</param>
        /// <returns></returns>
        public string BuildInsertUrl(string entityName, string additionalDataKey, string masterRecordID, string masterEntityName, string masterAdditionalDataKey, string parentIDInTree)
        {
            string s = InsertUrlTemplate;
            s = ReplaceParam(s, "{EntityName}", entityName);
            s = ReplaceParam(s, "{AdditionalDataKey}", additionalDataKey);
            s = ReplaceParam(s, "{MasterEntityName}", masterEntityName);
            s = ReplaceParam(s, "{MasterAdditionalDataKey}", masterAdditionalDataKey);
            s = ReplaceParam(s, "{MasterRecordID}", masterRecordID);
            s = ReplaceParam(s, "{ParentIDInTree}", parentIDInTree);
            return s;

        }

        /// <summary>
        /// Builds the tree URL.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <param name="masterRecordID">The master record identifier.</param>
        /// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
        /// <returns></returns>
        public string BuildTreeUrl(string entityName, string additionalDataKey, string masterRecordID, string masterEntityName, string masterAdditionalDataKey, bool isReadOnly)
        {
            string s = TreeUrlTemplate;
            s = ReplaceParam(s, "{EntityName}", entityName);
            s = ReplaceParam(s, "{AdditionalDataKey}", additionalDataKey);
            s = ReplaceParam(s, "{MasterEntityName}", masterEntityName);
            s = ReplaceParam(s, "{MasterAdditionalDataKey}", masterAdditionalDataKey);
            s = ReplaceParam(s, "{MasterRecordID}", masterRecordID);
            s = ReplaceParam(s, "{IsReadOnly}", isReadOnly.ToString().ToLower());
            return s;
        }

        /// <summary>
        /// Builds the tree URL.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <param name="masterRecordID">The master record identifier.</param>
        /// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
        /// <returns></returns>
        public string BuildTreeGridUrl(string entityName, string additionalDataKey, string masterRecordID, string masterEntityName, string masterAdditionalDataKey, bool isReadOnly)
        {
            string s = TreeGridUrlTemplate;
            s = ReplaceParam(s, "{EntityName}", entityName);
            s = ReplaceParam(s, "{AdditionalDataKey}", additionalDataKey);
            s = ReplaceParam(s, "{MasterEntityName}", masterEntityName);
            s = ReplaceParam(s, "{MasterAdditionalDataKey}", masterAdditionalDataKey);
            s = ReplaceParam(s, "{MasterRecordID}", masterRecordID);
            s = ReplaceParam(s, "{IsReadOnly}", isReadOnly.ToString().ToLower());
            return s;
        }


        /// <summary>
        /// Builds the edit user control URL.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <returns></returns>
        public string BuildEditUserControlUrl(string schema, string entityName)
        {
            string s = EditUserControlUrlTemplate;
            s = ReplaceParam(s, "{Schema}", schema);
            s = ReplaceParam(s, "{EntityName}", entityName);
            return s;
        }


        public string BuildEntityScriptFileUrl(string schema, string entityName)
        {
            string s = this.EntityScriptFileUrlTemplate;
            s = ReplaceParam(s, "{Schema}", schema);
            s = ReplaceParam(s, "{EntityName}", entityName);
            return s;
        }





        /// <summary>
        /// Replaces the parameter.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <returns></returns>
        public string ReplaceParam(string template, string paramName, string paramValue)
        {
            if (paramValue == null)
                paramValue = "";

            Check.Ensure(paramValue.IndexOf('}') == -1 && paramValue.IndexOf('{') == -1, "ParameterValue can not contain '{' or '}' characters");

            return template.Replace(paramName, paramValue);
        }

        /// <summary>
        /// Replaces the parameter.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">if set to <c>true</c> [parameter value].</param>
        /// <returns></returns>
        public string ReplaceParam(string template, string paramName, bool paramValue)
        {
            return template.Replace(paramName, paramValue.ToString().ToLower());
        }

    }
}
