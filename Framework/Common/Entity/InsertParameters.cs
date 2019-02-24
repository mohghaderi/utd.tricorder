using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    public class InsertParameters
    {
        //public insertColumns
        private List<DetailObjectInfo> _DetailEntityObjects = new List<DetailObjectInfo>();


        /// <summary>
        /// Gets or sets the detail entity objects.
        /// These entities will be updated along with the main entity in one transaction
        /// </summary>
        /// <value>
        /// The detail entity objects.
        /// </value>
        public List<DetailObjectInfo> DetailEntityObjects
        {
            get { return _DetailEntityObjects; }
            set { _DetailEntityObjects = value; }
        }


    }



}
