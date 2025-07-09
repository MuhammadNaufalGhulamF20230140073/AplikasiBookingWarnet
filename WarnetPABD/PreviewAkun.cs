using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace WarnetPABD
{
    public partial class PreviewAkun : Form
    {
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";
        private DataTable importedTable;
        

        public PreviewAkun(string filePath)
        {
            InitializeComponent();
            strKonek = kn.connectionString();
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

                    importedTable = result.Tables[0]; // Ambil sheet pertama
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
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();

                    foreach (DataRow row in importedTable.Rows)
                    {
                        string username = row["Username"].ToString();
                        string password = row["Password"].ToString();

                        // Gunakan stored procedure agar aman
                        SqlCommand cmd = new SqlCommand("TransaksiTambahPengguna", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil diimpor ke database.");
                this.Close(); // Tutup form setelah impor
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan data ke database: {ex.Message}");
            }
        }
    }
}
