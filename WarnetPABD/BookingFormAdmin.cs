using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class BookingFormAdmin : Form
    {
        public BookingFormAdmin()
        {
            InitializeComponent();
            LoadBookings();  // Memuat data booking saat form dibuka
            LoadAvailableDevices(); // Memuat perangkat yang tersedia saat form dibuka
        }

        // Memuat data booking ke DataGridView
        private void LoadBookings()
        {
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookingID, Username, DeviceID, Durasi FROM Booking";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dgvBookings.DataSource = dt;  // Menampilkan data di DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data booking: {ex.Message}");
            }
        }

        // Memuat perangkat yang tersedia (Status = 'Tidak Terpakai')
        private void LoadAvailableDevices()
        {
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DeviceID FROM Device WHERE StatusPC = 'Tidak Terpakai'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Mengosongkan combo box sebelum mengisinya
                    cmbDevice.Items.Clear();

                    // Menambahkan perangkat yang tersedia ke ComboBox
                    while (reader.Read())
                    {
                        cmbDevice.Items.Add(reader["DeviceID"].ToString()); // Menambahkan DeviceID ke ComboBox
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat perangkat: {ex.Message}");
            }
        }

        // Event handler untuk klik pada DataGridView
        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Pastikan baris yang diklik valid
            {
                // Ambil nilai BookingID dari baris yang diklik
                DataGridViewRow row = dgvBookings.Rows[e.RowIndex];
                txtBookingID.Text = row.Cells["BookingID"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                cmbDevice.SelectedItem = row.Cells["DeviceID"].Value.ToString();
                txtDuration.Text = row.Cells["Durasi"].Value.ToString();
            }
        }

        // Event handler untuk tombol Create (Create Booking)
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string deviceID = cmbDevice.SelectedItem?.ToString();
            int duration;

            // Validasi input durasi
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username tidak boleh kosong!");
                return;
            }

            if (string.IsNullOrEmpty(deviceID))
            {
                MessageBox.Show("Pilih perangkat terlebih dahulu!");
                return;
            }

            if (!int.TryParse(txtDuration.Text, out duration) || duration <= 0)
            {
                MessageBox.Show("Durasi harus angka positif!");
                return;
            }

            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query untuk mendapatkan BookingID yang belum dipakai
                    string query = "INSERT INTO Booking (Username, DeviceID, Durasi) OUTPUT INSERTED.BookingID VALUES (@username, @deviceID, @durasi)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@deviceID", deviceID);
                    cmd.Parameters.AddWithValue("@durasi", duration);

                    // Mendapatkan BookingID yang baru
                    int bookingID = (int)cmd.ExecuteScalar();
                    txtBookingID.Text = bookingID.ToString();  // Menampilkan Booking ID ke TextBox

                    // Menandai perangkat yang dipakai menjadi 'Terpakai' di tabel Device
                    string updateDeviceQuery = "UPDATE Device SET StatusPC = 'Terpakai' WHERE DeviceID = @deviceID";
                    SqlCommand cmdUpdateDevice = new SqlCommand(updateDeviceQuery, conn);
                    cmdUpdateDevice.Parameters.AddWithValue("@deviceID", deviceID);
                    cmdUpdateDevice.ExecuteNonQuery();

                    // **Insert data pembayaran setelah booking berhasil**
                    string queryPembayaran = "INSERT INTO Pembayaran (BookingID, MetodePembayaran, StatusPembayaran, TotalHarga) " +
                                             "VALUES (@bookingID, 'CASH', 'PENDING', @totalHarga)";
                    SqlCommand cmdPembayaran = new SqlCommand(queryPembayaran, conn);
                    // Hitung total harga berdasarkan durasi (misalnya harga per jam adalah 10000)
                    int hargaPerJam = 10000; // Anda bisa ganti dengan harga dari database jika ada
                    int totalHarga = hargaPerJam * duration;
                    cmdPembayaran.Parameters.AddWithValue("@bookingID", bookingID);
                    cmdPembayaran.Parameters.AddWithValue("@totalHarga", totalHarga);
                    cmdPembayaran.ExecuteNonQuery();

                    LoadBookings();  // Memuat ulang daftar booking setelah pemesanan
                    MessageBox.Show($"Pemesan perangkat berhasil! Booking ID: {bookingID}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memproses pemesanan: {ex.Message}");
            }
        }

        // Event handler untuk tombol Update (Update Booking)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBookingID.Text, out int bookingID))
            {
                string username = txtUsername.Text;
                string deviceID = cmbDevice.SelectedItem?.ToString();
                int duration = int.Parse(txtDuration.Text);

                string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE Booking SET DeviceID = @deviceID, Durasi = @durasi WHERE BookingID = @bookingID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@deviceID", deviceID);
                        cmd.Parameters.AddWithValue("@durasi", duration);
                        cmd.Parameters.AddWithValue("@bookingID", bookingID);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Pemesan berhasil diperbarui.");
                        LoadBookings();  // Memuat ulang daftar booking setelah update
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat mengupdate pemesanan: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Masukkan Booking ID yang valid untuk update.");
            }
        }

        // Event handler untuk tombol Delete (Delete Booking)
        // Event handler untuk tombol Delete (Delete Booking)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBookingID.Text, out int bookingID))
            {
                string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Mengambil DeviceID yang terkait dengan BookingID yang dihapus
                        string queryGetDeviceID = "SELECT DeviceID FROM Booking WHERE BookingID = @bookingID";
                        SqlCommand cmdGetDeviceID = new SqlCommand(queryGetDeviceID, conn);
                        cmdGetDeviceID.Parameters.AddWithValue("@bookingID", bookingID);
                        string deviceID = (string)cmdGetDeviceID.ExecuteScalar();

                        // Pastikan DeviceID ditemukan sebelum melanjutkan
                        if (string.IsNullOrEmpty(deviceID))
                        {
                            MessageBox.Show("DeviceID tidak ditemukan untuk BookingID: " + bookingID);
                            return;
                        }

                        // Menghapus booking
                        string queryDeleteBooking = "DELETE FROM Booking WHERE BookingID = @bookingID";
                        SqlCommand cmdDeleteBooking = new SqlCommand(queryDeleteBooking, conn);
                        cmdDeleteBooking.Parameters.AddWithValue("@bookingID", bookingID);
                        cmdDeleteBooking.ExecuteNonQuery();

                        // Mengubah status perangkat menjadi 'Tidak Terpakai' setelah booking dihapus
                        string queryUpdateDevice = "UPDATE Device SET StatusPC = 'Tidak Terpakai' WHERE DeviceID = @deviceID";
                        SqlCommand cmdUpdateDevice = new SqlCommand(queryUpdateDevice, conn);
                        cmdUpdateDevice.Parameters.AddWithValue("@deviceID", deviceID);
                        cmdUpdateDevice.ExecuteNonQuery();

                        MessageBox.Show("Pemesan berhasil dihapus dan perangkat telah diupdate menjadi 'Tidak Terpakai'.");
                        LoadBookings();  // Memuat ulang daftar booking setelah penghapusan
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat menghapus pemesanan: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Masukkan Booking ID yang valid untuk dihapus.");
            }
        }


        // Event handler untuk form load
        private void BookingFormAdmin_Load(object sender, EventArgs e)
        {
            LoadBookings();  // Memuat data booking saat form dibuka
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookings();  // Memuat ulang data booking saat tombol refresh ditekan
            LoadAvailableDevices();  // Memuat ulang perangkat yang tersedia saat tombol refresh ditekan
        }
    }
}
