using Jacob_Rosendahl_Appointed_Program.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jacob_Rosendahl_Appointed_Program
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
            string firstName;
            if (Login.CurrentUser.Name.Contains(" "))
            {
                firstName = Login.CurrentUser.Name.Substring(0, Login.CurrentUser.Name.IndexOf(" "));
            }
            else
            {
                firstName = Login.CurrentUser.Name;
            }
            welcomeLabel.Text = $"Welcome {firstName}";
            if (Login.CurrentUser.AccessLevel == 3)
            {
                reportsButton.Enabled = false;
            }
        }

        private void PersonalInfoButton_Click(object sender, EventArgs e)
        {
            Users.usersList.Clear();
            Users.usersList.Add(Login.CurrentUser);
            Users.Id = Login.CurrentUser.UserId;
            AddUpdateUser.fromHome = true;
            AddUpdateUser.currentIndex = 0;
            if (Login.CurrentUser.AccessLevel == 1)
            {
                AddUpdateUser.Role = "Admin";
            }
            else if (Login.CurrentUser.AccessLevel == 2)
            {
                foreach (Consultant consultant in Consultant.Consultants)
                {
                    if (consultant.UserId == Login.CurrentUser.UserId)
                    {
                        AddUpdateUser.CurrentAddress = consultant.Address;
                        AddUpdateUser.CurrentCity = consultant.City;
                        AddUpdateUser.CurrentCountry = consultant.Country;
                        AddUpdateUser.CurrentPostalCode = consultant.PostalCode;
                        AddUpdateUser.CurrentPhone = consultant.Phone;
                        AddUpdateUser.CurrentSpecialty = consultant.Specialty;
                        break;
                    }
                }
                AddUpdateUser.Role = "Consultant";
            }
            else if (Login.CurrentUser.AccessLevel == 3)
            {
                foreach (Customer customer in Customer.Customers)
                {
                    if (customer.UserId == Login.CurrentUser.UserId)
                    {

                        AddUpdateUser.CurrentAddress = customer.Address;
                        AddUpdateUser.CurrentCity = customer.City;
                        AddUpdateUser.CurrentCountry = customer.Country;
                        AddUpdateUser.CurrentPostalCode = customer.PostalCode;
                        AddUpdateUser.CurrentPhone = customer.Phone;
                    }
                }
                AddUpdateUser.Role = "Customer";
            }
            AddUpdateUser addUpdateUser = new AddUpdateUser();
            addUpdateUser.Text = "Update User";
            addUpdateUser.Show();
            homeMenu.Hide();
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            homeMenu.Hide();
            changePassword.Show();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            
            users.Show();
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
