using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.FWCodeGenerator.Helpers
{
    public class EntityHelper
    {
        public static EnvInfo envInfo;

        public static Dictionary<EntityFileTypeEnum, EntityFileInfo> GetEntityFilesListByEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<EntityFileTypeEnum, EntityFileInfo> GetEntityFilesListByENFilePath(string enFilePath)
        {
            Dictionary<EntityFileTypeEnum, EntityFileInfo> list = new Dictionary<EntityFileTypeEnum, EntityFileInfo>();

            AddEntityInfoPath(list,  GetFileInfo(enFilePath, EntityFileTypeEnum.EntityInfoEN));
            AddEntityInfoPath(list,  GetFileInfo(enFilePath.Replace("EntityInfos", "EntityObjects").Replace("EN.cs", ".cs"), EntityFileTypeEnum.EntityObjT));
            AddEntityInfoPath(list,  GetFileInfo(enFilePath.Replace("EntityInfos", "EntityObjects").Replace("EN.cs", ".hbm.xml"), EntityFileTypeEnum.EntityObjTXml));
            AddEntityInfoPath(list,  GetFileInfo(enFilePath.Replace("EntityInfos", "SP").Replace("EN.cs", "SP.cs"), EntityFileTypeEnum.EntitySP));
            AddEntityInfoPath(list,  GetFileInfo(AddFilePrefix(enFilePath.Replace("EntityInfos", "EntityObjects").Replace("EN.cs", ".cs"), "v"), EntityFileTypeEnum.EntityObjV));
            AddEntityInfoPath(list,  GetFileInfo(AddFilePrefix(enFilePath.Replace("EntityInfos", "EntityObjects").Replace("EN.cs", ".hbm.xml"), "v"), EntityFileTypeEnum.EntityObjVXml));
            AddEntityInfoPath(list,  GetFileInfo(AddFilePrefix(enFilePath.Replace("EntityInfos", "ServiceInterfaces").Replace("EN.cs", "Service.cs"), "I"), EntityFileTypeEnum.EntityServiceInterface));
            AddEntityInfoPath(list,  GetFileInfo(enFilePath.Replace(".Common\\EntityInfos", ".DataAccess").Replace("EN.cs", "DA.cs"), EntityFileTypeEnum.EntityDA));
            AddEntityInfoPath(list,  GetFileInfo(enFilePath.Replace(".Common\\EntityInfos", ".BusinessRule").Replace("EN.cs", "BR.cs"), EntityFileTypeEnum.EntityBR));
            AddEntityInfoPath(list,  GetFileInfo(enFilePath.Replace(".Common\\EntityInfos", ".Service").Replace("EN.cs", "Service.cs"), EntityFileTypeEnum.EntityService));
            AddEntityInfoPath(list,  GetFileInfo(enFilePath.Replace(".Common\\EntityInfos", ".Website\\Controllers").Replace("EN.cs", "Controller.cs"), EntityFileTypeEnum.EntityMvcController));
            AddEntityInfoPath(list,  GetFileInfo(enFilePath.Replace(".Common\\EntityInfos", ".Website\\app\\controllers").Replace("EN.cs", ".js"), EntityFileTypeEnum.AngularJSController));

            return list;
        }

        private static void AddEntityInfoPath(Dictionary<EntityFileTypeEnum, EntityFileInfo> list, EntityFileInfo info)
        {
            list.Add(info.EntityFileType, info);
        }

        private static string AddFilePrefix(string path, string prefix)
        {
            var i = path.LastIndexOf('\\');
            if (i > 0)
            {
                return path.Substring(0, i + 1) + prefix + path.Substring(i + 1, path.Length - i - 1);
            }
            return prefix + path;
        }

        private static EntityFileInfo GetFileInfo(string path, EntityFileTypeEnum type)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);

            EntityFileInfo info = new EntityFileInfo();
            info.FullPath = path;
            info.EntityFileType = type;
            var item = envInfo.solution.FindProjectItem(info.FullPath);
            if (item != null)
            {
                info.IsExistsInProject = true;
                info.ProjectItem = item;
            }

            info.FileName = fileInfo.Name;
            info.IsExistsInHard = fileInfo.Exists;
            info.Project = GetProjectByEntityFileType(info.EntityFileType);
            return info;
        }

        public static Project GetProjectByEntityFileType(EntityFileTypeEnum t)
        {
            switch (t)
            {
                case EntityFileTypeEnum.EntityBR:
                    return envInfo.businessProject;
                case EntityFileTypeEnum.EntityDA:
                    return envInfo.dataAccessProject;
                case EntityFileTypeEnum.EntityInfoEN:
                    return envInfo.commonProject;
                case EntityFileTypeEnum.EntityMvcController:
                    return envInfo.webSiteProject;
                case EntityFileTypeEnum.EntityObjT:
                    return envInfo.commonProject;
                case EntityFileTypeEnum.EntityObjTXml:
                    return envInfo.commonProject;
                case EntityFileTypeEnum.EntityObjV:
                    return envInfo.commonProject;
                case EntityFileTypeEnum.EntityObjVXml:
                    return envInfo.commonProject;
                case EntityFileTypeEnum.EntityService:
                    return envInfo.servicesProject;
                case EntityFileTypeEnum.EntityServiceInterface:
                    return envInfo.commonProject;
                case EntityFileTypeEnum.EntitySP:
                    return envInfo.commonProject;
                case EntityFileTypeEnum.AngularJSController:
                    return envInfo.webSiteProject;
            }
            return null;
        }



    }
}
