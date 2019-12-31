using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace tp.Prototype
{
    static class PrototypeExtensionMethods
    {
        public static T DeepCopyByBinaryFormatter<T>(this T sourceObj)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Class must be marked [Serializable]!");
            }
            if (Object.ReferenceEquals(sourceObj, null))
            {
                return default(T);
            }
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, sourceObj);
                ms.Position = 0;
                object copy = bf.Deserialize(ms);
                return (T)copy;
            }
        }

        public static T DeepCopyByXmlSerializer<T>(this T sourceObj)
        {
            if (!typeof(T).IsPublic)
            {
                throw new ArgumentException("Class must be with 'public' access level!");
            }
            if (Object.ReferenceEquals(sourceObj, null))
            {
                return default(T);
            }
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, sourceObj);
                ms.Position = 0;
                object copy = s.Deserialize(ms);
                return (T)copy;
            }
        }

        public static T DeepCopyByJsonSerializer<T>(this T sourceObj)
        {
            if (Object.ReferenceEquals(sourceObj, null))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(sourceObj));
        }
    }

    [Serializable] //required by BinaryFormatter
    public //required by XmlSerializer
    class EmployeeSerialization
    {
        public string Name;
        public DepartmentSerialization Department;

        //required by XmlSerializer
        public EmployeeSerialization()
        {
        }

        public EmployeeSerialization(string name, DepartmentSerialization department)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public override string ToString() =>
            $"{nameof(Name)}: {Name}; {nameof(Department)}: {Department.ToString()}";
    }

    [Serializable] //required by BinaryFormatter
    public //required by XmlSerializer
    class DepartmentSerialization
    {
        public string Name;
        public DepartmentSerialization Parent;

        //required by XmlSerializer
        public DepartmentSerialization()
        {
        }

        public DepartmentSerialization(string name, DepartmentSerialization parent)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parent = parent;
        }

        public override string ToString() =>
            string.Format("{0}: {1}; {2}: {3}", nameof(Name), Name, nameof(Parent), Parent!.Name ?? "null");
    }
}
