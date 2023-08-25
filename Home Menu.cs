using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jacob_Rosendahl_C969_Scheduling_Application
{
    public partial class HomeMenu : Form
    {
        public static HomeMenu homeMenu;

        public static Login login;

        public static bool canClose;

        public HomeMenu()
        {
            InitializeComponent();
            homeMenu = this;
            canClose = false;
            welcomeLabel.Text = $"Welcome {Login.CurrentUser.Name}";
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            Users customers = new Users();
            customers.Show();
            homeMenu.Hide();
        }

        private void AppointmentButton_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments();
            appointments.Show();
            homeMenu.Hide();
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            homeMenu.Hide();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Log out?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                canClose = true;
                Login login = new Login();
                login.Show();
                Close();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Added this to make the default close button also close the application

        private void HomeMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose == false)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the application?", "Exit application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    canClose = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void HomeMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            canClose = false;
        }
    }
}
