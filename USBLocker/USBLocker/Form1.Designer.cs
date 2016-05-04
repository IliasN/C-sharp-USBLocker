namespace USBLocker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmrLock = new System.Windows.Forms.Timer(this.components);
            this.pibWallpaper = new System.Windows.Forms.PictureBox();
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pibWallpaper)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrLock
            // 
            this.tmrLock.Enabled = true;
            this.tmrLock.Tick += new System.EventHandler(this.tmrLock_Tick);
            // 
            // pibWallpaper
            // 
            this.pibWallpaper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pibWallpaper.Image = ((System.Drawing.Image)(resources.GetObject("pibWallpaper.Image")));
            this.pibWallpaper.Location = new System.Drawing.Point(0, 0);
            this.pibWallpaper.Name = "pibWallpaper";
            this.pibWallpaper.Size = new System.Drawing.Size(649, 349);
            this.pibWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pibWallpaper.TabIndex = 0;
            this.pibWallpaper.TabStop = false;
            // 
            // niMain
            // 
            this.niMain.Text = "notifyIcon1";
            this.niMain.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(648, 348);
            this.Controls.Add(this.pibWallpaper);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "USB locker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pibWallpaper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrLock;
        private System.Windows.Forms.PictureBox pibWallpaper;
        private System.Windows.Forms.NotifyIcon niMain;
    }
}

