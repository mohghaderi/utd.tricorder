using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixLocaleForFilesInAFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            //string dir = AppDomain.CurrentDomain.BaseDirectory;
            string dir = @"I:\VSOnline\mohghaderi\Tricorder Web\TricorderSolution\UTD.Tricorder.Website\Scripts\bootstrapvalidator-dist-0.5.0\dist\js\language\";
            RenameAllToLower(dir);
            MakeTopLocale(dir);
            MakeTopLocale(dir); // level 2 for en-us-2993
        }

        private static void MakeTopLocale(string directoryFullPath)
        {
            DirectoryInfo dir = new DirectoryInfo(directoryFullPath);
            foreach (var file in dir.GetFiles())
            {
                if (file.Name.Contains("-"))
                {
                    string cal = GetClosestCulture(file.Name);
                    if (cal != null)
                    {
                        string topCultureFileName = Path.Combine(dir.FullName, cal + file.Extension);
                        if (File.Exists(topCultureFileName) == false)
                            file.CopyTo(topCultureFileName);
                    }
                }
            }
        }

        private static void RenameAllToLower(string directoryFullPath)
        {
            DirectoryInfo dir = new DirectoryInfo(directoryFullPath);
            foreach (var file in dir.GetFiles())
            {
                string validName = file.Name.ToLower().Replace("_", "-");
                if (file.Name != file.Name.ToLower())
                {
                    file.MoveTo(Path.Combine(file.Directory.FullName, validName));
                }
            }
        }


        /// <summary>
        /// gets closest culturename to a culture by removing the last part
        /// For example, it converts en-us-1293 to en-us
        /// and en-us to en
        /// and en to null
        /// </summary>
        /// <param name="cultureName">culture name</param>
        /// <returns></returns>
        public static string GetClosestCulture(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName))
                return null;

            var i = cultureName.LastIndexOf('-');
            if (i > 0)
                return cultureName.Substring(0, i);
            else
                return null;
        }


    }
}
