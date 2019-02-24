using Framework.Common;
using Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace UTD.Tricorder.Website.Helpers
{
    public interface IUploadConfiguration
    {
        IDictionary<string, string> FormAttributes { get; }
        IDictionary<string, string> FormFields { get; }
    }


    public static class FWHtml
    {

        private class SelectizeOptions
        {
            public string valueField;
            public string labelField;
            public bool create;
            public string[] searchField;
            public string EntityName;
            public bool DropDownUseCustomLoad;
        }
        
        private static class FWHtmlS
        {

            public static string EditorAttributes(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("name=\"" + colInfo.Name + "\"");
                sb.Append(" class=\"form-control\"");
                sb.Append(" data-ng-model=\"model." + colInfo.Name + "\"");
                if (string.IsNullOrEmpty(extraAttributes) == false)
                    sb.Append(" ").Append(extraAttributes);
                if (colInfo.ValidationIsNullable == false)
                    sb.Append(" data-bv-notempty=\"true\"");

                // textbox extra properties
                if (colInfo.EditorControl == EditorControlTypes.TextBox)
                {
                    if (colInfo.ValidationMaxLength < 10000)
                    {
                        sb.Append(" maxlength=\"").Append(colInfo.ValidationMaxLength).Append("\"");
                    }
                }

                // MultiLine text extra attributes
                if (colInfo.EditorControl == EditorControlTypes.MultiLineTextBox)
                if (colInfo.ValidationMaxLength > 200)
                {
                    int rows = 4;
                    if (colInfo.ValidationMaxLength > 1000)
                        rows = 5;
                    if (colInfo.ValidationMaxLength > 2100)
                        rows = 6;
                    if (colInfo.ValidationMaxLength > 3000)
                        rows = 7;
                    sb.Append(" rows=\"").Append(rows).Append("\"");
                }
                return sb.ToString();
            }


            public static string Label(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<label class=\"control-label\">");
                sb.Append(colInfo.Caption);
                sb.Append("</label>");
                return sb.ToString();
            }

            public static string TextBox(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<input type=\"text\" ");
                sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append(" />");
                return sb.ToString();
            }

            public static string NumericTextBox(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<input type=\"number\" ");
                sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append(" />");
                return sb.ToString();
            }

            public static string Password(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<input type=\"password\" ");
                sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append(" />");
                return sb.ToString();
            }

            public static string CheckBox(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();

                //<div class="checkbox">
                //    <label>
                //        <input type="checkbox" name="languages[]" value="french" /> French
                //    </label>
                //</div>

                //sb.Append("<input type=\"checkbox\" ");
                //sb.Append(EditorAttributes(colInfo, extraAttributes));
                //sb.Append(" />");
                //return sb.ToString();


                // Radio button option
                // <div>
                //    <label class="radio-inline">
                //        <input type="radio" name="rating" value="terrible" /> Terrible
                //    </label>
                //    <label class="radio-inline">
                //        <input type="radio" name="rating" value="watchable" /> Watchable
                //    </label>
                //    <label class="radio-inline">
                //        <input type="radio" name="rating" value="best" /> Best ever
                //    </label>
                //</div>
                if (colInfo.ValidationIsNullable == false)
                {
                    sb.AppendLine("<div class=\"form-group iCheckGroup\">");
                    sb.Append(CreateYesNoRadios("model.", colInfo.Name, !colInfo.ValidationIsNullable, "Yes", "No"));
                    sb.AppendLine("</div>");
                }
                else
                {
                    sb.Append("<select ");
                    sb.Append(EditorAttributes(colInfo, extraAttributes));
                    sb.Append(">");
                    sb.Append("<option value=\"\"></option>");
                    sb.Append("<option value=\"true\">").Append("Yes").Append("</option>");
                    sb.Append("<option value=\"false\">").Append("No").Append("</option>");
                    sb.Append(SelectOptions(colInfo));
                    sb.Append("</select>");
                }


                return sb.ToString();

            }

            private static string CreateRadio(ColumnInfo colInfo, string caption, string value, string ngValue)
            {
                string name = colInfo.Name;
                bool addValidationIsNullable = !colInfo.ValidationIsNullable;
                return CreateRadio("model.", name, addValidationIsNullable, caption, value, ngValue);
            }


            public static string CreateRadio(string modelPrefix, string name, bool addValidationIsNullable, string caption, string value, string ngValue)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<label>");
                sb.Append("<input type=\"radio\"");
                sb.Append(" class=\"radio-inline\"");
                sb.Append(" data-ng-icheck");
                sb.Append(" name=\"").Append(name).Append("\"");
                sb.Append(" data-ng-model=\"").Append(modelPrefix).Append(name).Append("\"");
                sb.Append(" value=").Append("\"").Append(value).Append("\"");
                if (string.IsNullOrEmpty(ngValue) == false)
                    sb.Append(" ng-value=\"").Append(ngValue).Append("\"");
                if (addValidationIsNullable == true)
                    sb.Append(" data-bv-notempty=\"true\"");
                sb.Append(" />");
                sb.Append(caption);
                sb.AppendLine("</label>");
                return sb.ToString();
            }

            public static string CreateYesNoRadios(string modelPrefix, string name, bool addValidationIsNullable, string yesTitle, string noTitle)
            {
                StringBuilder sb = new StringBuilder();

                //sb.AppendLine("<div class=\"form-group\">");
                sb.Append(CreateRadio(modelPrefix, name, addValidationIsNullable, yesTitle, "true", "true"));
                sb.Append(CreateRadio(modelPrefix, name, addValidationIsNullable, noTitle, "false", "false"));
                //sb.AppendLine("</div>");

                return sb.ToString();
            }



            public static string DatePicker(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<div ");
                sb.Append(" datetimepicker=\"{pickTime: false}\"");
                sb.Append(" data-ng-model=\"model." + colInfo.Name + "\"");
                sb.Append(">");

                sb.Append("<input type=\"text\" ");
                sb.Append("name=\"" + colInfo.Name + "\"");
                sb.Append(" class=\"form-control\"");
                if (string.IsNullOrEmpty(extraAttributes) == false)
                    sb.Append(" ").Append(extraAttributes);
                if (colInfo.ValidationIsNullable == false)
                    sb.Append(" data-bv-notempty=\"true\"");

                //sb.Append(EditorAttributes(colInfo, extraAttributes));

                //sb.Append(" data-date-format=\"YYYY/MM/DD\"");
                //sb.Append(" datetimepicker=\"{pickTime: false}\"");

                sb.Append(" data-date-format=\"YYYY/MM/DD\"");
                sb.Append(" data-mask=\"0000/00/00\"");
                sb.Append(" data-bv-date=\"true\"");
                sb.Append(" data-bv-date-format=\"YYYY/MM/DD\"");
                sb.Append(" />");

                sb.Append("</div>");
                return sb.ToString();
            }

            public static string DateTimePicker(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<div ");
                sb.Append(" datetimepicker=\"\"");
                sb.Append(" data-ng-model=\"model." + colInfo.Name + "\"");
                sb.Append(">");

                sb.Append("<input type=\"text\" ");
                //sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append("name=\"" + colInfo.Name + "\"");
                sb.Append(" class=\"form-control\"");
                if (string.IsNullOrEmpty(extraAttributes) == false)
                    sb.Append(" ").Append(extraAttributes);
                if (colInfo.ValidationIsNullable == false)
                    sb.Append(" data-bv-notempty=\"true\"");

                sb.Append(" data-date-format=\"YYYY/MM/DD h:m:s\"");
                sb.Append(" data-mask=\"0000/00/00 00:00:00\"");
                sb.Append(" data-bv-date=\"true\"");
                sb.Append(" data-bv-date-format=\"YYYY/MM/DD h:m:s\"");
                sb.Append(" />");

                sb.Append("</div>");
                return sb.ToString();
            }




            public static string ComboBox(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<div ");
                sb.Append(" data-selectize=\"{}\"");
                sb.Append(" data-ng-model=\"model." + colInfo.Name + "\"");
                sb.Append(">");
                sb.Append("<select ");
                //sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append("name=\"" + colInfo.Name + "\"");
                sb.Append(" class=\"form-control\"");
                if (string.IsNullOrEmpty(extraAttributes) == false)
                    sb.Append(" ").Append(extraAttributes);
                if (colInfo.ValidationIsNullable == false)
                    sb.Append(" data-bv-notempty=\"true\"");

                sb.Append(">");
                sb.Append("<option value=\"\"></option>");
                sb.Append(SelectOptions(colInfo));
                sb.Append("</select>");
                sb.Append("</div>");
                return sb.ToString();
            }

            public static string DropDownList(ColumnInfo colInfo, string extraAttributes = null)
            {
                var foreignEntity = EntityFactory.GetEntityInfoByName(colInfo.ForeignEntityName, colInfo.ForeignEntityAdditionalDataKey);

                var options = new SelectizeOptions();
                options.valueField = foreignEntity.IDFieldName;
                options.labelField = foreignEntity.TitleFieldName;
                options.create = false; // we don't do auto create to load by ajax later; Google Chrome sometimes don't render it
                options.searchField = new string[] { foreignEntity.TitleFieldName };
                options.EntityName = foreignEntity.EntityName;
                options.DropDownUseCustomLoad = colInfo.DropDownUseCustomLoad;

                StringBuilder sb = new StringBuilder();
                sb.Append("<div ");
                sb.Append(" data-selectize=\"")
                    .Append(FWUtils.EntityUtils.JsonSerializeObject(options).Replace("\"", "'"))
                    .Append("\"");
                sb.Append(" data-ng-model=\"model." + colInfo.Name + "\"");
                sb.Append(">");

                sb.Append("<select ");
                //sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append("name=\"" + colInfo.Name + "\"");
                sb.Append(" class=\"form-control\"");
                if (string.IsNullOrEmpty(extraAttributes) == false)
                    sb.Append(" ").Append(extraAttributes);
                if (colInfo.ValidationIsNullable == false)
                    sb.Append(" data-bv-notempty=\"true\"");

                sb.Append(">");
                //sb.Append("<option value=\"\"></option>");
                sb.Append("</select>");
                sb.Append("</div>");

                return sb.ToString();
            }

            public static string PickList(ColumnInfo colInfo, string extraAttributes = null)
            {
                return ComboBox(colInfo);
            }

            public static string MultiLineTextBox(ColumnInfo colInfo, string extraAttributes = null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<textarea ");
                sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append("></textarea>");
                return sb.ToString();
            }


            public static string SelectOptions(ColumnInfo colInfo)
            {
                string entityName = colInfo.ForeignEntityName;
                string adk = colInfo.ForeignEntityAdditionalDataKey;

                return SelectOptions(entityName, adk);
            }

            public static string SelectOptions(string entityName, string adk)
            {
                IServiceBase service = EntityFactory.GetEntityServiceByName(entityName, adk);
                FilterExpression filter = new FilterExpression();
                SortExpression sort = new SortExpression(service.Entity.TitleFieldName);
                List<string> columns = new List<string>();
                columns.Add(service.Entity.IDFieldName);
                columns.Add(service.Entity.TitleFieldName);
                var list = service.GetByFilter(new GetByFilterParameters(filter, sort, 0, 1000, columns, GetSourceTypeEnum.View));

                StringBuilder sb = new StringBuilder();

                foreach (var item in list)
                {
                    string idValue = FWUtils.EntityUtils.GetObjectFieldValueString(item, service.Entity.IDFieldName);
                    string title = FWUtils.EntityUtils.GetObjectFieldValueString(item, service.Entity.TitleFieldName);
                    sb.Append("<option value=\"" + idValue + "\">" + title + "</option>\r\n");
                }

                return sb.ToString();
            }


            public static string Editor(ColumnInfo colInfo, string extraAttributes = null)
            {
                if (colInfo.EditFormIsHidden)
                    return "";

                StringBuilder sb = new StringBuilder();

                switch (colInfo.EditorControl)
                {
                    case EditorControlTypes.None:
                        return "";
                    case EditorControlTypes.TextBox:
                        return TextBox(colInfo, extraAttributes);
                    case EditorControlTypes.NumericTextBox:
                        return NumericTextBox(colInfo, extraAttributes);
                    case EditorControlTypes.ComboBox:
                        return ComboBox(colInfo, extraAttributes);
                    case EditorControlTypes.PickList:
                        return PickList(colInfo, extraAttributes);
                    case EditorControlTypes.DropDownList:
                        return DropDownList(colInfo, extraAttributes);
                    case EditorControlTypes.CheckBox:
                        return CheckBox(colInfo, extraAttributes);
                    case EditorControlTypes.DatePicker:
                        return DatePicker(colInfo, extraAttributes);
                    case EditorControlTypes.DateTimePicker:
                        return DateTimePicker(colInfo, extraAttributes);
                    case EditorControlTypes.PersianDatePicker:
                        return DatePicker(colInfo, extraAttributes);
                    case EditorControlTypes.HtmlEditor:
                        return MultiLineTextBox(colInfo, extraAttributes);
                    case EditorControlTypes.Password:
                        return Password(colInfo, extraAttributes);
                    case EditorControlTypes.FileUploader:
                        return "";
                    case EditorControlTypes.FilePicker:
                        return "";
                    case EditorControlTypes.MultiLineTextBox:
                        return MultiLineTextBox(colInfo, extraAttributes);
                    case EditorControlTypes.LargeNumberTextBox:
                        return LargeNumberTextBox(colInfo, extraAttributes);
                    case EditorControlTypes.EmailTextBox:
                        return EmailTextBox(colInfo, extraAttributes);
                    case EditorControlTypes.PhoneNumberE164TextBox:
                        return PhoneNumberE164TextBox(colInfo, extraAttributes);
                    case EditorControlTypes.UserNameTextBox:
                        return UserNameTextBox(colInfo, extraAttributes);
                    default:
                        throw new NotImplementedException();
                }
            }

            private static string PhoneNumberE164TextBox(ColumnInfo colInfo, string extraAttributes)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<input type=\"text\" ");
                sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append(" international-phone-number ");
                //sb.Append(" data-bv-regexp-message=\"").Append(StringMsgs.GeneralMessages.PhoneNumebrE164Validation).Append("\"");
                //Developer note: Change pattern with pattern in UserBR file.
                //sb.Append(" pattern=\"").Append(@"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{6,14}$").Append("\"");
                sb.Append(" />");
                return sb.ToString();
            }

            private static string EmailTextBox(ColumnInfo colInfo, string extraAttributes)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<input type=\"text\" ");
                sb.Append(EditorAttributes(colInfo, extraAttributes));
                //sb.Append(" data-bv-regexp-message=\"").Append(StringMsgs.GeneralMessages.EmailValidation).Append("\"");
                //sb.Append(" pattern=\"").Append(@"^(?=.{5,50}$)([A-Za-z0-9][._]?)*$").Append("\"");
                sb.Append(" data-bv-emailaddress=\"true\"");
                sb.Append(" />");
                return sb.ToString();
            }

            private static string UserNameTextBox(ColumnInfo colInfo, string extraAttributes)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<input type=\"text\" ");
                sb.Append(EditorAttributes(colInfo, extraAttributes));
                sb.Append(" data-bv-regexp-message=\"").Append(UTD.Tricorder.BusinessRule.BusinessErrorStrings.User.UserName_RegularExpressionCheck).Append("\"");
                //Developer note: Change pattern with pattern in UserBR file.
                sb.Append(" pattern=\"").Append(@"^(?=.{5,50}$)([A-Za-z0-9][._]?)*$").Append("\"");
                sb.Append(" />");
                return sb.ToString();
            }

            public static string LargeNumberTextBox(ColumnInfo colInfo, string extraAttributes = null)
            {
                return TextBox(colInfo, extraAttributes);
            }


            internal static string OptionsRadio(string modelPrefix, string name, bool addValidationIsNullable, string[] optionsTitleValue)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < optionsTitleValue.Length; i += 2)
                {
                    sb.Append(CreateRadio(modelPrefix, name, addValidationIsNullable, optionsTitleValue[i], optionsTitleValue[i + 1], optionsTitleValue[i + 1]));
                }

                return sb.ToString();
            }
        }

        public static MvcHtmlString OptionsListForEntity(string entityName)
        {
            return new MvcHtmlString(FWHtmlS.SelectOptions(entityName, ""));
        }

        public static MvcHtmlString Label(string entityName, string columnName)
        {
            var entityInfo = EntityFactory.GetEntityInfoByName(entityName, "");
            var colInfo = entityInfo.EntityColumns[columnName];
            return new MvcHtmlString(FWHtmlS.Label(colInfo));
        }


        public static MvcHtmlString EditorAttributes(string entityName, string columnName)
        {
            var entityInfo = EntityFactory.GetEntityInfoByName(entityName, "");
            var colInfo = entityInfo.EntityColumns[columnName];
            return new MvcHtmlString(FWHtmlS.EditorAttributes(colInfo));
        }


        public static MvcHtmlString Editor(ColumnInfo colInfo, string extraAttributes = null)
        {
            StringBuilder sb = new StringBuilder();
            var editorText = FWHtmlS.Editor(colInfo, extraAttributes);
            if (string.IsNullOrEmpty(editorText) == false)
            {
                sb.AppendLine("<div class=\"form-group\">");
                sb.AppendLine(FWHtmlS.Label(colInfo));
                sb.AppendLine(editorText);
                sb.Append("</div>");
            }
            return new MvcHtmlString(sb.ToString());
        }



        public static MvcHtmlString SubmitButtonOnClickCallService(string entityName, string serviceName, bool hasBeforeFn, bool hasAfterFn)
        {
            string beforeFn = "";
            if (hasBeforeFn)
                beforeFn = "before" + entityName + serviceName;
            string afterFn = "";
            if (hasAfterFn)
                afterFn = beforeFn = "after" + entityName + serviceName;

            StringBuilder sb = new StringBuilder();
            sb.Append("if (isFormValid('form')) {");
                sb.Append("var scope = angular.element(event.target).scope();");
                sb.Append("scope.CallService(");
                sb.Append("{ sName: '").Append(serviceName).Append(" '");
                sb.Append(", data: scope.model");
                sb.Append(", $event: event");
                if (string.IsNullOrEmpty(beforeFn) == false)
                    sb.Append(", beforeFn: ").Append(beforeFn);
                if (string.IsNullOrEmpty(afterFn) == false)
                    sb.Append(", afterFn: ").Append(afterFn);
                sb.Append("});");
            sb.Append("}");

            return new MvcHtmlString(sb.ToString());
        }


        /// <summary>
        /// creates an identifier to be used in the client-side from a title
        /// </summary>
        /// <param name="sectionTitle">title</param>
        /// <returns></returns>
        public static string CreateSafeIDForTitle(string title)
        {
            StringBuilder sb = new StringBuilder("_"); // id should start with "_" so that number at the beginning doesn't cause a problem
            foreach (char ch in title)
                if (char.IsLetterOrDigit(char.ToLower(ch)))
                    sb.Append(ch);
                else
                    sb.Append("_");
            return sb.ToString();
        }

        /// <summary>
        /// Creates Yes No Radio buttons
        /// It doesn't add "div class='form-group'" and its label
        /// </summary>
        /// <param name="name">name + adding angular model</param>
        /// <param name="addValidationIsNullable"></param>
        /// <returns></returns>
        public static MvcHtmlString YesNoRadios(string modelPrefix, string name, bool addValidationIsNullable, string yesTitle = "Yes", string noTitle = "No")
        {
            return new MvcHtmlString(FWHtmlS.CreateYesNoRadios(modelPrefix, name, addValidationIsNullable, yesTitle, noTitle));
        }

        /// <summary>
        /// Creates unlimited Radio buttons
        /// It doesn't add "div class='form-group'" and its label
        /// </summary>
        /// <param name="name">name + adding angular model</param>
        /// <param name="addValidationIsNullable"></param>
        /// <returns></returns>
        public static MvcHtmlString OptionsRadio(string modelPrefix, string name, bool addValidationIsNullable, params string[] optionsTitleValue)
        {
            return new MvcHtmlString(FWHtmlS.OptionsRadio(modelPrefix, name, addValidationIsNullable, optionsTitleValue));
        }

        public static MvcHtmlString CheckBox(string modelPrefix, string name, string title)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"checkbox\">");
            sb.Append("<label>");
            sb.Append("<input type=\"checkbox\" ");
            sb.Append(" name=\"").Append(name).Append("\"");
            sb.Append(" data-ng-model=\"").Append(modelPrefix).Append(name).Append("\"");
            //sb.Append(" data-bv-notempty=\"true\"");
            sb.Append(" ng-icheck");
            sb.Append(" >");
            sb.Append(" " + title);
            sb.Append("</input>");
            sb.Append("</label>");
            sb.Append("</div>");

            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Creates on radio button
        /// </summary>
        /// <param name="modelPrefix"></param>
        /// <param name="name"></param>
        /// <param name="addValidationIsNullable"></param>
        /// <param name="caption"></param>
        /// <param name="value"></param>
        /// <param name="ngValue"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioButton(string modelPrefix, string name, bool addValidationIsNullable, string caption, string value, string ngValue)
        {
            return new MvcHtmlString(FWHtmlS.CreateRadio(modelPrefix, name, addValidationIsNullable, caption, value, ngValue));
        }



        /// <summary>
        /// convert an integer hour (like 0) to its string value (like 12 AM)
        /// </summary>
        /// <param name="hour">hour</param>
        /// <returns></returns>
        public static string GetHourAM_PM(int hour)
        {
            return GetTimeAM_PM(hour, null);
        }

        public static string GetTimeAM_PM(int hour, int? minute)
        {
            string minuteString = "";
            if (minute.HasValue)
                minuteString = ":" + new String('0', 2 - minute.Value.ToString().Length) + minute.Value.ToString();

            switch (hour)
            {
                case 0:
                    return "12" + minuteString + " AM";
                case 12:
                    return "12" + minuteString + " PM";
            }

            if (hour > 12)
            {
                hour = (hour - 12);
                var hourString = new String('0', 2 - hour.ToString().Length) + hour.ToString();
                return hourString + minuteString + " PM";
            }
            else
            {
                var hourString = new String('0', 2 - hour.ToString().Length) + hour.ToString();
                return hourString + minuteString + " AM";
            }
        }

        /// <summary>
        /// returns active if tabId is the same as activeTabId
        /// </summary>
        /// <param name="tabId">tab Id</param>
        /// <param name="activeTabId">active tab id</param>
        /// <returns></returns>
        public static MvcHtmlString GetActiveTabClass(string tabId, string activeTabId)
        {
            if (tabId == activeTabId)
                return new MvcHtmlString("active");
            else
                return new MvcHtmlString("");
        }

        public static bool IsDebug()
        {
            return FWUtils.ConfigUtils.GetAppSettings().Project.IsDebug;
                
            // http://stackoverflow.com/questions/4696175/razor-view-engine-how-to-enter-preprocessorif-debug
            #if DEBUG
                  //return true;
            #else
                  //return false;
            #endif
        }



        public static MvcForm BeginAsyncUploadForm<T>(this HtmlHelper<T> htmlHelper, Uri callbackUrl, IUploadConfiguration uploadConfiguration, object htmlAttributes = null)
        {
            var formAttributes = new Dictionary<string, string>
			{
				{ "data-post", callbackUrl.OriginalString },
				{ "enctype", "multipart/form-data" },
			}.Concat(uploadConfiguration.FormAttributes);

            var formTagBuilder = new TagBuilder("form");
            foreach (var attribute in formAttributes)
            {
                formTagBuilder.MergeAttribute(attribute.Key, attribute.Value);
            }

            if (htmlAttributes != null)
            {
                var htmlAttributeDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                formTagBuilder.MergeAttributes(htmlAttributeDictionary, replaceExisting: true);
            }

            var writer = htmlHelper.ViewContext.Writer;

            writer.Write(formTagBuilder.ToString(TagRenderMode.StartTag));

            foreach (var field in uploadConfiguration.FormFields)
            {
                writer.Write(htmlHelper.Hidden(field.Key, field.Value));
            }

            return new MvcForm(htmlHelper.ViewContext);
        }


    }
}