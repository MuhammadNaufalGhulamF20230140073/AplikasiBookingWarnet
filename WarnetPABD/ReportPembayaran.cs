using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WarnetPABD
{
    public partial class ReportPembayaran : Form
    {
        public ReportPembayaran()  // No parameters needed anymore
        {
            InitializeComponent();
        }

        // Form Load Event
        private void ReportPembayaran_Load(object sender, EventArgs e)
        {
            LoadReport();  // Load report when form is loaded
        }

        // Function to load the report
        private void LoadReport()
        {
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Updated query to calculate TotalHarga based on Durasi
                    string query = "SELECT b.Username, " +
                                   "SUM(b.Durasi) AS Durasi, " +
                                   "SUM(b.Durasi * 10000) AS TotalHarga, " +  // Multiply Durasi by price per hour (10,000)
                                   "p.TanggalBayar " +
                                   "FROM Booking AS b " +
                                   "INNER JOIN Pembayaran AS p ON b.BookingID = p.BookingID " +
                                   "GROUP BY b.Username, p.TanggalBayar " +
                                   "ORDER BY p.TanggalBayar DESC";

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
                    string reportPath = @"C:\Users\n\source\repos\WarnetPABD\WarnetPABD\PembayaranReport.rdlc";
                    reportViewer1.LocalReport.ReportPath = reportPath;

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
