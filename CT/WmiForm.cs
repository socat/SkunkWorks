using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;

namespace diskdrive_info
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get all the disk drives
            ManagementObjectSearcher mosDisk = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            // Loop through each object (disk) retrieved by WMI
            foreach (ManagementObject moDisk in mosDisk.Get())
            {
                cmbHdd.Items.Add(moDisk["Model"].ToString());
            }
        }

        private void cmbHdd_SelectedIndexChanged(object sender, EventArgs e)
        {
    try
    {
        ManagementObjectSearcher mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Model = '" + cmbHdd.SelectedItem + "'");
        foreach (ManagementObject moDisk in mosDisks.Get())
        {

            lblSystemName.Text = "SystemName: " + moDisk["systemname"];
            lblType.Text = "Type: " + moDisk["MediaType"].ToString();
            lblModel.Text = "Model: " + moDisk["Model"].ToString();
            lblCapacity.Text = "Capacity: " + moDisk["Size"].ToString() + " bytes (" + Math.Round(((((double)Convert.ToDouble(moDisk["Size"]) / 1024) / 1024) / 1024), 2) + " GB)";
            lblPartitions.Text = "Partitions: " + moDisk["Partitions"].ToString();
            lblSectors.Text = "Sectors: " + moDisk["SectorsPerTrack"].ToString();
            lblSignature.Text = "Signature: " + moDisk["Signature"].ToString();
            lblFirmware.Text = "Firmware: " + moDisk["FirmwareRevision"].ToString();
            lblFirmware.Text = "Firmware: " + moDisk["FirmwareRevision"] == null ? "Not Available" : moDisk["FirmwareRevision"].ToString();
            lblcapability_desc.Text = "Capability Description: " + moDisk["CapabilityDescription"].ToString();
            lblAvailability.Text = "Availability: " + moDisk["Availability"].ToString();
            lblbytepersector.Text = "Bytes per Sector: " + moDisk["BytesPerSector"].ToString();
            lbl_deviceid.Text = "Device ID: " + moDisk["systemname"].ToString();
        }
    }
    catch (Exception exp)
    {
        lblError.Text = "Some properties were not shown due to WMI errors or member not available on this system";
    }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //lblSystemName.Text = string.Empty;
            lblSystemName.Text = "SystemName: " + "";
            lblType.Text = "Type: " + "";
            lblModel.Text = "Model: " + "";
            lblCapacity.Text = "Capacity: " + "";
            lblPartitions.Text = "Partitions: " + "";
            lblSectors.Text = "Sectors: " + "";
            lblSignature.Text = "Signature: " + "";
            lblFirmware.Text = "Firmware: " + "";
            lblError.Text = String.Empty;
            cmbHdd.Items.Clear();
            cmbHdd.Text = "";
            ManagementObjectSearcher mosDisk = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject moDisk in mosDisk.Get())
            {
                cmbHdd.Items.Add(moDisk["Model"].ToString());
            }
        }
    }
}