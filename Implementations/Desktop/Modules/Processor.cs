// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : Processor.cs
// Author           : vonderborch
// Created          : 01-01-2017
//
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="Processor.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the processor class.
// </summary>
//
// Changelog:
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
            var procs = new Dictionary<string, Dictionary<string, string>>();
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
                    break;
            }

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
                            case "L3CacheSize": cpu.CacheSize = Convertors.StringToInt(procValue.Value, -1); break;
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
                    }

                    finalOutput.Add(cpu);
                }
            }

            return finalOutput;
        }

        #endregion Public Methods
    }
}