using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WarnetPABD
{
    public partial class FormKontrolUser : Form
    {
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";

        public FormKontrolUser()
        {
            InitializeComponent();
            strKonek = kn.connectionString();
        }

        private void LoadUsers()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    string query = "SELECT Username, Password FROM Pengguna";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dgvUsers.DataSource = dt;
                }

                stopwatch.Stop();
                MessageBox.Show($"Data pengguna berhasil dimuat dalam {stopwatch.Elapsed.TotalSeconds:F2} detik.");
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                MessageBox.Show($"Terjadi kesalahan saat memuat data pengguna: {ex.Message}");
            }
        }


        private void FormKontrolUser_Load(object sender, EventArgs e)
        {
            LoadUsers();
            // InitializeStoredProcedures(); // Tidak diperlukan lagi karena prosedur sudah dibuat manual
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("TambahPengguna", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pengguna berhasil ditambahkan.");
                    LoadUsers();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Gagal menambahkan pengguna: {ex.Message}");
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UpdatePengguna", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Pengguna berhasil diperbarui.");
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memperbarui pengguna: {ex.Message}");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DeletePengguna", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pengguna berhasil dihapus.");
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menghapus pengguna: {ex.Message}");
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                PreviewAkun preview = new PreviewAkun(filePath);
                preview.ShowDialog();

                stopwatch.Stop();
                MessageBox.Show($"Import data selesai dalam {stopwatch.Elapsed.TotalSeconds:F2} detik.");

                LoadUsers(); // Refresh data setelah impor
            }
        }

    }
}
