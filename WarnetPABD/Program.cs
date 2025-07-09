using System;
using System.Windows.Forms;
using WarnetPABD;  


namespace WarnetPABD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Mengaktifkan gaya visual untuk aplikasi Windows Forms
            Application.EnableVisualStyles();
            // Mengatur kompatibilitas rendering teks
            Application.SetCompatibleTextRenderingDefault(false);
            // Menjalankan aplikasi dengan membuka LoginForm
            Application.Run(new LoginForm());
        }
    }
}
