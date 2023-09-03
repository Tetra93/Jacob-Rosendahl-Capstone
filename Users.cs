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
    public partial class Users : Form
    {
        public static Users users;

        public static int Id { set; get; }

        public static int LastId { set; get; }

        public static List<User> usersList = new List<User>();

        public Users()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("UserId", "User ID");
            dataGridView1.Columns.Add("AccessLevel", "Role");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Specialty", "Specialty");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("City", "City");
            dataGridView1.Columns.Add("Country", "Country");
            dataGridView1.Columns.Add("Phone", "Phone Number");
            dataGridView1.Columns.Add("PostalCode", "Postal Code");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            usersList.Clear();
            if (Login.CurrentUser.AccessLevel == 1)
            {
                usersList.AddRange(Admin.Admins);
            }
            usersList.AddRange(Customer.Customers);
            usersList.AddRange(Consultant.Consultants);
            usersList = usersList.OrderBy(u => u.UserId).ToList();

            dataGridView1.DataSource = usersList;
            users = this;
            
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is Admin admin)
                {
                    row.Cells["UserId"].Value = admin.UserId;
                    row.Cells["Name"].Value = admin.Name;
                    row.Cells["AccessLevel"].Value = "Admin";
                    row.Cells["Specialty"].Value = "N/A";
                    row.Cells["Address"].Value = "N/A";
                    row.Cells["City"].Value = "N/A";
                    row.Cells["Country"].Value = "N/A";
                    row.Cells["PostalCode"].Value = "N/A";
                    row.Cells["Phone"].Value = "N/A";
                }
                else if (row.DataBoundItem is Customer customer)
                {
                    row.Cells["UserId"].Value = customer.UserId;
                    row.Cells["Name"].Value = customer.Name;
                    row.Cells["AccessLevel"].Value = "Customer";
                    row.Cells["Specialty"].Value = "N/A";
                    row.Cells["Address"].Value = customer.Address;
                    row.Cells["City"].Value = customer.City;
                    row.Cells["Country"].Value = customer.Country;
                    row.Cells["PostalCode"].Value = customer.PostalCode;
                    row.Cells["Phone"].Value = customer.Phone;
                }
                else if (row.DataBoundItem is Consultant consultant)
                {
                    row.Cells["UserId"].Value = consultant.UserId;
                    row.Cells["Name"].Value = consultant.Name;
                    row.Cells["AccessLevel"].Value = "Consultant";
                    row.Cells["Specialty"].Value = consultant.Specialty;
                    row.Cells["Address"].Value = consultant.Address;
                    row.Cells["City"].Value = consultant.City;
                    row.Cells["Country"].Value = consultant.Country;
                    row.Cells["PostalCode"].Value = consultant.PostalCode;
                    row.Cells["Phone"].Value = consultant.Phone;
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;
            int searchCount = 0;
            string searchValue = searchTextBox.Text.ToString();
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                for (int i = 0; i < Customer.Customers.Count; i++)
                {
                    if (Customer.Customers[i].ToString().ToUpper().Contains(searchValue.ToUpper()))
                    {
                        searchCount++;
                        dataGridView1.Rows[i].Selected = true;
                    }
                }
                if (searchCount == 0)
                {
                    MessageBox.Show("No results found.");
                }
                else
                {
                    MessageBox.Show($"{searchCount} results found");
                }
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
            }
        }

        private void SearchTextBox_Validated(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    updateButton.Enabled = true;
                    deleteButton.Enabled = true;
                }
                else
                {
                    updateButton.Enabled = false;
                    deleteButton.Enabled = false;
                }
            }
            else
            {
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddUpdateUser.fromHome = false;
            AddUpdateUser addUpdateUser = new AddUpdateUser();
            addUpdateUser.Text = "Add User";
            addUpdateUser.Show();
            this.Hide();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            AddUpdateUser.fromHome = false;
            Id = int.Parse(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString());
            AddUpdateUser.Role = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            AddUpdateUser.CurrentSpecialty = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            AddUpdateUser.CurrentAddress = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            AddUpdateUser.CurrentCity = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            AddUpdateUser.CurrentCountry = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            AddUpdateUser.CurrentPhone = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            AddUpdateUser.CurrentPostalCode = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            AddUpdateUser addUpdateUser = new AddUpdateUser();
            AddUpdateUser.currentIndex = dataGridView1.SelectedRows[0].Index;
            addUpdateUser.Text = "Update User";
            addUpdateUser.Show();
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Selected)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Delete Customer?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    Id = usersList[index].UserId;
                    DBCustomerDelete.DeleteUser();
                    DBCustomerDelete.DeleteAddress();
                    User.PopulateUsers();
                    Customer.PopulateCustomers();
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            HomeMenu.homeMenu.Show();
        }

        private void Users_Activated(object sender, EventArgs e)
        {
                usersList.Clear();
                if (Login.CurrentUser.AccessLevel == 1)
                {
                    usersList.AddRange(Admin.Admins);
                }
                usersList.AddRange(Customer.Customers);
                usersList.AddRange(Consultant.Consultants);
                usersList = usersList.OrderBy(u => u.UserId).ToList();

                dataGridView1.DataSource = usersList;
        }
    }
}
