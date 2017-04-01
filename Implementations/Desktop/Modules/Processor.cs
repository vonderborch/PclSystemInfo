// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : Processor.cs
// Author           : vonderborch
// Created          : 01-01-2017
//
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 03-31-2017
// ***********************************************************************
// <copyright file="Processor.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the processor class.
// </summary>
//
// Changelog:
//            - 1.0.0 (03-31-2017) - Added more support for processor caches.
//            - 1.0.0 (01-30-2017) - Revised how processor information is retrieved.
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Classes;
using PclSystemInfo.Helpers;
using System;
using System.Collections.Generic;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class Processor.
    /// </summary>
    /// <seealso cref="PclSystemInfo.Modules.AProcessor" />
    public class Processor : AProcessor
    {
        #region Private Fields

        /// <summary>
        /// The WMI component name
        /// </summary>
        private const string WmiComponentName = "Win32_Processor";

        /// <summary>
        /// The cache WMI component name
        /// </summary>
        private const string CacheWmiComponentName = "Win32_CacheMemory";

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Gets the processor names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public override List<string> GetProcessorNames()
        {
            var output = new List<string>();
            switch (MachineEnvironment.Environment.OS.PlatformId)
            {
                // Should always break early...
                case PclPlatformId.None:
                    break;
                // TODO : ?
                case PclPlatformId.MaxOSX:
                case PclPlatformId.Unix:
                    break;
                // TODO
                case PclPlatformId.Xbox:
                    break;
                // Can use WMI system...
                case PclPlatformId.Win32NT:
                case PclPlatformId.Win32S:
                case PclPlatformId.Win32Windows:
                case PclPlatformId.WinCE:
                    output = WMI.GetComponentDevices(WmiComponentName);
                    break;
            }

            return output;
        }

        /// <summary>
        /// Gets the processors.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>List&lt;CPU&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public override List<CPU> GetProcessors(string deviceId = null)
        {
            var finalOutput = new List<CPU>();
            var cacheList = new List<ProcessorCache>();
            var procs = new Dictionary<string, Dictionary<string, string>>();
            var caches = new Dictionary<string, Dictionary<string, string>>();
            switch (MachineEnvironment.Environment.OS.PlatformId)
            {
                // Should always break early...
                case PclPlatformId.None:
                    break;
                // TODO : ?
                case PclPlatformId.MaxOSX:
                case PclPlatformId.Unix:
                    procs = FileParser.ParseFile("\\proc\\cpuinfo", "processor", "CPU");
                    break;
                // TODO
                case PclPlatformId.Xbox:
                    break;
                // Can use WMI system...
                case PclPlatformId.Win32NT:
                case PclPlatformId.Win32S:
                case PclPlatformId.Win32Windows:
                case PclPlatformId.WinCE:
                    procs = WMI.GetAllWmiValuesForWmiComponent(WmiComponentName);
                    caches = WMI.GetAllWmiValuesForWmiComponent(CacheWmiComponentName);
                    break;
            }

            // parse cache info
            foreach (var cache in caches.Keys)
            {
                var cac = new ProcessorCache();

                var splitList = new string[0];
                foreach (var cacheValue in caches[cache])
                {
                    switch (cacheValue.Key)
                    {
                        // WMI Support
                        case "Associativity": cac.Associativity = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "Availability": cac.Availability = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "BlockSize": cac.BlockSize = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "CacheType": cac.CacheType = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "Caption": cac.Caption = cacheValue.Value; break;
                        case "CurrentSRAM": cac.CurrentSRAM = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "Description": cac.Description = cacheValue.Value; break;
                        case "DeviceID": cac.DeviceID = cacheValue.Value; break;
                        case "ErrorCorrectType": cac.ErrorCorrectType = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "InstalledSize": cac.InstalledSize = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "Level": cac.Level = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "Location": cac.Location = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "MaxCacheSize": cac.MaxCacheSize = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "Name": cac.Name = cacheValue.Value; break;
                        case "NumberOfBlocks": cac.NumberOfBlocks = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "Purpose": cac.Purpose = cacheValue.Value; break;
                        case "Status": cac.Status = cacheValue.Value; break;
                        case "StatusInfo": cac.StatusInfo = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "SupportedSRAM": cac.SupportedSRAM = Convertors.StringToInt(cacheValue.Value, -1); break;
                        case "WritePolicy": cac.WritePolicy = Convertors.StringToInt(cacheValue.Value, -1); break;

                        // UNIX Support
                    }
                }

                cacheList.Add(cac);
            }

            // parse proc info
            foreach (var proc in procs.Keys)
            {
                if (deviceId == proc || deviceId == null)
                {
                    var cpu = new CPU()
                    {
                        DeviceId = proc,
                        LogicalCoreCount = Environment.ProcessorCount
                    };

                    var splitList = new string[0];
                    foreach (var procValue in procs[proc])
                    {
                        switch (procValue.Key)
                        {
                            // WMI Support
                            //case "L3CacheSize": cpu.L3CacheSize = Convertors.StringToInt(procValue.Value, -1); break;
                            case "MaxClockSpeed": cpu.ClockSpeed = Convertors.StringToDouble(procValue.Value, -1); break;
                            case "NumberOfCores": cpu.CoreCount = Convertors.StringToInt(procValue.Value, cpu.LogicalCoreCount); break;
                            case "Caption":
                                splitList = procValue.Value.Split(' ');
                                for (int i = 0; i < splitList.Length; i++)
                                {
                                    switch (splitList[i])
                                    {
                                        case "Family": cpu.Family = splitList[i + 1]; break;
                                        case "Model": cpu.Model = splitList[i + 1]; break;
                                        case "Stepping": cpu.Stepping = splitList[i + 1]; break;
                                    }
                                }
                                break;

                            case "Manufacturer": cpu.Manufacturer = procValue.Value; break;
                            case "Name": cpu.Name = procValue.Value; break;

                            // UNIX Support
                        }

                        cpu.Cache = new List<ProcessorCache>();
                        cpu.L1CacheSize = 0;
                        cpu.L2CacheSize = 0;
                        cpu.L3CacheSize = 0;
                        for (var i = 0; i < cacheList.Count; i++)
                        {
                            if ($"CPU{cacheList[i].Location}" == cpu.DeviceId)
                            {
                                switch (cacheList[i].Purpose)
                                {
                                    case "L1 Cache": cpu.L1CacheSize += cacheList[i].InstalledSize; break;
                                    case "L2 Cache": cpu.L2CacheSize += cacheList[i].InstalledSize; break;
                                    case "L3 Cache": cpu.L3CacheSize += cacheList[i].InstalledSize; break;
                                }

                                cpu.Cache.Add(cacheList[i]);
                            }
                        }
                    }

                    finalOutput.Add(cpu);
                }
            }

            return finalOutput;
        }

        #endregion Public Methods
    }
}