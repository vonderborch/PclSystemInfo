// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : ProcessorCache.cs
// Author           : ricky
// Created          : 03-31-2017
// 
// Version          : 1.0.0
// Last Modified By : ricky
// Last Modified On : 03-31-2017
// ***********************************************************************
// <copyright file="ProcessorCache.cs" company="">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the processor cache class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (03-31-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo.Classes
{
    /// <summary>
    /// Class ProcessorCache.
    /// </summary>
    public struct ProcessorCache
    {
        #region Public Fields

        /// <summary>
        /// The associativity
        /// </summary>
        public int Associativity;

        /// <summary>
        /// The availability
        /// </summary>
        public int Availability;

        /// <summary>
        /// The block size
        /// </summary>
        public int BlockSize;

        /// <summary>
        /// The cache type
        /// </summary>
        public int CacheType;

        /// <summary>
        /// The caption
        /// </summary>
        public string Caption;

        /// <summary>
        /// The current sram
        /// </summary>
        public int CurrentSRAM;

        /// <summary>
        /// The description
        /// </summary>
        public string Description;

        /// <summary>
        /// The device identifier
        /// </summary>
        public string DeviceID;

        /// <summary>
        /// The error correct type
        /// </summary>
        public int ErrorCorrectType;

        /// <summary>
        /// The installed size
        /// </summary>
        public int InstalledSize;

        /// <summary>
        /// The level
        /// </summary>
        public int Level;

        /// <summary>
        /// The location
        /// </summary>
        public int Location;

        /// <summary>
        /// The maximum cache size
        /// </summary>
        public int MaxCacheSize;

        /// <summary>
        /// The name
        /// </summary>
        public string Name;

        /// <summary>
        /// The number of blocks
        /// </summary>
        public int NumberOfBlocks;

        /// <summary>
        /// The purpose
        /// </summary>
        public string Purpose;

        /// <summary>
        /// The status
        /// </summary>
        public string Status;

        /// <summary>
        /// The status information
        /// </summary>
        public int StatusInfo;

        /// <summary>
        /// The supported sram
        /// </summary>
        public int SupportedSRAM;

        /// <summary>
        /// The write policy
        /// </summary>
        public int WritePolicy;

        #endregion Public Fields

        #region Public Properties

        /// <summary>
        /// Gets the installed size m bytes.
        /// </summary>
        /// <value>The installed size m bytes.</value>
        public double InstalledSizeMBytes
        {
            get { return InstalledSize / (double)1024; }
        }

        #endregion Public Properties
    }
}