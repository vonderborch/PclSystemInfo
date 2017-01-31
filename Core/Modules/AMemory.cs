// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : AMemory.cs
// Author           : vonderborch
// Created          : 01-30-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-30-2017
// ***********************************************************************
// <copyright file="AMemory.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the abstract memory class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-30-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class AMemory.
    /// </summary>
    public abstract class AMemory
    {
        #region Public Properties

        /// <summary>
        /// Gets the available bytes.
        /// </summary>
        /// <value>The available bytes.</value>
        public abstract long AvailableBytes { get; }

        /// <summary>
        /// Gets the available g bytes.
        /// </summary>
        /// <value>The available g bytes.</value>
        public double AvailableGBytes
        {
            get { return AvailableMBytes / 1000; }
        }

        /// <summary>
        /// Gets the available m bytes.
        /// </summary>
        /// <value>The available m bytes.</value>
        public double AvailableMBytes
        {
            get { return AvailableBytes / (double)1000000; }
        }

        /// <summary>
        /// Gets the available percent.
        /// </summary>
        /// <value>The available percent.</value>
        public double AvailablePercent
        {
            get { return (AvailableBytes / TotalBytes) * 100; }
        }

        /// <summary>
        /// Gets the total bytes.
        /// </summary>
        /// <value>The total bytes.</value>
        public abstract long TotalBytes { get; }

        /// <summary>
        /// Gets the total g bytes.
        /// </summary>
        /// <value>The total g bytes.</value>
        public double TotalGBytes
        {
            get { return TotalMBytes / 1000; }
        }

        /// <summary>
        /// Gets the total m bytes.
        /// </summary>
        /// <value>The total m bytes.</value>
        public double TotalMBytes
        {
            get { return TotalBytes / (double)1000000; }
        }

        /// <summary>
        /// Gets the used bytes.
        /// </summary>
        /// <value>The used bytes.</value>
        public long UsedBytes
        {
            get { return TotalBytes - AvailableBytes; }
        }

        /// <summary>
        /// Gets the used g bytes.
        /// </summary>
        /// <value>The used g bytes.</value>
        public double UsedGBytes
        {
            get { return UsedMBytes / 1000; }
        }

        /// <summary>
        /// Gets the used m bytes.
        /// </summary>
        /// <value>The used m bytes.</value>
        public double UsedMBytes
        {
            get { return UsedBytes / (double)1000000; }
        }

        /// <summary>
        /// Gets the used percent.
        /// </summary>
        /// <value>The used percent.</value>
        public double UsedPercent
        {
            get { return (UsedBytes / TotalBytes) * 100; }
        }

        #endregion Public Properties
    }
}