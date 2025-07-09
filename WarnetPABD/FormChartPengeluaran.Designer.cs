namespace WarnetPABD
{
    partial class FormChartPengeluaran
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.cmbFilterWaktu = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.chartPengeluaran = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPengeluaran)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.cmbFilterWaktu);
            this.panelTop.Controls.Add(this.lblFilter);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 50);
            this.panelTop.TabIndex = 0;
            // 
            // cmbFilterWaktu
            // 
            this.cmbFilterWaktu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterWaktu.FormattingEnabled = true;
            this.cmbFilterWaktu.Location = new System.Drawing.Point(110, 12);
            this.cmbFilterWaktu.Name = "cmbFilterWaktu";
            this.cmbFilterWaktu.Size = new System.Drawing.Size(200, 24);
            this.cmbFilterWaktu.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 15);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(82, 16);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter Waktu:";
            // 
            // chartPengeluaran
            // 
            this.chartPengeluaran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPengeluaran.Location = new System.Drawing.Point(0, 50);
            this.chartPengeluaran.Name = "chartPengeluaran";
            this.chartPengeluaran.Size = new System.Drawing.Size(800, 400);
            this.chartPengeluaran.TabIndex = 1;
            this.chartPengeluaran.Text = "chartPengeluaran";
            // 
            // FormChartPengeluaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartPengeluaran);
            this.Controls.Add(this.panelTop);
            this.Name = "FormChartPengeluaran";
            this.Text = "Grafik Pengeluaran User";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPengeluaran)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox cmbFilterWaktu;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPengeluaran;
    }
}
