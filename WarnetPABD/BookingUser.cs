using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class BookingUser : Form
    {
        private string username;
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";

        public BookingUser(string username)
        {
            InitializeComponent();
            this.username = username;
            strKonek = kn.connectionString();
            txtUsername.Text = username;
            txtUsername.Enabled = false;
            LoadAvailableDevices();
            GenerateBookingID();
        }

        private void BookingUser_Load(object sender, EventArgs e)
        {
            LoadAvailableDevices();
        }

        private void LoadAvailableDevices()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    string query = "SELECT DeviceID FROM Device WHERE StatusPC = 'Tidak Terpakai'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbDevices.Items.Clear();
                    while (reader.Read())
                    {
                        cmbDevices.Items.Add(reader["DeviceID"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat perangkat: {ex.Message}");
            }
        }

        private void GenerateBookingID()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    string query = "SELECT MAX(BookingID) + 1 FROM Booking";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        txtBookingID.Text = result.ToString();
                    }
                    else
                    {
                        txtBookingID.Text = "1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat mengenerate BookingID: {ex.Message}");
            }
        }

        private void btnBookDevice_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            int bookingID = int.Parse(txtBookingID.Text);

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username tidak boleh kosong!");
                return;
            }

            string deviceID = cmbDevices.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(deviceID))
            {
                MessageBox.Show("Error Device Sudah digunakan");
                return;
            }

            if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("Durasi harus angka positif!");
                return;
            }

            // ✅ KONFIRMASI DULU
            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin ingin memesan perangkat berikut?\n\n" +
                $"Username: {username}\n" +
                $"Perangkat: {deviceID}\n" +
                $"Durasi: {duration} jam\n\nKlik Yes untuk melanjutkan.",
                "Konfirmasi Pemesanan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return; // Batal jika user tekan No
            }

            int totalHarga = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();

                    // Ambil harga per jam
                    string query = "SELECT HargaPerJam FROM Harga WHERE HargaID = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    totalHarga = (int)cmd.ExecuteScalar();
                    totalHarga *= duration;

                    // Insert ke Booking
                    query = "INSERT INTO Booking (Username, DeviceID, Durasi) OUTPUT INSERTED.BookingID VALUES (@username, @deviceID, @durasi)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@deviceID", deviceID);
                    cmd.Parameters.AddWithValue("@durasi", duration);

                    int newBookingID = (int)cmd.ExecuteScalar();
                    txtBookingID.Text = newBookingID.ToString();

                    // Insert ke Pembayaran
                    string queryPembayaran = "INSERT INTO Pembayaran (BookingID, MetodePembayaran, StatusPembayaran, TotalHarga) VALUES (@bookingID, 'CASH', 'PENDING', @totalHarga)";
                    cmd = new SqlCommand(queryPembayaran, conn);
                    cmd.Parameters.AddWithValue("@bookingID", newBookingID);
                    cmd.Parameters.AddWithValue("@totalHarga", totalHarga);
                    cmd.ExecuteNonQuery();

                    // Arahkan ke form pembayaran
                    PembayaranForm pembayaranForm = new PembayaranForm(newBookingID, totalHarga);
                    pembayaranForm.Show();
                    this.Hide();
                    MessageBox.Show($"Pemesan perangkat berhasil! Booking ID: {newBookingID}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memesan perangkat: {ex.Message}");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void lblDuration_Click(object sender, EventArgs e)
        {
        }
    }
}
