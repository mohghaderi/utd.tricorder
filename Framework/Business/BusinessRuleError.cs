using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Framework.Business
{
    public class BusinessRuleError
    {
        public string ColumnName { get; set; }

        private string columnTitle;
        public string ColumnTitle 
        { 
            get{
                if (string.IsNullOrEmpty(columnTitle))
                    return this.ColumnName; 
                else 
                    return columnTitle; 
            }
            set
            {
                columnTitle = value;
            }
        }
        public string ErrorDescription { get; set; }


        public override string ToString()
        {
            return string.Concat(this.ColumnName, " : ", this.ErrorDescription);
        }
    }

    public class BusinessRuleErrorList : Collection<BusinessRuleError>
    {
        public void Add(string columnName, string errDescription)
        {
            this.Add(new BusinessRuleError() { ColumnName= columnName, ErrorDescription= errDescription});
        }
    }


}
