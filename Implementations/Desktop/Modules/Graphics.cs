// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : Graphics.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="Graphics.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the desktop implemented graphics class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Classes;
using PclSystemInfo.Helpers;
using System.Collections.Generic;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class Graphics.
    /// </summary>
    /// <seealso cref="PclSystemInfo.Modules.AGraphics" />
    public class Graphics : AGraphics
    {
        #region Private Fields

        /// <summary>
        /// The WMI component name
        /// </summary>
        private const string WmiComponentName = "Win32_VideoController";

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Gets the graphic card names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public override List<string> GetGraphicCardNames()
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
        /// Gets the graphic cards.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>List&lt;GraphicsCard&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public override List<GraphicsCard> GetGraphicCards(string deviceId = null)
        {
            var finalOutput = new List<GraphicsCard>();
            var gcards = new Dictionary<string, Dictionary<string, string>>();
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
                    gcards = WMI.GetAllWmiValuesForWmiComponent(WmiComponentName);
                    break;
            }

            foreach (var gcard in gcards.Keys)
            {
                if (deviceId == gcard || deviceId == null)
                {
                    var gpu = new GraphicsCard() { DeviceId = gcard };

                    foreach (var gcardValue in gcards[gcard])
                    {
                        switch (gcardValue.Key)
                        {
                            // WMI Support
                            case "AdapterCompatibility": gpu.Manufacturer = gcardValue.Value; break;
                            case "AdapterDACType": gpu.DacType = gcardValue.Value; break;
                            case "AdapterRAM":
                                gpu.MemoryBytes = Convertors.StringToInt(gcardValue.Value, -1);
                                gpu.MemoryMBytes = gpu.MemoryBytes / 1000000;
                                gpu.MemoryGBytes = gpu.MemoryBytes / 1000f;
                                break;

                            case "Name": gpu.Name = gcardValue.Value; break;
                            case "CurrentBitsPerPixel": gpu.CurrentBitsPerPixel = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "CurrentHorizontalResolution": gpu.CurrentHorizontalResolution = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "CurrentNumberOfColors": gpu.CurrentNumberOfColors = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "CurrentRefreshRate": gpu.CurrentRefreshRate = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "CurrentScanMode": gpu.CurrentScanMode = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "CurrentVerticalResolution": gpu.CurrentVerticalResolution = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "DriverDate": gpu.DriverDate = gcardValue.Value; break;
                            case "DriverVersion": gpu.DriverVersion = gcardValue.Value; break;
                            case "MaxRefreshRate": gpu.MaxRefreshRate = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "MinRefreshRate": gpu.MinRefreshRate = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "VideoArchitecture": gpu.VideoArchitecture = Convertors.StringToInt(gcardValue.Value, -1); break;
                            case "VideoMemoryType": gpu.VideoMemoryType = Convertors.StringToInt(gcardValue.Value, -1); break;

                                // UNIX Support
                        }
                    }

                    finalOutput.Add(gpu);
                }
            }

            return finalOutput;
        }

        #endregion Public Methods
    }
}