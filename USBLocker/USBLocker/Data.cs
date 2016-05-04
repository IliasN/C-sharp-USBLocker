using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBLocker
{
    class Data
    {
        #region Fields

        private string _unlockCode;
        private string _unlockDriveCode;
        private Timer _tmrCheckDrive;
        private Drives _drives;
        private bool _locked;

        #endregion

        #region Properties

        public string UnlockCode
        {
            get
            {
                return _unlockCode;
            }

            set
            {
                _unlockCode = value;
            }
        }

        public string UnlockDriveCode
        {
            get
            {
                return _unlockDriveCode;
            }

            set
            {
                _unlockDriveCode = value;
            }
        }

        internal Drives Drives
        {
            get
            {
                return _drives;
            }

            set
            {
                _drives = value;
            }
        }

        public bool Locked
        {
            get
            {
                return _locked;
            }

            set
            {
                _locked = value;
            }
        }

        #endregion

        #region Methodes

        #region Constructor

        public Data()
        {
            //Init vars
            _tmrCheckDrive = new Timer();
            _tmrCheckDrive.Interval = 1000;
            _tmrCheckDrive.Tick += new EventHandler(tmrCheckDrive_Tick);
            _tmrCheckDrive.Start();

            this.Drives = new Drives();

            this.UnlockCode = "ok";
        }

        #endregion

        private void tmrCheckDrive_Tick(object sender, EventArgs e)
        {
            this.Drives.UpdateDrives();
            this.UnlockDriveCode = Drives.GetCode();
            if (this.Locked && this.UnlockDriveCode != null && this.UnlockDriveCode == this.UnlockCode)
            {
                this.Locked = false;
                MessageBox.Show("Unlock");
            }

            if (!this.Locked && (this.UnlockDriveCode == null || this.UnlockDriveCode != this.UnlockCode))
            {
                this.Locked = true;
                MessageBox.Show("Lock");
            }
        }

        #endregion
    }
}
