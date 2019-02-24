using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.FWCodeGenerator.Helpers
{
    public class EntityFileInfo
    {
        public string FullPath;
        public string FileName;
        public EntityFileTypeEnum EntityFileType;
        public bool IsExistsInProject;
        public bool IsExistsInHard;
        public object ProjectItem;
        public object Project;
    }
}
