using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace booking
{
    public partial class Booking: Form
    {
        private string connectionString = "Data Source=DESKTOP-4D54309;Initial Catalog=bookingpc;Integrated Security=True";
        private string loggedInUsername;

        public FormBooking(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }