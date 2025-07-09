using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WarnetPABD
{
    public partial class PreviewBooking : Form
    {
        Koneksi kn = new Koneksi(); //memanggil class koneksi
        string strKonek = "";
        private DataTable data;
       

        public PreviewBooking(DataTable importedData)
        {
            InitializeComponent();
            strKonek = kn.connectionString();
            data = importedData;
            dataGridView1.DataSource = data;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Import data ke database?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ImportDataToDatabase();
                this.Close();
            }
        }

        private void ImportDataToDatabase()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            try
            {
                using (SqlConnection conn = new SqlConnection(strKonek))
                {
                    conn.Open();
                    foreach (DataRow row in data.Rows)
                    {
                        // 1. Tambah Booking
                        SqlCommand cmd = new SqlCommand("sp_TambahBooking", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Username", row["Username"]);
                        cmd.Parameters.AddWithValue("@DeviceID", row["DeviceID"]);
                        cmd.Parameters.AddWithValue("@Durasi", Convert.ToInt32(row["Durasi"]));
                        cmd.ExecuteNonQuery();

                        // 2. Ambil BookingID terbaru
                        SqlCommand getBookingIDCmd = new SqlCommand(
                            "SELECT TOP 1 BookingID FROM Booking WHERE Username = @Username AND DeviceID = @DeviceID AND Durasi = @Durasi ORDER BY BookingID DESC", conn);
                        getBookingIDCmd.Parameters.AddWithValue("@Username", row["Username"]);
                        getBookingIDCmd.Parameters.AddWithValue("@DeviceID", row["DeviceID"]);
                        getBookingIDCmd.Parameters.AddWithValue("@Durasi", Convert.ToInt32(row["Durasi"]));

                        object result = getBookingIDCmd.ExecuteScalar();
                        if (result != null)
                        {
                            int bookingID = Convert.ToInt32(result);
                            int durasi = Convert.ToInt32(row["Durasi"]);
                            int totalHarga = durasi * 10000;

                            // 3. Tambah ke tabel Pembayaran
                            SqlCommand insertPaymentCmd = new SqlCommand(
                                "INSERT INTO Pembayaran (BookingID, MetodePembayaran, StatusPembayaran, TotalHarga) VALUES (@BookingID, @Metode, @Status, @Total)",
                                conn);
                            insertPaymentCmd.Parameters.AddWithValue("@BookingID", bookingID);
                            insertPaymentCmd.Parameters.AddWithValue("@Metode", "CASH");
                            insertPaymentCmd.Parameters.AddWithValue("@Status", "PENDING");
                            insertPaymentCmd.Parameters.AddWithValue("@Total", totalHarga);
                            insertPaymentCmd.ExecuteNonQuery();
                        }
                    }

                    stopwatch.Stop();
                    MessageBox.Show($"Data booking dan pembayaran berhasil diimport!\nWaktu proses: {stopwatch.Elapsed.TotalSeconds:F2} detik");
                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                MessageBox.Show("Gagal import data: " + ex.Message);
            }
        }


    }
}