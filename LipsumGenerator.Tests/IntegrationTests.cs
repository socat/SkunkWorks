using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LipsumGeneratorTests
{

    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void IntegrationTestViaConsoleTestRunner()
        {
            //string[] args = new string[1];
            //dynamic ob = new CT.ProgramTestInterface();
            //ob.Runner(args);

        }


        [TestMethod]
        public void stuff( )
        {
            List<FileInfo> files;
            DirectoryInfo dir = new DirectoryInfo( @"d:\enlist\sql\analytics\" );
            files = dir.GetFiles( "*proj", SearchOption.AllDirectories ).ToList( );
            files.AddRange( dir.GetFiles( "*targets", SearchOption.AllDirectories ) );
            files.AddRange( dir.GetFiles( "*props", SearchOption.AllDirectories ) );
            Console.WriteLine( string.Join( "\r\n",
                         files.Select(
                             f => string.Format( "c:\\program files (x86)\\Notepad++\\notepad++.exe {0}", f.FullName ) )
                              .ToArray( ) ) );

        }

    }
}
