using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperLibrary.Wmi
{
    /// <summary>
    /// Use the Win32_ScheduledJob class. Note that this class can only return jobs that are created using either a script or AT.exe. It cannot return information about jobs that are either created by or modified by the Scheduled Task wizard. 
    /// </summary>
    public class Win32_ScheduledJob : WmiClass
    {
        public string Caption;
        public string Command;
        public UInt32 DaysOfMonth;
        public UInt32 DaysOfWeek;
        public string Description;
        public DateTime ElapsedTime;
        public DateTime InstallDate;
        public bool InteractWithDesktop;
        public UInt32 JobId;
        public string JobStatus;
        public string Name;
        public string Notify;
        public string Owner;
        public UInt32 Priority;
        public bool RunRepeatedly;
        public DateTime StartTime;
        public string Status;
        public DateTime TimeSubmitted;
        public DateTime UntilTime;
    }
}