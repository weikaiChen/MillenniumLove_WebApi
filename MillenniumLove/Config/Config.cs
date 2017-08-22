using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Linq;
using System;

namespace MillenniumLove
{
    public class Config : ConfigurationSection
    {

        public class Application
        {
            private const string _SectionName = "MillenniumLovely";
            public static string Get(string group, string name,string defValue)
            {

                string val = defValue;

                TryGet(group, name,ref val);
              
                return val;
            }

            public static bool TryGet(string group, string name,ref string val)
            {
                var result = false; 
                try
                {
                    ApplicationSection mySection = (ApplicationSection)ConfigurationManager.GetSection(_SectionName);
                    var item = mySection.ApplicationElementCollection[group, name];
                    if (item != null)
                    {
                        val = item.Value;
                    }
                }
                catch (Exception ex)
                {
                    LogRecord.Create("Config.TryGet")
                       .SetMessage(ex.Message)
                       .Error()
                   ;

                }

                return result;
            }
        }
    }
    public class ApplicationSection : ConfigurationSection
    {
        [ConfigurationProperty("Application", IsDefaultCollection = false),
           ConfigurationCollection(typeof(ApplicationElementCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
        public ApplicationElementCollection ApplicationElementCollection
        {
            get { return this["Application"] as ApplicationElementCollection; }
        }
    }

    public class ApplicationElement : ConfigurationElement
    {
        [ConfigurationProperty("group")]
        public string Group { get { return this["group"].ToString(); } }
        [ConfigurationProperty("name")]
        public string Name { get { return this["name"].ToString(); } }

        [ConfigurationProperty("value")]
        public string Value { get { return this["value"].ToString(); } }
    }

    [ConfigurationCollection(typeof(ApplicationElement))]
    public class ApplicationElementCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public ApplicationElement this[int index]
        {
            get { return (ApplicationElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public ApplicationElement this[string group, string name]
        {
            get
            {
                return this.OfType<ApplicationElement>().FirstOrDefault(item => item.Group == group && item.Name == name);
            }
        }

        public new List<ApplicationElement> this[string Group]
        {
            get
            {
                return this.OfType<ApplicationElement>().Where(x => x.Group == Group).ToList();
            }
        }

        public void Add(ApplicationElement element) { BaseAdd(element); }

        public void Remove(string name) { BaseRemove(name); }

        public void RemoveAt(int index) { BaseRemoveAt(index); }

        public void Clear() { BaseClear(); }

        protected override ConfigurationElement CreateNewElement() { return new ApplicationElement(); }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var ele = (ApplicationElement)element;
            var group = ele.Group;
            var name = ele.Name;
            return group + name;
        }

    }
}


