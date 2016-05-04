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
            //Init vars
            this.DrivesPath = new List<string>();
            //Get drives
            DriveInfo[] driveList = DriveInfo.GetDrives();

            foreach (DriveInfo drive in driveList)
            {
                this.DrivesPath.Add(drive.Name.ToString());
            }

        }

        #endregion

        /// <summary>
        /// Check if unlock file exists in all drives
        /// </summary>
        /// <returns>The path of the drives where the file is located</returns>
        public string CheckFile()
        {
            foreach (var drive in this.DrivesPath)
            {
                if (File.Exists(drive + FILE))
                    return drive + FILE;
            }
            return null;
        }

        /// <summary>
        /// Get the code found on the first line of the unlock file
        /// </summary>
        /// <returns>The code found</returns>
        public string GetCode()
        {
            string unlockDrive = CheckFile();
            if (unlockDrive != null)
            {
                using (StreamReader reader = new StreamReader(unlockDrive, Encoding.Default))
                {
                    return reader.ReadLine();
                }
            }
            return null;
        }

        /// <summary>
        /// Update the drives to check if new drives has been connected
        /// </summary>
        public void UpdateDrives()
        {
            this.DrivesPath.Clear();
            //Get drives
            DriveInfo[] driveList = DriveInfo.GetDrives();

            foreach (DriveInfo drive in driveList)
            {
                this.DrivesPath.Add(drive.Name.ToString());
            }
        }

        public bool ChangeCode(string code)
        {
            string path = CheckFile();
            if (path != null)
            {
                File.WriteAllText(path, code);
                return true;
            }
            return false;
        }

        #endregion
    }
}
