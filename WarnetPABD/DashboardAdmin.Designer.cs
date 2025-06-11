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
            this.btnKontrolUser = new System.Windows.Forms.Button();  // Tombol untuk kontrol pengguna

            this.SuspendLayout();
            // 
            // btnDevice
            // 
            this.btnDevice.Location = new System.Drawing.Point(50, 50);  // Atur posisi tombol sesuai kebutuhan
            this.btnDevice.Name = "btnDevice";
            this.btnDevice.Size = new System.Drawing.Size(150, 40);
            this.btnDevice.TabIndex = 0;
            this.btnDevice.Text = "Kelola Perangkat";
            this.btnDevice.UseVisualStyleBackColor = true;
            this.btnDevice.Click += new System.EventHandler(this.btnDevice_Click);
            // 
            // btnDataPemesan
            // 
            this.btnDataPemesan.Location = new System.Drawing.Point(50, 100);
            this.btnDataPemesan.Name = "btnDataPemesan";
            this.btnDataPemesan.Size = new System.Drawing.Size(150, 40);
            this.btnDataPemesan.TabIndex = 1;
            this.btnDataPemesan.Text = "Data Pemesanan";
            this.btnDataPemesan.UseVisualStyleBackColor = true;
            this.btnDataPemesan.Click += new System.EventHandler(this.btnDataPemesan_Click);
            // 
            // btnDataPembayaran
            // 
            this.btnDataPembayaran.Location = new System.Drawing.Point(50, 150);
            this.btnDataPembayaran.Name = "btnDataPembayaran";
            this.btnDataPembayaran.Size = new System.Drawing.Size(150, 40);
            this.btnDataPembayaran.TabIndex = 2;
            this.btnDataPembayaran.Text = "Data Pembayaran";
            this.btnDataPembayaran.UseVisualStyleBackColor = true;
            this.btnDataPembayaran.Click += new System.EventHandler(this.btnDataPembayaran_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(50, 200);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnKontrolUser
            // 
            this.btnKontrolUser.Location = new System.Drawing.Point(50, 250);  // Posisi tombol kontrol pengguna
            this.btnKontrolUser.Name = "btnKontrolUser";
            this.btnKontrolUser.Size = new System.Drawing.Size(150, 40);
            this.btnKontrolUser.TabIndex = 4;
            this.btnKontrolUser.Text = "Kontrol Pengguna";
            this.btnKontrolUser.UseVisualStyleBackColor = true;
            this.btnKontrolUser.Click += new System.EventHandler(this.btnKontrolUser_Click);

            // 
            // DashboardAdmin
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKontrolUser);  // Tambahkan tombol kontrol pengguna
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnDataPembayaran);
            this.Controls.Add(this.btnDataPemesan);
            this.Controls.Add(this.btnDevice);
            this.Name = "DashboardAdmin";
            this.Text = "Dashboard Admin";
            this.Load += new System.EventHandler(this.DashboardAdmin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDevice;
        private System.Windows.Forms.Button btnDataPemesan;
        private System.Windows.Forms.Button btnDataPembayaran;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnKontrolUser;  // Tombol untuk kontrol pengguna
    }
}
