using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class BookingUser : Form
    {
        private string username;

        public BookingUser(string username)  // Menyimpan username yang diterima dari login
        {
            InitializeComponent();
            this.username = username;
            txtUsername.Text = username;  // Menampilkan username di TextBox
            txtUsername.Enabled = false;  // Disable agar tidak bisa diedit oleh pengguna
            LoadAvailableDevices();  // Memanggil method untuk memuat perangkat yang tersedia
            GenerateBookingID();  // Generate BookingID otomatis
        }

        // Event handler saat form dimuat
        private void BookingUser_Load(object sender, EventArgs e)
        {
            LoadAvailableDevices();  // Memuat perangkat yang tersedia
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
                    cmbDevices.Items.Clear();

                    // Menambahkan perangkat yang tersedia ke ComboBox
                    while (reader.Read())
                    {
                        cmbDevices.Items.Add(reader["DeviceID"].ToString()); // Menambahkan DeviceID ke ComboBox
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat perangkat: {ex.Message}");
            }
        }

        // Fungsi untuk mengenerate BookingID otomatis yang belum digunakan
        private void GenerateBookingID()
        {
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query untuk mendapatkan BookingID yang belum dipakai
                    string query = "SELECT MAX(BookingID) + 1 FROM Booking";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        txtBookingID.Text = result.ToString();  // Menampilkan BookingID di TextBox
                    }
                    else
                    {
                        txtBookingID.Text = "1";  // Jika belum ada BookingID, mulai dari 1
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat mengenerate BookingID: {ex.Message}");
            }
        }

        // Memesan perangkat
        private void btnBookDevice_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            int bookingID = int.Parse(txtBookingID.Text);  // Menggunakan BookingID yang sudah terisi otomatis

            // Validasi input
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username tidak boleh kosong!");
                return;
            }

            // Memastikan perangkat dipilih
            string deviceID = cmbDevices.SelectedItem?.ToString();  // Perbaiki dari 'cmbDevice' menjadi 'cmbDevices'
            if (string.IsNullOrEmpty(deviceID))
            {
                MessageBox.Show("Pilih perangkat terlebih dahulu!");
                return;
            }

            // Validasi durasi
            if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("Durasi harus angka positif!");
                return;
            }

            // Hitung harga total berdasarkan harga per jam
            int totalHarga = 0;
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Mengambil harga per jam dari tabel Harga
                    string query = "SELECT HargaPerJam FROM Harga WHERE HargaID = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    totalHarga = (int)cmd.ExecuteScalar();  // Directly getting the value (not using DataReader here)
                    totalHarga *= duration;  // Multiply with the duration to get total price

                    // Menyimpan data booking ke database dan mendapatkan BookingID
                    query = "INSERT INTO Booking (Username, DeviceID, Durasi) OUTPUT INSERTED.BookingID VALUES (@username, @deviceID, @durasi)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@deviceID", deviceID);
                    cmd.Parameters.AddWithValue("@durasi", duration);

                    int newBookingID = (int)cmd.ExecuteScalar(); // Getting the newly inserted BookingID
                    txtBookingID.Text = newBookingID.ToString(); // Set BookingID in the TextBox

                    // Menyimpan data pembayaran
                    string queryPembayaran = "INSERT INTO Pembayaran (BookingID, MetodePembayaran, StatusPembayaran, TotalHarga) VALUES (@bookingID, 'CASH', 'PENDING', @totalHarga)";
                    cmd = new SqlCommand(queryPembayaran, conn);
                    cmd.Parameters.AddWithValue("@bookingID", newBookingID);
                    cmd.Parameters.AddWithValue("@totalHarga", totalHarga);
                    cmd.ExecuteNonQuery();

                    // Mengubah status perangkat menjadi 'Terpakai'
                    string updateDeviceQuery = "UPDATE Device SET StatusPC = 'Terpakai' WHERE DeviceID = @deviceID";
                    SqlCommand cmdUpdateDevice = new SqlCommand(updateDeviceQuery, conn);
                    cmdUpdateDevice.Parameters.AddWithValue("@deviceID", deviceID);
                    cmdUpdateDevice.ExecuteNonQuery();

                    // Setelah booking berhasil, langsung arahkan ke form pembayaran
                    PembayaranForm pembayaranForm = new PembayaranForm(newBookingID, totalHarga);
                    pembayaranForm.Show();
                    this.Hide();  // Menyembunyikan form BookingUser
                    MessageBox.Show($"Pemesan perangkat berhasil! Booking ID: {newBookingID}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memesan perangkat: {ex.Message}");
            }
        }
    }
}
