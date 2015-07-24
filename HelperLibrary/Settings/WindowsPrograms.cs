namespace HelperLibrary
{
    using System;
    using System.Management;
    
    using Microsoft.Win32;

    public class WindowsPrograms
    {
        #region Properties

        public static bool IsMSMSQInstalled
        {
            get
            {
                return false;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// EWWWWW
        /// </summary>
        public static void GetInstalled()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        if (sk.GetValue("DisplayName").IsNullOrEmpty())
                        {
                            string missingFileOutput = String.Format("{0} - {1}", sk.GetValue("InstallSource"), skName);
                            // Console.WriteLine(missingFileOutput);
                        }
                        else
                        {
                            // Console.WriteLine(sk.GetValue("DisplayName"));
                        }
                    }
                }
            }
        }

        public static void InstallMsmq()
        {
            // 2008 only understands the second portion, not the MSMQ-Container; prefix
            string MsmqCoreVariable = "MSMQ-Container;MSMQ-Server /norestart";
            string MsmqADVariable = "MSMQ-Container;MSMQ-ADIntegration /norestart";
            using (System.Diagnostics.Process MSMQInstall = System.Diagnostics.Process.Start("ocsetup.exe", MsmqCoreVariable))
            {
                MSMQInstall.WaitForExit();
                MSMQInstall.Close();
            }
            using (System.Diagnostics.Process MSMQADInstall = System.Diagnostics.Process.Start("ocsetup.exe", MsmqADVariable))
            {
                MSMQADInstall.WaitForExit();
                MSMQADInstall.Close();
            }
        }

        #endregion Methods
    }
}