//----------------------------------------------------------------
// <copyright file="Win32_NTDomain.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------



namespace HelperLibrary.Wmi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Win32_NTDomain : WmiClass
    {
        public string Caption;
        public string DcSiteName;
        public string Description;
        public string DnsForestName;
        public string DomainControllerAddress;
        public Int32 DomainControllerAddressType;
        public string DomainControllerName;
        public string DomainGuid;
        public string DomainName;
        public bool DSDirectoryServiceFlag;
        public bool DSDnsControllerFlag;
        public bool DSDnsDomainFlag;
        public bool DSDnsForestFlag;
        public bool DSGlobalCatalogFlag;
        public bool DSKerberosDistributionCenterFlag;
        public bool DSPrimaryDomainControllerFlag;
        public bool DSTimeServiceFlag;
        public bool DSWritableFlag;
        public DateTime InstallDate;
        public string Name;
        public string NameFormat;
        public string PrimaryOwnerContact;
        public string PrimaryOwnerName;
        public string[] Roles;
        public string Status;


    }
}
