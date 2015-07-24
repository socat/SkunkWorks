//----------------------------------------------------------------
// <copyright file="Win32_OperatingSystem.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Wmi
{
    using System;

    /// <summary>
    /// Model for the Win32_OperatingSystem win32 wmi class.
    /// </summary>
    public class Win32_OperatingSystem : WmiClass
    {
        #region Fields

        public string BootDevice;
        public string BuildNumber;
        public string BuildType;
        public string Caption;
        public string CodeSet;
        public string CountryCode;
        public string CreationClassName;
        public string CSCreationClassName;
        public string CSDVersion;
        public string CSName;
        public Int16 CurrentTimeZone;
        public bool DataExecutionPrevention_32BitApplications;
        public bool DataExecutionPrevention_Available;
        public bool DataExecutionPrevention_Drivers;
        public UInt64 DataExecutionPrevention_SupportPolicy;
        public bool Debug;
        public string Description;
        public bool Distributed;
        public UInt32 EncryptionLevel;
        public UInt16 ForegroundApplicationBoost;
        public UInt64 FreePhysicalMemory;
        public UInt64 FreeSpaceInPagingFiles;
        public UInt64 FreeVirtualMemory;
        public DateTime InstallDate;
        public UInt32 LargeSystemCache;
        public DateTime LastBootUpTime;
        public DateTime LocalDateTime;
        public string Locale;
        public string Manufacturer;
        public UInt32 MaxNumberOfProcesses;
        public UInt64 MaxProcessMemorySize;
        public string[] MUILanguages;
        public string Name;
        public UInt32 NumberOfLicensedUsers;
        public UInt32 NumberOfProcesses;
        public UInt32 NumberOfUsers;
        public UInt32 OperatingSystemSKU;
        public string Organization;
        public string OSArchitecture;
        public UInt32 OSLanguage;
        public UInt32 OSProductSuite;
        public UInt16 OSType;
        public string OtherTypeDescription;
        public bool PAEEnabled;
        public string PlusProductID;
        public string PlusVersionNumber;
        public bool Primary;
        public UInt32 ProductType;
        public string RegisteredUser;
        public string SerialNumber;
        public UInt16 ServicePackMajorVersion;
        public UInt16 ServicePackMinorVersion;
        public UInt64 SizeStoredInPagingFiles;
        public string Status;
        public UInt32 SuiteMask;
        public string SystemDevice;
        public string SystemDirectory;
        public string SystemDrive;
        public UInt64 TotalSwapSpaceSize;
        public UInt64 TotalVirtualMemorySize;
        public UInt64 TotalVisibleMemorySize;
        public string Version;
        public string WindowsDirectory;

        #endregion Fields
        
    }
}