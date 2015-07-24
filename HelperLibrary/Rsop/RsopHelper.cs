//----------------------------------------------------------------
// <copyright file="RsopHelper.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary.Rsop
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management;
    using System.Reflection;

    public class RemoteConnect
    {
        #region Other

        //public static void Main()
        //{
        //    /*// Build an options object for the remote connection
        //    //   if you plan to connect to the remote
        //    //   computer with a different user name
        //    //   and password than the one you are currently using
        //         ConnectionOptions options =
        //             new ConnectionOptions();
        //         // and then set the options.Username and
        //         // options.Password properties to the correct values
        //         // and also set
        //         // options.Authority = "ntdlmdomain:DOMAIN";
        //         // and replace DOMAIN with the remote computer's
        //         // domain.  You can also use kerberose instead
        //         // of ntdlmdomain.
        //    */
        //    // Make a connection to a remote computer.
        //    // Replace the "FullComputerName" section of the
        //    // string "\\\\FullComputerName\\root\\cimv2" with
        //    // the full computer name or IP address of the
        //    // remote computer.
        //    ManagementScope scope =
        //        new ManagementScope(
        //            "\\\\FullComputerName\\root\\cimv2");
        //    scope.Connect();
        //    // Use this code if you are connecting with a
        //    // different user name and password:
        //    //
        //    // ManagementScope scope =
        //    //    new ManagementScope(
        //    //        "\\\\FullComputerName\\root\\cimv2", options);
        //    // scope.Connect();
        //    //Query system for Operating System information
        //    ObjectQuery query = new ObjectQuery(
        //        "SELECT * FROM Win32_OperatingSystem");
        //    ManagementObjectSearcher searcher =
        //        new ManagementObjectSearcher(scope, query);
        //    ManagementObjectCollection queryCollection = searcher.Get();
        //    foreach (ManagementObject m in queryCollection)
        //    {
        //        // Display the remote computer information
        //        Console.WriteLine("Computer Name : {0}",
        //            m["csname"]);
        //        Console.WriteLine("Windows Directory : {0}",
        //            m["WindowsDirectory"]);
        //        Console.WriteLine("Operating System: {0}",
        //            m["Caption"]);
        //        Console.WriteLine("Version: {0}", m["Version"]);
        //        Console.WriteLine("Manufacturer : {0}",
        //            m["Manufacturer"]);
        //    }
        //}

        #endregion Other
    }

    public partial class RsopHelper
    {
        #region Methods

        /*

        ManagementScope scope;
        ConnectionOptions options = new ConnectionOptions();
        options.Username = tbUsername.Text;
        options.Password = tbPassword.Password;
        options.Authority = String.Format("ntlmdomain:{0}", tbDomain.Text);
        scope = new ManagementScope(String.Format("\\\\{0}\\root\\RSOP", tbHost.Text), options);
        scope.Connect();
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new ObjectQuery("SELECT * FROM RSOP_RegistryPolicySetting"));
        foreach (ManagementObject queryObj in searcher.Get())
        {
        wmiResults.Text += String.Format("id={0}\n", queryObj["id"]);
        wmiResults.Text += String.Format("precedence={0}\n", queryObj["precedence"]);
        wmiResults.Text += String.Format("registryKey={0}\n", queryObj["registryKey"]);
        wmiResults.Text += String.Format("valueType={0}\n", queryObj["valueType"]);
        }

        */
        /// <summary>
        /// Generic method that uses reflection for wiring up a local class to the corresponding win32_class and properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Snapshot<T>()
        {
            List<T> returncollection = new List<T>();

            // connect to a remote computer, need to pass user credentials with permissions to query a computer remotely.
            // ManagementScope scope = new ManagementScope("\\\\FullComputerName\\root\\cimv2");
            // scope.Connect();
            // then new ManagementObjectSearcher(scope, select);
            string scopeNS = string.Format("\\root\\RSOP\\{0}", Environment.MachineName);
            var scope = new ManagementScope(scopeNS);
            scope.Connect();

            var rsoptype = Activator.CreateInstance<T>().GetType();

            var select = new SelectQuery(rsoptype.Name);

            var searcher = new ManagementObjectSearcher(scope, select);

            foreach (ManagementObject item in searcher.Get())
            {
                var listItem = Activator.CreateInstance<T>();

                var controlType = listItem.GetType();

                var controlPropertiesArray = controlType.GetProperties();

                foreach (PropertyInfo controlProperty in controlPropertiesArray)
                {
                    if (item[controlProperty.Name] != null)
                    {
                        controlProperty.SetValue(listItem,
                            (controlProperty.PropertyType == typeof(DateTime))
                                ? System.Management.ManagementDateTimeConverter.ToDateTime(item[controlProperty.Name].ToString())
                                : Convert.ChangeType(item[controlProperty.Name], controlProperty.PropertyType),
                            null);
                    }
                }
                returncollection.Add(listItem);
            }
            return returncollection;
        }

        #endregion Methods
    }

    public class Rsop_SnapshotTestClass
    {
        #region Properties

        public int NonexistentPropertyID
        {
            get; set;
        }

        #endregion Properties
    }
}