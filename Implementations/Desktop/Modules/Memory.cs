// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : Memory.cs
// Author           : vonderborch
// Created          : 01-30-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 03-31-2017
// ***********************************************************************
// <copyright file="Memory.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the implemented memory class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (03-31-2017) - Added support for physical memory.
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Helpers;
using System.Diagnostics;
using PclSystemInfo.Classes;
using System.Collections.Generic;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class Memory.
    /// </summary>
    /// <seealso cref="PclSystemInfo.Modules.AMemory" />
    public class Memory : AMemory
    {
        #region Private Fields

        /// <summary>
        /// The WMI component name
        /// </summary>
        private const string WmiComponentName = "Win32_ComputerSystem";

        /// <summary>
        /// The physical memory WMI component name
        /// </summary>
        private const string PhysicalMemoryWmiComponentName = "Win32_PhysicalMemory";

        /// <summary>
        /// The available bytes
        /// </summary>
        private PerformanceCounter availableBytes;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Memory"/> class.
        /// </summary>
        public Memory()
        {
            availableBytes = new PerformanceCounter()
            {
                CategoryName = "Memory",
                CounterName = "Available Bytes"
            };
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the available bytes.
        /// </summary>
        /// <value>The available bytes.</value>
        public override long AvailableBytes
        {
            get
            {
                availableBytes.NextSample();
                return availableBytes.RawValue;
            }
        }

        /// <summary>
        /// Gets the total bytes.
        /// </summary>
        /// <value>The total bytes.</value>
        public override long TotalBytes
        {
            get
            {
                switch (MachineEnvironment.Environment.OS.PlatformId)
                {
                    // Can use WMI system...
                    case PclPlatformId.Win32NT:
                    case PclPlatformId.Win32S:
                    case PclPlatformId.Win32Windows:
                    case PclPlatformId.WinCE:
                        return Convertors.StringToLong(WMI.GetWmiComponentKeyValue(WmiComponentName, "TotalPhysicalMemory").Value, 0);
                    // TODO : /proc/cpuinfo
                    case PclPlatformId.MaxOSX:
                    case PclPlatformId.Unix:
                    // TODO
                    case PclPlatformId.Xbox:
                    // Should always break early...
                    case PclPlatformId.None:
                    default:
                        return 0;
                }
            }
        }

        #endregion Public Properties

        #region Public Functions

        /// <summary>
        /// Gets the physical memory.
        /// </summary>
        /// <param name="deviceTag">The device tag.</param>
        /// <returns>List&lt;PhysicalMemory&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// Changelog:
        ///             - 1.0.0 (03-31-2017) - Initial version.
        public override List<PhysicalMemory> GetPhysicalMemory(string deviceTag = null)
        {
            var finalOutput = new List<PhysicalMemory>();
            var memDimms = new Dictionary<string, Dictionary<string, string>>();
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
                    memDimms = WMI.GetAllWmiValuesForWmiComponent(PhysicalMemoryWmiComponentName);
                    break;
            }

            var totalCacheSpeed = 0;

            foreach (var memDimm in memDimms.Keys)
            {
                if (deviceTag == memDimm || deviceTag == null)
                {
                    var mem = new PhysicalMemory() { Tag = memDimm };

                    foreach (var memDimmValue in memDimms[memDimm])
                    {
                        switch (memDimmValue.Key)
                        {
                            // WMI Support
                            case "Attributes": mem.Attributes = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "BankLabel": mem.BankLabel = memDimmValue.Value; break;
                            case "Capacity": mem.Capacity = Convertors.StringToLong(memDimmValue.Value, -1); break;
                            case "Caption": mem.Caption = memDimmValue.Value; break;
                            case "ConfiguredClockSpeed": mem.ConfiguredClockSpeed = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "ConfiguredVoltage": mem.ConfiguredVoltage = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "DataWidth": mem.DataWidth = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "Description": mem.Description = memDimmValue.Value; break;
                            case "DeviceLocator": mem.DeviceLocator = memDimmValue.Value; break;
                            case "FormFactor": mem.FormFactor = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "InterleaveDataDepth": mem.InterleaveDataDepth = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "InterleavePosition": mem.InterleavePosition = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "Manufacturer": mem.Manufacturer = memDimmValue.Value; break;
                            case "MaxVoltage": mem.MaxVoltage = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "MemoryType": mem.MemoryType = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "MinVoltage": mem.MinVoltage = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "PartNumber": mem.PartNumber = memDimmValue.Value; break;
                            case "PositionInRow": mem.PositionInRow = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "SerialNumber": mem.SerialNumber = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "SMBIOSMemoryType": mem.SMBiosMemoryType = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "Speed":
                                mem.Speed = Convertors.StringToInt(memDimmValue.Value, -1);
                                totalCacheSpeed += mem.Speed;
                                break;
                            case "Tag": mem.Tag = memDimmValue.Value; break;
                            case "TotalWidth": mem.TotalWidth = Convertors.StringToInt(memDimmValue.Value, -1); break;
                            case "TypeDetail": mem.TypeDetail = Convertors.StringToInt(memDimmValue.Value, -1); break;

                            // UNIX Support
                        }
                    }

                    finalOutput.Add(mem);
                }
            }

            AverageMemoryClockSpeed = totalCacheSpeed / memDimms.Count;

            return finalOutput;
        }

        /// <summary>
        /// Gets the physical memory names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// Changelog:
        ///             - 1.0.0 (03-31-2017) - Initial version.
        public override List<string> GetPhysicalMemoryNames()
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
                    output = WMI.GetComponentDevices(PhysicalMemoryWmiComponentName);
                    break;
            }

            return output;
        }

        #endregion Public Functions
    }
}