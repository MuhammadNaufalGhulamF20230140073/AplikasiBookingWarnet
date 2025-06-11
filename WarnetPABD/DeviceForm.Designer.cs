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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDevices
            // 
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Location = new System.Drawing.Point(30, 150);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(600, 200);
            this.dgvDevices.TabIndex = 0;
            this.dgvDevices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevices_CellClick);
            // 
            // lblDeviceID
            // 
            this.lblDeviceID.AutoSize = true;
            this.lblDeviceID.Location = new System.Drawing.Point(30, 20);
            this.lblDeviceID.Name = "lblDeviceID";
            this.lblDeviceID.Size = new System.Drawing.Size(58, 13);
            this.lblDeviceID.TabIndex = 1;
            this.lblDeviceID.Text = "Device ID:";
            // 
            // lblSpek
            // 
            this.lblSpek.AutoSize = true;
            this.lblSpek.Location = new System.Drawing.Point(30, 50);
            this.lblSpek.Name = "lblSpek";
            this.lblSpek.Size = new System.Drawing.Size(39, 13);
            this.lblSpek.TabIndex = 2;
            this.lblSpek.Text = "Spek:";
            // 
            // lblLokasiPC
            // 
            this.lblLokasiPC.AutoSize = true;
            this.lblLokasiPC.Location = new System.Drawing.Point(30, 80);
            this.lblLokasiPC.Name = "lblLokasiPC";
            this.lblLokasiPC.Size = new System.Drawing.Size(59, 13);
            this.lblLokasiPC.TabIndex = 3;
            this.lblLokasiPC.Text = "Lokasi PC:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Location = new System.Drawing.Point(120, 20);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(100, 20);
            this.txtDeviceID.TabIndex = 5;
            // 
            // txtSpek
            // 
            this.txtSpek.Location = new System.Drawing.Point(120, 50);
            this.txtSpek.Name = "txtSpek";
            this.txtSpek.Size = new System.Drawing.Size(200, 20);
            this.txtSpek.TabIndex = 6;
            // 
            // txtLokasiPC
            // 
            this.txtLokasiPC.Location = new System.Drawing.Point(120, 80);
            this.txtLokasiPC.Name = "txtLokasiPC";
            this.txtLokasiPC.Size = new System.Drawing.Size(200, 20);
            this.txtLokasiPC.TabIndex = 7;
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
            this.cmbStatus.Location = new System.Drawing.Point(120, 110);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 8;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(30, 370);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(75, 23);
            this.btnAddDevice.TabIndex = 9;
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnUpdateDevice
            // 
            this.btnUpdateDevice.Location = new System.Drawing.Point(120, 370);
            this.btnUpdateDevice.Name = "btnUpdateDevice";
            this.btnUpdateDevice.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDevice.TabIndex = 10;
            this.btnUpdateDevice.Text = "Update Device";
            this.btnUpdateDevice.UseVisualStyleBackColor = true;
            this.btnUpdateDevice.Click += new System.EventHandler(this.btnUpdateDevice_Click);
            // 
            // btnDeleteDevice
            // 
            this.btnDeleteDevice.Location = new System.Drawing.Point(210, 370);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDevice.TabIndex = 11;
            this.btnDeleteDevice.Text = "Delete Device";
            this.btnDeleteDevice.UseVisualStyleBackColor = true;
            this.btnDeleteDevice.Click += new System.EventHandler(this.btnDeleteDevice_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(300, 370);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DeviceForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 450);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
