using EnvDTE;
using EnvDTE80;
using Framework.FWCodeGenerator.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Framework.FWCodeGenerator
{
    public partial class EntityManagementMain : Form
    {
        public static EnvInfo envInfo;

        public EntityManagementMain(DTE dte)
        {
            InitializeComponent();
            this.Shown += EntityManagementMain_Shown;

            if (envInfo == null)
                envInfo = new EnvInfo(dte);


            OpenIServiceButton.Tag = EntityFileTypeEnum.EntityServiceInterface;
            OpenJSButton.Tag = EntityFileTypeEnum.AngularJSController;
            OpenServiceButton.Tag = EntityFileTypeEnum.EntityService;
            OpenSPButton.Tag = EntityFileTypeEnum.EntitySP;
        }


        void EntityManagementMain_Shown(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            var list = envInfo.GetSelectedItemsList();
            foreach (var item in list)
            {
                sb.AppendLine(item);
            }
            EntityList.Text = sb.ToString();
        }

        private void CheckoutAndGenerateButton_Click(object sender, EventArgs e)
        {
            var list = envInfo.GetSelectedItemsList();
            CheckOutMainItems(list.ToArray());
        }

        private void CheckOutMainItems(string[] listOfEntityInfoPaths)
        {
            EntityHelper.envInfo = envInfo;
            foreach (var enPath in listOfEntityInfoPaths)
            {
                var allItems = EntityHelper.GetEntityFilesListByENFilePath(enPath);
                TFSHelper.CheckOutFile(envInfo.dte, allItems[EntityFileTypeEnum.EntityInfoEN].FullPath);
                TFSHelper.CheckOutFile(envInfo.dte, allItems[EntityFileTypeEnum.EntityObjT].FullPath);
                TFSHelper.CheckOutFile(envInfo.dte, allItems[EntityFileTypeEnum.EntityObjV].FullPath);
                TFSHelper.CheckOutFile(envInfo.dte, allItems[EntityFileTypeEnum.EntityObjTXml].FullPath);
                TFSHelper.CheckOutFile(envInfo.dte, allItems[EntityFileTypeEnum.EntityObjVXml].FullPath);
            }
        }


        private void IncludeInProject(string[] listOfEntityInfoPaths)
        {
            EntityHelper.envInfo = envInfo;
            foreach (var enPath in listOfEntityInfoPaths)
            {
                var allItems = EntityHelper.GetEntityFilesListByENFilePath(enPath);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityInfoEN]);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityObjT]);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityObjV]);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityObjTXml], true);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityObjVXml], true);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityServiceInterface]);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityDA]);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityBR]);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityService]);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.EntityMvcController]);
                AddFileToProject(envInfo, allItems[EntityFileTypeEnum.AngularJSController]);
            }
        }

        private void AddFileToProject(EnvInfo envInfo, EntityFileInfo fileInfo, bool embededResource = false)
        {
            var item = envInfo.AddFileToProject((Project) fileInfo.Project, fileInfo.FullPath, fileInfo.FileName);
            if (embededResource)
                envInfo.SetItemBuildAction(item, "EmbeddedResource");
        }


        private void IncludeInProjectButton_Click(object sender, EventArgs e)
        {
            var list = envInfo.GetSelectedItemsList();
            IncludeInProject(list.ToArray());
        }

        private void OpenEntityFileButton_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            EntityFileTypeEnum filetype = (EntityFileTypeEnum) btn.Tag;
            string entityName = GetSelectedItemEntityName();
            var allItems = EntityHelper.GetEntityFilesListByEntityName(entityName);
            envInfo.OpenFile(allItems[filetype].FullPath);
        }

        private string GetSelectedItemEntityName()
        {
            throw new NotImplementedException();
        }


        private void OpenFile(EntityFileTypeEnum type)
        {
            
        }



    }
}
