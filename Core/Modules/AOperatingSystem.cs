// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : AOperatingSystem.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-01-2017
// ***********************************************************************
// <copyright file="AOperatingSystem.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the Operating System information class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo
{
    /// <summary>
    /// Class AOperatingSystem.
    /// </summary>
    public abstract class AOperatingSystem
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether [is64 bit].
        /// </summary>
        /// <value><c>true</c> if [is64 bit]; otherwise, <c>false</c>.</value>
        public abstract bool Is64Bit { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is linux.
        /// </summary>
        /// <value><c>true</c> if this instance is linux; otherwise, <c>false</c>.</value>
        public bool IsLinux
        {
            get { return PlatformId == PclPlatformId.Unix; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is mac.
        /// </summary>
        /// <value><c>true</c> if this instance is mac; otherwise, <c>false</c>.</value>
        public bool IsMac
        {
            get { return PlatformId == PclPlatformId.MaxOSX; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is windows.
        /// </summary>
        /// <value><c>true</c> if this instance is windows; otherwise, <c>false</c>.</value>
        public bool IsWindows
        {
            get { return PlatformId == PclPlatformId.Win32NT || PlatformId == PclPlatformId.Win32S 
                      || PlatformId == PclPlatformId.Win32Windows || PlatformId == PclPlatformId.WinCE; }
        }

        /// <summary>
        /// Gets the platform identifier.
        /// </summary>
        /// <value>The platform identifier.</value>
        public abstract PclPlatformId PlatformId { get; }

        /// <summary>
        /// Gets the service pack.
        /// </summary>
        /// <value>The service pack.</value>
        public abstract string ServicePack { get; }

        /// <summary>
        /// Gets the version build.
        /// </summary>
        /// <value>The version build.</value>
        public abstract int VersionBuild { get; }
        /// <summary>
        /// Gets the version major.
        /// </summary>
        /// <value>The version major.</value>
        public abstract int VersionMajor { get; }
        /// <summary>
        /// Gets the version major revision.
        /// </summary>
        /// <value>The version major revision.</value>
        public abstract short VersionMajorRevision { get; }
        /// <summary>
        /// Gets the version minor.
        /// </summary>
        /// <value>The version minor.</value>
        public abstract int VersionMinor { get; }
        /// <summary>
        /// Gets the version minor revision.
        /// </summary>
        /// <value>The version minor revision.</value>
        public abstract short VersionMinorRevision { get; }
        /// <summary>
        /// Gets the version revision.
        /// </summary>
        /// <value>The version revision.</value>
        public abstract int VersionRevision { get; }
        /// <summary>
        /// Gets the version string.
        /// </summary>
        /// <value>The version string.</value>
        public abstract string VersionString { get; }

        #endregion Public Properties
    }
}