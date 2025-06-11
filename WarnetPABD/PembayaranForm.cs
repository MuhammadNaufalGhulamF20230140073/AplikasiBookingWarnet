using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class PembayaranForm : Form
    {
        private int bookingID;
        private int totalHarga;

        // Konstruktor yang menerima BookingID dan TotalHarga dari BookingUser
        public PembayaranForm(int bookingID, int totalHarga)
        {
            InitializeComponent();
            this.bookingID = bookingID;
            this.totalHarga = totalHarga;

            // Menampilkan informasi yang diperlukan di form
            txtBookingID.Text = bookingID.ToString();
            txtUsername.Text = "";  // Untuk username akan diisi setelah query
            txtStatusPembayaran.Text = "PENDING";  // Status pembayaran diatur menjadi 'PENDING'
            txtMetodePembayaran.Text = "CASH";  // Metode Pembayaran diatur menjadi 'CASH'
            txtTotalHarga.Text = totalHarga.ToString();  // Menampilkan Total Harga
        }

        // Event handler untuk tombol Bayar
        private void btnPay_Click(object sender, EventArgs e)
        {
            string paymentMethod = "CASH";  // Asumsi metode pembayaran adalah CASH
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Memasukkan data pembayaran ke dalam tabel Pembayaran
                    string query = "UPDATE Pembayaran SET MetodePembayaran = @paymentMethod, StatusPembayaran = 'LUNAS' WHERE BookingID = @bookingID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);  // Metode pembayaran diatur ke 'CASH'
                    cmd.Parameters.AddWithValue("@bookingID", bookingID);

                    // Mengeksekusi query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Tampilkan pesan bahwa pembayaran telah berhasil
                        MessageBox.Show("Silahkan bayar ke operator. Menyebutkan username: " + txtUsername.Text);
                        this.Close();  // Menutup form pembayaran setelah berhasil
                    }
                    else
                    {
                        MessageBox.Show("Booking ID tidak ditemukan.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memproses pembayaran: {ex.Message}");
            }
        }

        // Fungsi untuk memuat data pengguna berdasarkan BookingID
        private void LoadUserData()
        {
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query untuk mendapatkan username berdasarkan BookingID
                    string query = "SELECT Username FROM Booking WHERE BookingID = @bookingID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bookingID", bookingID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtUsername.Text = reader["Username"].ToString();  // Menampilkan Username di TextBox
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data pengguna: {ex.Message}");
            }
        }

        // Event handler saat form dimuat
        private void PembayaranForm_Load(object sender, EventArgs e)
        {
            LoadUserData();  // Memuat data pengguna berdasarkan BookingID
        }
    }
}
