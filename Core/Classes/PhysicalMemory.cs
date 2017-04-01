// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : PhysicalMemory.cs
// Author           : ricky
// Created          : 03-31-2017
// 
// Version          : 1.0.0
// Last Modified By : ricky
// Last Modified On : 03-31-2017
// ***********************************************************************
// <copyright file="PhysicalMemory.cs" company="">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the physical memory class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (03-31-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo.Classes
{
    /// <summary>
    /// Class PhysicalMemory.
    /// </summary>
    public class PhysicalMemory
    {
        #region Public Fields

        /// <summary>
        /// The attributes
        /// </summary>
        public int Attributes;

        /// <summary>
        /// The bank label
        /// </summary>
        public string BankLabel;

        /// <summary>
        /// The capacity
        /// </summary>
        public long Capacity;

        /// <summary>
        /// The caption
        /// </summary>
        public string Caption;

        /// <summary>
        /// The configured clock speed
        /// </summary>
        public int ConfiguredClockSpeed;

        /// <summary>
        /// The configured voltage
        /// </summary>
        public int ConfiguredVoltage;

        /// <summary>
        /// The data width
        /// </summary>
        public int DataWidth;

        /// <summary>
        /// The description
        /// </summary>
        public string Description;

        /// <summary>
        /// The device locator
        /// </summary>
        public string DeviceLocator;

        /// <summary>
        /// The form factor
        /// </summary>
        public int FormFactor;

        /// <summary>
        /// The interleave data depth
        /// </summary>
        public int InterleaveDataDepth;

        /// <summary>
        /// The interleave position
        /// </summary>
        public int InterleavePosition;

        /// <summary>
        /// The manufacturer
        /// </summary>
        public string Manufacturer;

        /// <summary>
        /// The maximum voltage
        /// </summary>
        public int MaxVoltage;

        /// <summary>
        /// The memory type
        /// </summary>
        public int MemoryType;

        /// <summary>
        /// The minimum voltage
        /// </summary>
        public int MinVoltage;

        /// <summary>
        /// The part number
        /// </summary>
        public string PartNumber;

        /// <summary>
        /// The position in row
        /// </summary>
        public int PositionInRow;

        /// <summary>
        /// The serial number
        /// </summary>
        public int SerialNumber;

        /// <summary>
        /// The sm bios memory type
        /// </summary>
        public int SMBiosMemoryType;

        /// <summary>
        /// The speed
        /// </summary>
        public int Speed;

        /// <summary>
        /// The tag
        /// </summary>
        public string Tag;

        /// <summary>
        /// The total width
        /// </summary>
        public int TotalWidth;

        /// <summary>
        /// The type detail
        /// </summary>
        public int TypeDetail;

        #endregion Public Fields
    }
}