// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : PclPlatformId.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-01-2017
// ***********************************************************************
// <copyright file="PclPlatformId.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the PlatformID enum.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo
{
    /// <summary>
    /// Enum PclPlatformId
    /// </summary>
    public enum PclPlatformId
    {
        /// <summary>
        /// No detectable, or unsupported, operating system.
        /// </summary>
        /// <summary>
        /// The none
        /// </summary>
        None = -1,

        /// <summary>
        /// The operating system is Win32s. Win32s is a layer that runs on 16-bit versions of Windows to provide access to 32-bit applications.
        /// </summary>
        /// <summary>
        /// The win32 s
        /// </summary>
        Win32S = 0,

        /// <summary>
        /// The operating system is Windows 95 or Windows 98.
        /// </summary>
        /// <summary>
        /// The win32 windows
        /// </summary>
        Win32Windows = 1,

        /// <summary>
        /// The operating system is Windows NT or later.
        /// </summary>
        /// <summary>
        /// The win32 nt
        /// </summary>
        Win32NT = 2,

        /// <summary>
        /// The operating system is Windows CE.
        /// </summary>
        /// <summary>
        /// The win ce
        /// </summary>
        WinCE = 3,

        /// <summary>
        /// The operating system is Unix.
        /// </summary>
        /// <summary>
        /// The unix
        /// </summary>
        Unix = 4,

        /// <summary>
        /// The development platform is Xbox 360.
        /// </summary>
        /// <summary>
        /// The xbox
        /// </summary>
        Xbox = 5,

        /// <summary>
        /// The operating system is Macintosh.
        /// </summary>
        /// <summary>
        /// The maximum osx
        /// </summary>
        MaxOSX = 6
    }
}