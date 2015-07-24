//----------------------------------------------------------------
// <copyright file="Win32_LogicalDisk.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Wmi
{
    using System;

    /// <summary>
    /// Model for the Win32_LogicalDisk win32 wmi class.
    /// </summary>
    public class Win32_LogicalDisk : WmiClass
    {
        #region Fields

        public UInt16 Access;
        public UInt16 Availability;
        public UInt64 BlockSize;
        public string Caption;
        public bool Compressed;
        public UInt32 ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public UInt32 DriveType;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public string FileSystem;
        public UInt64 FreeSpace;
        public DateTime InstallDate;
        public UInt32 LastErrorCode;
        public UInt32 MaximumComponentLength;
        public UInt32 MediaType;
        public string Name;
        public UInt64 NumberOfBlocks;
        public string PNPDeviceID;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProviderName;
        public string Purpose;
        public bool QuotasDisabled;
        public bool QuotasIncomplete;
        public bool QuotasRebuilding;
        public UInt64 Size;
        public string Status;
        public UInt16 StatusInfo;
        public bool SupportsDiskQuotas;
        public bool SupportsFileBasedCompression;
        public string SystemCreationClassName;
        public string SystemName;
        public bool VolumeDirty;
        public string VolumeName;
        public string VolumeSerialNumber;

        #endregion Fields
    }
}