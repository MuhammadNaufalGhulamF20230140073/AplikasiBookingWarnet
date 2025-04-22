using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace booking
{
    public partial class FormBooking : Form
    {
        private string connectionString = "Data Source=DESKTOP-4D54309;Initial Catalog=bookingpc;Integrated Security=True";
        private string loggedInUsername;

        public FormBooking(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }
        private void FormBooking_Load(object sender, EventArgs e)
        {
            txtUsername.Text = loggedInUsername;
            txtUsername.ReadOnly = true;
            txtbookingID.Text = GenerateBookingID();
            txtbookingID.ReadOnly = true;
            LoadBookingData();
        }
        private string GenerateBookingID()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 1 bookingID FROM booking ORDER BY bookingID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string lastID = result.ToString();
                    int num = int.Parse(lastID.Substring(1)) + 1;
                    return "B" + num.ToString("D4");
                }
                else
                {
                    return "B0001";
                }
            }
        }
        private void btnPesan_Click(object sender, EventArgs e)
        {
            if (txtDeviceID.Text == "" || txtWaktu.Text == "")
            {
                MessageBox.Show("Isi semua data.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO booking (bookingID, Username, deviceID, Waktu) VALUES (@bookingID, @Username, @deviceID, @Waktu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookingID", txtbookingID.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@deviceID", txtDeviceID.Text);
                cmd.Parameters.AddWithValue("@Waktu", int.Parse(txtWaktu.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Booking berhasil!");
                ClearForm();
                LoadBookingData();
            }
        }
        private void btnBatal_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM booking WHERE bookingID = @bookingID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookingID", txtbookingID.Text);
                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show(rowsAffected > 0 ? "Booking dibatalkan." : "Data tidak ditemukan.");
                ClearForm();
                LoadBookingData();
            }
        }
        private void ClearForm()
        {
            txtDeviceID.Clear();
            txtWaktu.Clear();
            txtbookingID.Text = GenerateBookingID();
        }

        private void LoadBookingData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT bookingID, deviceID, Waktu FROM booking WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", loggedInUsername);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBooking.DataSource = dt;
            }
        }

        private void dgvBooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooking.Rows[e.RowIndex];
                txtbookingID.Text = row.Cells["bookingID"].Value.ToString();
                txtDeviceID.Text = row.Cells["deviceID"].Value.ToString();
                txtWaktu.Text = row.Cells["Waktu"].Value.ToString();
            }
        }
    }
}



