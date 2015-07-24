//----------------------------------------------------------------
// <copyright file="Win32_Thread.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Wmi
{
    using System;

    public class Win32_Thread : WmiClass
    {
        #region Fields

        public string Caption;
        public string CreationClassName;
        public string CSCreationClassName;
        public string CSName;
        public string Description;
        public UInt64 ElapsedTime;
        public UInt16 ExecutionState;
        public string Handle;
        public DateTime InstallDate;
        public UInt64 KernelModeTime;
        public string Name;
        public string OSCreationClassName;
        public string OSName;
        public UInt32 Priority;
        public UInt32 PriorityBase;
        public string ProcessCreationClassName;
        public string ProcessHandle;
        public UInt32 StartAddress;
        public string Status;
        public UInt32 ThreadState;
        public UInt32 ThreadWaitReason;
        public UInt64 UserModeTime;

        #endregion Fields

    }
}