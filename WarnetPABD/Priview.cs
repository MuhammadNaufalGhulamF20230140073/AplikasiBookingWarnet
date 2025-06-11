using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class Priview : Form
    {
        private DataTable data;

        public Priview(DataTable importedData)
        {
            InitializeComponent();
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
            try
            {
                string connStr = @"Server=DESKTOP-4D54309; Database=WarnetDB; Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    foreach (DataRow row in data.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("sp_TambahBooking", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Username", row["Username"]);
                        cmd.Parameters.AddWithValue("@DeviceID", row["DeviceID"]);
                        cmd.Parameters.AddWithValue("@Durasi", Convert.ToInt32(row["Durasi"]));

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data berhasil diimport!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal import data: " + ex.Message);
            }
        }
    }
}
