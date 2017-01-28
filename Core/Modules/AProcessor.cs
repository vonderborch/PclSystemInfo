// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : AProcessor.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-27-2017
// ***********************************************************************
// <copyright file="AProcessor.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the abstract processor class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
using System;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class AProcessor.
    /// </summary>
    public abstract class AProcessor
    {
        #region Public Properties

        /// <summary>
        /// Gets the size of the cache.
        /// </summary>
        /// <value>The size of the cache.</value>
        public abstract int CacheSize { get; }

        /// <summary>
        /// Gets the clock speed.
        /// </summary>
        /// <value>The clock speed.</value>
        public abstract double ClockSpeed { get; }

        /// <summary>
        /// Gets the core count.
        /// </summary>
        /// <value>The core count.</value>
        public abstract int CoreCount { get; }

        /// <summary>
        /// Gets the family.
        /// </summary>
        /// <value>The family.</value>
        public abstract string Family { get; }

        /// <summary>
        /// Gets the logical core count.
        /// </summary>
        /// <value>The logical core count.</value>
        public int LogicalCoreCount
        {
            get { return Environment.ProcessorCount; }
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public abstract string Manufacturer { get; }
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        public abstract string Model { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; }
        /// <summary>
        /// Gets the stepping.
        /// </summary>
        /// <value>The stepping.</value>
        public abstract string Stepping { get; }

        #endregion Public Properties
    }
}