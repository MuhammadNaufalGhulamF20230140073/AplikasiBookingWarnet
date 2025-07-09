using System;
using System.Windows.Forms;

namespace WarnetPABD
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Event handler untuk tombol Login sebagai User
        private void btnLoginUser_Click(object sender, EventArgs e)
        {
            // Menyembunyikan form login utama dan membuka form login untuk user
            LoginDetailsUser loginDetailsUser = new LoginDetailsUser();
            loginDetailsUser.Show();
            this.Hide();  // Sembunyikan LoginForm
        }

        // Event handler untuk tombol Login sebagai Admin
        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            // Menyembunyikan form login utama dan membuka form login untuk admin
            LoginDetailsAdmin loginDetailsAdmin = new LoginDetailsAdmin();
            loginDetailsAdmin.Show();
            this.Hide();  // Sembunyikan LoginForm
        }

        // Event handler untuk tombol Cancel (menutup aplikasi)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Menutup aplikasi jika Cancel ditekan
        }

        private void lblSelectLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
