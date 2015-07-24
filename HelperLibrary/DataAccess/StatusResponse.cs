namespace HelperLibrary.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #region Enumerations

    /// <summary>
    /// Used by the API to determine response status.
    /// </summary>
    public enum StatusResponse : int
    {
        /// <summary>
        /// Request completed successfully.
        /// </summary>
        OK = 0,
        /// <summary>
        /// Interface returned an error.
        /// </summary>
        ERROR = 1,
        /// <summary>
        /// Query produced zero results.
        /// </summary>
        ZERO_RESULTS = 2,
        /// <summary>
        /// Request denied due to security.
        /// </summary>
        REQUEST_DENIED = 3,
        /// <summary>
        /// Invalid or missing data.
        /// </summary>
        INVALID_REQUEST = 4
    }

    #endregion Enumerations
}