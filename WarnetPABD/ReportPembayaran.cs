using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WarnetPABD
{
    public partial class ReportPembayaran : Form
    {
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";
        public ReportPembayaran()  // No parameters needed anymore
        {
            InitializeComponent();
            strKonek = kn.connectionString();
        }

        // Form Load Event
        private void ReportPembayaran_Load(object sender, EventArgs e)
        {
            LoadReport();  // Load report when form is loaded
        }

        // Function to load the report
        private void LoadReport()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();

                    // Updated query to calculate TotalHarga based on Durasi
                    string query = "SELECT b.Username, " +
       "SUM(b.Durasi) AS TotalDurasi, " +
       "SUM(b.Durasi * 10000) AS TotalHarga, " +
       "MAX(p.TanggalBayar) AS TanggalBayar " +
       "FROM Booking AS b " +
       "INNER JOIN Pembayaran AS p ON b.BookingID = p.BookingID " +
       "WHERE p.StatusPembayaran = 'LUNAS' " +  // Hanya yang LUNAS
       "GROUP BY b.Username " +
       "ORDER BY b.Username";




                    // Prepare the SQL command and fetch the data
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Check if any data was returned
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found.");
                    }

                    // Set up the ReportDataSource and link it to the ReportViewer
                    ReportDataSource rds = new ReportDataSource("DataSet1", dataTable);  // Ensure this matches the DataSource name in the RDLC
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);

                    // Set the report path
                    string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PembayaranReport.rdlc");

                    // Refresh the report to display data
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat laporan: {ex.Message}");
            }
        }
    }
}
