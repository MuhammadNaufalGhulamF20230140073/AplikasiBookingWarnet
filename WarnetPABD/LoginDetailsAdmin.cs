using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WarnetPABD;  // Correct namespace

namespace WarnetPABD
{
    public partial class LoginDetailsAdmin : Form
    {
        public LoginDetailsAdmin()
        {
            InitializeComponent();
        }

        // Event handler untuk tombol Login (untuk Admin)
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Koneksi ke database
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Admin WHERE Username = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Jika login berhasil, buka DashboardAdmin
                    DashboardAdmin dashboardAdmin = new DashboardAdmin();
                    dashboardAdmin.Show();
                    this.Hide();  // Menyembunyikan LoginDetailsAdmin
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
            this.Hide();  // Menyembunyikan LoginDetailsAdmin
        }
    }
}
