#region Header

//----------------------------------------------------------------
// <copyright file="Program.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------

#endregion Header
using System.Collections.Generic;
using System.Management;
using System.Net.Mime;
using System.Threading.Tasks;
using HelperLibrary.Wmi;
using TaskScheduler;
namespace CT
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Collections.Concurrent;
    using Microsoft.Win32;

    using HelperLibrary;

    using HtmlAgilityPack;

    using LipsumGenerator;

    using Dbg = HelperLibrary.DebugOut;

    using sw = System.Console;
#if DEBUG
#endif
    internal class ProgramTestInterface
    {
        internal void Runner( string[] args )
        {
            Program.Main( args );
        }
    }

    internal class Program
    {

        static StringBuilder sb = new StringBuilder( );


        #region Methods

        //static unsafe void chardump(string str)
        //{
        //    fixed(char* pfixed = str)
        //    {
        //        for(char* p = pfixed; *p != 0; p++)
        //        {
        //            Console.WriteLine("{0}", char.ConvertToUtf32(p,));
        //        }
        //    }
        //}
        //public static JustificationValues? GetJustificationFromString(string alignment)
        //{
        //    switch (alignment)
        //    {
        //        case "centre":
        //            return JustificationValues.Center;
        //        case "droite":
        //            return JustificationValues.Right;
        //        case "gauche":
        //            return JustificationValues.Left;
        //        default:
        //            return null;
        //    }
        //}


        /// <summary>
        /// This method returns a list of registry values from a given key in .reg format.
        /// </summary>
        /// <param name="key">Registry key from which to obtain values.</param>
        /// <returns>A CR-separated list of all the registry values for a given key.</returns>
        private static string ParseChildValues( RegistryKey key )
        {
            if ( key.IsNull( ) )
                return string.Empty;
            StringBuilder sb = new StringBuilder( );

            foreach ( string val in key.GetValueNames( ) )
            {
                sb.AppendFormat( "{0}=\"{1}\"", string.IsNullOrEmpty( val ) ? "@" : val, key.GetValue( val ) );
                sb.AppendLine( );
            }

            return sb.ToString( );
        }

        /// <summary>
        /// Parses the SubKeys of a given RegistryKey.
        /// </summary>
        /// <param name="key">A registry key</param>
        /// <returns>Lots of important data!</returns>
        private static string ParseKey( RegistryKey key )
        {
            if ( key.IsNull( ) )
                return string.Empty;
            StringBuilder sb = new StringBuilder( );
            sb.AppendLine( );
            sb.AppendFormat( "[{0}]", key.Name );
            sb.AppendLine( );
            sb.Append( ParseChildValues( key ) );
            foreach ( var subKey in key.GetSubKeyNames( ) )
            {
                sb.Append( ParseKey( key.OpenSubKey( subKey ) ) );
            }
            return sb.ToString( );
        }


        static void ConvertEllipses( )
        {
            System.Console.WriteLine( "Ellipses converted." );
        }

        static void ConvertRectangles( )
        {
            System.Console.WriteLine( "Rectangles converted." );
        }

        static void ConvertLines( )
        {
            System.Console.WriteLine( "Lines converted." );
        }

        static void ConvertText( )
        {
            System.Console.WriteLine( "Text converted." );
        }

        internal static void xxMain(string[] args)
        {
            var host = "cloudbarn.redmond.corp.microsoft.com";
            var taskName = "filecleaner";
            Process p = new Process();
            p.StartInfo.LoadUserProfile = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "SCHTASKS.exe";
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.StartInfo.Arguments = String.Format("/Query /S {0} /TN {1} /FO TABLE /NH", host, taskName);

            p.Start();
            // Read the error stream
            string error = p.StandardError.ReadToEnd();

            //Read the output string
            p.StandardOutput.ReadLine();
            string tbl = p.StandardOutput.ReadToEnd();

            //Then wait for it to finish
            p.WaitForExit();

            //Check for an error
            if (!String.IsNullOrWhiteSpace(error))
            {
                throw new Exception(error);
            }

            //Parse output
            Console.WriteLine(tbl.Split(new String[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
            Console.ReadLine();
        }


        internal static void Main( string[] args )
        {
            var host = "lshost9102.redmond.corp.microsoft.com";
            //List<FileInfo> files;
            //DirectoryInfo dir = new DirectoryInfo( @"d:\enlist\sql\analytics\" );
            //files = dir.GetFiles( "*proj", SearchOption.AllDirectories ).ToList( );
            //files.AddRange( dir.GetFiles( "*targets", SearchOption.AllDirectories ) );
            //files.AddRange( dir.GetFiles( "*props", SearchOption.AllDirectories ) );
            //files.AddRange( dir.GetFiles( "*.settings", SearchOption.AllDirectories ) );
            //Console.WriteLine( string.Join( "\r\n",
            //             files.Select(
            //                 f => string.Format( "c:\\program files (x86)\\Notepad++\\notepad++.exe {0}", f.FullName ) )
            //                  .ToArray( ) ) );
            //return;

            //string zipFileName = "drop.zip";
            //string filePath = @"D:\enlist\CMCBX\dev\src\Test\CodeMine.IntegrationTests\SfmDrop";



            //return;
            //var intval = Convert.ChangeType(-420, typeof (Int64));

            Stopwatch sw = new Stopwatch( );

            ConcurrentQueue<WmiClass> WmiValues = new ConcurrentQueue<WmiClass>( );

            List<WmiClass> WmiVals = new List<WmiClass>( );


            //sw.MeasureProcess(
            //    () =>
            //        {

            //            WmiHelper.Snapshot<Win32_DiskDrive>().ForEach(p => WmiVals.Add(p));
            //            WmiHelper.Snapshot<Win32_ComputerSystem>().ForEach(p => WmiVals.Add(p));
            //            WmiHelper.Snapshot<Win32_Battery>().ForEach(p => WmiVals.Add(p));
            //            WmiHelper.Snapshot<Win32_Processor>().ForEach(p => WmiVals.Add(p));
            //            WmiHelper.Snapshot<Win32_NTDomain>().ForEach(p => WmiVals.Add(p));
            //            WmiHelper.Snapshot<Win32_OperatingSystem>().ForEach(p => WmiVals.Add(p));
            //            WmiHelper.Snapshot<Win32_LogicalDisk>().ForEach(p => WmiVals.Add(p));
            //        }, 1
            //    );

            //Console.WriteLine("Normal {0}", sw.Elapsed.ToString());

            //#region Parallel Invoke
            //#endregion Parallel Invoke

            //sw.MeasureProcess(() =>
            //        {
            //            Parallel.Invoke(
            //                () => { WmiHelper.Snapshot<Win32_DiskDrive>().ForEach(p => WmiValues.Enqueue(p)); },
            //                () => { WmiHelper.Snapshot<Win32_ComputerSystem>().ForEach(p => WmiValues.Enqueue(p)); },
            //                () => { WmiHelper.Snapshot<Win32_Battery>().ForEach(p => WmiValues.Enqueue(p)); },
            //                () => { WmiHelper.Snapshot<Win32_Processor>().ForEach(p => WmiValues.Enqueue(p)); },
            //                () => { WmiHelper.Snapshot<Win32_NTDomain>().ForEach(p => WmiValues.Enqueue(p)); },
            //                () => { WmiHelper.Snapshot<Win32_OperatingSystem>().ForEach(p => WmiValues.Enqueue(p)); },
            //                () => { WmiHelper.Snapshot<Win32_LogicalDisk>().ForEach(p => WmiValues.Enqueue(p)); }

            //                );
            //        }, 1
            //    );


            //Console.WriteLine("Parallel method {0}\r\n", sw.Elapsed.ToString());

            List<Win32_LogicalDisk> disks = WmiHelper.Snapshot<Win32_LogicalDisk>(host).ToList();

            foreach (var disk in disks) 
            {
                long free = (long)disk.FreeSpace;
                long size = (long)disk.Size;

                Console.WriteLine("{2} {0}/{1}", free.FormatFileSize(), size.FormatFileSize(), disk.Name);
            }
            Console.ReadLine();
            return;

            List<Win32_ScheduledJob> scheduledTasks = WmiHelper.Snapshot<Win32_ScheduledJob>(host).ToList();
            foreach (var task in scheduledTasks)
            {
                Console.WriteLine("{0} {1} {2} {3}", task.Name, task.Status, task.Owner, task.Notify);
            }

            List<Win32_Product> software = WmiHelper.Snapshot<Win32_Product>(host).ToList();
            foreach ( var win32Product in software )
            {
                Console.WriteLine( "* {0} * ", win32Product.Name );
            }


            return;
            try
            {
                ////sb.AppendFormat("Report for {0}.\r\n", WmiValues.OfType<Win32_ComputerSystem>().First().Name);
                //XmlDocument xml = new XmlDocument();

                //sw.MeasureProcess(
                //    () =>
                //    {
                //        xml.LoadXml(WmiHelper.SerializeToXml(WmiVals, WmiVals.Select(p => p.GetType()).ToList()));
                //        xml.Save("xmlreport01.xml");
                //    }, 1
                //    );

                //xml = new XmlDocument();
                //Console.WriteLine("Export List {0}\r\n", sw.Elapsed.ToString());


                //sw.MeasureProcess(
                //    () =>
                //    {

                //        xml.LoadXml(WmiHelper.SerializeToXml(WmiValues.ToList(), WmiValues.Select(p => p.GetType()).ToList()));
                //        xml.Save("xmlreport02.xml");
                //    }, 1
                //    );
                //xml = new XmlDocument();
                //Console.WriteLine("Export List {0}\r\n", sw.Elapsed.ToString());

            }
            catch ( Exception ex )
            {
                sb.AppendFormat( "{0}\r\n", ex.ToString( ) );
            }

            Console.WriteLine( sb.ToString( ) );

            // Console.ReadLine();


            return;
            // Dump the contents of HKEY_CLASSES_ROOT\*
            Console.WriteLine( "Getting the contents of HKCR\\* on the local machine" );
            RegistryKey localHKCR = Registry.ClassesRoot.OpenSubKey( "*", RegistryKeyPermissionCheck.ReadSubTree );
            Console.WriteLine( ParseKey( localHKCR ) );

            // Dump the contents of HKEY_CLASSES_ROOT\* on a remote machine.
            Console.WriteLine( );
            Console.WriteLine( "Getting the contents of HKCR\\* via OpenRemoteBaseKey" );
            RegistryKey remoteHKCR = RegistryKey.OpenRemoteBaseKey( RegistryHive.ClassesRoot, "codebarn" );
            Console.WriteLine( ParseKey( remoteHKCR.OpenSubKey( "*", RegistryKeyPermissionCheck.ReadSubTree ) ) );


            return;
            string logFile = Directory.GetCurrentDirectory( ) + "\\logfile.log";

            Log.AddTextListener( logFile );
            //Log.AddDefaultTextListener(Directory.GetCurrentDirectory());
            Log.TraceWarning( 40, "a warning message {0} ", "warning" );
            Log.TraceVerbose( "verbose message" );


            Log.Flush( );

            Console.WriteLine( logFile );
            return;
            string hindi = "श्रीगंगानगर। हनुमानगढ़ मार्ग पर लालगढ़ जाटान छावनी के नजदीक शनिवार सुबह सड़क से पन्द्रह";
            // string converted = System.Net.WebUtility.HtmlEncode(hindi);
            var hindichars = hindi.ToCharArray( );
            Console.WriteLine( ToUnicode( hindi ) );
            for ( int i = 0; i < hindi.Length; i++ )
            {
                //Console.WriteLine("{0} {1} {2}", i, hindi[i], ToUnicode(hindi[i].ToString()));
            }

            //foreach (var hindichar in hindichars)
            //    {
            //        Console.WriteLine(hindichar.ToString());
            //        int code = int.Parse(hindichar.ToString(), System.Globalization.NumberStyles.Any);
            //        Console.WriteLine("{0}", char.ConvertFromUtf32(code));
            //    }
            //System.IO.File.WriteAllText("sample.txt", converted);

            return;



            return;
            ExpItem expectedItem = null;
            expectedItem = new ExpItem( ) { ExpectedResultAmount = "stuff" };
            string x = expectedItem != null && expectedItem.ExpectedResultAmount != null
            ? expectedItem.ExpectedResultAmount
            : string.Empty;
            write( "." + x );

            return;
            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.Load("samplehtml.htm");

            //write(doc.IsNull());

            //var tablecollection = doc.DocumentNode.SelectNodes("//table");

            //string store = string.Empty;
            //if (tablecollection != null)
            //{
            //    foreach (HtmlNode table in tablecollection)
            //    {
            //        foreach (HtmlNode row in table.DescendantNodes().Where(desc => desc.Name.Equals("tr", StringComparison.OrdinalIgnoreCase) && desc.DescendantNodes().Any(child => child.Name.Equals("td", StringComparison.OrdinalIgnoreCase))))
            //        {
            //            store = string.Join("|", row.DescendantNodes().Where(
            //                desc => desc.Name.Equals("td", StringComparison.OrdinalIgnoreCase)).Select(
            //                    desc => desc.InnerText));

            //            sw.Write(store);
            //            sw.WriteLine();
            //        }
            //    }
            //}
            //sw.Flush();
            //sw.Close();

            return;
            //string stringToReverse = "A quick plan.";

            //string reversedString = string.Join(string.Empty, stringToReverse.ToCharArray().Reverse());
            //Console.WriteLine("{0} - {1}", stringToReverse, reversedString);

            //Console.ReadLine();
            return;
            Random rand = new Random( );

            DieRoller roller = new DieRoller( );

            Func<int, int, int> rollDice = ( dieCount, sides ) =>
            {
                Die[] dieArray = new Die[ dieCount ];
                for ( int i = 0; i < dieCount; i++ )
                {
                    dieArray[ i ] = new Die( sides );
                }
                return roller.RollDice( dieArray );
            };
            Action<int, int, int> rollIterate = ( diecount, sides, rollCount ) =>
            {
                for ( int i = 0; i < rollCount; i++ )
                {
                    int result = rollDice( diecount, sides );
                }
            };

            Func<int, int, int, int> rollDie = ( dieCount, sides, timesToRoll ) =>
            {
                Die die = new Die( sides );
                int sum = 0;
                for ( int iDie = 0; iDie < dieCount; iDie++ )
                {
                    for ( int iRoll = 0; iRoll < timesToRoll; iRoll++ )
                    {
                        sum += die.Roll( rand );
                    }
                }
                return sum;
            };

            // rollIterate(3, 6, 300);

            int total = 0;
            sw.MeasureProcess( ( ) => total = rollDie( 1, 6, 1000 ), 10000 );
            Console.WriteLine( "1: {0} {1}", total, sw.Elapsed.TotalSeconds );

            sw.MeasureProcess( ( ) => total = rollDie( 10, 6, 1000 ), 10000 );
            Console.WriteLine( "10: {0} {1}", total, sw.Elapsed.TotalSeconds );

            sw.MeasureProcess( ( ) => total = rollDie( 100, 6, 1000 ), 10000 );
            Console.WriteLine( "100: {0} {1}", total, sw.Elapsed.TotalSeconds );

            sw.MeasureProcess( ( ) => total = rollDie( 1000, 6, 1000 ), 10000 );
            Console.WriteLine( "1000: {0} {1}", total, sw.Elapsed.TotalSeconds );

            //Die d4 = Die.D4;
            //Die d20 = Die.D20;

            //for (int i = 0; i < 1000; i ++ )
            //{
            //    Console.Write("{0} {1} ", d4.Roll(rand), d20.Roll(rand));
            //    if (i % 15 == 0)
            //    {
            //        Console.Write("\r\n");
            //    }
            //}

            if ( Dbg.IsDebugMode )
            {
                Console.ReadLine( );
            }
        }

        private static string ToUnicode( string value )
        {
            MemoryStream ms = new MemoryStream( new UnicodeEncoding( ).GetBytes( value ) );
            StreamReader sr = new StreamReader( ms );
            string s = sr.ReadToEnd( );
            sr.Close( );
            return s;
        }

        //static unsafe void ToUpper(string str)
        //{
        //    fixed (char* pfixed = str)
        //        for (char* p = pfixed; *p != 0; p++)
        //            *p = char.ToUpper(*p);
        //}
        static void write( object message, params object[] args )
        {
            Console.Write( message.ToString( ), args );
        }

        #endregion Methods

        #region Nested Types

        public class ExpItem
        {
            #region Properties

            public string ExpectedResultAmount
            {
                get;
                set;
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}