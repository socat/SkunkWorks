namespace HelperLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class Log
    {
        #region Fields

        private const int DefaultTraceEventId = 0;
        private const string LogFileExtension = "log";
        private const string LogFileSearchPattern = "*.log";

        private static readonly TimeSpan DefaultLogExpirationAge = TimeSpan.FromDays(3.0);
        private static readonly string defaultTextWriterFileName;
        private static readonly TraceSource tracer;

        private static Collection<string> logfilePaths;

        #endregion Fields

        #region Constructors

        static Log()
        {
            using (Process proc = Process.GetCurrentProcess())
            {
                string name = GetProcessTraceSourceName(proc.ProcessName);
                tracer = new TraceSource(name);
                defaultTextWriterFileName = string.Format("{0}-{1}.{2}", name, proc.Id, "log");
            }
        }

        #endregion Constructors

        #region Properties

        public static Collection<string> LogFiles
        {
            get
            {
                if (logfilePaths == null)
                {
                    logfilePaths = new Collection<string>();
                }
                return logfilePaths;
            }
        }

        #endregion Properties

        #region Methods

        public static void AddDefaultTextListener(string dirPath)
        {
            if (string.IsNullOrEmpty(dirPath))
            {
                throw new ArgumentNullException("dirPath");
            }
            if (!Directory.Exists(dirPath))
            {
                throw new ArgumentException(string.Format("Directory for log must already exist: {0}", dirPath));
            }
            string filePath = Path.Combine(dirPath, defaultTextWriterFileName);
            TextWriterTraceListener textListener = new TextWriterTraceListener(filePath)
            {
                TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.ProcessId | TraceOptions.DateTime,
                IndentSize = 2
            };
            tracer.Listeners.Add(textListener);
            LogFiles.Add(filePath);
        }

        public static void AddDefaultTextListener(string dirPath, SourceLevels traceLevel)
        {
            SourceSwitch sourceSwitch = new SourceSwitch("SourceSwitch")
                                            {
                                                Level = traceLevel
                                            };
            tracer.Switch = sourceSwitch;
            AddDefaultTextListener(dirPath);
        }

        public static void AddTextListener(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }
            if (Path.GetExtension(filePath).Equals("log", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format("log file must have extension: '{0}'", "log"));
            }
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                throw new ArgumentException(string.Format("Containing directory for log must already exist: {0}", filePath));
            }
            TextWriterTraceListener textListener = new TextWriterTraceListener(filePath)
            {
                TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.ProcessId | TraceOptions.DateTime,
                IndentSize = 2
            };
            tracer.Listeners.Add(textListener);
            LogFiles.Add(filePath);
        }

        public static void ClearOldLogs(string logDir)
        {
            ClearOldLogs(logDir, DefaultLogExpirationAge);
        }

        public static void ClearOldLogs(string logDir, TimeSpan age)
        {
            string[] logfiles = Directory.GetFiles(logDir, "*.log", SearchOption.TopDirectoryOnly);
            DateTime utcNow = DateTime.UtcNow;
            foreach (string logfile in logfiles)
            {
                FileInfo fileInfo = new FileInfo(logfile);
                if ((utcNow - fileInfo.LastAccessTimeUtc) > age)
                {
                    try
                    {
                        File.Delete(logfile);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public static void Close()
        {
            tracer.Flush();
            tracer.Close();
        }

        public static void Flush()
        {
            tracer.Flush();
        }

        public static void TraceError(int id, object objectToTrace)
        {
            string message = (objectToTrace == null) ? "<null>" : objectToTrace.ToString();
            tracer.TraceEvent(TraceEventType.Error, id, message);
        }

        public static void TraceError(int id, string message)
        {
            tracer.TraceEvent(TraceEventType.Error, id, message);
        }

        public static void TraceError(int id, string format, params object[] args)
        {
            tracer.TraceEvent(TraceEventType.Error, id, format, args);
        }

        public static void TraceInfo(string message)
        {
            tracer.TraceEvent(TraceEventType.Information, 0, message);
        }

        public static void TraceInfo(string format, params object[] args)
        {
            tracer.TraceEvent(TraceEventType.Information, 0, format, args);
        }

        public static void TraceVerbose(string message)
        {
            tracer.TraceEvent(TraceEventType.Verbose, 0, message);
        }

        public static void TraceVerbose(string format, params object[] args)
        {
            tracer.TraceEvent(TraceEventType.Verbose, 0, format, args);
        }

        public static void TraceWarning(int id, string message)
        {
            tracer.TraceEvent(TraceEventType.Warning, id, message);
        }

        public static void TraceWarning(int id, string format, params object[] args)
        {
            tracer.TraceEvent(TraceEventType.Warning, id, format, args);
        }

        private static string GetProcessTraceSourceName(string name)
        {
            if (name.IndexOf("CodeFlow", StringComparison.OrdinalIgnoreCase) != -1)
            {
                name = "CodeFlow";
                return name;
            }
            if (name.IndexOf("devenv", StringComparison.OrdinalIgnoreCase) != -1)
            {
                name = "VsCodeFlow";
                return name;
            }
            if (name.IndexOf("rascalpro", StringComparison.OrdinalIgnoreCase) != -1)
            {
                name = "RascalPro";
                return name;
            }
            int pos = name.IndexOf(".", StringComparison.InvariantCulture);
            if (pos != -1)
            {
                name = name.Substring(0, pos);
            }
            return name;
        }

        #endregion Methods

        #region Nested Types

        public static class WarnId
        {
            #region Fields

            public const int ActiveDirectoryCacheException = 0x138d;
            public const int ApplicationSettingsException = 0x139a;
            public const int ApplicationUnhandledException = 0x1396;
            public const int ChangeSetCacheException = 0x138c;
            public const int ChangeSetProviderException = 0x138b;
            public const int ClientFault = 0x1393;
            public const int ClientSettings = 0x13a1;
            public const int CodeFlowServiceExtensionException = 0x138a;
            public const int CompositionException = 0x1392;
            public const int DashboardException = 0x139f;
            public const int DeploymentException = 0x1394;
            public const int DirectoryCacheException = 0x1397;
            public const int EmailSendFailure = 0x139e;
            public const int FeatureUsageReporter = 0x1398;
            public const int FileOwnershipProvider = 0x139c;
            public const int InvalidCodePackageFromat = 0x13a2;
            public const int InvalidPropertyName = 0x138f;
            public const int InvalidStartupParameters = 0x1395;
            public const int IOError = 0x1390;
            public const int ObsoleteServiceUsage = 0x1387;
            public const int ReplaceCommentsWithNoSelection = 0x1399;
            public const int ReviewListenerException = 0x13a0;
            public const int ReviewStateCorrupted = 0x270f;
            public const int ServiceClientInitialization = 0x270e;
            public const int ServiceFault = 0x1389;
            public const int ServiceNotAvailable = 0x1388;
            public const int StaticAnalysisExtensibility = 0x13a3;
            public const int ThumbnailConverter = 0x139d;
            public const int UnknownMessageReceived = 0x1391;
            public const int WorkItemProvider = 0x139b;

            #endregion Fields
        }

        #endregion Nested Types
    }
}