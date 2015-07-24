//----------------------------------------------------------------
// <copyright file="WmiHelper.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------

using System.Collections;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;

namespace HelperLibrary.Wmi
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management;
    using System.Reflection;
    using System.Text;

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


    public partial class WmiHelper
    {
        #region Properties

        /// <summary>
        /// Returns the number of virtual processors.
        /// </summary>
        public static int NumberOfLogicalProcessors
        {
            get
            {
                return Environment.ProcessorCount;
            }
        }

        /// <summary>
        /// Gets the number of physical processors.
        /// </summary>
        public static int NumberOfPhysicalProcessors
        {
            get
            {
                int processorCount = 0;
                using (ManagementObjectSearcher mgmtObjects = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
                {
                    foreach (var item in mgmtObjects.Get())
                    {
                        processorCount = Convert.ToInt16(item["NumberOfProcessors"]);
                    }
                }
                return processorCount;
            }
        }

        #endregion Properties

        #region Methods


        /// <summary>
        /// Generic method that uses reflection for wiring up a local class to the corresponding win32_class and properties.
        /// </summary>
        /// <param name="computer">The remote computer to query</param>
        /// <typeparam name="T">A class who's name and fields correspond to those of a WMI class.</typeparam>
        /// <returns>A collection of WMI data.</returns>
        public static IEnumerable<T> Snapshot<T>( string computer )
        {
            // List<T> returncollection = new List<T>();

            // connect to a remote computer, need to pass user credentials with permissions to query a computer remotely.
            // ManagementScope scope = new ManagementScope("\\\\FullComputerName\\root\\cimv2");
            // scope.Connect();
            // then new ManagementObjectSearcher(scope, select);

            //var w32Type = Activator.CreateInstance<T>().GetType();
            //var select = new SelectQuery(w32Type.Name);
            //var searcher = new ManagementObjectSearcher(select);

            ManagementScope scope = new ManagementScope( string.Format("\\\\{0}\\root\\cimv2", computer) );
            //scope.Options.EnablePrivileges = true;
            scope.Options.Impersonation = ImpersonationLevel.Impersonate;
            scope.Options.Authentication = AuthenticationLevel.PacketPrivacy;
            scope.Connect();


            var searcher = new ManagementObjectSearcher( scope,  new SelectQuery( Activator.CreateInstance<T>( ).GetType( ).Name ) );


            foreach ( ManagementObject mo in searcher.Get( ) )
            {
                var listItem = Activator.CreateInstance<T>( );

                foreach ( var field in listItem.GetType( ).GetFields( ).Where( field => mo[ field.Name ] != null ) )
                {
                    string moInfo = string.Empty;
                    try
                    {

                        moInfo = string.Format( "{0} {1} {2} {3}\r\n", mo[ field.Name ].ToString( ), field.Name, typeof( T ).ToString( ), mo.ClassPath );
                        field.SetValue( listItem,
                            field.FieldType == typeof( DateTime )
                                ? ManagementDateTimeConverter.ToDateTime( mo[ field.Name ].ToString( ) )
                                : Convert.ChangeType( mo[ field.Name ], field.FieldType ) );


                    }
                    catch ( Exception ex )
                    {
                        StringBuilder sb = new StringBuilder( );
                        sb.AppendFormat( moInfo );
                        sb.AppendLine( );
                        sb.AppendFormat( ex.ToString( ) );
                        sb.AppendLine( );
                        throw new Exception( sb.ToString( ) );
                    }

                }

                foreach ( var prop in listItem.GetType( ).GetProperties( ).Where( prop => mo[ prop.Name ] != null ) )
                {
                    prop.SetValue( listItem,
                                  prop.PropertyType == typeof( DateTime )
                                      ? ManagementDateTimeConverter.ToDateTime( mo[ prop.Name ].ToString( ) )
                                      : Convert.ChangeType( mo[ prop.Name ], prop.PropertyType ), null );
                }

                yield return listItem;
            }
        }


        /// <summary>
        /// Generic method that uses reflection for wiring up a local class to the corresponding win32_class and properties.
        /// </summary>
        /// <typeparam name="T">A class who's name and fields correspond to those of a WMI class.</typeparam>
        /// <returns>A collection of WMI data.</returns>
        public static IEnumerable<T> Snapshot<T>()
        {
            // List<T> returncollection = new List<T>();

            // connect to a remote computer, need to pass user credentials with permissions to query a computer remotely.
            // ManagementScope scope = new ManagementScope("\\\\FullComputerName\\root\\cimv2");
            // scope.Connect();
            // then new ManagementObjectSearcher(scope, select);

            //var w32Type = Activator.CreateInstance<T>().GetType();
            //var select = new SelectQuery(w32Type.Name);
            //var searcher = new ManagementObjectSearcher(select);

            var searcher = new ManagementObjectSearcher(new SelectQuery(Activator.CreateInstance<T>().GetType().Name));


            foreach (ManagementObject mo in searcher.Get())
            {
                var listItem = Activator.CreateInstance<T>();

                foreach (var field in listItem.GetType().GetFields().Where(field => mo[field.Name] != null))
                {
                    string moInfo = string.Empty;
                    try
                    {

                        moInfo = string.Format("{0} {1} {2} {3}\r\n", mo[field.Name].ToString(), field.Name, typeof(T).ToString(), mo.ClassPath);
                        field.SetValue(listItem,
                            field.FieldType == typeof (DateTime)
                                ? ManagementDateTimeConverter.ToDateTime(mo[field.Name].ToString())
                                : Convert.ChangeType(mo[field.Name], field.FieldType));
                

                    }
                    catch (Exception ex)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat(moInfo);
                        sb.AppendLine();
                        sb.AppendFormat(ex.ToString());
                        sb.AppendLine();
                        throw new Exception(sb.ToString());
                    }

                }

                foreach (var prop in listItem.GetType().GetProperties().Where(prop => mo[prop.Name] != null))
                {
                    prop.SetValue(listItem,
                                  prop.PropertyType == typeof (DateTime)
                                      ? ManagementDateTimeConverter.ToDateTime(mo[prop.Name].ToString())
                                      : Convert.ChangeType(mo[prop.Name], prop.PropertyType), null);
                }

                yield return listItem;
            }
        }
         

        public static string SerializeToXml<T>(T value, List<Type> types )
        {
            string formattedXml = string.Empty;


            
            //if(value is IList )
            //{
            //    var collection = value as IList; 
            //    types = collection.Select(p => p.GetType()).ToList();
            //}
            

            var xmlSerializer = new XmlSerializer(typeof(T), types.ToArray());
            
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            
            xmlSerializer.Serialize(stringWriter, value);

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(stringBuilder.ToString());

            using (StringWriter sw = new StringWriter())
            {
                XmlTextWriter writer = new XmlTextWriter(sw);
                writer.Formatting = Formatting.Indented;
                xmlDoc.WriteTo(writer);
                formattedXml = sw.ToString();
            }
            return formattedXml;

        }


        public static void GetValues<T>(T value, ref StringBuilder sb)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                sb.AppendFormat("{0}: {1}", prop.Name, (prop.GetValue(value, null) ?? string.Empty));
            }

            foreach (var field in typeof(T).GetFields())
            {
                sb.AppendFormat("{0}: {1}", field.Name, (field.GetValue(value) ?? string.Empty));
            }
        }

        public static string ToCsv<T>(string separator, IEnumerable<T> objectlist)
        {
            Type t = typeof(T);
            FieldInfo[] fields = t.GetFields();

            string header = String.Join(separator, fields.Select(f => f.Name).ToArray());

            StringBuilder csvdata = new StringBuilder();
            csvdata.AppendLine(header);

            foreach (var o in objectlist)
            {
                csvdata.AppendLine(ToCsvFields(separator, fields, o));
            }

            return csvdata.ToString();
        }

        public static string ToCsvFields(string separator, FieldInfo[] fields, object o)
        {
            StringBuilder linie = new StringBuilder();

            foreach (var f in fields)
            {
                if (linie.Length > 0)
                {
                    linie.Append(separator);
                }

                var x = f.GetValue(o);

                if (x != null)
                {
                    linie.Append(x.ToString());
                }
            }

            return linie.ToString();
        }

        #endregion Methods
    }
}