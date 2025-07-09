using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WarnetPABD
{
    public partial class FormChartPengeluaran : Form
    {
        Koneksi kn = new Koneksi();
        private string strKonek = "";

        public FormChartPengeluaran()
        {
            InitializeComponent();
            strKonek = kn.connectionString();

            cmbFilterWaktu.Items.AddRange(new string[] { "Semua Waktu", "Tahun Ini", "Bulan Ini", "Hari Ini" });
            cmbFilterWaktu.SelectedIndex = 0;

            cmbFilterWaktu.SelectedIndexChanged += cmbFilterWaktu_SelectedIndexChanged;

            LoadChartPengeluaran("Semua Waktu");
        }

        private void cmbFilterWaktu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cmbFilterWaktu.SelectedItem.ToString();
            LoadChartPengeluaran(selectedFilter);
        }

        private void LoadChartPengeluaran(string filter)
        {
            chartPengeluaran.Series.Clear();
            chartPengeluaran.Titles.Clear();
            chartPengeluaran.ChartAreas.Clear();

            // Chart Area
            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.Beige;
            area.AxisX.Title = "Organisasi";
            area.AxisY.Title = "Jumlah (Rp)";
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.Interval = 1;
            chartPengeluaran.ChartAreas.Add(area);

            string query = @"SELECT b.Username, SUM(p.TotalHarga) AS TotalPengeluaran
                             FROM Pembayaran p
                             INNER JOIN Booking b ON p.BookingID = b.BookingID
                             WHERE p.StatusPembayaran = 'LUNAS' ";

            if (filter == "Tahun Ini")
                query += "AND YEAR(TanggalBayar) = YEAR(GETDATE()) ";
            else if (filter == "Bulan Ini")
                query += "AND YEAR(TanggalBayar) = YEAR(GETDATE()) AND MONTH(TanggalBayar) = MONTH(GETDATE()) ";
            else if (filter == "Hari Ini")
                query += "AND CONVERT(date, TanggalBayar) = CONVERT(date, GETDATE()) ";

            query += "GROUP BY b.Username ORDER BY SUM(p.TotalHarga) DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak ada data pengeluaran ditemukan.");
                        return;
                    }

                    Series seriesPengeluaran = new Series("Pengeluaran")
                    {
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true,
                        LabelForeColor = Color.Black,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Color = Color.IndianRed,
                        BorderWidth = 1,
                        BorderColor = Color.DarkRed
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        string username = row["Username"].ToString();
                        decimal total = Convert.ToDecimal(row["TotalPengeluaran"]);
                        seriesPengeluaran.Points.AddXY(username, total);
                    }

                    chartPengeluaran.Series.Add(seriesPengeluaran);

                    Title title = new Title("Grafik Total Pengeluaran per User", Docking.Top,
                        new Font("Segoe UI", 12, FontStyle.Bold), Color.Black);
                    chartPengeluaran.Titles.Add(title);

                    chartPengeluaran.Legends.Clear(); // Hapus legend karena hanya 1 seri
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat chart: {ex.Message}");
            }
        }
    }
}
