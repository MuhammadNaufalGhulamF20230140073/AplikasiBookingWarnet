using System.Windows.Forms;

namespace WarnetPABD
{
    partial class BookingUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, False.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingUser));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtBookingID = new System.Windows.Forms.TextBox();
            this.btnBookDevice = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(150, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(144, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // cmbDevices
            // 
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(150, 70);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(144, 21);
            this.cmbDevices.TabIndex = 3;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(150, 110);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(32, 20);
            this.txtDuration.TabIndex = 5;
            // 
            // txtBookingID
            // 
            this.txtBookingID.Enabled = false;
            this.txtBookingID.Location = new System.Drawing.Point(150, 150);
            this.txtBookingID.Name = "txtBookingID";
            this.txtBookingID.Size = new System.Drawing.Size(144, 20);
            this.txtBookingID.TabIndex = 7;
            // 
            // btnBookDevice
            // 
            this.btnBookDevice.Location = new System.Drawing.Point(150, 190);
            this.btnBookDevice.Name = "btnBookDevice";
            this.btnBookDevice.Size = new System.Drawing.Size(92, 30);
            this.btnBookDevice.TabIndex = 8;
            this.btnBookDevice.Text = "Pesan";
            this.btnBookDevice.UseVisualStyleBackColor = true;
            this.btnBookDevice.Click += new System.EventHandler(this.btnBookDevice_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(50, 33);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(50, 73);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(43, 13);
            this.lblDevice.TabIndex = 2;
            this.lblDevice.Text = "NO PC:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(50, 113);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(40, 13);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Durasi:";
            this.lblDuration.Click += new System.EventHandler(this.lblDuration_Click);
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.Location = new System.Drawing.Point(50, 153);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(63, 13);
            this.lblBookingID.TabIndex = 6;
            this.lblBookingID.Text = "Booking ID:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(356, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(389, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BookingUser
            // 
            this.ClientSize = new System.Drawing.Size(757, 250);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBookDevice);
            this.Controls.Add(this.txtBookingID);
            this.Controls.Add(this.lblBookingID);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Name = "BookingUser";
            this.Text = "Booking User";
            this.Load += new System.EventHandler(this.BookingUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtBookingID;
        private System.Windows.Forms.Button btnBookDevice;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblBookingID;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
