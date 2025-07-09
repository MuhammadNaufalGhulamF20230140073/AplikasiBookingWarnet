namespace WarnetPABD
{
    partial class PembayaranForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBookingID;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblStatusPembayaran;
        private System.Windows.Forms.Label lblMetodePembayaran;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.TextBox txtBookingID;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtStatusPembayaran;
        private System.Windows.Forms.TextBox txtMetodePembayaran;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.Button btnPay;

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
            this.lblBookingID = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblStatusPembayaran = new System.Windows.Forms.Label();
            this.lblMetodePembayaran = new System.Windows.Forms.Label();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.txtBookingID = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtStatusPembayaran = new System.Windows.Forms.TextBox();
            this.txtMetodePembayaran = new System.Windows.Forms.TextBox();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.Location = new System.Drawing.Point(40, 30);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(63, 13);
            this.lblBookingID.TabIndex = 0;
            this.lblBookingID.Text = "Booking ID:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(40, 60);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // lblStatusPembayaran
            // 
            this.lblStatusPembayaran.AutoSize = true;
            this.lblStatusPembayaran.Location = new System.Drawing.Point(40, 90);
            this.lblStatusPembayaran.Name = "lblStatusPembayaran";
            this.lblStatusPembayaran.Size = new System.Drawing.Size(102, 13);
            this.lblStatusPembayaran.TabIndex = 4;
            this.lblStatusPembayaran.Text = "Status Pembayaran:";
            // 
            // lblMetodePembayaran
            // 
            this.lblMetodePembayaran.AutoSize = true;
            this.lblMetodePembayaran.Location = new System.Drawing.Point(40, 120);
            this.lblMetodePembayaran.Name = "lblMetodePembayaran";
            this.lblMetodePembayaran.Size = new System.Drawing.Size(108, 13);
            this.lblMetodePembayaran.TabIndex = 6;
            this.lblMetodePembayaran.Text = "Metode Pembayaran:";
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.Location = new System.Drawing.Point(40, 150);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(66, 13);
            this.lblTotalHarga.TabIndex = 8;
            this.lblTotalHarga.Text = "Total Harga:";
            // 
            // txtBookingID
            // 
            this.txtBookingID.Location = new System.Drawing.Point(154, 23);
            this.txtBookingID.Name = "txtBookingID";
            this.txtBookingID.ReadOnly = true;
            this.txtBookingID.Size = new System.Drawing.Size(200, 20);
            this.txtBookingID.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(154, 57);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtStatusPembayaran
            // 
            this.txtStatusPembayaran.Location = new System.Drawing.Point(154, 91);
            this.txtStatusPembayaran.Name = "txtStatusPembayaran";
            this.txtStatusPembayaran.ReadOnly = true;
            this.txtStatusPembayaran.Size = new System.Drawing.Size(200, 20);
            this.txtStatusPembayaran.TabIndex = 5;
            // 
            // txtMetodePembayaran
            // 
            this.txtMetodePembayaran.Location = new System.Drawing.Point(154, 117);
            this.txtMetodePembayaran.Name = "txtMetodePembayaran";
            this.txtMetodePembayaran.ReadOnly = true;
            this.txtMetodePembayaran.Size = new System.Drawing.Size(200, 20);
            this.txtMetodePembayaran.TabIndex = 7;
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Location = new System.Drawing.Point(154, 143);
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.ReadOnly = true;
            this.txtTotalHarga.Size = new System.Drawing.Size(200, 20);
            this.txtTotalHarga.TabIndex = 9;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(176, 188);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(151, 23);
            this.btnPay.TabIndex = 10;
            this.btnPay.Text = "Bayar";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // PembayaranForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtTotalHarga);
            this.Controls.Add(this.lblTotalHarga);
            this.Controls.Add(this.txtMetodePembayaran);
            this.Controls.Add(this.lblMetodePembayaran);
            this.Controls.Add(this.txtStatusPembayaran);
            this.Controls.Add(this.lblStatusPembayaran);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtBookingID);
            this.Controls.Add(this.lblBookingID);
            this.Name = "PembayaranForm";
            this.Text = "Pembayaran";
            this.Load += new System.EventHandler(this.PembayaranForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
