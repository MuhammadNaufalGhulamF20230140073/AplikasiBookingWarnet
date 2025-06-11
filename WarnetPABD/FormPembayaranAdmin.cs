using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;


namespace WarnetPABD
{
    public partial class FormPembayaranAdmin : Form
    {
        private int bookingID;
        private int totalHarga;



        // Constructor
        public FormPembayaranAdmin(int bookingID, int totalHarga)
        {
            InitializeComponent();
            this.bookingID = bookingID;
            this.totalHarga = totalHarga;
            txtBookingID.Text = bookingID.ToString();
            txtTotalHarga.Text = totalHarga.ToString(); // Display the totalHarga in the textbox
            LoadPembayaranData();  // Load payment data when form is loaded

            // Disable the Username TextBox and Add Button initially
            txtUsername.ReadOnly = true;
        }

        // Event handler when the form is loaded
        private void FormPembayaranAdmin_Load(object sender, EventArgs e)
        {
            LoadPembayaranData();
        }

        // Function to load data from the database into the DataGridView
        private void LoadPembayaranData()
        {
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("PembayaranData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvPembayaran.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data pembayaran: {ex.Message}");
            }
        }

        // Event handler when a row is clicked in the DataGridView
        private void dgvPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPembayaran.Rows[e.RowIndex];
                txtBookingID.Text = row.Cells["BookingID"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtDurasi.Text = row.Cells["Durasi"].Value.ToString();
                cmbStatusPembayaran.SelectedItem = row.Cells["StatusPembayaran"].Value.ToString();
                cmbMetodePembayaran.SelectedItem = row.Cells["MetodePembayaran"].Value.ToString();
                txtTanggalBayar.Text = row.Cells["TanggalBayar"].Value.ToString();  // Display TanggalBayar
            }
        }

        // Add a new payment



        // Toggle the state of the Username TextBox and Add Button
        private void btnToggle_Click(object sender, EventArgs e)
        {
            // Enable/Disable the Username textbox and the Add button
            bool isEnabled = !txtUsername.ReadOnly;
            txtUsername.ReadOnly = isEnabled;
           // Enable/Disable Add button based on the state of Username TextBox
        }

        // Update an existing payment
        private void btnUpdatePembayaran_Click(object sender, EventArgs e)
        {
            // Validasi input: pastikan semua kolom terisi
            if (string.IsNullOrEmpty(txtBookingID.Text) || string.IsNullOrEmpty(txtDurasi.Text) ||
                string.IsNullOrEmpty(txtTotalHarga.Text) || string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Pastikan semua kolom terisi!"); // Tampilkan pesan jika ada yang kosong
                return; // Hentikan eksekusi
            }

            int bookingID = int.Parse(txtBookingID.Text); // Ambil BookingID dari textbox
            string statusPembayaran = cmbStatusPembayaran.SelectedItem?.ToString() ?? ""; // Ambil status pembayaran
            int durasi = int.Parse(txtDurasi.Text); // Ambil durasi
            DateTime tanggalBayar = DateTime.Parse(txtTanggalBayar.Text); // Ambil tanggal bayar
            string username = txtUsername.Text; // Ambil username
            int hargaPerJam = 10000; // Harga per jam ditetapkan tetap
            int totalHarga = durasi * hargaPerJam; // Hitung total harga

            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;"; // String koneksi

            using (SqlConnection conn = new SqlConnection(connectionString)) // Buka koneksi
            {
                SqlTransaction transaction = null; // Siapkan variabel untuk transaksi

                try
                {
                    conn.Open(); // Buka koneksi
                    transaction = conn.BeginTransaction(); // Mulai transaksi

                    // Buat perintah untuk stored procedure UpdatePembayaran
                    SqlCommand cmd = new SqlCommand("UpdatePembayaran", conn, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Tambahkan parameter-parameter ke stored procedure
                    cmd.Parameters.Add("@BookingID", SqlDbType.Int).Value = bookingID;
                    cmd.Parameters.Add("@StatusPembayaran", SqlDbType.VarChar, 10).Value = statusPembayaran;
                    cmd.Parameters.Add("@TotalHarga", SqlDbType.Int).Value = totalHarga;
                    cmd.Parameters.Add("@Durasi", SqlDbType.Int).Value = durasi;
                    cmd.Parameters.Add("@TanggalBayar", SqlDbType.DateTime).Value = tanggalBayar;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;

                    cmd.ExecuteNonQuery(); // Eksekusi perintah update

                    transaction.Commit(); // Jika berhasil, commit transaksi
                    MessageBox.Show("Pembayaran berhasil diperbarui."); // Tampilkan pesan sukses
                    LoadPembayaranData(); // Refresh tampilan data di grid
                }
                catch (Exception ex)
                {
                    transaction?.Rollback(); // Jika terjadi error, rollback transaksi
                    MessageBox.Show($"Terjadi kesalahan saat memperbarui pembayaran: {ex.Message}"); // Tampilkan error
                }
            }
        }




        // Delete an existing payment
        private void btnDeletePembayaran_Click(object sender, EventArgs e)
        {
            // Validasi: BookingID tidak boleh kosong
            if (string.IsNullOrEmpty(txtBookingID.Text))
            {
                MessageBox.Show("Booking ID tidak boleh kosong!"); // Tampilkan pesan
                return; // Hentikan eksekusi
            }

            int bookingID = int.Parse(txtBookingID.Text); // Ambil BookingID dari textbox
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;"; // String koneksi

            using (SqlConnection conn = new SqlConnection(connectionString)) // Buat koneksi
            {
                SqlTransaction transaction = null; // Variabel transaksi

                try
                {
                    conn.Open(); // Buka koneksi
                    transaction = conn.BeginTransaction(); // Mulai transaksi

                    // Buat command untuk stored procedure DeletePembayaran
                    SqlCommand cmd = new SqlCommand("DeletePembayaran", conn, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookingID", bookingID); // Tambahkan parameter BookingID
                    cmd.ExecuteNonQuery(); // Jalankan perintah hapus

                    transaction.Commit(); // Jika berhasil, commit transaksi
                    MessageBox.Show("Pembayaran berhasil dihapus."); // Tampilkan pesan sukses
                    LoadPembayaranData(); // Refresh tampilan
                }
                catch (Exception ex)
                {
                    transaction?.Rollback(); // Rollback jika error
                    MessageBox.Show($"Terjadi kesalahan saat menghapus pembayaran: {ex.Message}"); // Tampilkan error
                }
            }
        }


        // Function to load data from Excel file and return as DataTable
        private DataTable LoadExcelData(string filePath)
        {
            DataTable result = new DataTable();
            try
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var dataSet = reader.AsDataSet();
                        result = dataSet.Tables[0];

                        // Renaming columns to match database columns
                        result.Columns[0].ColumnName = "Username";  // Rename first column to "Username"
                        result.Columns[1].ColumnName = "Durasi";    // Rename second column to "Durasi"
                        result.Columns[2].ColumnName = "TotalHarga"; // Rename third column to "TotalHarga"
                        result.Columns[3].ColumnName = "StatusPembayaran"; // Rename fourth column to "StatusPembayaran"
                        result.Columns[4].ColumnName = "MetodePembayaran"; // Rename fifth column to "MetodePembayaran"
                        result.Columns[5].ColumnName = "TanggalBayar"; // Rename sixth column to "TanggalBayar"
                        result.Columns[6].ColumnName = "DeviceID";  // Rename seventh column to "DeviceID"
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading the Excel file: {ex.Message}");
            }
            return result;
        }





        private void ImportDataToDatabase(DataTable excelData)
        {
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";

            foreach (DataRow row in excelData.Rows)
            {
                // Get the Username and Durasi from Excel Data
                string username = row["Username"].ToString();
                int durasi = Convert.ToInt32(row["Durasi"]);
                int totalHarga = Convert.ToInt32(row["TotalHarga"]);
                string statusPembayaran = row["StatusPembayaran"].ToString();
                string metodePembayaran = row["MetodePembayaran"].ToString();
                DateTime tanggalBayar = Convert.ToDateTime(row["TanggalBayar"]);

                // Fetch BookingID from the database based on Username and Durasi
                int bookingID = GetBookingIDFromDatabase(username, durasi);
                if (bookingID == 0)
                {
                    MessageBox.Show($"BookingID not found for Username: {username} and Durasi: {durasi}");
                    continue;  // Skip this row if BookingID is not found
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("AddPembayaran", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Pass the necessary values to the stored procedure
                        cmd.Parameters.AddWithValue("@BookingID", bookingID);
                        cmd.Parameters.AddWithValue("@MetodePembayaran", metodePembayaran);
                        cmd.Parameters.AddWithValue("@StatusPembayaran", statusPembayaran);
                        cmd.Parameters.AddWithValue("@TotalHarga", totalHarga);
                        cmd.Parameters.AddWithValue("@Durasi", durasi);
                        cmd.Parameters.AddWithValue("@TanggalBayar", tanggalBayar);

                        // Execute the insert command
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting payment data for Username: {username}: {ex.Message}");
                }
            }

            MessageBox.Show("Data successfully imported.");
        }

        private int GetBookingIDFromDatabase(string username, int durasi)
        {
            int bookingID = 0;
            string connectionString = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookingID FROM Booking WHERE Username = @Username AND Durasi = @Durasi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Durasi", durasi);

                    // Execute the query and get the BookingID
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        bookingID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching BookingID: {ex.Message}");
            }

            return bookingID;
        }




        // Event handler untuk tombol Import
        // Event handler untuk tombol Import
        // Event handler for the Import Button
        private void btnImport_Click(object sender, EventArgs e)
        {
            // Open the file dialog to select an Excel file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load Excel file and pass it to PreviewPembayaran
                    string filePath = openFileDialog.FileName;
                    DataTable excelData = LoadExcelData(filePath); // Loading the data from Excel file

                    // Open the PreviewPembayaran form and pass the data
                    PreviewPembayaran previewForm = new PreviewPembayaran(excelData);
                    if (previewForm.ShowDialog() == DialogResult.OK) // Wait for user to confirm the data
                    {
                        // When the user clicks OK in PreviewPembayaran, import the data
                        ImportDataToDatabase(excelData); // Now calling ImportDataToDatabase
                    }
                }
            }
        }


        

        // Show the report
        private void btnShowReport_Click(object sender, EventArgs e)
        {
            // Open the ReportPembayaran form without passing any parameters
            ReportPembayaran reportForm = new ReportPembayaran();
            reportForm.Show();  // Show the report form
        }
    }
}
