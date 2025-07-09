using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class PreviewPembayaran : Form
    {
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";
        private DataTable _excelData;

        // Constructor menerima DataTable untuk menampilkan data
        public PreviewPembayaran(DataTable excelData)
        {
            InitializeComponent();
            strKonek = kn.connectionString();
            _excelData = excelData;

            // Set the DataTable to DataGridView
            dgvPreview.DataSource = _excelData;
        }

        // Event handler for the "OK" button to import data into the database
        private void btnImportToDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();

                    foreach (DataRow row in _excelData.Rows)
                    {
                        // Skip the header row
                        if (row[0].ToString() == "Username")
                            continue;

                        string username = row["Username"].ToString();
                        string deviceID = row["DeviceID"].ToString(); // Ensure DeviceID is retrieved from the data

                        // Ensure Durasi and TotalHarga are integers
                        if (!int.TryParse(row["Durasi"].ToString(), out int durasi))
                        {
                            MessageBox.Show($"Invalid 'Durasi' value for Username: {username}");
                            continue;
                        }

                        if (!int.TryParse(row["TotalHarga"].ToString(), out int totalHarga))
                        {
                            MessageBox.Show($"Invalid 'TotalHarga' value for Username: {username}");
                            continue;
                        }

                        // Ensure TanggalBayar is a valid DateTime
                        if (!DateTime.TryParse(row["TanggalBayar"].ToString(), out DateTime tanggalBayar))
                        {
                            MessageBox.Show($"Invalid 'TanggalBayar' value for Username: {username}");
                            continue;
                        }

                        string statusPembayaran = row["StatusPembayaran"].ToString();
                        string metodePembayaran = row["MetodePembayaran"].ToString();

                        // Now calling the GetOrCreateBookingID to fetch the BookingID for the Username and Durasi
                        int bookingID = GetOrCreateBookingID(conn, username, durasi, deviceID);
                        if (bookingID == 0)
                        {
                            MessageBox.Show($"BookingID not found for Username: {username} and Durasi: {durasi}");
                            continue;
                        }

                        // Insert data into the Pembayaran table
                        SqlCommand cmd = new SqlCommand("AddPembayaran", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BookingID", bookingID);
                        cmd.Parameters.AddWithValue("@MetodePembayaran", metodePembayaran);
                        cmd.Parameters.AddWithValue("@StatusPembayaran", statusPembayaran);
                        cmd.Parameters.AddWithValue("@TotalHarga", totalHarga);
                        cmd.Parameters.AddWithValue("@Durasi", durasi);
                        cmd.Parameters.AddWithValue("@TanggalBayar", tanggalBayar);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data imported successfully.");
                    this.Close();  // Close the preview form after importing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing data: " + ex.Message);
            }
        }

        // Function to get or create BookingID based on Username, Durasi, and DeviceID
        private int GetOrCreateBookingID(SqlConnection conn, string username, int durasi, string deviceID)
        {
            // Try to find the existing BookingID
            int bookingID = 0;
            string query = "SELECT BookingID FROM Booking WHERE Username = @Username AND Durasi = @Durasi AND DeviceID = @DeviceID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Durasi", durasi);
                cmd.Parameters.AddWithValue("@DeviceID", deviceID); // Add DeviceID to the search query
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    bookingID = Convert.ToInt32(result);
                }
            }

            // If BookingID not found, create a new Booking
            if (bookingID == 0)
            {
                string insertQuery = "INSERT INTO Booking (Username, Durasi, DeviceID) OUTPUT INSERTED.BookingID VALUES (@Username, @Durasi, @DeviceID)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Durasi", durasi);
                    cmd.Parameters.AddWithValue("@DeviceID", deviceID); // Add DeviceID to the new Booking
                    bookingID = (int)cmd.ExecuteScalar();
                }
            }

            return bookingID;
        }
    }
}
