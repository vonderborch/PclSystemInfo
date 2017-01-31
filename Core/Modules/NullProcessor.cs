// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : NullProcessor.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="NullProcessor.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the null processor class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Classes;
using System.Collections.Generic;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class NullProcessor.
    /// </summary>
    /// <seealso cref="PclSystemInfo.Modules.AGraphics" />
    public class NullProcessor : AProcessor
    {
        #region Public Methods

        /// <summary>
        /// Gets the processor names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public override List<string> GetProcessorNames()
        {
            return new List<string>();
        }

        /// <summary>
        /// Gets the processors.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>List&lt;GraphicsCard&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public override List<CPU> GetProcessors(string deviceId = null)
        {
            return new List<CPU>();
        }

        #endregion Public Methods
    }
}