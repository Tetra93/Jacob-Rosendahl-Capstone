using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jacob_Rosendahl_C969_Scheduling_Application.Classes;
using Jacob_Rosendahl_C969_Scheduling_Application.Database;

namespace Jacob_Rosendahl_C969_Scheduling_Application
{
    public partial class AddUpdateUser : Form
    {
        public static string Username = string.Empty;
        public static int UserID { set; get; }
        public static string CustomerName { set; get; }
        public static string Specialty { get; set; }
        public static string Address { set; get; }
        public static string City { set; get; }
        public static string PostalCode { set; get; }
        public static string Country { set; get; }
        public static string Phone { set; get; }
        public static string Role { set; get; }
        public static string CurrentSpecialty { set; get; }
        public static string CurrentAddress { set; get; }
        public static string CurrentCity { set; get; }
        public static string CurrentPostalCode { set; get; }
        public static string CurrentCountry { set; get; }
        public static string CurrentPhone { set; get; }


        public static bool canSave = false;


        public AddUpdateUser()
        {
            InitializeComponent();
        }

        public static void ClearAll()
        {
            UserID = 0;
            CustomerName = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            PostalCode = string.Empty;
            Country = string.Empty;
            Phone = string.Empty;
        }

        private void AddModifyCustomer_Load(object sender, EventArgs e)
        {
            if (this.Text == "Add User")
            {

                UserID = (Users.LastId + 1);
                IDTextBox.Text = UserID.ToString();
                usernameLabel.Visible = true;
                usernameTextBox.Visible = true;
                specialtyLabel.Visible = false;
                specialtyTextBox.Visible = false;
                canSave = false;
            }
            if (this.Text == "Update User")
            {
                UserID = Users.Id;
                usernameLabel.Visible = false;
                usernameTextBox.Visible = false;
                IDTextBox.Text = UserID.ToString();
                nameTextBox.Text = Users.usersList[Users.Id -1].Name;
                if (Role != "Admin")
                {
                    addressTextBox.Text = CurrentAddress;
                    cityTextBox.Text = CurrentCity;
                    DBCustomerChecks.AddressCheck(Users.Id);
                    postalTextBox.Text = DBCustomerChecks.PostalCode;
                    countryTextBox.Text = CurrentCountry;
                    phoneTextBox.Text = CurrentPhone;
                }
                if (Role == "Consultant")
                {
                    specialtyTextBox.Text = CurrentSpecialty;
                }
                if (Role == "Admin")
                {
                    addressLabel.Visible = false;
                    addressTextBox.Visible = false;
                    cityLabel.Visible = false;
                    cityTextBox.Visible = false;
                    postalLabel.Visible = false;
                    postalTextBox.Visible = false;
                    countryLabel.Visible = false;
                    countryTextBox.Visible = false;
                    phoneLabel.Visible = false;
                    phoneTextBox.Visible = false;
                    specialtyLabel.Visible = false;
                    specialtyTextBox.Visible = false;
                }
                else if (Role == "Customer")
                {
                    specialtyLabel.Visible = false;
                    specialtyTextBox.Visible = false;
                }
                canSave = true;
            }
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            Username = usernameTextBox.Text;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerName = nameTextBox.Text;
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            Address = addressTextBox.Text;
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            City = cityTextBox.Text;
        }

        private void PostalTextBox_TextChanged(object sender, EventArgs e)
        {
            PostalCode = postalTextBox.Text;
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            Country = countryTextBox.Text;
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            Phone = phoneTextBox.Text;
        }

        private void SpecialtyTextBox_TextChanged(object sender, EventArgs e)
        {
            CurrentSpecialty = specialtyTextBox.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (Role == "Admin")
                    {
                        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                        {
                            MessageBox.Show($"{textBox.Name} cannot be empty.", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        if (textBox.Name == "specialtyTextBox" && Role == "Customer")
                        {
                            continue;
                        }
                        else if (textBox.Name == "specialtyTextBox" && this.Text == "Add User")
                        {
                            continue;
                        }
                        else if (textBox.Name == "usernameTextBox" && this.Text == "Update User")
                        {
                            continue;
                        }
                        MessageBox.Show($"{textBox.Name} cannot be empty.", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            if (this.Text == "Add User")
            {
                DBCustomerAdd.AddUser();
                Task.Delay(1000).Wait();
                DBCustomerAdd.AddAddress();
                //DBCustomerAdd.CustomerAddressCorrect();
            }
            else if (this.Text == "Update User")
            {
                DBCustomerUpdate.UpdateUser(specialtyTextBox.Text);
                DBCustomerUpdate.UpdateAddress();
            }
            User.PopulateUsers();
            Customer.PopulateCustomers();
            ClearAll();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ClearAll();
            this.Close();
        }

        private void AddUpdateCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Users.users.Show();
        }

    }
}
