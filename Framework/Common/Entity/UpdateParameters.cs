using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Common
{
    /// <summary>
    /// Class to define parameters used by Update function in framework layers
    /// </summary>
    public class UpdateParameters
    {

        private List<DetailObjectInfo> _DetailEntityObjects = new List<DetailObjectInfo>();

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateParameters"/> class.
        /// </summary>
        public UpdateParameters()
        { 
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateParameters"/> class.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="checkConcurrency">if set to <c>true</c> [check concurrency].</param>
        public UpdateParameters(bool checkConcurrency)
        {
            _CheckConcurrency = checkConcurrency;
        }

        #endregion

        private bool _CheckConcurrency;

        /// <summary>
        /// Gets or sets a value indicating whether [check concurrency].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [check concurrency]; otherwise, <c>false</c>.
        /// </value>
        public bool CheckConcurrency
        {
            get { return _CheckConcurrency; }
            set { _CheckConcurrency = value; }
        }


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
