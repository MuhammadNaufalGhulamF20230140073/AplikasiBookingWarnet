namespace booking
    partial class FormBooking
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.txtWaktu = new System.Windows.Forms.TextBox();
        this.txtDeviceID = new System.Windows.Forms.TextBox();
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.txtbookingID = new System.Windows.Forms.TextBox();
        this.btnPesan = new System.Windows.Forms.Button();
        this.btnHapus = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.SuspendLayout();

        // txtWaktu
        this.txtWaktu.Location = new System.Drawing.Point(120, 100);
        this.txtWaktu.Name = "txtWaktu";
        this.txtWaktu.Size = new System.Drawing.Size(200, 22);
        this.txtWaktu.TabIndex = 0;
        // txtDeviceID
        this.txtDeviceID.Location = new System.Drawing.Point(120, 70);
        this.txtDeviceID.Name = "txtDeviceID";
        this.txtDeviceID.Size = new System.Drawing.Size(200, 22);
        this.txtDeviceID.TabIndex = 1;

        // txtUsername
        this.txtUsername.Location = new System.Drawing.Point(120, 40);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.ReadOnly = true;
        this.txtUsername.Size = new System.Drawing.Size(200, 22);
        this.txtUsername.TabIndex = 2;
        // txtbookingID
        this.txtbookingID.Location = new System.Drawing.Point(120, 10);
        this.txtbookingID.Name = "txtbookingID";
        this.txtbookingID.ReadOnly = true;
        this.txtbookingID.Size = new System.Drawing.Size(200, 22);
        this.txtbookingID.TabIndex = 3;
        // btnPesan
        this.btnPesan.Location = new System.Drawing.Point(120, 140);
        this.btnPesan.Name = "btnPesan";
        this.btnPesan.Size = new System.Drawing.Size(95, 30);
        this.btnPesan.TabIndex = 4;
        this.btnPesan.Text = "Pesan";
        this.btnPesan.UseVisualStyleBackColor = true;
        this.btnPesan.Click += new System.EventHandler(this.btnPesan_Click);
        // btnBatal
        // 
        this.btnBatal.Location = new System.Drawing.Point(169, 114);
        this.btnBatal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.btnBatal.Name = "btnBatal";
        this.btnBatal.Size = new System.Drawing.Size(71, 24);
        this.btnBatal.TabIndex = 5;
        this.btnBatal.Text = "Batal";
        this.btnBatal.UseVisualStyleBackColor = true;
        this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
        //         // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(19, 11);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(63, 13);
        this.label1.TabIndex = 6;
        this.label1.Text = "Booking ID:";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(19, 35);
        this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(58, 13);
        this.label2.TabIndex = 7;
        this.label2.Text = "Username:";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(19, 59);
        this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(58, 13);
        this.label3.TabIndex = 8;
        this.label3.Text = "Device ID:";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(19, 84);
        this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(42, 13);
        this.label4.TabIndex = 9;
        this.label4.Text = "Waktu:";
        // 
        // dgvBooking
        this.dgvBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvBooking.Location = new System.Drawing.Point(25, 190);
        this.dgvBooking.Name = "dgvBooking";
        this.dgvBooking.RowHeadersWidth = 51;
        this.dgvBooking.RowTemplate.Height = 24;
        this.dgvBooking.Size = new System.Drawing.Size(500, 200);
        this.dgvBooking.TabIndex = 10;

        // FormBooking
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(560, 420);
        this.Controls.Add(this.dgvBooking);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.btnBatal);
        this.Controls.Add(this.btnPesan);
        this.Controls.Add(this.txtbookingID);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.txtDeviceID);
        this.Controls.Add(this.txtWaktu);
        this.Name = "FormBooking";
        this.Text = "Booking PC";
        this.Load += new System.EventHandler(this.FormBooking_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    
            // FormBooking
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.Controls.Add(this.dgvBooking);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnPesan);
            this.Controls.Add(this.txtbookingID);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtDeviceID);
            this.Controls.Add(this.txtWaktu);
            this.Name = "FormBooking";
            this.Text = "Booking PC";
            this.Load += new System.EventHandler(this.FormBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
}
