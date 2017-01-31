// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : AProcessor.cs
// Author           : vonderborch
// Created          : 01-01-2017
//
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="AProcessor.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the abstract processor class.
// </summary>
//
// Changelog:
//            - 1.0.0 (01-30-2017) - Revised how processor information is retrieved.
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Classes;
using System.Collections.Generic;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class AProcessor.
    /// </summary>
    public abstract class AProcessor
    {
        #region Public Methods

        /// <summary>
        /// Gets the processor names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public abstract List<string> GetProcessorNames();

        /// <summary>
        /// Gets the processors.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>List&lt;CPU&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public abstract List<CPU> GetProcessors(string deviceId = null);

        #endregion Public Methods
    }
}