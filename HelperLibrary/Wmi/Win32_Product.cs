﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperLibrary.Wmi
{
    public class Win32_Product :  WmiClass
    {
        public UInt16   AssignmentType;
        public string   Caption;
        public string   Description;
        public string   IdentifyingNumber;
        public string   InstallDate;
        public DateTime InstallDate2;
        public string   InstallLocation;
        public Int16   InstallState;
        public string   HelpLink;
        public string   HelpTelephone;
        public string   InstallSource;
        public string   Language;
        public string   LocalPackage;
        public string   Name;
        public string   PackageCache;
        public string   PackageCode;
        public string   PackageName;
        public string   ProductID;
        public string   RegOwner;
        public string   RegCompany;
        public string   SKUNumber;
        public string   Transforms;
        public string   URLInfoAbout;
        public string   URLUpdateInfo;
        public string   Vendor;
        public UInt32   WordCount;
        public string   Version;
    };
}
