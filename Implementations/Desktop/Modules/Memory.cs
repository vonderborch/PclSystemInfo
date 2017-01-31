// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : Memory.cs
// Author           : vonderborch
// Created          : 01-30-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="Memory.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the implemented memory class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Helpers;
using System.Diagnostics;

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
                CategoryName = "",
                CounterName = ""
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
    }
}