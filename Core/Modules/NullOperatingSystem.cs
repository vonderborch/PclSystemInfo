// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : NullOperatingSystem.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-01-2017
// ***********************************************************************
// <copyright file="NullOperatingSystem.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the null version of the Operating System class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo
{
    /// <summary>
    /// Class NullOperatingSystem.
    /// </summary>
    /// <seealso cref="PclSystemInfo.AOperatingSystem" />
    public class NullOperatingSystem : AOperatingSystem
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether [is64 bit].
        /// </summary>
        /// <value><c>true</c> if [is64 bit]; otherwise, <c>false</c>.</value>
        public override bool Is64Bit
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the platform identifier.
        /// </summary>
        /// <value>The platform identifier.</value>
        public override PclPlatformId PlatformId
        {
            get { return PclPlatformId.None; }
        }

        /// <summary>
        /// Gets the service pack.
        /// </summary>
        /// <value>The service pack.</value>
        public override string ServicePack
        {
            get { return ""; }
        }

        /// <summary>
        /// Gets the version build.
        /// </summary>
        /// <value>The version build.</value>
        public override int VersionBuild
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the version major.
        /// </summary>
        /// <value>The version major.</value>
        public override int VersionMajor
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the version major revision.
        /// </summary>
        /// <value>The version major revision.</value>
        public override short VersionMajorRevision
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the version minor.
        /// </summary>
        /// <value>The version minor.</value>
        public override int VersionMinor
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the version minor revision.
        /// </summary>
        /// <value>The version minor revision.</value>
        public override short VersionMinorRevision
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the version revision.
        /// </summary>
        /// <value>The version revision.</value>
        public override int VersionRevision
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the version string.
        /// </summary>
        /// <value>The version string.</value>
        public override string VersionString
        {
            get { return ""; }
        }

        #endregion Public Properties
    }
}