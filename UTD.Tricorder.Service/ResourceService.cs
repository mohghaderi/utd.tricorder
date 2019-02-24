using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Service;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Service
{
    //public partial class ResourceService : ServiceBase<Resource>, IResourceService
    //{
    //    /// <summary>
    //    /// Gets the resource tree.
    //    /// </summary>
    //    /// <returns></returns>
    //    /// <exception cref="System.Exception">ResourceID is not exists in Database, but there is a item with ParentID =  + parentId</exception>
    //    public IList<Resource> GetResourceTree()
    //    {
    //        IList<Resource> results = new List<Resource>();
    //        Dictionary<long, Resource> dicInfo = new Dictionary<long, Resource>(); // temproraty hash to find parent with child

    //        IList<Resource> list = GetAllT();
    //        foreach (Resource r in list)
    //            dicInfo.Add(r.ResourceID, r);

    //        // adding root items that have parentID == null
    //        foreach (Resource r in list)
    //        {
    //            if (r.ParentID.HasValue == false) // null
    //                results.Add(r);
    //            else
    //            {
    //                var parentId = r.ParentID.Value;
    //                if (dicInfo.ContainsKey(parentId) == false)
    //                    throw new Exception("ResourceID is not exists in Database, but there is a item with ParentID = " + parentId);
    //                {
    //                    dicInfo[parentId].Childs.Add(r);
    //                }
    //            }
    //        }

    //        return results;

    //    }

    //}
}
