using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PclSystemInfo
{
    public static class WMI
    {
        public static object LoadComponent(string key)
        {
            var managementAsm = LoadSystemManagement();

            var infoSearcherType = managementAsm.GetType("System.Management.ManagementObjectSearcher");

            return Activator.CreateInstance(infoSearcherType, new string[] { $@"\\{Environment.MachineName}\root\CIMV2",  $"select * from {key}" });
        }

        public static Dictionary<string, string> GetAllWmiValuesForWmiComponent(string component)
        {
            var searcher = WMI.LoadComponent(component);
            var searcherMethod = searcher.GetType().GetMethod("Get", new Type[0]);
            var getMethod = searcherMethod.Invoke(searcher, null);

            var output = new Dictionary<string, string>();

            foreach (var child in (IEnumerable)getMethod)
            {
                var propertiesProperty = child.GetType().GetProperty("Properties");

                var properties = propertiesProperty.GetValue(child);

                foreach (var property in (IEnumerable)properties)
                {
                    var propertyNameProperty = property.GetType().GetProperty("Name");
                    var propertyValueProperty = property.GetType().GetProperty("Value");

                    var propertyName = propertyNameProperty.GetValue(property);
                    var propertyValue = propertyValueProperty.GetValue(property);

                    output.Add(propertyName.ToString(), propertyValue == null ? null : propertyValue.ToString());
                }
            }

            return output;
        }

        public static KeyValuePair<string, string> GetWmiComponentKeyValue(string component, string key)
        {
            var searcher = WMI.LoadComponent(component);
            var searcherMethod = searcher.GetType().GetMethod("Get", new Type[0]);
            var getMethod = searcherMethod.Invoke(searcher, null);

            var output = new KeyValuePair<string, string>();

            foreach (var child in (IEnumerable)getMethod)
            {
                var propertiesProperty = child.GetType().GetProperty("Properties");

                var properties = propertiesProperty.GetValue(child);

                foreach (var property in (IEnumerable)properties)
                {
                    var propertyNameProperty = property.GetType().GetProperty("Name");
                    var propertyValueProperty = property.GetType().GetProperty("Value");

                    var propertyName = propertyNameProperty.GetValue(property);
                    var propertyValue = propertyValueProperty.GetValue(property);

                    if (propertyName.ToString() == key)
                    {
                        output = new KeyValuePair<string, string>(propertyName.ToString(), propertyValue == null ? null : propertyValue.ToString());
                        break;
                    }
                }
            }

            return output;
        }

        public static Assembly LoadSystemManagement()
        {
            return Assembly.LoadWithPartialName("System.Management");
        }
    }
}
