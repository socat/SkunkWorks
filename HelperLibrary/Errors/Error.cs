namespace HelperLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Xml;

    #region Enumerations

    /// <summary>
    /// Represents error severities.
    /// </summary>
    public enum ErrorSeverity
    {
        /// <example>
        /// If you need to track debugging information
        /// </example>
        INFORMATION,

        /// <example>
        /// If data was missing from the database.
        /// </example>
        WARNING,

        /// <summary>
        /// A severe application error has occured.
        /// </summary>
        CRITICAL
    }

    #endregion Enumerations
}