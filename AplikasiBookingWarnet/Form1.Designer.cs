namespace AplikasiBookingWarnet
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvAkun = new System.Windows.Forms.DataGridView();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPw = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkun)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(150, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(150, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(150, 60);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(150, 20);
            this.txtPw.TabIndex = 1;
            // 
                 // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.GreenYellow;
            this.btnTambah.Location = new System.Drawing.Point(330, 30);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 2;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.GreenYellow;
            this.btnHapus.Location = new System.Drawing.Point(330, 60);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 3;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.GreenYellow;
            this.btnRefresh.Location = new System.Drawing.Point(330, 90);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.GreenYellow;
            this.btnEdit.Location = new System.Drawing.Point(330, 120);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvAkun
            // 
            this.dgvAkun.Location = new System.Drawing.Point(50, 160);
            this.dgvAkun.Name = "dgvAkun";
            this.dgvAkun.Size = new System.Drawing.Size(400, 200);
            this.dgvAkun.TabIndex = 6;
            this.dgvAkun.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAkun_CellClick);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.GreenYellow;
            this.lblUsername.Location = new System.Drawing.Point(50, 33);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "Username";
            // 
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.BackColor = System.Drawing.Color.GreenYellow;
            this.lblPw.Location = new System.Drawing.Point(50, 63);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(22, 13);
            this.lblPw.TabIndex = 8;
            this.lblPw.Text = "Pw";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.dgvAkun);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvAkun;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPw;
    }
}