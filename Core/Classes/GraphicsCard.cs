// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : GraphicsCard.cs
// Author           : vonderborch
// Created          : 01-27-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="GraphicsCard.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the graphics card class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo.Classes
{
    /// <summary>
    /// Class GraphicsCard.
    /// </summary>
    public class GraphicsCard
    {
        #region Public Fields

        /// <summary>
        /// The current bits per pixel
        /// </summary>
        public int CurrentBitsPerPixel;
        /// <summary>
        /// The current horizontal resolution
        /// </summary>
        public int CurrentHorizontalResolution;
        /// <summary>
        /// The current number of colors
        /// </summary>
        public int CurrentNumberOfColors;
        /// <summary>
        /// The current refresh rate
        /// </summary>
        public int CurrentRefreshRate;
        /// <summary>
        /// The current scan mode
        /// </summary>
        public int CurrentScanMode;
        /// <summary>
        /// The current vertical resolution
        /// </summary>
        public int CurrentVerticalResolution;
        /// <summary>
        /// The dac type
        /// </summary>
        public string DacType;
        /// <summary>
        /// The device identifier
        /// </summary>
        public string DeviceId;
        /// <summary>
        /// The driver date
        /// </summary>
        public string DriverDate;
        /// <summary>
        /// The driver version
        /// </summary>
        public string DriverVersion;
        /// <summary>
        /// The manufacturer
        /// </summary>
        public string Manufacturer;
        /// <summary>
        /// The maximum refresh rate
        /// </summary>
        public int MaxRefreshRate;
        /// <summary>
        /// The memory bytes
        /// </summary>
        public long MemoryBytes;
        /// <summary>
        /// The memory g bytes
        /// </summary>
        public double MemoryGBytes;
        /// <summary>
        /// The memory m bytes
        /// </summary>
        public double MemoryMBytes;
        /// <summary>
        /// The minimum refresh rate
        /// </summary>
        public int MinRefreshRate;
        /// <summary>
        /// The name
        /// </summary>
        public string Name;
        /// <summary>
        /// The video architecture
        /// </summary>
        public int VideoArchitecture;
        /// <summary>
        /// The video memory type
        /// </summary>
        public int VideoMemoryType;

        #endregion Public Fields
    }
}