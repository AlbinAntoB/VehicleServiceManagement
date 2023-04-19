using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Collections;
using System.Reflection;

namespace VehicleSeviceManagement.Framework.Helper
{

    public class DataMapper
    {
        public static T XmlReaderToObject<T>(XmlReader xr)
        {
            T result;
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            result = (T)serializer.Deserialize(xr);

            return result;
        }

        public static T XmlStringToObject<T>(string xml)
        {
            T result;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)serializer.Deserialize(tr);
            }
            return result;
        }

        public static List<T> DataReaderToList<T>(IDataReader dr) where T : new()
        {
            Type businessEntityType = typeof(T);
            List<T> entitys = new List<T>();
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] properties = businessEntityType.GetProperties();

            foreach (PropertyInfo info in properties)
            {
                hashtable[info.Name.ToUpper()] = info;
            }

            while (dr.Read())
            {
                T newObject = new T();
                for (int index = 0; index < dr.FieldCount; index++)
                {
                    PropertyInfo info = (PropertyInfo)hashtable[dr.GetName(index).ToUpper()];
                    if ((info != null) && info.CanWrite)
                    {
                        info.SetValue(newObject, dr.GetValue(index), null);
                    }
                }
                entitys.Add(newObject);
            }
            dr.Close();
            return entitys;
        }

        public static List<T> XmlReaderToList<T>(XmlReader xr, string root = "")
        {
            if (root == "")
            { root = typeof(T).Name + "s"; }

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(root));

            List<T> result = (List<T>)serializer.Deserialize(xr);
            if (result == null)
            { result = new List<T>(); }

            return result;
        }

    }
}
