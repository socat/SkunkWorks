//----------------------------------------------------------------
// <copyright file="Win32_Battery.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Wmi
{
    using System;

    public class Win32_Battery : WmiClass
    {
        #region Fields

        public UInt16 Availability;
        public UInt32 BatteryRechargeTime;
        public UInt16 BatteryStatus;
        public string Caption;
        public UInt16 Chemistry;
        public UInt32 ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public UInt32 DesignCapacity;
        public UInt64 DesignVoltage;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public UInt16 EstimatedChargeRemaining;
        public UInt32 EstimatedRunTime;
        public UInt32 ExpectedBatteryLife;
        public UInt32 ExpectedLife;
        public UInt32 FullChargeCapacity;
        public DateTime InstallDate;
        public UInt32 LastErrorCode;
        public UInt32 MaxRechargeTime;
        public string Name;
        public string PNPDeviceID;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string SmartBatteryVersion;
        public string Status;
        public UInt16 StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public UInt32 TimeOnBattery;
        public UInt32 TimeToFullCharge;

        #endregion Fields
         
    }
}