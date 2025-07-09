using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;

namespace WarnetPABD
{
    public partial class FormPembayaranAdmin : Form
    {
        private int bookingID;
        private int totalHarga;
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";

        // Constructor
        public FormPembayaranAdmin(int bookingID, int totalHarga)
        {
            InitializeComponent();
            strKonek = kn.connectionString();
            this.bookingID = bookingID;
            this.totalHarga = totalHarga;
            txtBookingID.Text = bookingID.ToString();
            txtTotalHarga.Text = totalHarga.ToString();

            // Selalu inisialisasi ComboBox status pembayaran dengan PENDING default
            cmbStatusPembayaran.Items.Clear();
            cmbStatusPembayaran.Items.Add("PENDING");
            cmbStatusPembayaran.Items.Add("LUNAS");
            cmbStatusPembayaran.SelectedItem = "PENDING";

            LoadPembayaranData();

            txtUsername.ReadOnly = true;
        }

        private void FormPembayaranAdmin_Load(object sender, EventArgs e)
        {
            LoadPembayaranData();
        }

        private void LoadPembayaranData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("PembayaranData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvPembayaran.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data pembayaran: {ex.Message}");
            }
        }

        private void dgvPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPembayaran.Rows[e.RowIndex];
                txtBookingID.Text = row.Cells["BookingID"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtDurasi.Text = row.Cells["Durasi"].Value.ToString();


                // PROTEKSI: Selalu set default "PENDING" kalau status null/kosong/salah
                string statusValue = row.Cells["StatusPembayaran"].Value?.ToString().Trim().ToUpper() ?? "PENDING";
                if (statusValue == "LUNAS")
                    cmbStatusPembayaran.SelectedItem = "LUNAS";
                else
                    cmbStatusPembayaran.SelectedItem = "PENDING";

                cmbMetodePembayaran.SelectedItem = row.Cells["MetodePembayaran"].Value?.ToString();
                txtTanggalBayar.Text = row.Cells["TanggalBayar"].Value?.ToString();
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = !txtUsername.ReadOnly;
        }

        private void btnUpdatePembayaran_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookingID.Text) || string.IsNullOrEmpty(txtDurasi.Text) ||
                string.IsNullOrEmpty(txtTotalHarga.Text) || string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Pastikan semua kolom terisi!");
                return;
            }

            int bookingID = int.Parse(txtBookingID.Text);
            string statusPembayaran = cmbStatusPembayaran.SelectedItem?.ToString().ToUpper() ?? "PENDING";
            int durasi = int.Parse(txtDurasi.Text);
            DateTime tanggalBayar = DateTime.Parse(txtTanggalBayar.Text);
            string username = txtUsername.Text;
            int hargaPerJam = 10000;
            int totalHarga = durasi * hargaPerJam;


            using (SqlConnection conn = new SqlConnection(strKonek))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    SqlCommand cmd = new SqlCommand("UpdatePembayaran", conn, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BookingID", SqlDbType.Int).Value = bookingID;
                    cmd.Parameters.Add("@StatusPembayaran", SqlDbType.VarChar, 10).Value = statusPembayaran;
                    cmd.Parameters.Add("@TotalHarga", SqlDbType.Int).Value = totalHarga;
                    cmd.Parameters.Add("@Durasi", SqlDbType.Int).Value = durasi;
                    cmd.Parameters.Add("@TanggalBayar", SqlDbType.DateTime).Value = tanggalBayar;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;

                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                    // Jika status diubah ke LUNAS oleh admin, update device ke Terpakai
                    if (statusPembayaran == "LUNAS")
                    {
                        try
                        {
                            using (SqlConnection connDevice = new SqlConnection(strKonek))
                            {
                                connDevice.Open();
                                string getDeviceQuery = "SELECT DeviceID FROM Booking WHERE BookingID = @BookingID";
                                SqlCommand getDeviceCmd = new SqlCommand(getDeviceQuery, connDevice);
                                getDeviceCmd.Parameters.AddWithValue("@BookingID", bookingID);
                                object deviceIdObj = getDeviceCmd.ExecuteScalar();
                                if (deviceIdObj != null)
                                {
                                    string deviceID = deviceIdObj.ToString();
                                    string updateDeviceQuery = "UPDATE Device SET StatusPC = 'Terpakai' WHERE DeviceID = @DeviceID";
                                    SqlCommand updateDeviceCmd = new SqlCommand(updateDeviceQuery, connDevice);
                                    updateDeviceCmd.Parameters.AddWithValue("@DeviceID", deviceID);
                                    updateDeviceCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Gagal update status device: {ex.Message}");
                        }
                    }

                    MessageBox.Show("Pembayaran berhasil diperbarui.");
                    LoadPembayaranData();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Terjadi kesalahan saat memperbarui pembayaran: {ex.Message}");
                }
            }
        }

        private void btnDeletePembayaran_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookingID.Text))
            {
                MessageBox.Show("Booking ID tidak boleh kosong!");
                return;
            }

            int bookingID = int.Parse(txtBookingID.Text);

            using (SqlConnection conn = new SqlConnection(strKonek))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    SqlCommand cmd = new SqlCommand("DeletePembayaran", conn, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Pembayaran berhasil dihapus.");
                    LoadPembayaranData();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Terjadi kesalahan saat menghapus pembayaran: {ex.Message}");
                }
            }
        }

        private DataTable LoadExcelData(string filePath)
        {
            DataTable result = new DataTable();
            try
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var dataSet = reader.AsDataSet();
                        result = dataSet.Tables[0];
                        result.Columns[0].ColumnName = "Username";
                        result.Columns[1].ColumnName = "Durasi";
                        result.Columns[2].ColumnName = "TotalHarga";
                        result.Columns[3].ColumnName = "StatusPembayaran";
                        result.Columns[4].ColumnName = "MetodePembayaran";
                        result.Columns[5].ColumnName = "TanggalBayar";
                        result.Columns[6].ColumnName = "DeviceID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading the Excel file: {ex.Message}");
            }
            return result;
        }

        private void ImportDataToDatabase(DataTable excelData)
        {
                foreach (DataRow row in excelData.Rows)
            {
                string username = row["Username"].ToString();
                int durasi = Convert.ToInt32(row["Durasi"]);
                int totalHarga = Convert.ToInt32(row["TotalHarga"]);

                string deviceId = row["DeviceID"].ToString(); // Tambahkan ini!
                string statusPembayaran = "PENDING";
                if (row.Table.Columns.Contains("StatusPembayaran"))
                {
                    string colVal = row["StatusPembayaran"]?.ToString().Trim().ToUpper();
                    if (colVal == "LUNAS")
                        statusPembayaran = "LUNAS";
                }

                string metodePembayaran = row["MetodePembayaran"].ToString();
                DateTime tanggalBayar = Convert.ToDateTime(row["TanggalBayar"]);

                // Ubah ke 3 parameter!
                int bookingID = GetBookingIDFromDatabase(username, durasi, deviceId);

                if (bookingID == 0)
                {
                    MessageBox.Show($"BookingID not found for Username: {username}, Durasi: {durasi}, DeviceID: {deviceId}");
                    continue;
                }

                try
                {
                        using (SqlConnection conn = new SqlConnection(strKonek))
                        {
                            conn.Open();
                        SqlCommand cmd = new SqlCommand("AddPembayaran", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BookingID", bookingID);
                        cmd.Parameters.AddWithValue("@MetodePembayaran", metodePembayaran);
                        cmd.Parameters.AddWithValue("@StatusPembayaran", statusPembayaran);
                        cmd.Parameters.AddWithValue("@TotalHarga", totalHarga);
                        cmd.Parameters.AddWithValue("@Durasi", durasi);
                        cmd.Parameters.AddWithValue("@TanggalBayar", tanggalBayar);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting payment data for Username: {username}: {ex.Message}");
                }
            }

            MessageBox.Show("Data successfully imported.");
        }


        private int GetBookingIDFromDatabase(string username, int durasi, string deviceId)
        {
            int bookingID = 0;
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 BookingID FROM Booking WHERE Username = @Username AND Durasi = @Durasi AND DeviceID = @DeviceID ORDER BY BookingID DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Durasi", durasi);
                    cmd.Parameters.AddWithValue("@DeviceID", deviceId);

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        bookingID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching BookingID: {ex.Message}");
            }

            return bookingID;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    DataTable excelData = LoadExcelData(filePath);

                    PreviewPembayaran previewForm = new PreviewPembayaran(excelData);
                    if (previewForm.ShowDialog() == DialogResult.OK)
                    {
                        ImportDataToDatabase(excelData);
                    }
                }
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ReportPembayaran reportForm = new ReportPembayaran();
            reportForm.Show();
        }

        private void btnLihatChart_Click(object sender, EventArgs e)
        {
            FormChartPengeluaran chartForm = new FormChartPengeluaran();
            chartForm.ShowDialog();
        }
    }
}
