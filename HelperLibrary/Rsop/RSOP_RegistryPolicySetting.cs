namespace HelperLibrary.Rsop
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management;
    using System.Reflection;

    public class RSOP_RegistryPolicySetting
    {
        #region Properties

        public string command
        {
            get; set;
        }

        public bool deleted
        {
            get; set;
        }

        public string id
        {
            get; set;
        }

        public UInt32 precedence
        {
            get; set;
        }

        public string registryKey
        {
            get; set;
        }

        public UInt16[] value
        {
            get; set;
        }

        public string valueName
        {
            get; set;
        }

        public UInt32 valueType
        {
            get; set;
        }

        #endregion Properties
    }
}