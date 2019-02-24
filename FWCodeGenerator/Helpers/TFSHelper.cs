using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;

namespace Framework.FWCodeGenerator.Helpers
{
    public static class TFSHelper
    {
        /// <summary>
        /// Checks the out file.
        /// </summary>
        /// <param name="vs">The vs.</param>
        /// <param name="filePath">The file path.</param>
        public static void CheckOutFile(_DTE vs, string filePath)
        {
            if (vs == null)
                throw new ArgumentNullException("vs");

            if (File.Exists(filePath))
            {
                if (vs.SourceControl.IsItemUnderSCC(filePath) &&
                    !vs.SourceControl.IsItemCheckedOut(filePath))
                {
                    bool checkout = vs.SourceControl.CheckOutItem(filePath);
                    if (!checkout)
                    {
                        throw new CheckoutException(
                            string.Format(CultureInfo.CurrentCulture, "Properties.Resources.CheckoutException {0}", filePath));
                    }
                }
                else
                {
                    // perform an extra check if the file is read only.
                    if (IsReadOnly(filePath))
                    {
                        ResetReadOnly(filePath);
                    }
                }
            }
        }

        private static bool IsReadOnly(string path)
        {
            return (File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
        }

        private static void ResetReadOnly(string path)
        {
            File.SetAttributes(path, File.GetAttributes(path) ^ FileAttributes.ReadOnly);
        }
    }
}
