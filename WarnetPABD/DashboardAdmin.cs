using System;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class DashboardAdmin : Form
    {
        public DashboardAdmin()
        {
            InitializeComponent();
        }

        // Event handler saat form dimuat
        private void DashboardAdmin_Load(object sender, EventArgs e)
        {
            // Misalnya Anda ingin menampilkan data atau melakukan sesuatu saat form dimuat
            MessageBox.Show("Dashboard Admin dimuat!");
        }

        // Event handler untuk membuka form Device
        private void btnDevice_Click(object sender, EventArgs e)
        {
            DeviceForm deviceForm = new DeviceForm();
            deviceForm.Show();
        }

        // Event handler untuk membuka form Data Pemesanan
        private void btnDataPemesan_Click(object sender, EventArgs e)
        {
            BookingFormAdmin pemesananForm = new BookingFormAdmin();
            pemesananForm.Show();
        }

        // Event handler untuk membuka form Data Pembayaran
        private void btnDataPembayaran_Click(object sender, EventArgs e)
        {
            // Contoh: Menyediakan BookingID dan totalHarga yang sesuai dengan yang diinginkan
            int bookingID = 1;  // Anda bisa ambil dari DataGrid atau sumber lainnya
            int totalHarga = 10000;  // Misalnya harga total yang Anda ambil dari data booking

            // Membuka FormPembayaranAdmin dan mengirimkan BookingID dan TotalHarga
            FormPembayaranAdmin pembayaranAdminForm = new FormPembayaranAdmin(bookingID, totalHarga);
            pembayaranAdminForm.Show();
        }

        // Event handler untuk Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        // Event handler untuk membuka form Kontrol User
        private void btnKontrolUser_Click(object sender, EventArgs e)
        {
            FormKontrolUser kontrolUserForm = new FormKontrolUser();
            kontrolUserForm.Show();
        }
    }
}
