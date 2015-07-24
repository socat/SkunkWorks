//----------------------------------------------------------------
// <copyright file="Win32_Process.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Wmi
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management;
    using System.Reflection;

    /// <summary>
    /// Model for the Win32_Process win32 wmi class.
    /// </summary>
    public class Win32_Process : WmiClass
    {
        #region Fields

        public string Caption;
        public string CommandLine;
        public string CreationClassName;
        public DateTime CreationDate;
        public string CSCreationClassName;
        public string CSName;
        public string Description;
        public string ExecutablePath;
        public UInt16 ExecutionState;
        public string Handle;
        public UInt32 HandleCount;
        public DateTime InstallDate;
        public UInt64 KernelModeTime;
        public UInt32 MaximumWorkingSetSize;
        public UInt32 MinimumWorkingSetSize;
        public string Name;
        public string OSCreationClassName;
        public string OSName;
        public UInt64 OtherOperationCount;
        public UInt64 OtherTransferCount;
        public UInt32 PageFaults;
        public UInt32 PageFileUsage;
        public UInt32 ParentProcessId;
        public UInt32 PeakPageFileUsage;
        public UInt64 PeakVirtualSize;
        public UInt32 PeakWorkingSetSize;
        public UInt32 Priority;
        public UInt64 PrivatePageCount;
        public UInt32 ProcessId;
        public UInt32 QuotaNonPagedPoolUsage;
        public UInt32 QuotaPagedPoolUsage;
        public UInt32 QuotaPeakNonPagedPoolUsage;
        public UInt32 QuotaPeakPagedPoolUsage;
        public UInt64 ReadOperationCount;
        public UInt64 ReadTransferCount;
        public UInt32 SessionId;
        public string Status;
        public DateTime TerminationDate;
        public UInt32 ThreadCount;
        public UInt64 UserModeTime;
        public UInt64 VirtualSize;
        public string WindowsVersion;
        public UInt64 WorkingSetSize;
        public UInt64 WriteOperationCount;
        public UInt64 WriteTransferCount;

        #endregion Fields
         
    }
}