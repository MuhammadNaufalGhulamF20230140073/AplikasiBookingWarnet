using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class LoginDetailsUser : Form
    {
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";

        public LoginDetailsUser()
        {
            InitializeComponent();
            strKonek = kn.connectionString(); // Mendapatkan string koneksi dari class Koneksi
        }

        // Event handler untuk tombol Login (untuk User)
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;  // Ambil password dari TextBox

            // Koneksi ke database
            using (SqlConnection conn = new SqlConnection(strKonek))
            {
                conn.Open();
                string query = "SELECT * FROM Pengguna WHERE Username = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);  // Periksa password juga

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Jika login berhasil, buka BookingUser dan pass username sebagai parameter
                    BookingUser bookingUser = new BookingUser(username); // Passing the username
                    bookingUser.Show();
                    this.Hide();  // Menyembunyikan LoginDetailsUser
                }
                else
                {
                    MessageBox.Show("Username atau Password salah.");
                }
            }
        }

        // Event handler untuk tombol Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();  // Menampilkan LoginForm
            this.Hide();  // Menyembunyikan LoginDetailsUser
        }
    }
}
