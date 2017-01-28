// ***********************************************************************
// Assembly         : PclSystemInfo
// Component        : NullProcessor.cs
// Author           : vonderborch
// Created          : 01-01-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 01-27-2017
// ***********************************************************************
// <copyright file="NullProcessor.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Defines the null processor class.
// </summary>
//
// Changelog: 
//            - 1.0.0 (01-01-2017) - Initial version created.
// ***********************************************************************
namespace PclSystemInfo.Modules
{
    /// <summary>
    /// Class NullProcessor.
    /// </summary>
    /// <seealso cref="PclSystemInfo.Modules.AProcessor" />
    public class NullProcessor : AProcessor
    {
        #region Public Properties

        /// <summary>
        /// Gets the size of the cache.
        /// </summary>
        /// <value>The size of the cache.</value>
        public override int CacheSize
        {
            get { return -1; }
        }

        /// <summary>
        /// Gets the clock speed.
        /// </summary>
        /// <value>The clock speed.</value>
        public override double ClockSpeed
        {
            get { return -1; }
        }

        /// <summary>
        /// Gets the core count.
        /// </summary>
        /// <value>The core count.</value>
        public override int CoreCount
        {
            get { return -1; }
        }

        /// <summary>
        /// Gets the family.
        /// </summary>
        /// <value>The family.</value>
        public override string Family
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public override string Manufacturer
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        public override string Model
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public override string Name
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the stepping.
        /// </summary>
        /// <value>The stepping.</value>
        public override string Stepping
        {
            get { return null; }
        }

        #endregion Public Properties
    }
}