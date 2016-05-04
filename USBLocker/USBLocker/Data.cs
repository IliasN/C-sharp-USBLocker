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
        private string _unlockDrive;
        private Timer _tmrCheckDrive;
        private Drives _drives;

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

        public string UnlockDrive
        {
            get
            {
                return _unlockDrive;
            }

            set
            {
                _unlockDrive = value;
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

        #endregion

        #region Methodes

        #region Constructor

        public Data(Drives drives)
        {
            //Init vars
            _tmrCheckDrive = new Timer();
            _tmrCheckDrive.Interval = 1000;
            _tmrCheckDrive.Tick += new EventHandler(tmrCheckDrive_Tick);

            this.Drives = drives;
        }

        #endregion

        private void tmrCheckDrive_Tick(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
