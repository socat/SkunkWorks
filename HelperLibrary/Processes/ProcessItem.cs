namespace HelperLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ProcessItem
    {
        #region Properties

        /// <summary>
        /// Process ID
        /// </summary>
        public int ID
        {
            get; set;
        }

        /// <summary>
        /// ProcessName
        /// </summary>
        public string Name
        {
            get; set;
        }

        public System.Diagnostics.ProcessModule procModel
        {
            get; set;
        }

        /// <summary>
        /// MainWindowTitle
        /// </summary>
        public string Title
        {
            get; set;
        }

        #endregion Properties
    }
}