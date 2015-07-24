//----------------------------------------------------------------
// <copyright file="Win32_ComputerSystem.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Wmi
{
    using System;

    /// <summary>
    /// Model for the Win32_ComputerSystem win32 wmi class.
    /// </summary>
    public class Win32_ComputerSystem : WmiClass
    {
        #region Fields

        public UInt16 AdminPasswordStatus;
        public bool AutomaticManagedPagefile;
        public bool AutomaticResetBootOption;
        public bool AutomaticResetCapability;
        public UInt16 BootOptionOnLimit;
        public UInt16 BootOptionOnWatchDog;
        public bool BootROMSupported;
        public string BootupState;
        public string Caption;
        public UInt16 ChassisBootupState;
        public string CreationClassName;
        public int CurrentTimeZone;
        public bool DaylightInEffect;
        public string Description;
        public string DNSHostName;
        public string Domain;
        public UInt16 DomainRole;
        public bool EnableDaylightSavingsTime;
        public UInt16 FrontPanelResetStatus;
        public bool InfraredSupported;
        public string InitialLoadInfo;
        public DateTime InstallDate { get; set; }
        public UInt16 KeyboardPasswordStatus;
        public string LastLoadInfo;
        public string Manufacturer;
        public string Model;
        public string Name;
        public string NameFormat;
        public bool NetworkServerModeEnabled;
        public UInt32 NumberOfLogicalProcessors;
        public UInt32 NumberOfProcessors;
        public UInt16[] OEMLogoBitmap;
        public string[] OEMstringArray;
        public bool PartOfDomain;
        public Int64 PauseAfterReset;
        public UInt16 PCSystemType;
        public UInt16 PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public UInt16 PowerOnPasswordStatus;
        public UInt16 PowerState;
        public UInt16 PowerSupplyState;
        public string PrimaryOwnerContact;
        public string PrimaryOwnerName;
        public UInt16 ResetCapability;
        public Int16 ResetCount;
        public Int16 ResetLimit;
        public string[] Roles;
        public string Status;
        public string[] SupportContactDescription;
        public UInt16 SystemStartupDelay;
        public string[] SystemStartupOptions;
        public UInt16 SystemStartupSetting;
        public string SystemType;
        public UInt16 ThermalState;
        public UInt64 TotalPhysicalMemory;
        public string UserName;
        public UInt16 WakeUpType;
        public string Workgroup;

        #endregion Fields
         
    }
}