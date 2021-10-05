using System;
using System.Windows.Forms;

namespace CG.Traveler
{
    /// <summary>
    /// This class utility contains global constants.
    /// </summary>
    internal class Globals
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This field contains the name of our registry key.
        /// </summary>
        public static readonly string REGKEYNAME =
            $"SOFTWARE\\CodeGator\\{Application.ProductName}";

        #endregion
    }
}
