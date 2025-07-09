namespace WarnetPABD
{
    partial class DeviceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Label lblDeviceID;
        private System.Windows.Forms.Label lblSpek;
        private System.Windows.Forms.Label lblLokasiPC;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtDeviceID;
        private System.Windows.Forms.TextBox txtSpek;
        private System.Windows.Forms.TextBox txtLokasiPC;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnUpdateDevice;
        private System.Windows.Forms.Button btnDeleteDevice;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnImport; // <- Sudah diganti dari button1

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.lblDeviceID = new System.Windows.Forms.Label();
            this.lblSpek = new System.Windows.Forms.Label();
            this.lblLokasiPC = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.txtSpek = new System.Windows.Forms.TextBox();
            this.txtLokasiPC = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnUpdateDevice = new System.Windows.Forms.Button();
            this.btnDeleteDevice = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDevices
            // 
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Location = new System.Drawing.Point(33, 205);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(640, 233);
            this.dgvDevices.TabIndex = 0;
            this.dgvDevices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevices_CellClick);
            // 
            // lblDeviceID
            // 
            this.lblDeviceID.AutoSize = true;
            this.lblDeviceID.Location = new System.Drawing.Point(30, 30);
            this.lblDeviceID.Name = "lblDeviceID";
            this.lblDeviceID.Size = new System.Drawing.Size(58, 13);
            this.lblDeviceID.TabIndex = 1;
            this.lblDeviceID.Text = "Device ID:";
            // 
            // lblSpek
            // 
            this.lblSpek.AutoSize = true;
            this.lblSpek.Location = new System.Drawing.Point(30, 60);
            this.lblSpek.Name = "lblSpek";
            this.lblSpek.Size = new System.Drawing.Size(35, 13);
            this.lblSpek.TabIndex = 3;
            this.lblSpek.Text = "Spek:";
            // 
            // lblLokasiPC
            // 
            this.lblLokasiPC.AutoSize = true;
            this.lblLokasiPC.Location = new System.Drawing.Point(30, 90);
            this.lblLokasiPC.Name = "lblLokasiPC";
            this.lblLokasiPC.Size = new System.Drawing.Size(58, 13);
            this.lblLokasiPC.TabIndex = 5;
            this.lblLokasiPC.Text = "Lokasi PC:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status:";
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Location = new System.Drawing.Point(120, 27);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.ReadOnly = false;
            this.txtDeviceID.Size = new System.Drawing.Size(100, 20);
            this.txtDeviceID.TabIndex = 2;
            this.txtDeviceID.TextChanged += new System.EventHandler(this.txtDeviceID_TextChanged);
            // 
            // txtSpek
            // 
            this.txtSpek.Location = new System.Drawing.Point(120, 57);
            this.txtSpek.Name = "txtSpek";
            this.txtSpek.Size = new System.Drawing.Size(240, 20);
            this.txtSpek.TabIndex = 4;
            // 
            // txtLokasiPC
            // 
            this.txtLokasiPC.Location = new System.Drawing.Point(120, 87);
            this.txtLokasiPC.Name = "txtLokasiPC";
            this.txtLokasiPC.Size = new System.Drawing.Size(100, 20);
            this.txtLokasiPC.TabIndex = 6;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Tidak Terpakai",
            "Terpakai",
            "Rusak",
            "Maintenance"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 117);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(142, 21);
            this.cmbStatus.TabIndex = 8;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(400, 17);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(110, 30);
            this.btnAddDevice.TabIndex = 9;
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnUpdateDevice
            // 
            this.btnUpdateDevice.Location = new System.Drawing.Point(400, 70);
            this.btnUpdateDevice.Name = "btnUpdateDevice";
            this.btnUpdateDevice.Size = new System.Drawing.Size(110, 30);
            this.btnUpdateDevice.TabIndex = 10;
            this.btnUpdateDevice.Text = "Update Device";
            this.btnUpdateDevice.UseVisualStyleBackColor = true;
            this.btnUpdateDevice.Click += new System.EventHandler(this.btnUpdateDevice_Click);
            // 
            // btnDeleteDevice
            // 
            this.btnDeleteDevice.Location = new System.Drawing.Point(400, 120);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteDevice.TabIndex = 11;
            this.btnDeleteDevice.Text = "Delete Device";
            this.btnDeleteDevice.UseVisualStyleBackColor = true;
            this.btnDeleteDevice.Click += new System.EventHandler(this.btnDeleteDevice_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(539, 120);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.DarkOrange;
            this.btnImport.Location = new System.Drawing.Point(539, 17);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(110, 30);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // DeviceForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteDevice);
            this.Controls.Add(this.btnUpdateDevice);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtLokasiPC);
            this.Controls.Add(this.txtSpek);
            this.Controls.Add(this.txtDeviceID);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblLokasiPC);
            this.Controls.Add(this.lblSpek);
            this.Controls.Add(this.lblDeviceID);
            this.Controls.Add(this.dgvDevices);
            this.Name = "DeviceForm";
            this.Text = "Manage Devices";
            this.Load += new System.EventHandler(this.DeviceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
