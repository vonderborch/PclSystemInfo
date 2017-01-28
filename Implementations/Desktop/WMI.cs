// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : WMI.cs
// Author           : vonderborch
// Created          : 01-23-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-27-2017
// ***********************************************************************
// <copyright file="WMI.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines methods to access WMI information, using reflection for compatibility.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-23-2017) - Initial version created.
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace PclSystemInfo
{
    /// <summary>
    /// Class WMI.
    /// </summary>
    public static class WMI
    {
        #region Public Methods

        /// <summary>
        /// Gets all WMI values for WMI component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-23-2017) - Initial version.
        public static Dictionary<string, Dictionary<string, string>> GetAllWmiValuesForWmiComponent(string component)
        {
            var searcher = WMI.LoadComponent(component);
            var searcherMethod = searcher.GetType().GetMethod("Get", new Type[0]);
            var getMethod = searcherMethod.Invoke(searcher, null);

            var finalOutput = new Dictionary<string, Dictionary<string, string>>();

            PropertyInfo propertiesProperty = null;
            PropertyInfo pathProperty = null;
            foreach (var child in (IEnumerable)getMethod)
            {
                if (propertiesProperty == null) propertiesProperty = child.GetType().GetProperty("Properties");
                if (pathProperty == null) pathProperty = child.GetType().GetProperty("Path");

                var output = new Dictionary<string, string>();
                var properties = (IEnumerable)propertiesProperty.GetValue(child);
                var path = pathProperty.GetValue(child).ToString();
                
                var deviceId = String.Empty;
                var splitPath = path.Split('=');
                if (splitPath.Length == 2)
                    deviceId = splitPath[1].Replace("\"", "");

                PropertyInfo propertyNameProperty = null;
                PropertyInfo propertyValueProperty = null;
                foreach (var property in properties)
                {
                    if (propertyNameProperty == null) propertyNameProperty = property.GetType().GetProperty("Name");
                    if (propertyValueProperty == null) propertyValueProperty = property.GetType().GetProperty("Value");

                    var propertyName = propertyNameProperty.GetValue(property);
                    var propertyValue = propertyValueProperty.GetValue(property);

                    output.Add(propertyName.ToString(), propertyValue == null ? null : propertyValue.ToString());
                }

                finalOutput.Add(deviceId, output);
            }

            return finalOutput;
        }

        /// <summary>
        /// Gets the component devices.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-23-2017) - Initial version.
        public static List<string> GetComponentDevices(string component)
        {
            var searcher = WMI.LoadComponent(component);
            var searcherMethod = searcher.GetType().GetMethod("Get", new Type[0]);
            var getMethod = searcherMethod.Invoke(searcher, null);

            var output = new List<string>();
            
            PropertyInfo pathProperty = null;
            foreach (var child in (IEnumerable)getMethod)
            {
                if (pathProperty == null) pathProperty = child.GetType().GetProperty("Path");
                
                var path = pathProperty.GetValue(child).ToString();

                var deviceId = String.Empty;
                var splitPath = path.Split('=');
                if (splitPath.Length == 2)
                    deviceId = splitPath[1].Replace("\"", "");

                output.Add(deviceId);
            }

            return output;
        }

        /// <summary>
        /// Gets the WMI component key value.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="key">The key.</param>
        /// <param name="deviceId">The device ID.</param>
        /// <returns>KeyValuePair&lt;System.String, System.String&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-23-2017) - Initial version.
        public static KeyValuePair<string, string> GetWmiComponentKeyValue(string component, string key, string deviceId = null)
        {
            var searcher = WMI.LoadComponent(component);
            var searcherMethod = searcher.GetType().GetMethod("Get", new Type[0]);
            var getMethod = searcherMethod.Invoke(searcher, null);

            var output = new KeyValuePair<string, string>();

            PropertyInfo propertiesProperty = null;
            PropertyInfo pathProperty = null;
            foreach (var child in (IEnumerable)getMethod)
            {
                if (propertiesProperty == null) propertiesProperty = child.GetType().GetProperty("Properties");
                if (pathProperty == null) pathProperty = child.GetType().GetProperty("Path");

                var properties = (IEnumerable)propertiesProperty.GetValue(child);
                var path = pathProperty.GetValue(child).ToString();

                var device = String.Empty;
                var splitPath = path.Split('=');
                if (splitPath.Length == 2)
                    device = splitPath[1].Replace("\"", "");

                if (deviceId != null && device != deviceId)
                    continue;

                PropertyInfo propertyNameProperty = null;
                PropertyInfo propertyValueProperty = null;
                foreach (var property in properties)
                {
                    if (propertyNameProperty == null) propertyNameProperty = property.GetType().GetProperty("Name");
                    if (propertyValueProperty == null) propertyValueProperty = property.GetType().GetProperty("Value");

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

        /// <summary>
        /// Loads the component.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-23-2017) - Initial version.
        public static object LoadComponent(string key)
        {
            var managementAsm = LoadSystemManagement();

            var infoSearcherType = managementAsm.GetType("System.Management.ManagementObjectSearcher");

            return Activator.CreateInstance(infoSearcherType, new string[] { $@"\\{Environment.MachineName}\root\CIMV2", $"select * from {key}" });
        }

        /// <summary>
        /// Loads the system management.
        /// </summary>
        /// <returns>Assembly.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-23-2017) - Initial version.
        public static Assembly LoadSystemManagement()
        {
            return Assembly.LoadWithPartialName("System.Management");
        }

        #endregion Public Methods
    }
}