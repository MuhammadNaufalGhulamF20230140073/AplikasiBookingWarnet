namespace WarnetPABD
{
    partial class ReportPembayaran
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;  // ReportViewer control

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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportPath = "PembayaranReport.rdlc";  // Path to your RDLC report file
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 450); // Adjust size as needed
            this.reportViewer1.TabIndex = 0;
            // 
            // ReportPembayaran
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportPembayaran";
            this.Text = "Pembayaran Report";
            this.Load += new System.EventHandler(this.ReportPembayaran_Load);
            this.ResumeLayout(false);
        }
    }
}
