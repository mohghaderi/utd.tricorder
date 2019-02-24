using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    //TODO: use string template library to make a real template engine here.
    // we need that library because of doing Date formatting and more advanced features
    // that sometimes is necessary

    /// <summary>
    /// Paramerters to be replaced in templates
    /// </summary>
    public class TemplateParams
    {
        private Dictionary<string, string> _ParametersValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateParams"/> class.
        /// </summary>
        public TemplateParams()
        {
            _ParametersValues = new Dictionary<string, string>();
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="TemplateParams"/> class.
        ///// </summary>
        ///// <param name="serializedString">The serialized string.</param>
        //public TemplateParams(string serializedString)
        //{
        //    DeserializeFromString(serializedString);
        //}

        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="paramValues">parameters in the form of param then value each as a separate input. For example: new TemplateParams("P1", "P1Value", "P2", "P2Value")</param>
        public TemplateParams(params string[] paramValues)
        {
            Check.Require((paramValues.Length % 2) == 0, "parameters of paramValues should be param, value");
            _ParametersValues = new Dictionary<string, string>();
            for (int i = 0; i < paramValues.Length; i += 2)
            {
                _ParametersValues.Add(paramValues[i], paramValues[i + 1]);
            }
        }

        /// <summary>
        /// Gets the parameters values.
        /// </summary>
        /// <value>
        /// The parameters values.
        /// </value>
        public Dictionary<string, string> ParametersValues
        {
            get { return _ParametersValues; }
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="pKey">The p key.</param>
        /// <param name="pValue">The p value.</param>
        public void AddParameter(string pKey, string pValue)
        {
            ParametersValues.Add(pKey, pValue);
        }

        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <param name="paramsValues">The parameters values.</param>
        /// <returns>returns the same object for c</returns>
        public TemplateParams DeserializeFromString(string paramsValues)
        {
            if (string.IsNullOrEmpty(paramsValues))
            {
                this._ParametersValues = new Dictionary<string, string>();
                return this;
            }

            this._ParametersValues = (Dictionary<string, string>)Newtonsoft.Json.JsonConvert.DeserializeObject(paramsValues, typeof(Dictionary<string, string>));
            return this;
        }

        /// <summary>
        /// Serializes to string.
        /// </summary>
        /// <returns></returns>
        public string SerializeToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this.ParametersValues, Newtonsoft.Json.Formatting.None);
        }


        /// <summary>
        /// Processes the template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public string ProcessTemplate(string template)
        {
            if (string.IsNullOrEmpty(template))
                return template;

            string tmp = template;
            foreach (var item in this.ParametersValues)
                tmp = tmp.Replace("{" + item.Key + "}", item.Value);
            return tmp;
        }


        public static TemplateParams FromSerializedString(string paramsValues)
        {
            return new TemplateParams().DeserializeFromString(paramsValues);
        }


    }
}
