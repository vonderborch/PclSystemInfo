// ***********************************************************************
// Assembly         : Desktop
// Component        : OperatingSystem.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-01-2017
// ***********************************************************************
// <copyright file="OperatingSystem.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Information on the Operating System.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
using System;

namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class OperatingSystem.
    /// </summary>
    /// <seealso cref="PclSystemInfo.AOperatingSystem" />
    public class OperatingSystem : AOperatingSystem
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether [is64 bit].
        /// </summary>
        /// <value><c>true</c> if [is64 bit]; otherwise, <c>false</c>.</value>
        public override bool Is64Bit
        {
            get { return Environment.Is64BitOperatingSystem; }
        }

        /// <summary>
        /// Gets the platform identifier.
        /// </summary>
        /// <value>The platform identifier.</value>
        public override PclPlatformId PlatformId
        {
            get
            {
                var type = (int)Environment.OSVersion.Platform;
                return (PclPlatformId)type;
            }
        }

        /// <summary>
        /// Gets the service pack.
        /// </summary>
        /// <value>The service pack.</value>
        public override string ServicePack
        {
            get { return Environment.OSVersion.ServicePack; }
        }

        /// <summary>
        /// Gets the version build.
        /// </summary>
        /// <value>The version build.</value>
        public override int VersionBuild
        {
            get { return Environment.OSVersion.Version.Build; }
        }

        /// <summary>
        /// Gets the version major.
        /// </summary>
        /// <value>The version major.</value>
        public override int VersionMajor
        {
            get { return Environment.OSVersion.Version.Major; }
        }

        /// <summary>
        /// Gets the version major revision.
        /// </summary>
        /// <value>The version major revision.</value>
        public override short VersionMajorRevision
        {
            get { return Environment.OSVersion.Version.MajorRevision; }
        }

        /// <summary>
        /// Gets the version minor.
        /// </summary>
        /// <value>The version minor.</value>
        public override int VersionMinor
        {
            get { return Environment.OSVersion.Version.Minor; }
        }

        /// <summary>
        /// Gets the version minor revision.
        /// </summary>
        /// <value>The version minor revision.</value>
        public override short VersionMinorRevision
        {
            get { return Environment.OSVersion.Version.MinorRevision; }
        }

        /// <summary>
        /// Gets the version revision.
        /// </summary>
        /// <value>The version revision.</value>
        public override int VersionRevision
        {
            get { return Environment.OSVersion.Version.Revision; }
        }

        /// <summary>
        /// Gets the version string.
        /// </summary>
        /// <value>The version string.</value>
        public override string VersionString
        {
            get { return Environment.OSVersion.VersionString; }
        }

        #endregion Public Properties
    }
}