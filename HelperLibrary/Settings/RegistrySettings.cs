namespace HelperLibrary
{
    using System;

    using Microsoft.Win32;

    public static partial class Registry
    {
        #region Fields

        static RegistryKey HklmFileSystem = null;
        static string RegistryLocation_FileSystem = @"System\CurrentControlSet\Control\FileSystem";
        static string RegistryValue_Disable8dot31 = @"NtfsDisable8dot3NameCreation";
        static string RegistryValue_DisableLastAccess = @"NtfsDisableLastAccessUpdate";

        #endregion Fields

        #region Enumerations

        /// <summary>
        /// Settings that determine how NTFS volumes create 8.3 short file names.
        /// </summary>
        public enum Disable8Dot3 : int
        {
            /// <summary>
            /// NTFS creates short file names. This setting enables applications that cannot process long file names and computers that use differentcode pages to find the files.
            /// </summary>
            CreateShortFileNames = 0,
            /// <summary>
            /// NTFS does not create short file names. Although this setting increases file performance, applications that cannot process long file names, and computers that use different code pages, might not be able to find the files.
            /// </summary>
            DisableShortFileNames = 1,
            /// <summary>
            /// NTFS sets the 8.3 naming convention creation on a per volume basis.
            /// </summary>
            PerVolume = 2,
            /// <summary>
            /// NTFS disables 8dot3 name creation on all volumes except the system volume.
            /// </summary>
            EnabledOnSystemVolume = 3
        }

        /// <summary>
        /// Settings that determine how the NTFS volumes update the last accessed time stamp when a file is opened.
        /// </summary>
        public enum DisableLastAccess : int
        {
            /// <summary>
            /// NTFS updates the last-accessed timestamp of a file whenever that file is opened.
            /// </summary>
            UpdateLastAccess = 0,
            /// <summary>
            /// NTFS does not update the last-access timestamp of a file when that file is opened.
            /// </summary>
            DoNotUpdateLastAccess = 1
        }

        #endregion Enumerations

        #region Properties

        /// <summary>
        /// Gets or sets the NtfsDisable8dot3NameCreation in the registry.
        /// </summary>
        public static Disable8Dot3 Disable8Dot3Value
        {
            get
            {
                using (HklmFileSystem = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegistryLocation_FileSystem, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    return (Disable8Dot3)Enum.Parse(typeof(Disable8Dot3), HklmFileSystem.GetValue(RegistryValue_Disable8dot31).ToString());
                }
            }
            set
            {
                using (HklmFileSystem = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegistryLocation_FileSystem, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    HklmFileSystem.SetValue(RegistryValue_Disable8dot31, (int)value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the NtfsDisableLastAccessUpdate value from the registry.
        /// </summary>
        public static DisableLastAccess DisableLastAccessValue
        {
            get
            {
                using (HklmFileSystem = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegistryLocation_FileSystem, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    return (DisableLastAccess)Enum.Parse(typeof(DisableLastAccess), HklmFileSystem.GetValue(RegistryValue_DisableLastAccess).ToString());
                }
            }
            set
            {
                using (HklmFileSystem = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegistryLocation_FileSystem, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    HklmFileSystem.SetValue(RegistryValue_DisableLastAccess, (int)value);
                }
            }
        }

        #endregion Properties
    }
}