using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;


namespace WarnetPABD
{
    public partial class FormKontrolUser : Form
    {

        string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";

        public FormKontrolUser()
        {
            InitializeComponent();
        }


        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Username, Password FROM Pengguna";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dataAdapter.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data pengguna: {ex.Message}");
            }
        }


        private void InitializeStoredProcedures()
        {
            string[] procedures = new string[]
            {
                @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'TransaksiTambahPengguna')
                EXEC('
                    CREATE PROCEDURE TransaksiTambahPengguna
                        @Username VARCHAR(50),
                        @Password VARCHAR(20)
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        BEGIN TRY
                            BEGIN TRANSACTION;

                            IF EXISTS (SELECT 1 FROM Pengguna WITH (UPDLOCK, HOLDLOCK) WHERE Username = @Username)
                            BEGIN
                                RAISERROR(''Username sudah terdaftar.'', 16, 1);
                                ROLLBACK TRANSACTION;
                                RETURN;
                            END

                            INSERT INTO Pengguna (Username, Password)
                            VALUES (@Username, @Password);

                            COMMIT TRANSACTION;
                        END TRY
                        BEGIN CATCH
                            ROLLBACK TRANSACTION;
                            THROW;
                        END CATCH
                    END')
                ",

                @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdatePengguna')
                EXEC('
                    CREATE PROCEDURE UpdatePengguna
                        @Username VARCHAR(50),
                        @Password VARCHAR(20)
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        UPDATE Pengguna SET Password = @Password WHERE Username = @Username;
                    END')
                ",

                @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'HapusPengguna')
                EXEC('
                    CREATE PROCEDURE HapusPengguna
                        @Username VARCHAR(50)
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        DELETE FROM Pengguna WHERE Username = @Username;
                    END')
                ",

                @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'LihatPengguna')
                EXEC('
                    CREATE PROCEDURE LihatPengguna
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        SELECT Username, Password FROM Pengguna;
                    END')
                ",

                @"
                IF NOT EXISTS (
                    SELECT * FROM sys.indexes 
                    WHERE name = 'IX_Pengguna_Username' 
                      AND object_id = OBJECT_ID('Pengguna')
                )
                CREATE UNIQUE INDEX IX_Pengguna_Username ON Pengguna(Username);
                "
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (string proc in procedures)
                    {
                        using (SqlCommand cmd = new SqlCommand(proc, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuat prosedur tersimpan: {ex.Message}");
            }
        }

        private void FormKontrolUser_Load(object sender, EventArgs e)
        {
            LoadUsers();
            InitializeStoredProcedures();
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("TransaksiTambahPengguna", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
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
            string username = txtUsername.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
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
            OpenFileDialog openFileDialog = new OpenFileDialog(); // <-- Tambahkan baris ini
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                PreviewAkun preview = new PreviewAkun(filePath);
                preview.ShowDialog();

                LoadUsers(); // Refresh data setelah impor
            }
        }

    }
}
