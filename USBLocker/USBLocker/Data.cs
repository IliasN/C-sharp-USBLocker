using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace USBLocker
{
    class Data
    {
        #region Fields

        private string _unlockCode;
        private string _unlockDriveCode;
        private Timer _tmrCheckDrive;
        private Timer _tmrGenerateCode;
        private Drives _drives;
        private bool _locked;
        private const string CODE_FILE = "code.txt";
        private Form1 _view;

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

        public Form1 View
        {
            get
            {
                return _view;
            }

            set
            {
                _view = value;
            }
        }

        #endregion

        #region Methodes

        #region Constructor

        public Data(Form1 view)
        {
            //Init vars
            _tmrCheckDrive = new Timer();
            _tmrCheckDrive.Interval = 1000;
            _tmrCheckDrive.Tick += new EventHandler(tmrCheckDrive_Tick);

            _tmrGenerateCode = new Timer();
            _tmrGenerateCode.Interval = 60000;
            _tmrGenerateCode.Tick += new EventHandler(tmrGenerateCode_Tick);

            this.View = view;

            this.Drives = new Drives();

            this.UnlockCode = "ok";

            this.LoadCode();
        }

        #endregion

        /// <summary>
        /// Start le timer
        /// </summary>
        public void Start()
        {
            _tmrCheckDrive.Start();
            _tmrGenerateCode.Start();
        }

        /// <summary>
        /// Stop le timer
        /// </summary>
        public void Stop()
        {
            _tmrCheckDrive.Stop();
            _tmrGenerateCode.Stop();
        }

        /// <summary>
        /// Verifie si la clé est entrée dans le poste et verifie le mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrCheckDrive_Tick(object sender, EventArgs e)
        {
            this.Drives.UpdateDrives();
            this.UnlockDriveCode = Drives.GetCode();
            if (this.Locked && this.UnlockDriveCode != null && this.UnlockDriveCode == this.UnlockCode)
            {
                this.Locked = false;
                this.View.Unlock();
                //MessageBox.Show("Unlock");
            }

            if (!this.Locked && (this.UnlockDriveCode == null || this.UnlockDriveCode != this.UnlockCode))
            {
                this.Locked = true;
                this.View.Lock();
                //MessageBox.Show("Lock");
            }
        }

        /// <summary>
        /// Genere un code different si la clé est presente est le modifie en consequence sur la clé et dans le logiciel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrGenerateCode_Tick(object sender, EventArgs e)
        {
            SHA1 encrypt = new SHA1CryptoServiceProvider();
            string newCode = BitConverter.ToString(encrypt.ComputeHash(Encoding.UTF8.GetBytes(DateTime.Now.ToString())));

            if (this.Drives.ChangeCode(newCode))
            {
                File.WriteAllText(CODE_FILE, newCode);
                this.UnlockCode = newCode;
            }
        }

        /// <summary>
        /// Charge le code depuis le fichier
        /// </summary>
        public void LoadCode()
        {
            if (File.Exists(CODE_FILE))
            {
                using (StreamReader reader = new StreamReader(CODE_FILE, Encoding.Default))
                {
                    string line = reader.ReadLine();
                    if (line != null)
                        this.UnlockCode = line;
                }
            }
            else
            {
                this.UnlockCode = "ntmdavid";
                File.WriteAllText(CODE_FILE, "ntmdavid");
            }
        }

        #endregion
    }
}
