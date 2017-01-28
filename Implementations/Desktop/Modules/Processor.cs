// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : Processor.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-27-2017
// ***********************************************************************
// <copyright file="Processor.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the processor class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Helpers;
using System;

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

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Processor"/> class.
        /// </summary>
        public Processor()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the size of the cache.
        /// </summary>
        /// <value>The size of the cache.</value>
        public override int CacheSize
        {
            get { return Convertors.StringToInt(GetProcessorValue("L3CacheSize", "cache size"), -1); }
        }

        /// <summary>
        /// Gets the clock speed.
        /// </summary>
        /// <value>The clock speed.</value>
        public override double ClockSpeed
        {
            get { return Convertors.StringToDouble(GetProcessorValue("MaxClockSpeed", "cpu MHz"), 0); }
        }

        /// <summary>
        /// Gets the core count.
        /// </summary>
        /// <value>The core count.</value>
        public override int CoreCount
        {
            get { return Convertors.StringToInt(GetProcessorValue("NumberOfCores", "cpu cores"), LogicalCoreCount); }
        }

        /// <summary>
        /// Gets the family.
        /// </summary>
        /// <value>The family.</value>
        public override string Family
        {
            get
            {
                var output = GetProcessorValue("Caption", "cpu family");

                switch (MachineEnvironment.Environment.OS.PlatformId)
                {
                    // Should always break early...
                    case PclPlatformId.None:
                    case PclPlatformId.MaxOSX:
                    case PclPlatformId.Unix:
                    case PclPlatformId.Xbox:
                        break;
                    // Can use WMI system...
                    case PclPlatformId.Win32NT:
                    case PclPlatformId.Win32S:
                    case PclPlatformId.Win32Windows:
                    case PclPlatformId.WinCE:
                        var splitList = output.Split(' ');
                        for (int i = 0; i < splitList.Length; i++)
                        {
                            if (splitList[i] == "Family")
                            {
                                output = splitList[i + 1];
                                break;
                            }
                        }
                        break;
                }

                return output;
            }
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public override string Manufacturer
        {
            get { return GetProcessorValue("Manufacturer", "vendor_id"); }
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        public override string Model
        {
            get
            {
                var output = GetProcessorValue("Caption", "model");

                switch (MachineEnvironment.Environment.OS.PlatformId)
                {
                    // Should always break early...
                    case PclPlatformId.None:
                    case PclPlatformId.MaxOSX:
                    case PclPlatformId.Unix:
                    case PclPlatformId.Xbox:
                        break;
                    // Can use WMI system...
                    case PclPlatformId.Win32NT:
                    case PclPlatformId.Win32S:
                    case PclPlatformId.Win32Windows:
                    case PclPlatformId.WinCE:
                        var splitList = output.Split(' ');
                        for (int i = 0; i < splitList.Length; i++)
                        {
                            if (splitList[i] == "Model")
                            {
                                output = splitList[i + 1];
                                break;
                            }
                        }
                        break;
                }

                return output;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public override string Name
        {
            get { return GetProcessorValue("Name", "model name"); }
        }

        /// <summary>
        /// Gets the stepping.
        /// </summary>
        /// <value>The stepping.</value>
        public override string Stepping
        {
            get
            {
                var output = GetProcessorValue("Caption", "stepping");

                switch (MachineEnvironment.Environment.OS.PlatformId)
                {
                    // Should always break early...
                    case PclPlatformId.None:
                    case PclPlatformId.MaxOSX:
                    case PclPlatformId.Unix:
                    case PclPlatformId.Xbox:
                        break;
                    // Can use WMI system...
                    case PclPlatformId.Win32NT:
                    case PclPlatformId.Win32S:
                    case PclPlatformId.Win32Windows:
                    case PclPlatformId.WinCE:
                        var splitList = output.Split(' ');
                        for (int i = 0; i < splitList.Length; i++)
                        {
                            if (splitList[i] == "Stepping")
                            {
                                output = splitList[i + 1];
                                break;
                            }
                        }
                        break;
                }

                return output;
            }
        }

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Gets the processor value.
        /// </summary>
        /// <param name="windowsKey">The windows key.</param>
        /// <param name="unixKey">The unix key.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-01-2017) - Initial version.
        private string GetProcessorValue(string windowsKey = null, string unixKey = null)
        {
            string output = String.Empty;
            switch (MachineEnvironment.Environment.OS.PlatformId)
            {
                // Should always break early...
                case PclPlatformId.None:
                    break;
                // TODO : /proc/cpuinfo
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
                    if (windowsKey != null)
                    {
                        var result = WMI.GetWmiComponentKeyValue(WmiComponentName, windowsKey);
                        if (result.Key != null)
                            output = result.Value;
                    }
                    break;
            }

            return output;
        }

        #endregion Private Methods
    }
}