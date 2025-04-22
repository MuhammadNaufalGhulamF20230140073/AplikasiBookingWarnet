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
