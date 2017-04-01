// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : NullMemory.cs
// Author           : vonderborch
// Created          : 01-30-2017
//
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 03-31-2017
// ***********************************************************************
// <copyright file="NullMemory.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the null memory class.
// </summary>
//
// Changelog:
//            - 1.0.0 (03-31-2017) - Added support for physical memory.
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Classes;
using System.Collections.Generic;
using System;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class NullMemory.
    /// </summary>
    /// <seealso cref="PclSystemInfo.Modules.AMemory" />
    public class NullMemory : AMemory
    {
        #region Public Properties

        /// <summary>
        /// Gets the available bytes.
        /// </summary>
        /// <value>The available bytes.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public override long AvailableBytes
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the total bytes.
        /// </summary>
        /// <value>The total bytes.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public override long TotalBytes
        {
            get { return 0; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the physical memory.
        /// </summary>
        /// <param name="deviceLocator">The device locator.</param>
        /// <returns>List&lt;PhysicalMemory&gt;.</returns>
        /// Changelog:
        ///             - 1.0.0 (03-31-2017) - Initial version.
        public override List<PhysicalMemory> GetPhysicalMemory(string deviceLocator = null)
        {
            return new List<PhysicalMemory>();
        }

        /// <summary>
        /// Gets the physical memory names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// Changelog:
        ///             - 1.0.0 (03-31-2017) - Initial version.
        public override List<string> GetPhysicalMemoryNames()
        {
            return new List<string>();
        }

        #endregion Public Methods
    }
}