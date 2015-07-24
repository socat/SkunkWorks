//----------------------------------------------------------------
// <copyright file="Win32_NetworkAdapter.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Wmi
{
    using System;

    /// <summary>
    /// Model for the Win32_NetworkAdapter win32 wmi class.
    /// </summary>
    public class Win32_NetworkAdapter : WmiClass
    {
        #region Fields

        public string AdapterType;
        public UInt16 AdapterTypeID;
        public bool AutoSense;
        public UInt16 Availability;
        public string Caption;
        public UInt32 ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string GUID;
        public UInt32 Index;
        public DateTime InstallDate;
        public bool Installed;
        public UInt32 InterfaceIndex;
        public UInt32 LastErrorCode;
        public string MACAddress;
        public string Manufacturer;
        public UInt32 MaxNumberControlled;
        public UInt64 MaxSpeed;
        public string Name;
        public string NetConnectionID;
        public UInt16 NetConnectionStatus;
        public bool NetEnabled;
        public string[] NetworkAddresses;
        public string PermanentAddress;
        public bool PhysicalAdapter;
        public string PNPDeviceID;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProductName;
        public string ServiceName;
        public UInt64 Speed;
        public string Status;
        public UInt16 StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public DateTime TimeOfLastReset;

        #endregion Fields

    }
}