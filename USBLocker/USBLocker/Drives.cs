using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace USBLocker
{
    class Drives
    {
        #region Fields

        private List<string> _drivesPath;
        private const string FILE = "usblock.txt";

        #endregion

        #region Properties

        public List<string> DrivesPath
        {
            get
            {
                return _drivesPath;
            }

            set
            {
                _drivesPath = value;
            }
        }

        #endregion

        #region Methodes

        #region Constructor

        public Drives()
        {
            DriveInfo[] driveList = DriveInfo.GetDrives();

            foreach (DriveInfo drive in driveList)
            {
                this.DrivesPath.Add(drive.Name);
            }

        }

        #endregion

        public bool CheckFile()
        {
            foreach (var drive in this.DrivesPath)
            {
                if (File.Exists(drive + FILE))
                    return true;
            }
            return false;
        }

        #endregion
    }
}
