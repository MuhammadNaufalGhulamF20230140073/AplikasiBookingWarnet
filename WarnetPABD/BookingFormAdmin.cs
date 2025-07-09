using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using ExcelDataReader;


namespace WarnetPABD
{
    public partial class BookingFormAdmin : Form
    {
        private bool isProcessing = false;
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";


        public BookingFormAdmin()
        {
            InitializeComponent();
            InitializeCustomComponents();
            strKonek = kn.connectionString();

        }

        private void BookingFormAdmin_Load(object sender, EventArgs e)
        {
            LoadAllDataWithTime();

        }

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBookings.Rows[e.RowIndex];
                txtBookingID.Text = row.Cells["BookingID"].Value?.ToString();
                txtUsername.Text = row.Cells["Username"].Value?.ToString();
                txtDurasi.Text = row.Cells["Durasi"].Value?.ToString();

                // ISI ComboBox dengan SelectedItem (bukan Text!)
                string deviceId = row.Cells["DeviceID"].Value?.ToString();
                if (!string.IsNullOrEmpty(deviceId) && txtDeviceID.Items.Contains(deviceId))
                    txtDeviceID.SelectedItem = deviceId;
                else
                    txtDeviceID.SelectedIndex = -1;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string deviceId = txtDeviceID.Text.Trim();
            int durasi;

            if (!int.TryParse(txtDurasi.Text.Trim(), out durasi) || durasi <= 0)
            {
                MessageBox.Show("Durasi harus diisi dengan angka positif!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDurasi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(deviceId))
            {
                MessageBox.Show("Silakan pilih Device terlebih dahulu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 👉 Validasi apakah device masih tersedia
            using (SqlConnection conn = new SqlConnection(strKonek))
            {
                conn.Open();

                string checkDeviceQuery = "SELECT COUNT(*) FROM Device WHERE DeviceID = @DeviceID AND StatusPC = 'Tidak Terpakai'";
                using (SqlCommand checkCmd = new SqlCommand(checkDeviceQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@DeviceID", deviceId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Device sudah terpakai atau tidak valid. Silakan pilih yang lain.", "Device Tidak Tersedia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // -- 1. Insert ke Booking, dapatkan BookingID yang baru
                string queryBooking = "INSERT INTO Booking (Username, DeviceID, Durasi) OUTPUT INSERTED.BookingID VALUES (@Username, @DeviceID, @Durasi)";
                SqlCommand cmdBooking = new SqlCommand(queryBooking, conn);
                cmdBooking.Parameters.AddWithValue("@Username", username);
                cmdBooking.Parameters.AddWithValue("@DeviceID", deviceId);
                cmdBooking.Parameters.AddWithValue("@Durasi", durasi);

                int newBookingID = 0;
                try
                {
                    newBookingID = (int)cmdBooking.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat insert Booking: " + ex.Message);
                    return;
                }

                // -- 2. Insert ke Pembayaran
                int hargaPerJam = 10000;
                int totalHarga = durasi * hargaPerJam;

                string queryPembayaran = "INSERT INTO Pembayaran (BookingID, MetodePembayaran, StatusPembayaran, TotalHarga) VALUES (@BookingID, @MetodePembayaran, @StatusPembayaran, @TotalHarga)";
                SqlCommand cmdPembayaran = new SqlCommand(queryPembayaran, conn);
                cmdPembayaran.Parameters.AddWithValue("@BookingID", newBookingID);
                cmdPembayaran.Parameters.AddWithValue("@MetodePembayaran", "CASH");
                cmdPembayaran.Parameters.AddWithValue("@StatusPembayaran", "PENDING");
                cmdPembayaran.Parameters.AddWithValue("@TotalHarga", totalHarga);

                try
                {
                    cmdPembayaran.ExecuteNonQuery();
                    MessageBox.Show("Booking & pembayaran berhasil!\nBookingID: " + newBookingID);
                    LoadBookings();
                    LoadAvailableDevices();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat insert pembayaran: " + ex.Message);
                }
            }
        }






        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBookingID.Text, out int bookingID))
            {
                string deviceID = txtDeviceID.SelectedItem?.ToString() ?? "";
                int duration;

                if (!int.TryParse(txtDurasi.Text.Trim(), out duration) || duration <= 0)
                {
                    MessageBox.Show("Durasi harus diisi dengan angka positif!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDurasi.Focus();
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(strKonek))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_UpdateBooking", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BookingID", bookingID);
                        cmd.Parameters.AddWithValue("@DeviceID", deviceID);
                        cmd.Parameters.AddWithValue("@Durasi", duration);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking updated successfully!");
                            LoadBookings();
                            LoadAvailableDevices();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("No data was updated.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating booking: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Booking ID to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBookingID.Text.Trim(), out int bookingID))
            {
                string deviceID = "";

                try
                {
                    using (SqlConnection conn = new SqlConnection(strKonek))
                    {
                        conn.Open();

                        // Ambil DeviceID dulu sebelum hapus
                        using (SqlCommand getDeviceCmd = new SqlCommand("SELECT DeviceID FROM Booking WHERE BookingID = @BookingID", conn))
                        {
                            getDeviceCmd.Parameters.AddWithValue("@BookingID", bookingID);
                            var result = getDeviceCmd.ExecuteScalar();
                            if (result != null)
                                deviceID = result.ToString();
                        }

                        // Hapus booking
                        SqlCommand cmd = new SqlCommand("sp_HapusBooking", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BookingID", bookingID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Update device setelah hapus booking (tidak harus nunggu rowsAffected > 0, tapi lebih aman dicek)
                        if (!string.IsNullOrEmpty(deviceID))
                        {
                            using (SqlCommand updateDeviceCmd = new SqlCommand(
                                "UPDATE Device SET StatusPC = 'Tidak Terpakai' WHERE DeviceID = @DeviceID", conn))
                            {
                                updateDeviceCmd.Parameters.AddWithValue("@DeviceID", deviceID);
                                updateDeviceCmd.ExecuteNonQuery();
                            }
                        }

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking deleted successfully!\nStatus PC otomatis di-set ke Tidak Terpakai.");
                            LoadBookings();
                            LoadAvailableDevices();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Booking not found.");
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                ClearForm();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "Pilih file Excel untuk diimport"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            // Ambil sheet pertama
                            DataTable importedData = result.Tables[0];

                            // Tampilkan preview
                            PreviewBooking previewForm = new PreviewBooking(importedData);
                            previewForm.ShowDialog();

                            // Reload data ke tampilan
                            LoadBookings();
                            LoadAvailableDevices();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca file Excel: " + ex.Message);
                }
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllDataWithTime();
            MessageBox.Show("Data has been refreshed.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearForm()
        {
            txtBookingID.Clear();
            txtUsername.Clear();
            txtDurasi.Clear();
            txtDeviceID.SelectedIndex = -1;
        }

        private void LoadBookings(bool showTime = false)
        {
            Stopwatch stopwatch = new Stopwatch();
            if (showTime) stopwatch.Start();

            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    string query = "SELECT * FROM vw_LaporanBooking";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBookings.DataSource = dt;
                }

                if (showTime)
                {
                    stopwatch.Stop();
                    MessageBox.Show($"Data booking berhasil dimuat dalam {stopwatch.Elapsed.TotalSeconds:F2} detik.");
                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                MessageBox.Show($"Error loading booking data: {ex.Message}");
            }
        }

        private void LoadAvailableDevices(bool showTime = false)
        {
            Stopwatch stopwatch = new Stopwatch();
            if (showTime) stopwatch.Start();

            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    string query = "SELECT DeviceID FROM Device WHERE StatusPC = 'Tidak Terpakai'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    txtDeviceID.Items.Clear();
                    while (reader.Read())
                    {
                        txtDeviceID.Items.Add(reader["DeviceID"].ToString());
                    }
                    reader.Close();
                }

                if (showTime)
                {
                    stopwatch.Stop();
                    MessageBox.Show($"Data device berhasil dimuat dalam {stopwatch.Elapsed.TotalSeconds:F2} detik.");
                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                MessageBox.Show($"Error loading devices: {ex.Message}");
            }
        }


        private void LoadAllDataWithTime()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            LoadBookings(); // tidak tampilkan waktu
            LoadAvailableDevices(); // tidak tampilkan waktu

            stopwatch.Stop();
            MessageBox.Show($"Data berhasil dimuat dalam {stopwatch.Elapsed.TotalSeconds:F2} detik.");
        }


        private void InitializeCustomComponents()
        {
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.ReadOnly = true;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Load += BookingFormAdmin_Load;
            this.dgvBookings.CellClick += dgvBookings_CellClick;
            txtDeviceID.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void lblBookingID_Click(object sender, EventArgs e)
        {

        }
    }
}