namespace WarnetPABD
{
    partial class FormPembayaranAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPembayaran;
        private System.Windows.Forms.Label lblBookingID;
        private System.Windows.Forms.TextBox txtBookingID;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblDurasi;
        private System.Windows.Forms.TextBox txtDurasi;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.Label lblStatusPembayaran;
        private System.Windows.Forms.ComboBox cmbStatusPembayaran;
        private System.Windows.Forms.Label lblMetodePembayaran;
        private System.Windows.Forms.ComboBox cmbMetodePembayaran;
        private System.Windows.Forms.Button btnUpdatePembayaran;
        private System.Windows.Forms.Button btnDeletePembayaran;
        private System.Windows.Forms.Label lblTanggalBayar;
        private System.Windows.Forms.TextBox txtTanggalBayar;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Button btnToggle; // The toggle button to enable/disable Username and Add button
        private System.Windows.Forms.Button btnImport; // The Import button to open the PreviewPembayaran form

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
            this.dgvPembayaran = new System.Windows.Forms.DataGridView();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.txtBookingID = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblDurasi = new System.Windows.Forms.Label();
            this.txtDurasi = new System.Windows.Forms.TextBox();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.lblStatusPembayaran = new System.Windows.Forms.Label();
            this.cmbStatusPembayaran = new System.Windows.Forms.ComboBox();
            this.lblMetodePembayaran = new System.Windows.Forms.Label();
            this.cmbMetodePembayaran = new System.Windows.Forms.ComboBox();
            this.btnUpdatePembayaran = new System.Windows.Forms.Button();
            this.btnDeletePembayaran = new System.Windows.Forms.Button();
            this.lblTanggalBayar = new System.Windows.Forms.Label();
            this.txtTanggalBayar = new System.Windows.Forms.TextBox();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPembayaran
            // 
            this.dgvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembayaran.Location = new System.Drawing.Point(12, 12);
            this.dgvPembayaran.Name = "dgvPembayaran";
            this.dgvPembayaran.Size = new System.Drawing.Size(776, 200);
            this.dgvPembayaran.TabIndex = 0;
            this.dgvPembayaran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPembayaran_CellClick);
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.Location = new System.Drawing.Point(12, 220);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(63, 13);
            this.lblBookingID.TabIndex = 1;
            this.lblBookingID.Text = "Booking ID:";
            // 
            // txtBookingID
            // 
            this.txtBookingID.Location = new System.Drawing.Point(120, 217);
            this.txtBookingID.Name = "txtBookingID";
            this.txtBookingID.ReadOnly = true;
            this.txtBookingID.Size = new System.Drawing.Size(200, 20);
            this.txtBookingID.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 250);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(120, 247);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // lblDurasi
            // 
            this.lblDurasi.AutoSize = true;
            this.lblDurasi.Location = new System.Drawing.Point(12, 280);
            this.lblDurasi.Name = "lblDurasi";
            this.lblDurasi.Size = new System.Drawing.Size(40, 13);
            this.lblDurasi.TabIndex = 5;
            this.lblDurasi.Text = "Durasi:";
            // 
            // txtDurasi
            // 
            this.txtDurasi.Location = new System.Drawing.Point(120, 277);
            this.txtDurasi.Name = "txtDurasi";
            this.txtDurasi.Size = new System.Drawing.Size(200, 20);
            this.txtDurasi.TabIndex = 6;
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.Location = new System.Drawing.Point(12, 310);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(66, 13);
            this.lblTotalHarga.TabIndex = 7;
            this.lblTotalHarga.Text = "Total Harga:";
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Location = new System.Drawing.Point(120, 307);
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.Size = new System.Drawing.Size(200, 20);
            this.txtTotalHarga.TabIndex = 8;
            // 
            // lblStatusPembayaran
            // 
            this.lblStatusPembayaran.AutoSize = true;
            this.lblStatusPembayaran.Location = new System.Drawing.Point(12, 340);
            this.lblStatusPembayaran.Name = "lblStatusPembayaran";
            this.lblStatusPembayaran.Size = new System.Drawing.Size(102, 13);
            this.lblStatusPembayaran.TabIndex = 9;
            this.lblStatusPembayaran.Text = "Status Pembayaran:";
            // 
            // cmbStatusPembayaran
            // 
            this.cmbStatusPembayaran.FormattingEnabled = true;
            this.cmbStatusPembayaran.Items.AddRange(new object[] {
            "PENDING",
            "LUNAS"});
            this.cmbStatusPembayaran.Location = new System.Drawing.Point(120, 337);
            this.cmbStatusPembayaran.Name = "cmbStatusPembayaran";
            this.cmbStatusPembayaran.Size = new System.Drawing.Size(200, 21);
            this.cmbStatusPembayaran.TabIndex = 10;
            // 
            // lblMetodePembayaran
            // 
            this.lblMetodePembayaran.AutoSize = true;
            this.lblMetodePembayaran.Location = new System.Drawing.Point(12, 370);
            this.lblMetodePembayaran.Name = "lblMetodePembayaran";
            this.lblMetodePembayaran.Size = new System.Drawing.Size(108, 13);
            this.lblMetodePembayaran.TabIndex = 11;
            this.lblMetodePembayaran.Text = "Metode Pembayaran:";
            // 
            // cmbMetodePembayaran
            // 
            this.cmbMetodePembayaran.FormattingEnabled = true;
            this.cmbMetodePembayaran.Items.AddRange(new object[] {
            "CASH"});
            this.cmbMetodePembayaran.Location = new System.Drawing.Point(120, 367);
            this.cmbMetodePembayaran.Name = "cmbMetodePembayaran";
            this.cmbMetodePembayaran.Size = new System.Drawing.Size(200, 21);
            this.cmbMetodePembayaran.TabIndex = 12;
            // 
            // btnUpdatePembayaran
            // 
            this.btnUpdatePembayaran.Location = new System.Drawing.Point(15, 420);
            this.btnUpdatePembayaran.Name = "btnUpdatePembayaran";
            this.btnUpdatePembayaran.Size = new System.Drawing.Size(115, 33);
            this.btnUpdatePembayaran.TabIndex = 16;
            this.btnUpdatePembayaran.Text = "Update";
            this.btnUpdatePembayaran.UseVisualStyleBackColor = true;
            this.btnUpdatePembayaran.Click += new System.EventHandler(this.btnUpdatePembayaran_Click);
            // 
            // btnDeletePembayaran
            // 
            this.btnDeletePembayaran.Location = new System.Drawing.Point(208, 420);
            this.btnDeletePembayaran.Name = "btnDeletePembayaran";
            this.btnDeletePembayaran.Size = new System.Drawing.Size(112, 33);
            this.btnDeletePembayaran.TabIndex = 17;
            this.btnDeletePembayaran.Text = "Delete";
            this.btnDeletePembayaran.UseVisualStyleBackColor = true;
            this.btnDeletePembayaran.Click += new System.EventHandler(this.btnDeletePembayaran_Click);
            // 
            // lblTanggalBayar
            // 
            this.lblTanggalBayar.Location = new System.Drawing.Point(0, 0);
            this.lblTanggalBayar.Name = "lblTanggalBayar";
            this.lblTanggalBayar.Size = new System.Drawing.Size(100, 23);
            this.lblTanggalBayar.TabIndex = 13;
            // 
            // txtTanggalBayar
            // 
            this.txtTanggalBayar.Location = new System.Drawing.Point(0, 0);
            this.txtTanggalBayar.Name = "txtTanggalBayar";
            this.txtTanggalBayar.Size = new System.Drawing.Size(100, 20);
            this.txtTanggalBayar.TabIndex = 14;
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(355, 277);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(166, 34);
            this.btnShowReport.TabIndex = 18;
            this.btnShowReport.Text = "LIHAT LAPORAN(Report)";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 



            // lblTanggalBayar
            this.lblTanggalBayar.AutoSize = true;
            this.lblTanggalBayar.Location = new System.Drawing.Point(12, 400); // posisi di bawah metode pembayaran
            this.lblTanggalBayar.Name = "lblTanggalBayar";
            this.lblTanggalBayar.Size = new System.Drawing.Size(80, 13);
            this.lblTanggalBayar.TabIndex = 13;
            this.lblTanggalBayar.Text = "Tanggal Bayar:";

            // txtTanggalBayar
            this.txtTanggalBayar.Location = new System.Drawing.Point(120, 397); // sejajar dengan label
            this.txtTanggalBayar.Name = "txtTanggalBayar";
            this.txtTanggalBayar.Size = new System.Drawing.Size(200, 20);
            this.txtTanggalBayar.TabIndex = 14;

            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(355, 218);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(166, 36);
            this.btnToggle.TabIndex = 19;
            this.btnToggle.Text = "AKTIFKAN KOLOM USERNAME";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(355, 335);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(166, 36);
            this.btnImport.TabIndex = 20;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FormPembayaranAdmin
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvPembayaran);
            this.Controls.Add(this.lblBookingID);
            this.Controls.Add(this.txtBookingID);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblDurasi);
            this.Controls.Add(this.txtDurasi);
            this.Controls.Add(this.lblTotalHarga);
            this.Controls.Add(this.txtTotalHarga);
            this.Controls.Add(this.lblStatusPembayaran);
            this.Controls.Add(this.cmbStatusPembayaran);
            this.Controls.Add(this.lblMetodePembayaran);
            this.Controls.Add(this.cmbMetodePembayaran);
            this.Controls.Add(this.lblTanggalBayar);
            this.Controls.Add(this.txtTanggalBayar);
            this.Controls.Add(this.btnUpdatePembayaran);
            this.Controls.Add(this.btnDeletePembayaran);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.btnImport);
            this.Name = "FormPembayaranAdmin";
            this.Text = "Data Pembayaran";
            this.Load += new System.EventHandler(this.FormPembayaranAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
