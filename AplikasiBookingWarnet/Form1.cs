﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiBookingWarnet
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-4D54309;Initial Catalog=bookingpc;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Username, Pw FROM Akun";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAkun.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPw.Text == "")
            {
                MessageBox.Show("Harap isi semua data");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Akun (Username, Pw, Role) VALUES (@Username, @Pw, 'Pengguna')";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pw", txtPw.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil ditambahkan!");
                        LoadData();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvAkun.SelectedRows.Count > 0)
            { string username = dgvAkun.SelectedRows[0].Cells["Username"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Akun WHERE Username = @Username";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data berhasil dihapus!");
                            LoadData();
                            ClearForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus!");
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAkun.SelectedRows.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE Akun SET Pw = @Pw WHERE Username = @Username";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@Pw", txtPw.Text.Trim());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data berhasil diperbarui!");
                            LoadData();
                            ClearForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void dgvAkun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAkun.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPw.Text = row.Cells["Pw"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPw.Clear();
            txtUsername.Focus();
        }
    }
}

