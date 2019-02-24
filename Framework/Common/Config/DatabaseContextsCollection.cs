using System.Configuration;

namespace Framework.Common.Config
{

    [ConfigurationCollection(typeof(DatabaseContextConfigElement))]
    public sealed class DatabaseContextsCollection : ConfigurationElementCollection
    {
        public DatabaseContextsCollection()
        {
            DatabaseContextConfigElement sessionFactory = (DatabaseContextConfigElement)CreateNewElement();
            Add(sessionFactory);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DatabaseContextConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DatabaseContextConfigElement)element).Name;
        }

        public DatabaseContextConfigElement this[int index]
        {
            get
            {
                return (DatabaseContextConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }

        new public DatabaseContextConfigElement this[string name]
        {
            get
            {
                return (DatabaseContextConfigElement)BaseGet(name);
            }
        }

        public int IndexOf(DatabaseContextConfigElement sessionFactory)
        {
            return BaseIndexOf(sessionFactory);
        }

        public void Add(DatabaseContextConfigElement sessionFactory)
        {
            BaseAdd(sessionFactory);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(DatabaseContextConfigElement sessionFactory)
        {
            if (BaseIndexOf(sessionFactory) >= 0)
            {
                BaseRemove(sessionFactory.Name);
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}
