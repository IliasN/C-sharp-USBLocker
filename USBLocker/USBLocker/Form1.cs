using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBLocker
{
    public partial class Form1 : Form
    {
        #region Fields

        private bool _locked;

        #endregion

        #region Properties

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

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            Data data = new Data(this);
            data.Start();
        }

        public void Lock()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Locked = true;
        }

        public void Unlock()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.Locked = false;
        }

        #endregion

    }
}
