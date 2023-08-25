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
    public partial class AddUpdateCustomer : Form
    {
        public static int UserID { set; get; }
        public static string CustomerName { set; get; }
        public static string Address { set; get; }
        public static string City { set; get; }
        public static string PostalCode { set; get; }
        public static string Country { set; get; }
        public static string Phone { set; get; }

        public static bool canSave = false;

        public AddUpdateCustomer()
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
            if (this.Text == "Add Customer")
            {
                UserID = (Customer.Customers.Last().UserId + 1);
                IDTextBox.Text = UserID.ToString();
                canSave = false;
            }
            if (this.Text == "Update Customer")
            {
                UserID = Users.ID;
                IDTextBox.Text = UserID.ToString();
                nameTextBox.Text = Customer.Customers[Users.ID -1].Name;
                addressTextBox.Text = Customer.Customers[Users.ID - 1].Address;
                cityTextBox.Text = Customer.Customers[Users.ID - 1].City;
                DBCustomerChecks.AddressCheck(Users.ID);
                postalTextBox.Text = DBCustomerChecks.PostalCode;
                countryTextBox.Text = Customer.Customers[Users.ID - 1].Country;
                phoneTextBox.Text = Customer.Customers[Users.ID - 1].Phone;
                canSave = true;
            }
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show($"{textBox.Name} cannot be empty.", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            if (this.Text == "Add Customer")
            {
                DBCustomerAdd.AddUser();
                DBCustomerAdd.AddAddress();
                DBCustomerAdd.CustomerAddressCorrect();
            }
            else if (this.Text == "Update Customer")
            {
                DBCustomerUpdate.UpdateCustomer();
                DBCustomerUpdate.UpdateAddress();
            }
            ClearAll();
            this.Close();
            Customer.PopulateCustomers();
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
