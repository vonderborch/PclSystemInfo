// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : AGraphics.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 03-31-2017
// ***********************************************************************
// <copyright file="AGraphics.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the abstract graphics class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (03-31-2017) - Added more details on the CPU cache.
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Classes;
using System.Collections.Generic;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class AGraphics.
    /// </summary>
    public abstract class AGraphics
    {
        #region Public Methods

        /// <summary>
        /// Gets the graphic card names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public abstract List<string> GetGraphicCardNames();

        /// <summary>
        /// Gets the graphic cards.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>List&lt;GraphicsCard&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (01-30-2017) - Initial version.
        public abstract List<GraphicsCard> GetGraphicCards(string deviceId = null);

        #endregion Public Methods
    }
}