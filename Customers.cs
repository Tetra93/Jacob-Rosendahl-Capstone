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
    public partial class Customers : Form
    {
        public static Customers customers;

        public static int ID { set; get; }

        public Customers()
        {
            InitializeComponent();
            dataGridView1.DataSource = Customer.Customers;
            customers = this;
            
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
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
                    ID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
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
            AddUpdateCustomer addModifyCustomer = new AddUpdateCustomer();
            addModifyCustomer.Text = "Add Customer";
            addModifyCustomer.Show();
            this.Hide();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            AddUpdateCustomer addModifyCustomer = new AddUpdateCustomer();
            addModifyCustomer.Text = "Update Customer";
            addModifyCustomer.Show();
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Selected)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Delete Customer?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    DBCustomerDelete.DeleteCustomer();
                    DBCustomerDelete.DeleteAddress();
                    Customer.PopulateCustomers();
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            HomeMenu.homeMenu.Show();
        }

        private void Customers_Shown(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

    }
}
