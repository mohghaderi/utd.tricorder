using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;

namespace Framework.FWCodeGenerator.Helpers
{
    public class EnvInfo
    {
        public EnvDTE.DTE dte = null;

        /// <summary>
        /// يك نمونه از اطلاعات پروژه ايجاد مي كند
        /// </summary>
        /// <param name="dte"></param>
        public EnvInfo(EnvDTE.DTE dte)
        {
            this.dte = dte;
            this.PackageName = FindPackageName();
            FindAllProjects();
        }

        public Solution solution = null;

        public Project businessProject = null;
        public Project commonProject = null;
        public Project dataAccessProject = null;
        public Project servicesProject = null;
        public Project webSiteProject = null;

        /// <summary>
        /// آيا همه پروژه هاي موجود در برنامه پيدا شده اند
        /// </summary>
        /// <returns></returns>
        public bool IsAllProjectFounded()
        {
            if (businessProject != null &&
                commonProject != null &&
                dataAccessProject != null &&
                servicesProject != null &&
                webSiteProject != null)
                return true;
            else
                return false;
        }

        public string WebSiteName
        {
            get { return webSiteName; }
            set { webSiteName = value; }
        } protected string webSiteName;

        public string PackageName
        {
            get { return packageName; }
            set { packageName = value; }
        } protected string packageName;



        /// <summary>
        /// رفرنس به همه پروژه ها را پيدا مي كند
        /// </summary>
        /// <param name="dte"></param>
        public bool FindAllProjects()
        {
            Solution sol = dte.Solution;
            string[] tempA = sol.FullName.Split('\\');
            solution = sol;

            foreach (Project p in sol.Projects)
            {
                if (p.Name.StartsWith(this.PackageName))
                {
                    if (p.Name.EndsWith(".BusinessRule"))
                        businessProject = (Project)p;
                    if (p.Name.EndsWith(this.PackageName + ".Common"))
                        commonProject = (Project)p;
                    if (p.Name.EndsWith(this.PackageName + ".DataAccess"))
                        dataAccessProject = (Project)p;
                    if (p.Name.EndsWith(this.PackageName + ".Service"))
                        servicesProject = (Project)p;
                    if (p.Name.EndsWith(".Website"))
                        webSiteProject = (Project)p;
                }
            }

            return IsAllProjectFounded();
        }

        /// <summary>
        /// نام پكيج را پيدا ميكند
        /// مثلا MNA.MAD
        /// </summary>
        /// <returns></returns>
        protected string FindPackageName()
        {
            if (dte.SelectedItems.Count > 0)
            {
                string projectName = dte.SelectedItems.Item(1).ProjectItem.ContainingProject.Name;
                if (projectName.EndsWith(".Common"))
                    return projectName.Substring(0, projectName.LastIndexOf(".Common"));
                if (projectName.EndsWith(".BusinessRule"))
                    return projectName.Substring(0, projectName.LastIndexOf(".BusinessRule"));
                if (projectName.EndsWith(".DataAccess"))
                    return projectName.Substring(0, projectName.LastIndexOf(".DataAccess"));
                if (projectName.EndsWith(".Service"))
                    return projectName.Substring(0, projectName.LastIndexOf(".Service"));
                if (projectName.EndsWith(".Website"))
                    return projectName.Substring(0, projectName.LastIndexOf(".Website"));
            }
            else
            {
                //throw new Exception("No item is selected.");
            }
            return "";
        }

        public List<string> GetSelectedItemsList()
        {
            List<string> list = new List<string>();
            if (dte.SelectedItems.Count > 0)
            {
                for (int i = 1; i <= dte.SelectedItems.Count; i++)
                {
                    list.Add(dte.SelectedItems.Item(i).ProjectItem.FileNames[0]);
                }
            }
            return list;
        }

        /// <summary>
        /// فايل را باز مي كند اطلاعات جديد را جايگزين كرده و مي بندد
        /// </summary>
        /// <param name="p"></param>
        /// <param name="filename"></param>
        /// <param name="textToReplace"></param>
        /// <param name="ReplacementText"></param>
        public void ReplaceTextInDoc(Project project, string filename, string textToReplace, string replacementText)
        {
            ProjectItem item = project.ProjectItems.Item(filename);
            ReplaceTextInProjectItem(item, textToReplace, replacementText);
        }

        /// <summary>
        /// فايل را باز مي كند اطلاعات جديد را جايگزين كرده و مي بندد
        /// </summary>
        /// <param name="item">فايل در پروژه</param>
        /// <param name="textToReplace">متني كه بايد جايگزين شود</param>
        /// <param name="replacementText">متن جايگزين</param>
        public void ReplaceTextInProjectItem(ProjectItem item, string textToReplace, string replacementText)
        {
            bool fileopened = false;
            if (item.Document == null)
            {
                fileopened = true;
                item.Open(EnvDTE.Constants.vsViewKindCode); // فايل را باز كنيم
            }
            if (item.Document != null)
            {
                Document doc = item.Document;
                doc.ReplaceText(textToReplace, replacementText, 1);
                if (fileopened == true) // اگر فايل را خودمان باز كرده بوديم آن را ببنديم
                    doc.Close(vsSaveChanges.vsSaveChangesYes);
            }
        }


        

        /// <summary>
        /// فايل را باز مي كند اطلاعات جديد را جايگزين كرده و مي بندد
        /// </summary>
        /// <param name="item">فايل در پروژه</param>
        /// <param name="textToReplace">متني كه بايد جايگزين شود</param>
        /// <param name="replacementText">متن جايگزين</param>
        public void ReplaceParametersInProjectItem(ProjectItem item, Dictionary<string, string> parameters)
        {
            string fileName = item.FileNames[0];
            string fileContent = System.IO.File.ReadAllText(fileName, System.Text.UTF8Encoding.UTF8);
            foreach (var p in parameters)
            {
                fileContent = fileContent.Replace(p.Key, p.Value);
            }
            System.IO.File.WriteAllText(fileName, fileContent, System.Text.UTF8Encoding.UTF8);



        }


        ///// <summary>
        /////  نام فايل اطلاعات اضافي مربوط به يك موجوديت را بر مي گرداند
        ///// </summary>
        ///// <returns></returns>
        //public string GetEntityInformationFile(string entityNameSpace, string entityName)
        //{
        //    return GetProjectPath(commonProject) + @"Descriptor\" + ConcatNameSpaces(entityNameSpace, entityName) + "info.xml";
        //}


        /// <summary>
        /// يك آيتم را در پروژه پيدا مي كند
        /// </summary>
        /// <param name="items">آيتم هاي پروژه</param>
        /// <param name="filename">نام آيتم</param>
        /// <returns></returns>
        public ProjectItem FindProjectItem(ProjectItems items, string filename)
        {
            // BFS
            foreach (ProjectItem item in items)
            {
                if (item.Name == filename) // اگر معادل فايل بود
                {
                    return item;
                }
            }
            foreach (ProjectItem item in items)
            {
                if (item.ProjectItems != null)
                {
                    if (item.ProjectItems.Count > 0) // اگر زير آيتم داشت در زير آيتم ها بگردد
                    {
                        ProjectItem pi = FindProjectItem(item.ProjectItems, filename);
                        if (pi != null)
                            return pi;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// يك آيتم را در پروژه پيدا مي كند
        /// </summary>
        /// <param name="items">آيتم هاي پروژه</param>
        /// <param name="filename">نام آيتم</param>
        /// <returns></returns>
        public ProjectItem FindProjectItemByFilePath(ProjectItems items, string filePath)
        {
            // BFS
            foreach (ProjectItem item in items)
            {
                if (ProjectItemHasFilePath(item, filePath)) // اگر معادل فايل بود
                {
                    return item;
                }
            }
            foreach (ProjectItem item in items)
            {
                if (item.ProjectItems != null)
                {
                    if (item.ProjectItems.Count > 0) // اگر زير آيتم داشت در زير آيتم ها بگردد
                    {
                        ProjectItem pi = FindProjectItem(item.ProjectItems, filePath);
                        if (pi != null)
                            return pi;
                    }
                }
            }
            return null;
        }

        private bool ProjectItemHasFilePath(ProjectItem item, string filePath)
        {
            filePath = filePath.ToLower();
            if (item.FileCount > 0)
            {
                for (short i = 0; i <= item.FileCount; i++)
                {
                    if (item.get_FileNames(i).ToLower() == filePath)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// يك آيتم را از پروژه حذف ميكند
        /// </summary>
        public void DeleteProjectItem(Project project, ProjectItem item)
        {
            if (item == null)
                return;
            string filename = item.get_FileNames(1);
            item.Delete();
            if (System.IO.File.Exists(filename))
            {
                try
                {
                    System.IO.File.Delete(filename);
                }
                catch (Exception)
                {
                    // nothing to do!
                }
            }
        }

        /// <summary>
        /// adds a file to the project if it doesn't exists in the project
        /// </summary>
        /// <param name="project">project</param>
        /// <param name="filePath">file path</param>
        /// <param name="nameInProject">nameInProject</param>
        public ProjectItem AddFileToProject(Project project, string filePath, string nameInProject)
        {
            if (System.IO.File.Exists(filePath) == false)
                return null;

            ProjectItem projectItem = FindProjectItemByFilePath(project.ProjectItems, filePath);
            if (projectItem == null) // if it was not found then include in project
                return project.ProjectItems.AddFromFile(filePath);
 
            return null;
        }

        /// <summary>
        /// Sets build action of a project item
        /// </summary>
        /// <param name="item">project item</param>
        /// <param name="buildAction">build action value like EmbeddedResource</param>
        public void SetItemBuildAction(ProjectItem item, string buildAction)
        {
            if (item != null)
                item.Properties.Item("ItemType").Value = buildAction;
        }


        public void OpenFile(string filePath)
        {
            dte.ItemOperations.OpenFile(filePath);
        }


        ///// <summary>
        ///// يك الگوي استاندارد را به پروژه اضافه مي كند
        ///// ورژن قبلي
        ///// </summary>
        ///// <param name="project">پروژه</param>
        ///// <param name="TemplatePath">مسيري كه الگو در آن نصب شده</param>
        ///// <param name="name">نام فايل</param>
        //public void AddTemplateToProject(Project project, string templatePath, string entityName)
        //{
        //    project.ProjectItems.AddFromTemplate(this.AddinsPath + templatePath, entityName);
        //}


        //internal void CreateTemplateFiles(TemplateItemSetting templateItemSetting, string entityNameSpace, string entityName, Dictionary<string, string> parameters)
        //{
        //    string creationNameSpace = ConcatNameSpaces(templateItemSetting.NameSpace, entityNameSpace);

        //    for (int i = 0; i < templateItemSetting.FileNames.Length; i++)
        //    {
        //        string fileName = this.AddinsPath + templateItemSetting.TemplateFolder + @"\" + templateItemSetting.FileNames[i];
        //        Project project = getProjectByName(templateItemSetting.ProjectName);
        //        if (project != null)
        //        {
        //            ProjectItem suitableItem = FindProjectItemFolderByEntity(project, creationNameSpace);
        //            ProjectItems ItemList = null;
        //            if (suitableItem == null)
        //                ItemList = project.ProjectItems;
        //            else
        //                ItemList = suitableItem.ProjectItems;
        //            if (project.Name.EndsWith("Web\\") == false)
        //                CommonHelpers.TFSHelper.CheckOutFile(this.dte, project.FullName);
        //            string tempFileName = System.IO.Path.GetTempPath() + templateItemSetting.FileNames[i].Replace("Entity", entityName);
        //            System.IO.File.Copy(fileName, tempFileName, true);
        //            ProjectItem newItem = ItemList.AddFromFileCopy(tempFileName);
        //            System.IO.File.Delete(tempFileName);

        //            if (newItem != null)
        //            {
        //                parameters["$safeitemname$"] = newItem.Name.Substring(0, newItem.Name.IndexOf('.')); // GetSafeItemName(newItem.Name);
        //                parameters["$fileinputname$"] = entityName;
        //                parameters["$rootnamespace$"] = ConcatNameSpaces(project.Name, creationNameSpace);
        //                parameters["$ServiceInterfaceNameSpaceUsing$"] = "using " + ConcatNameSpaces(ConcatNameSpaces(this.commonProject.Name, "ServiceInterfaces"), entityNameSpace) + ";";
        //                parameters["$DataSetNameSpaceUsing$"] = "using " + ConcatNameSpaces(ConcatNameSpaces(this.commonProject.Name, "DataSets"), entityNameSpace) + ";";

        //                ReplaceParametersInProjectItem(newItem, parameters);
        //            }
        //        }
        //    }
        //}

        //internal void CreateTemplateFiles(TemplateItemSetting templateItemSetting, string folderPath, string entityNameSpace, string entityName, Dictionary<string, string> parameters)
        //{
        //    string creationNameSpace = ConcatNameSpaces(templateItemSetting.NameSpace, entityNameSpace);

        //    for (int i = 0; i < templateItemSetting.FileNames.Length; i++)
        //    {
        //        string fileName = this.AddinsPath + templateItemSetting.TemplateFolder + @"\" + templateItemSetting.FileNames[i];
        //        Project project = getProjectByName(templateItemSetting.ProjectName);
        //        if (project != null)
        //        {
        //            ProjectItem suitableItem = FindProjectItemFolderByEntity(project, ConcatNameSpaces(templateItemSetting.NameSpace, folderPath));
        //            ProjectItems ItemList = null;
        //            if (suitableItem == null)
        //                ItemList = project.ProjectItems;
        //            else
        //                ItemList = suitableItem.ProjectItems;
        //            if (project.Name.EndsWith("Web\\") == false)
        //                CommonHelpers.TFSHelper.CheckOutFile(this.dte, project.FullName);
        //            string tempFileName = System.IO.Path.GetTempPath() + templateItemSetting.FileNames[i].Replace("Entity", entityName);
        //            System.IO.File.Copy(fileName, tempFileName, true);
        //            ProjectItem newItem = ItemList.AddFromFileCopy(tempFileName);
        //            System.IO.File.Delete(tempFileName);

        //            if (newItem != null)
        //            {
        //                parameters["$safeitemname$"] = newItem.Name.Substring(0, newItem.Name.IndexOf('.')); // GetSafeItemName(newItem.Name);
        //                parameters["$fileinputname$"] = entityName;
        //                parameters["$rootnamespace$"] = project.Name;
        //                parameters["$ServiceInterfaceNameSpaceUsing$"] = "";//"using " + ConcatNameSpaces(ConcatNameSpaces(this.commonProject.Name, "ServiceInterfaces"), entityNameSpace) + ";";
        //                parameters["$DataSetNameSpaceUsing$"] = "";// "using " + ConcatNameSpaces(ConcatNameSpaces(this.commonProject.Name, "DataSets"), entityNameSpace) + ";";

        //                ReplaceParametersInProjectItem(newItem, parameters);
        //            }
        //        }
        //    }
        //}


        //internal void AddGeneratedTemplateToProject(TemplateItemSetting templateItemSetting, string folderPath, string entityNameSpace, string entityName, string generatedText)
        //{
        //    string creationNameSpace = ConcatNameSpaces(templateItemSetting.NameSpace, entityNameSpace);

        //    for (int i = 0; i < templateItemSetting.FileNames.Length; i++)
        //    {
        //        Project project = getProjectByName(templateItemSetting.ProjectName);
        //        if (project != null)
        //        {
        //            ProjectItem suitableItem = FindProjectItemFolderByEntity(project, ConcatNameSpaces(templateItemSetting.NameSpace, folderPath));
        //            ProjectItems ItemList = null;
        //            if (suitableItem == null)
        //                ItemList = project.ProjectItems;
        //            else
        //                ItemList = suitableItem.ProjectItems;
        //            //--if (project.Name.EndsWith("Web\\") == false)
        //            CommonHelpers.TFSHelper.CheckOutFile(this.dte, project.FullName);
        //            string tempFileName = System.IO.Path.GetTempPath() + templateItemSetting.FileNames[i].Replace("Entity", entityName);
        //            System.IO.File.WriteAllText(tempFileName, generatedText, System.Text.UTF8Encoding.UTF8);
        //            ProjectItem newItem = ItemList.AddFromFileCopy(tempFileName);
        //            System.IO.File.Delete(tempFileName);
        //        }
        //    }
        //}

        //internal void UpdateFileByTemplateSetting(TemplateItemSetting templateItemSetting, string folderPath, string entityNameSpace, string entityName, string generatedText)
        //{
        //    string creationNameSpace = ConcatNameSpaces(templateItemSetting.NameSpace, entityNameSpace);

        //    for (int i = 0; i < templateItemSetting.FileNames.Length; i++)
        //    {
        //        Project project = getProjectByName(templateItemSetting.ProjectName);
        //        if (project != null)
        //        {
        //            ProjectItem suitableItem = FindProjectItemFolderByEntity(project, ConcatNameSpaces(templateItemSetting.NameSpace, folderPath));
        //            ProjectItems ItemList = null;
        //            if (suitableItem == null)
        //                ItemList = project.ProjectItems;
        //            else
        //                ItemList = suitableItem.ProjectItems;
        //            //--if (project.Name.EndsWith("Web\\") == false)
        //                CommonHelpers.TFSHelper.CheckOutFile(this.dte, project.FullName);

        //            suitableItem = FindProjectItemByEntity(project, entityNameSpace, templateItemSetting.FileNames[i].Replace("Entity", entityName));
        //            string fileName = suitableItem.FileNames[0];
        //            CommonHelpers.TFSHelper.CheckOutFile(this.dte, fileName);
        //            System.IO.File.WriteAllText(fileName, generatedText);
        //        }
        //    }
        //}




        //internal void DeleteTemplateFiles(TemplateItemSetting templateItemSetting, string entityNameSpace, string entityName)
        //{
        //    string creationNameSpace = ConcatNameSpaces(templateItemSetting.NameSpace, entityNameSpace);
        //    for (int i = 0; i < templateItemSetting.FileNames.Length; i++)
        //    {
        //        Project project = getProjectByName(templateItemSetting.ProjectName);
        //        if (project != null)
        //        {
        //            string fileName = templateItemSetting.FileNames[i].Replace("Entity", entityName);
        //            ProjectItem item = FindProjectItemByEntity(project, creationNameSpace, fileName);

        //            if (item != null)
        //                this.DeleteProjectItem(project, item);
        //        }
        //    }

        //}

        //internal void DeleteTemplateFiles(TemplateItemSetting templateItemSetting, string folderPath, string entityNameSpace, string entityName)
        //{
        //    string creationNameSpace = ConcatNameSpaces(templateItemSetting.NameSpace, folderPath);
        //    for (int i = 0; i < templateItemSetting.FileNames.Length; i++)
        //    {
        //        Project project = getProjectByName(templateItemSetting.ProjectName);
        //        if (project != null)
        //        {
        //            string fileName = templateItemSetting.FileNames[i].Replace("Entity", entityName);
        //            ProjectItem item = FindProjectItemByEntity(project, creationNameSpace, fileName);

        //            if (item != null)
        //                this.DeleteProjectItem(project, item);
        //        }
        //    }

        //}



        private Project getProjectByName(string projectName)
        {
            Solution sol = dte.Solution;
            string[] tempA = sol.FullName.Split('\\');
            solution = sol;

            foreach (Project p in sol.Projects)
            {
                if (p.Name.StartsWith(this.PackageName) && p.Name.EndsWith("." + projectName))
                {
                    return p;
                }
                //if (p.Name.EndsWith("Web\\") && projectName == "Web") // websites are exception
                //{
                //    return p;
                //}
            }
            return null;
        }

        /// <summary>
        /// آيتم پروژه را بر اساس نام موجوديت پيدا ميكند
        /// </summary>
        /// <param name="project">پروژه</param>
        /// <param name="entityNameSpace"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public ProjectItem FindProjectItemByEntity(Project project, string entityNameSpace, string itemName)
        {
            ProjectItem folder = FindProjectItemFolderByEntity(project, entityNameSpace);
            ProjectItem answer = null;
            if (folder == null) // no folder in project = root
            {
                answer = GetProjectItemInItemsByName(project.ProjectItems, itemName);
            }
            else
            {
                answer = GetProjectItemInItemsByName(folder.ProjectItems, itemName);
            }
            return answer;
        }


        public ProjectItem FindProjectItemFolderByEntity(Project project, string entityNameSpace)
        {
            ProjectItems answer = project.ProjectItems;
            ProjectItem answerItem = null;
            string answerPath = new FileInfo(project.FullName).Directory.FullName + @"\";
            if (string.IsNullOrEmpty(entityNameSpace) == false)
            {
                string[] dirs = entityNameSpace.Split('.');
                for (int i = 0; i < dirs.Length; i++)
                {
                    string folderName = dirs[i];
                    ProjectItem folderItem = GetProjectItemInItemsByName(answer, folderName);
                    if (folderItem == null) // اگر پوشه وجود نداشت
                    {
                        string folderPath = answerPath + folderName;
                        if (System.IO.Directory.Exists(folderPath) == false)
                            answer.AddFolder(folderName);
                        else
                            answer.AddFromDirectory(folderPath);
                    }
                    answerItem = GetProjectItemInItemsByName(answer, folderName);
                    answer = answerItem.ProjectItems;
                    answerPath = answerItem.FileNames[1];
                }
            }
            else
            {
                return null;
            }
            return answerItem;
        }

        /// <summary>
        /// نام يك آيتم پروژه را در ليست آيتم ها پيدا ميكند
        /// </summary>
        /// <param name="pitems">آيتم هاي پروژه</param>
        /// <param name="itemName">نام آيتم</param>
        /// <returns></returns>
        private ProjectItem GetProjectItemInItemsByName(ProjectItems pitems, string itemName)
        {
            for (int n = 1; n <= pitems.Count; n++)
            {
                if (pitems.Item(n).Name == itemName)
                    return pitems.Item(n);
            }
            return null;
        }


        /// <summary>
        /// مسيري را كه پروژه در آن قرار گرفته است ميگيرد
        /// </summary>
        /// <param name="project">پروژه</param>
        /// <returns></returns>
        public string GetProjectPath(Project project)
        {
            return project.FileName.Substring(0, project.FileName.LastIndexOf('\\') + 1);
        }


        /// <summary>
        /// نام فايل اسمبلي يك پروژه را مي گيرد
        /// </summary>
        /// <param name="project">پروژه</param>
        /// <returns></returns>
        public string GetAssemblyFileFullName(Project project)
        {
            return GetProjectPath(project) + @"bin\Debug\" + project.Name + ".dll";
        }


        /// <summary>
        /// پوشه اي كه فايل اجرايي "اد اين" در آن قرار گرفته است" 
        /// </summary>
        public string AddinsPath
        {
            get
            {
                //return @"D:\Users\mghaderi\Documents\Visual Studio 2008\Projects\RPKPackage\RPKPackage\bin\Debug\";
                System.IO.FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
                return fi.DirectoryName + "\\";
            }
        }


        /// <summary>
        /// سلوشن را به طور كامل ذخيره ميكند
        /// </summary>
        public void SaveSolution()
        {
            dte.ExecuteCommand("File.SaveAll", "");
        }


        /// <summary>
        /// دو تا فضاي نام را به هم متصل ميكند
        /// </summary>
        /// <param name="ns1">فضاي نام اول</param>
        /// <param name="ns2">فضاي نام دوم</param>
        /// <returns></returns>
        public static string ConcatNameSpaces(string ns1, string ns2)
        {
            string creationNameSpace = "";
            if (string.IsNullOrEmpty(ns1) == false)
            {
                creationNameSpace = ns1;
                if (string.IsNullOrEmpty(ns2) == false)
                    creationNameSpace += "." + ns2;
            }
            else
                creationNameSpace = ns2;
            return creationNameSpace;
        }
    }
}
