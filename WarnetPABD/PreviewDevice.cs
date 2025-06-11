using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace WarnetPABD
{
    public partial class PreviewDevice : Form
    {
        string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
        private DataTable importedTable;

        public PreviewDevice(string filePath)
        {
            InitializeComponent();
            LoadExcelData(filePath);
        }

        private void LoadExcelData(string filePath)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });

                    importedTable = result.Tables[0]; // Sheet pertama
                    dgvPreview.DataSource = importedTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membaca file Excel: {ex.Message}");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataRow row in importedTable.Rows)
                    {
                        string deviceID = row["DeviceID"].ToString();
                        string spek = row["Spek"].ToString();
                        string lokasi = row["LokasiPC"].ToString();
                        string status = row["StatusPC"].ToString();

                        // Validasi status
                        string[] statusValid = { "Tidak Terpakai", "Terpakai", "Rusak", "Maintenance" };
                        if (Array.IndexOf(statusValid, status) == -1)
                        {
                            MessageBox.Show($"Status tidak valid pada DeviceID {deviceID}: {status}");
                            continue; // Skip baris ini
                        }

                        string query = "INSERT INTO Device (DeviceID, Spek, LokasiPC, StatusPC) VALUES (@DeviceID, @Spek, @LokasiPC, @StatusPC)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@DeviceID", deviceID);
                        cmd.Parameters.AddWithValue("@Spek", spek);
                        cmd.Parameters.AddWithValue("@LokasiPC", lokasi);
                        cmd.Parameters.AddWithValue("@StatusPC", status);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data perangkat berhasil diimpor ke database.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan data ke database: {ex.Message}");
            }
        }
    }
}
