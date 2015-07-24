﻿//----------------------------------------------------------------
// <copyright file="Win32_Processor.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Wmi
{
    using System;

    /// <summary>
    /// Model for the Win32_Processor win32 wmi class.
    /// </summary>
    public class Win32_Processor : WmiClass
    {
        #region Fields

        public UInt16 AddressWidth;
        public UInt16 Architecture;
        public UInt16 Availability;
        public string Caption;
        public UInt32 ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public UInt16 CpuStatus;
        public string CreationClassName;
        public UInt32 CurrentClockSpeed;
        public UInt16 CurrentVoltage;
        public UInt16 DataWidth;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public UInt32 ExtClock;
        public UInt16 Family;
        public DateTime InstallDate;
        public UInt32 L2CacheSize;
        public UInt32 L2CacheSpeed;
        public UInt32 L3CacheSize;
        public UInt32 L3CacheSpeed;
        public UInt32 LastErrorCode;
        public UInt16 Level;
        public UInt16 LoadPercentage;
        public string Manufacturer;
        public UInt32 MaxClockSpeed;
        public string Name;
        public UInt32 NumberOfCores;
        public UInt32 NumberOfLogicalProcessors;
        public string OtherFamilyDescription;
        public string PNPDeviceID;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProcessorId;
        public UInt16 ProcessorType;
        public UInt16 Revision;
        public string Role;
        public string SocketDesignation;
        public string Status;
        public UInt16 StatusInfo;
        public string Stepping;
        public string SystemCreationClassName;
        public string SystemName;
        public string UniqueId;
        public UInt16 UpgradeMethod;
        public string Version;
        public UInt32 VoltageCaps;

        #endregion Fields
         
    }
}