// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : CPU.cs
// Author           : vonderborch
// Created          : 01-30-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 03-31-2017
// ***********************************************************************
// <copyright file="CPU.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the CPU class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (03-31-2017) - Added more support for processor caches.
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
using System.Collections.Generic;

namespace PclSystemInfo.Classes
{
    /// <summary>
    /// Class CPU.
    /// </summary>
    public class CPU
    {
        #region Public Fields

        /// <summary>
        /// The memory caches for the processor
        /// </summary>
        public List<ProcessorCache> Cache;

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
        /// The l1 cache size
        /// </summary>
        public int L1CacheSize;

        /// <summary>
        /// The l2 cache size
        /// </summary>
        public int L2CacheSize;

        /// <summary>
        /// The l3 cache size
        /// </summary>
        public int L3CacheSize;

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