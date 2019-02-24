using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Runtime.Serialization;

namespace Framework.Common
{
    public enum PermissionsEnum
    {
        Undecided = -1,
        Deny = 0,
        Allow = 1,
        AllowForce = 2,
        DenyForce = 3
    }

    public class FastResourceInfo
    {
        public Guid ResourceID;
        public string ResourceCode;
        public Guid ParentID;
        public string ResourceName;
        public string URL;
        public FastResourceInfoList Childs;
        public int ResourceType;
    }


    public class FastResourceInfoList : List<FastResourceInfo>
    {
        public FastResourceInfoList RootItems { get; set; }

        public FastResourceInfoList GetItemsByParentID(Guid parentId)
        {
            FastResourceInfoList datalist = new FastResourceInfoList();
            foreach (FastResourceInfo r in this)
                if (r.ParentID == parentId)
                    datalist.Add(r);
            return datalist;
        }
    }



    public class ResourcePermissions
    {
        public ResourcePermissions(ResourcePermissionList permissionList, string userName)
        {
            this.PermissionList = permissionList;
            this.UserName = userName;
        }


        /// <summary>
        /// از اين ليست براي تعيين سطح دسترسي استفاده نكنيد
        /// براي تعيين سطح دسترسي فقط و فقط از متد HasAccess استفاده شود
        /// </summary>
        public ResourcePermissionList PermissionList { get; set; }

        //public DataSet ResourceDataSet
        //{
        //    get { return PermissionList.ResourceDataSet; }
        //}

        public string UserName { get; set; }


        /// <summary>
        /// آيا به اين منبع دسترسي دارد يا نه
        /// </summary>
        /// <param name="resourceCode">شناسه منبع</param>
        /// <returns></returns>
        public bool HasAccess(string resourceCode)
        {
            if (PermissionList.ContainsKey(resourceCode) == false)
                throw new Exception("resource not found: " + resourceCode.ToString());
            PermissionsEnum permission = (PermissionsEnum)PermissionList[resourceCode];
            if (permission == PermissionsEnum.Undecided) // undecided
                return false;


            if (permission == PermissionsEnum.Allow || permission == PermissionsEnum.AllowForce)
                return true;
            if (permission == PermissionsEnum.Deny || permission == PermissionsEnum.DenyForce)
                return false;

            return false;
        }
    }


    [Serializable]
    /// <summary>
    /// ليستي از كد ريسورس و دسترسي به آن
    /// </summary>
    public class ResourcePermissionList : Dictionary<string, PermissionsEnum>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcePermissionList"/> class.
        /// </summary>
        /// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object containing the information required to serialize the <see cref="T:System.Collections.Generic.Dictionary`2" />.</param>
        /// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> structure containing the source and destination of the serialized stream associated with the <see cref="T:System.Collections.Generic.Dictionary`2" />.</param>
        protected ResourcePermissionList(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        //public DataSet ResourceDataSet { get; set; }

        /// <summary>
        /// در تركيب ليست ها اولويت به دادن دسترسي است
        /// اين عملگرها قابل جايگذاري هستند يعني اينكه فرقي نميكند ليست اول با دومي اور شود يا ليست دوم با اولي
        /// </summary>
        /// <param name="list"></param>
        public void OR(ResourcePermissionList list)
        {
            if (list.Count != this.Count)
                throw new Exception("ResourcePermissionList.OR: ResourcePermissionList should have equal Counts");

            var resourceCodes = this.Keys.ToList();
            foreach (var key in resourceCodes)
            {
                var item1Permission = this[key];
                var item2Permission = list[key];
                PermissionsEnum result = PermissionsEnum.Undecided;

                if (item1Permission == PermissionsEnum.Undecided && item2Permission != PermissionsEnum.Undecided)
                    result = item2Permission;
                if (item2Permission == PermissionsEnum.Undecided && item1Permission != PermissionsEnum.Undecided)
                    result = item1Permission;

                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.AllowForce || item2Permission == PermissionsEnum.AllowForce)
                        result = PermissionsEnum.AllowForce;

                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.DenyForce || item2Permission == PermissionsEnum.DenyForce)
                        result = PermissionsEnum.DenyForce;

                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.Allow || item2Permission == PermissionsEnum.Allow)
                        result = PermissionsEnum.Allow;

                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.Deny || item2Permission == PermissionsEnum.Deny)
                        result = PermissionsEnum.Deny;

                if (result == PermissionsEnum.Undecided)
                    throw new Exception("Error in calculating OR list. Undecided result happened");

                this[key] = result;
            }

        }


        /// <summary>
        /// در تركيب ليست ها اولويت به دادن دسترسي است
        /// در اينجا ليست دومي كه وارد ميشود مهمتر است و دسترسي هاي آن اولويت خواهند داشت
        /// </summary>
        /// <param name="list"></param>
        public void OR_Force(ResourcePermissionList list)
        {
            if (list.Count != this.Count)
                throw new Exception("ResourcePermissionList.OR: ResourcePermissionList should have equal Counts");

            var resourceCodes = this.Keys.ToList();
            foreach (var key in resourceCodes)
            {
                var item1Permission = this[key];
                var item2Permission = list[key];
                PermissionsEnum result = PermissionsEnum.Undecided;

                if (item1Permission == PermissionsEnum.Undecided && item2Permission != PermissionsEnum.Undecided)
                    result = item2Permission;
                if (item2Permission == PermissionsEnum.Undecided && item1Permission != PermissionsEnum.Undecided)
                    result = item1Permission;

                if (result == PermissionsEnum.Undecided)
                    if (item2Permission == PermissionsEnum.AllowForce)
                        result = PermissionsEnum.AllowForce;

                if (result == PermissionsEnum.Undecided)
                    if (item2Permission == PermissionsEnum.DenyForce)
                        result = PermissionsEnum.DenyForce;

                if (result == PermissionsEnum.Undecided)
                    if (item2Permission == PermissionsEnum.Allow)
                        result = PermissionsEnum.Allow;

                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.Deny)
                        result = PermissionsEnum.Deny;

                if (result == PermissionsEnum.Undecided)
                    throw new Exception("Error in calculating OR list. Undecided result happened");

                this[key] = result;
            }

        }





        /// <summary>
        /// در تركيب ليست ها اولويت به دادن دسترسي است
        /// اين عملگرها قابل جايگذاري هستند يعني اينكه فرقي نميكند ليست اول با دومي اور شود يا ليست دوم با اولي
        /// </summary>
        /// <param name="list"></param>
        public void AND(ResourcePermissionList list)
        {
            if (list.Count != this.Count)
                throw new Exception("ResourcePermissionList.And: ResourcePermissionList should have equal Counts");

            var resourceCodes = this.Keys.ToList();
            foreach (var key in resourceCodes)
            {
                var item1Permission = this[key];
                var item2Permission = list[key];
                PermissionsEnum result = PermissionsEnum.Undecided;

                if (item1Permission == PermissionsEnum.Undecided && item2Permission != PermissionsEnum.Undecided)
                    result = item2Permission;
                if (item2Permission == PermissionsEnum.Undecided && item1Permission != PermissionsEnum.Undecided)
                    result = item1Permission;

                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.DenyForce || item2Permission == PermissionsEnum.DenyForce)
                        result = PermissionsEnum.DenyForce; 
                
                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.Deny || item2Permission == PermissionsEnum.Deny)
                        result = PermissionsEnum.Deny;

                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.AllowForce || item2Permission == PermissionsEnum.AllowForce)
                        result = PermissionsEnum.AllowForce;

                if (result == PermissionsEnum.Undecided)
                    if (item1Permission == PermissionsEnum.Allow || item2Permission == PermissionsEnum.Allow)
                        result = PermissionsEnum.Allow;

                if (item1Permission == PermissionsEnum.Undecided || item2Permission == PermissionsEnum.Undecided)
                    throw new Exception("Undecided Items can not be used in And-Or Functions.");

                if (result == PermissionsEnum.Undecided)
                    throw new Exception("Error in calculating AND list. Undecided result happened");

                this[key] = result;
            }

        }



    }



    //public class ResourcePermissionTree
    //{
    //    public ResourceNode Root { get; set; }
    //}

    //public class ResourceNode
    //{
    //    public Guid ResourceID { get; set; }
    //    public int AllowDeny { get; set; }
    //    public List<ResourceNode> Childs { get; set; }
    //    public ResourceNode Parent { get; set; }
    //}
}
