using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class ResourceService : ServiceBase<Resource, vResource>, IResourceService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets the resource tree.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">ResourceID is not exists in Database, but there is a item with ParentID =  + parentId</exception>
        public IList<Resource> GetResourceTree()
        {
            IList<Resource> results = new List<Resource>();
            Dictionary<long, Resource> dicInfo = new Dictionary<long, Resource>(); // temproraty hash to find parent with child

            SortExpression sort = new SortExpression(vResource.ColumnNames.RankOrder)
                                            .AddSort(vResource.ColumnNames.ResourceTitle);

            FilterExpression filter = new FilterExpression();

            IList<Resource> list = GetByFilterT(new GetByFilterParameters(filter, sort, 0, int.MaxValue));
            foreach (Resource r in list)
                dicInfo.Add(r.ResourceID, r);

            // adding root items that have parentID == null
            foreach (Resource r in list)
            {
                if (r.ParentID.HasValue == false) // null
                    results.Add(r);
                else
                {
                    var parentId = r.ParentID.Value;
                    if (dicInfo.ContainsKey(parentId) == false)
                        throw new Exception("ResourceID is not exists in Database, but there is a item with ParentID = " + parentId);
                    {
                        dicInfo[parentId].Childs.Add(r);
                    }
                }
            }

            return results;

        }


		#endregion

    }
}

