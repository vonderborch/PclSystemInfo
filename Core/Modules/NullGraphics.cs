// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : NullGraphics.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="NullGraphics.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the null graphics class.
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
    /// Class NullGraphics.
    /// </summary>
    /// <seealso cref="PclSystemInfo.Modules.AGraphics" />
    public class NullGraphics : AGraphics
    {
        #region Public Methods

        /// <summary>
        /// Gets the graphic card names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// Changelog:
        /// - 1.0.0 (01-01-2017) - Initial version.
        ///  Changelog:
        ///             - 1.0.0 (01-01-2017) - Initial version.
        public override List<string> GetGraphicCardNames()
        {
            return new List<string>();
        }

        /// <summary>
        /// Gets the graphic cards.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>List&lt;GraphicsCard&gt;.</returns>
        /// Changelog:
        /// - 1.0.0 (01-01-2017) - Initial version.
        ///  Changelog:
        ///             - 1.0.0 (01-01-2017) - Initial version.
        public override List<GraphicsCard> GetGraphicCards(string deviceId = null)
        {
            return new List<GraphicsCard>();
        }

        #endregion Public Methods
    }
}