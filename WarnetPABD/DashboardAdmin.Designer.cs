namespace WarnetPABD
{
    partial class DashboardAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnDevice = new System.Windows.Forms.Button();
            this.btnDataPemesan = new System.Windows.Forms.Button();
            this.btnDataPembayaran = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnKontrolUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTesKoneksi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDevice
            // 
            this.btnDevice.Location = new System.Drawing.Point(166, 123);
            this.btnDevice.Name = "btnDevice";
            this.btnDevice.Size = new System.Drawing.Size(150, 40);
            this.btnDevice.TabIndex = 0;
            this.btnDevice.Text = "Kelola Perangkat";
            this.btnDevice.UseVisualStyleBackColor = true;
            this.btnDevice.Click += new System.EventHandler(this.btnDevice_Click);
            // 
            // btnDataPemesan
            // 
            this.btnDataPemesan.Location = new System.Drawing.Point(427, 123);
            this.btnDataPemesan.Name = "btnDataPemesan";
            this.btnDataPemesan.Size = new System.Drawing.Size(150, 40);
            this.btnDataPemesan.TabIndex = 1;
            this.btnDataPemesan.Text = "Data Pemesanan";
            this.btnDataPemesan.UseVisualStyleBackColor = true;
            this.btnDataPemesan.Click += new System.EventHandler(this.btnDataPemesan_Click);
            // 
            // btnDataPembayaran
            // 
            this.btnDataPembayaran.Location = new System.Drawing.Point(427, 236);
            this.btnDataPembayaran.Name = "btnDataPembayaran";
            this.btnDataPembayaran.Size = new System.Drawing.Size(150, 40);
            this.btnDataPembayaran.TabIndex = 2;
            this.btnDataPembayaran.Text = "Data Pembayaran";
            this.btnDataPembayaran.UseVisualStyleBackColor = true;
            this.btnDataPembayaran.Click += new System.EventHandler(this.btnDataPembayaran_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(306, 376);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnKontrolUser
            // 
            this.btnKontrolUser.Location = new System.Drawing.Point(166, 236);
            this.btnKontrolUser.Name = "btnKontrolUser";
            this.btnKontrolUser.Size = new System.Drawing.Size(150, 40);
            this.btnKontrolUser.TabIndex = 4;
            this.btnKontrolUser.Text = "Kontrol Pengguna";
            this.btnKontrolUser.UseVisualStyleBackColor = true;
            this.btnKontrolUser.Click += new System.EventHandler(this.btnKontrolUser_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(230, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 65);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU ADMIN";
            // 
            // btnTesKoneksi
            // 
            this.btnTesKoneksi.Location = new System.Drawing.Point(427, 305);
            this.btnTesKoneksi.Name = "btnTesKoneksi";
            this.btnTesKoneksi.Size = new System.Drawing.Size(150, 40);
            this.btnTesKoneksi.TabIndex = 6;
            this.btnTesKoneksi.Text = "Test Koneksi";
            this.btnTesKoneksi.UseVisualStyleBackColor = true;
            this.btnTesKoneksi.Click += new System.EventHandler(this.btnTesKoneksi_Click);
            // 
            // DashboardAdmin
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTesKoneksi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKontrolUser);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnDataPembayaran);
            this.Controls.Add(this.btnDataPemesan);
            this.Controls.Add(this.btnDevice);
            this.Name = "DashboardAdmin";
            this.Text = "Dashboard Admin";
            this.Load += new System.EventHandler(this.DashboardAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDevice;
        private System.Windows.Forms.Button btnDataPemesan;
        private System.Windows.Forms.Button btnDataPembayaran;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnKontrolUser;  // Tombol untuk kontrol pengguna
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTesKoneksi;
    }
}
