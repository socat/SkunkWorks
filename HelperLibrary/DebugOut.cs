// <copyright file="System.Console.cs" company="Microsoft Corporation">
// Copyright (c) 2011 All Rights Reserved
// </copyright>
// <author>v-nicarl</author>
// <email></email>
// <date>26-Jan-11 09:51:20</date>
// <summary></summary>
namespace HelperLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public static partial class DebugOut
    {
        #region Fields

        /// <summary>
        /// Format string for timestamps.
        /// </summary>
        private static readonly string timeStampFormatString = "yyyy/MM/dd HH:mm:ss";

        private static string logFile = string.Empty;
        private static bool logging = false;

        #endregion Fields

        #region Properties

        /// <summary>
        /// True if the Debugger is attached, otherwise false.
        /// </summary>
        /// <remarks>
        /// get { return System.Diagnostics.Debugger.IsAttached; }
        /// </remarks>
        public static bool IsDebugMode
        {
            get { return System.Diagnostics.Debugger.IsAttached; }
        }

        /// <summary>
        /// Name of the log file to contain debug information.
        /// </summary>
        public static string LogFile
        {
            get
            {
                return logFile;
            }
            set
            {
                logFile = value;
            }
        }

        /// <summary>
        /// Determines whether or not to output debug information to the log file.
        /// </summary>
        public static bool Logging
        {
            get
            {
                return logging;
            }
            set
            {
                logging = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Deletes the current log file.
        /// </summary>
        public static void DeleteLog()
        {
            if (File.Exists(LogFile))
            {
                File.Delete(LogFile);
            }
        }

        /// <summary>
        /// Writes a single linebreak to the console, debug, or logfile output.
        /// </summary>
        public static void WriteLine()
        {
            Write("\r\n");

            if (Logging)
            {
                File.AppendAllLines(LogFile, new[] { "\r\n" });
            }
        }

        /// <summary>
        /// Writes a single line of output to the console, debugger, or logfile.
        /// </summary>
        /// <param name="stringFormat"></param>
        /// <param name="args"></param>
        public static void WriteLine(string stringFormat, params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[{0}] ", DateTime.Now.ToString(timeStampFormatString));
            sb.AppendLine(stringFormat, args);

            #region stack + calling data
            if (IsDebugMode)
            {
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
                System.Diagnostics.StackFrame sf = stackTrace.GetFrame(1);
                System.Reflection.MethodBase mb = sf.GetMethod();
                sb.AppendLine(" * ({0}) {1}.{2}.{3}; ",
                    mb.Module,
                    mb.DeclaringType.Namespace,
                    mb.DeclaringType.Name,
                    mb.ToString());
            }
            #endregion

            Write(sb.ToString());

            if (Logging)
            {
                File.AppendAllLines(LogFile, new[] { sb.ToString() });
            }

            sb.Clear();
        }

        private static void Write(string sb)
        {
            Action<string> write;

            if (IsDebugMode)
            {
                write = s => { System.Diagnostics.Debug.Write(s); };
            }
            else
            {
                write = s => { System.Console.Write(s); };
            }

            write(sb);
        }

        #endregion Methods
    }
}