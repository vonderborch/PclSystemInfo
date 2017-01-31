// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : CPU.cs
// Author           : vonderborch
// Created          : 01-30-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="CPU.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the CPU class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo.Classes
{
    /// <summary>
    /// Class CPU.
    /// </summary>
    public class CPU
    {
        #region Public Fields

        /// <summary>
        /// The cache size
        /// </summary>
        public int CacheSize;
        /// <summary>
        /// The clock speed
        /// </summary>
        public double ClockSpeed;
        /// <summary>
        /// The core count
        /// </summary>
        public int CoreCount;
        /// <summary>
        /// The device identifier
        /// </summary>
        public string DeviceId;
        /// <summary>
        /// The family
        /// </summary>
        public string Family;
        /// <summary>
        /// The logical core count
        /// </summary>
        public int LogicalCoreCount;
        /// <summary>
        /// The manufacturer
        /// </summary>
        public string Manufacturer;
        /// <summary>
        /// The model
        /// </summary>
        public string Model;
        /// <summary>
        /// The name
        /// </summary>
        public string Name;
        /// <summary>
        /// The stepping
        /// </summary>
        public string Stepping;

        #endregion Public Fields
    }
}