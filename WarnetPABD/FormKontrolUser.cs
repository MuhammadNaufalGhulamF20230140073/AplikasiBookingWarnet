using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class FormKontrolUser : Form
    {
        public FormKontrolUser()
        {
            InitializeComponent();
        }

        // Fungsi untuk memuat data pengguna ke dalam DataGridView
        private void LoadUsers()
        {
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Username, Password FROM Pengguna";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dataAdapter.Fill(dt);
                    dgvUsers.DataSource = dt;  // Menampilkan data di DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data pengguna: {ex.Message}");
            }
        }

        // Event handler saat form dimuat
        private void FormKontrolUser_Load(object sender, EventArgs e)
        {
            LoadUsers();  // Memuat data pengguna saat form dimuat
        }

        // Event handler untuk menambahkan pengguna baru
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Pengguna (Username, Password) VALUES (@username, @password)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pengguna berhasil ditambahkan.");
                    LoadUsers();  // Memuat ulang data pengguna setelah penambahan
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menambahkan pengguna: {ex.Message}");
            }
        }

        // Event handler untuk mengupdate data pengguna
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Pengguna SET Password = @password WHERE Username = @username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pengguna berhasil diperbarui.");
                    LoadUsers();  // Memuat ulang data pengguna setelah update
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memperbarui pengguna: {ex.Message}");
            }
        }

        // Event handler untuk menghapus pengguna
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;

            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Pengguna WHERE Username = @username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pengguna berhasil dihapus.");
                    LoadUsers();  // Memuat ulang data pengguna setelah penghapusan
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menghapus pengguna: {ex.Message}");
            }
        }

        // Event handler untuk memilih data pengguna di DataGridView
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }
    }
}
