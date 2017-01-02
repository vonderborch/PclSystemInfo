// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : MachineEnvironment.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-01-2017
// ***********************************************************************
// <copyright file="MachineEnvironment.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Main class for accessing/controlling information on the current machine environment.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
using PclSystemInfo.Modules;
using System;

namespace PclSystemInfo
{
    /// <summary>
    /// Class MachineEnvironment. This class cannot be inherited.
    /// </summary>
    public sealed class MachineEnvironment
    {
        #region Private Fields

        /// <summary>
        /// The class instance.
        /// </summary>
        private static readonly Lazy<MachineEnvironment> instance = new Lazy<MachineEnvironment>(() => new MachineEnvironment());

        /// <summary>
        /// Information on the CPU.
        /// </summary>
        private AProcessor cpu;

        /// <summary>
        /// Information on the Graphics.
        /// </summary>
        private AGraphics graphics;

        /// <summary>
        /// Information on the Memory.
        /// </summary>
        private AMemory memory;

        /// <summary>
        /// Information on the OS.
        /// </summary>
        private AOperatingSystem os;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="MachineEnvironment"/> class from being created.
        /// </summary>
        private MachineEnvironment()
        {
#if CORE
            graphics = new NullGraphics();
            memory = new NullMemory();
            os = new NullOperatingSystem();
            cpu = new NullProcessor();
#else
            graphics = new Graphics();
            memory = new Memory();
            os = new PclSystemInfo.Modules.OperatingSystem();
            cpu = new Processor();
#endif
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        /// Provides information on the machine environment.
        /// </summary>
        /// <value>The environment.</value>
        public static MachineEnvironment Environment { get { return instance.Value; } }

        /// <summary>
        /// Gets the cpu information.
        /// </summary>
        /// <value>The cpu.</value>
        public AProcessor CPU
        {
            get { return cpu; }
        }

        /// <summary>
        /// Gets the graphics information.
        /// </summary>
        /// <value>The graphics.</value>
        public AGraphics Graphics
        {
            get { return graphics; }
        }

        /// <summary>
        /// Gets the memory information.
        /// </summary>
        /// <value>The memory.</value>
        public AMemory Memory
        {
            get { return memory; }
        }

        /// <summary>
        /// Gets the os information.
        /// </summary>
        /// <value>The os.</value>
        public AOperatingSystem OS
        {
            get { return os; }
        }

        #endregion Public Properties
    }
}