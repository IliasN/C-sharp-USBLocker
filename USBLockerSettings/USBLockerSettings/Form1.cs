using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBLockerSettings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDevices.Items.Clear();
            DriveInfo[] driveList = DriveInfo.GetDrives();

            foreach (DriveInfo drive in driveList)
            {
                cmbDevices.Items.Add(drive.Name.ToString());
            }
            cmbDevices.SelectedIndex = 0;

        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            try
            {
                SHA1 encrypt = new SHA1CryptoServiceProvider();
                string newCode = BitConverter.ToString(encrypt.ComputeHash(Encoding.UTF8.GetBytes(DateTime.Now.ToString())));

                File.WriteAllText("code.txt", newCode);
                File.WriteAllText(cmbDevices.SelectedItem + "usblock.txt", newCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Form1_Load(this,e);
            }
        }
    }
}
