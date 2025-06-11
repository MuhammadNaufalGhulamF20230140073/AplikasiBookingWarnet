namespace WarnetPABD
{
    partial class PreviewPembayaran
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Button btnImportToDatabase;

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
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.btnImportToDatabase = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();

            // dgvPreview
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(12, 12);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.Size = new System.Drawing.Size(760, 350);
            this.dgvPreview.TabIndex = 0;

            // btnImportToDatabase
            this.btnImportToDatabase.Location = new System.Drawing.Point(325, 380);
            this.btnImportToDatabase.Name = "btnImportToDatabase";
            this.btnImportToDatabase.Size = new System.Drawing.Size(150, 23);
            this.btnImportToDatabase.TabIndex = 1;
            this.btnImportToDatabase.Text = "Import to Database";
            this.btnImportToDatabase.UseVisualStyleBackColor = true;
            this.btnImportToDatabase.Click += new System.EventHandler(this.btnImportToDatabase_Click);

            // PreviewPembayaran
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnImportToDatabase);
            this.Controls.Add(this.dgvPreview);
            this.Name = "PreviewPembayaran";
            this.Text = "Preview Pembayaran";

            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
