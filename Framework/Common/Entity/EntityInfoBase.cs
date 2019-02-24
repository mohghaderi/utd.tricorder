using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Framework.Common
{
    public class EntityInfoBase
    {
        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public virtual string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the additional data key.
        /// </summary>
        /// <value>
        /// The additional data key.
        /// </value>
        public virtual string AdditionalDataKey { get; set; }


        private string _className;
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>
        /// The name of the class.
        /// </value>
        public virtual string ClassName
        {
            get
            {
                return _className;
            }
        }


        private Dictionary<string, ColumnInfo> _entityColumns;

        [JsonIgnore()]
        /// <summary>
        /// Gets the entity columns.
        /// </summary>
        /// <value>
        /// The entity columns.
        /// </value>
        public virtual Dictionary<string, ColumnInfo> EntityColumns { get { return _entityColumns; } }



        /// <summary>
        /// Gets or sets the entity title.
        /// </summary>
        /// <value>
        /// The entity title.
        /// </value>
        public virtual string EntityTitle { get; set; }

        /// <summary>
        /// Gets or sets the name of the ID field.
        /// </summary>
        /// <value>
        /// The name of the ID field.
        /// </value>
        public virtual string IDFieldName { get; set; }
        /// <summary>
        /// Gets or sets the name of the code field.
        /// </summary>
        /// <value>
        /// The name of the code field.
        /// </value>
        public virtual string CodeFieldName { get; set; }
        /// <summary>
        /// Gets or sets the name of the title field.
        /// </summary>
        /// <value>
        /// The name of the title field.
        /// </value>
        public virtual string TitleFieldName { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public virtual string Schema { get; set; }

        /// <summary>
        /// Gets or sets the name of the context database that data should be stored in
        /// </summary>
        /// <value>
        /// The name of the context database that data should be stored in
        /// </value>
        public virtual string ContextName { get; set; }

        [JsonIgnore()]
        /// <summary>
        /// Gets or sets a value indicating whether [audit log enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [audit log enabled]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool AuditLogEnabled { get; set; }


        /// <summary>
        /// Gets the default size of the page for grid and lists
        /// </summary>
        /// <value>
        /// The default size of the page for grid and lists
        /// </value>
        public virtual int DefaultPageSize { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [include script file].
        /// Script files should be saved in js/schema/entityname.js
        /// </summary>
        /// <value>
        ///   <c>true</c> if [include script file]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool HasScriptFile { get; set; }

        [JsonIgnore()]
        /// <summary>
        /// Gets or sets the script file URL template.
        /// {Schema} and {EntityName} can be used as url template options
        /// </summary>
        /// <value>
        /// The script file URL template.
        /// </value>
        public virtual string ScriptFileUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow insert].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow insert]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool AllowInsert { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow update].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow update]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool AllowUpdate { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [allow delete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow delete]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool AllowDelete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow batch update].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow batch update]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool AllowBatchUpdate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has popup edit.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has popup edit; otherwise, <c>false</c>.
        /// </value>
        public virtual bool HasPopupEdit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has in place edit.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has in place edit; otherwise, <c>false</c>.
        /// </value>
        public virtual bool HasInPlaceEdit { get; set; }


        private string _SecurityResourceCode;

        [JsonIgnore()]
        /// <summary>
        /// Gets or sets the security resource code.
        /// </summary>
        /// <value>
        /// The security resource code.
        /// </value>
        public virtual string SecurityResourceCode
        {
            get
            {
                return _SecurityResourceCode;
            }
            set { _SecurityResourceCode = value; }
        }


        /// <summary>
        /// Gets or sets the detail entity tabs.
        /// </summary>
        /// <value>
        /// The detail entity tabs.
        /// </value>
        public virtual EntityDetailsDictionary DetailEntities { get; set; }


        /// <summary>
        /// Gets or sets the insert form URL.
        /// </summary>
        /// <value>
        /// The insert form URL.
        /// </value>
        public virtual string InsertFormUrl { get; set; }

        /// <summary>
        /// Gets or sets the edit form URL.
        /// Parameters can be added to URL by including {RecordID}, ... in the URL
        /// </summary>
        /// <value>
        /// The edit form URL.
        /// </value>
        public virtual string EditFormUrl { get; set; }

        /// <summary>
        /// Gets or sets the width of the edit form.
        /// </summary>
        /// <value>
        /// The width of the edit form.
        /// </value>
        public virtual int EditFormWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the edit form.
        /// </summary>
        /// <value>
        /// The height of the edit form.
        /// </value>
        public virtual int EditFormHeight { get; set; }

        /// <summary>
        /// Gets or sets the edit form open mode.
        /// </summary>
        /// <value>
        /// The edit form open mode.
        /// </value>
        public virtual EditFormOpenDialogModeEnum EditFormOpenMode { get; set; }

        /// <summary>
        /// Gets or sets the edit form title.
        /// </summary>
        /// <value>
        /// The edit form title.
        /// </value>
        public virtual string EditFormTitle { get; set; }

        [JsonIgnore()]
        /// <summary>
        /// Gets or sets the edit user control URL template.
        /// </summary>
        /// <value>
        /// The edit user control URL template.
        /// </value>
        public string EditUserControlUrlTemplate {get;set;}


        /// <summary>
        /// Gets or sets the default listing URL.
        /// </summary>
        /// <value>
        /// The default listing URL.
        /// </value>
        public string GridUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the actions list.
        /// </summary>
        /// <value>
        /// The actions list.
        /// </value>
        public List<EntityAction> ActionsList { get; set; }



        /// <summary>
        /// Gets or sets the default filter.
        /// This filter applies to entity get functions
        /// it ands with other filters in the entity
        /// </summary>
        /// <value>
        /// The default filter.
        /// </value>
        public FilterExpression DefaultFilter { get; set; }

        /// <summary>
        /// Gets or sets the default sort.
        /// </summary>
        /// <value>
        /// The default sort.
        /// </value>
        public SortExpression DefaultSort { get; set; }


        #region Utility Functions


        /// <summary>
        /// Finds an Action by its name
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        public EntityAction FindActionByName(string actionName)
        {
            Check.Require(string.IsNullOrEmpty(actionName) == false);

            foreach (EntityAction action in this.ActionsList)
                if (actionName == action.Name)
                    return action;

            throw new Exception("Action " + actionName + " is not defined for entity " + EntityName);
        }

        [JsonIgnore]
        public List<string> ServerOnlyColumns { get; set; }
 

        #endregion



        #region Initialization

        private bool _IsInitialized = false;

        /// <summary>
        /// Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitialized { get { return _IsInitialized; } }


        /// <summary>
        /// Initializes the by default.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        public virtual void Initialize(string entityName, string additionalDataKey)
        {
            _IsInitialized = true;

            this.EntityName = entityName;
            this.AdditionalDataKey = additionalDataKey;
            // className
            if (FWUtils.ConfigUtils.GetAppSettings().Project.UseSchemaWithEntityName == false)
                _className = this.EntityName;
            else
            {
                int i = this.EntityName.LastIndexOf(".");
                _className = this.EntityName.Substring(i + 1);
            }

            _entityColumns = new Dictionary<string, ColumnInfo>();

            this.EntityTitle = this.EntityName;
            this.IDFieldName = "";
            this.CodeFieldName = "";
            this.TitleFieldName = "";

            this.Schema = "";
            this.ContextName = "default";

            this.SecurityResourceCode = this.EntityName;
            if (string.IsNullOrEmpty(additionalDataKey) == false)
                this.SecurityResourceCode = this.SecurityResourceCode + "-" + additionalDataKey;

            this.AuditLogEnabled = true;
            this.DefaultPageSize = 10;


            this.HasScriptFile = false;

            this.AllowInsert = true;
            this.AllowUpdate = true;
            this.AllowDelete = true;
            this.AllowBatchUpdate = true;
            this.HasPopupEdit = true;
            this.HasInPlaceEdit = false;

            // since we would like to cache EntityInfo object, we can't do calculations based on user execution
            this.InsertFormUrl = FWUtils.UrlTemplateUtils.InsertUrlTemplate;
            this.EditFormUrl = FWUtils.UrlTemplateUtils.EditUrlTemplate;


            this.EditFormWidth = 800;
            this.EditFormHeight = 600;
            this.EditFormOpenMode = EditFormOpenDialogModeEnum.Default;
            this.EditFormTitle = this.EntityTitle + " Form";

            this.EditUserControlUrlTemplate = FWUtils.UrlTemplateUtils.EditUserControlUrlTemplate;
            this.GridUrlTemplate = FWUtils.UrlTemplateUtils.GridUrlTemplate;
            this.ScriptFileUrlTemplate = FWUtils.UrlTemplateUtils.EntityScriptFileUrlTemplate;

            this.DetailEntities = new EntityDetailsDictionary();
            this.ActionsList = new List<EntityAction>();
            this.DefaultFilter = new FilterExpression();
            this.DefaultSort = new SortExpression();
            this.ServerOnlyColumns = new List<string>();
        }


        protected virtual void InitAdditionalDataKey(string entityName, string additionalDataKey)
        {
            
        }


        #endregion

    }
}
