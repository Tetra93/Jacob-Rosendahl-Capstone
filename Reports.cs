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

namespace Jacob_Rosendahl_C969_Scheduling_Application
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            reportTypeBox.Items.Add("Number of appointments by type by month");
            reportTypeBox.Items.Add("Consultant schedules");
            reportTypeBox.Items.Add("Customer schedules");
        }


        private void ReportTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = string.Empty;
            if (reportTypeBox.SelectedItem.ToString() == "Number of appointments by type by month")
            {
                peopleListBox.Visible = false;
                AppointmentTypesByMonth.CountMonths();
                dataGridView1.DataSource = AppointmentTypesByMonth.appointmentMonthsBindingList;
                dataGridView1.Refresh();
            }
            else if (reportTypeBox.SelectedItem.ToString() == "Consultant schedules")
            {
                peopleListBox.Items.Clear();
                foreach (string user in User.userList)
                {
                    peopleListBox.Items.Add(user);
                }
                peopleListBox.Visible = true;
            }
            if (reportTypeBox.SelectedItem.ToString() == "Customer schedules")
            {
                peopleListBox.Items.Clear();
                foreach (Customer customer in Customer.Customers)
                {
                    peopleListBox.Items.Add(customer.Name);
                }
                peopleListBox.Visible = true;
            }
        }

        private void PeopleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportTypeBox.SelectedItem.ToString() == "Consultant schedules")
            {
                string user = peopleListBox.SelectedItem.ToString();
                Appointment.UserFilter(user);
                dataGridView1.DataSource = Appointment.AppointmentsFiltered;
                dataGridView1.Refresh();
            }
            else if (reportTypeBox.SelectedItem.ToString() == "Customer schedules")
            {
                string customer = peopleListBox.SelectedItem.ToString();
                Appointment.CustomerFilter(customer);
                dataGridView1.DataSource = Appointment.AppointmentsFiltered;
                dataGridView1.Refresh();
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
                if (dataGridView1.DataSource == AppointmentTypesByMonth.appointmentMonthsBindingList)
                    for (int i = 0; i < AppointmentTypesByMonth.appointmentMonthsBindingList.Count; i++)
                    {
                        if (AppointmentTypesByMonth.appointmentMonthsBindingList[i].ToString().ToUpper().Contains(searchValue.ToUpper()))
                        {
                            searchCount++;
                            dataGridView1.Rows[i].Selected = true;
                        }
                    }
                else if (dataGridView1.DataSource == Appointment.AppointmentsFiltered)
                {
                    for (int i = 0; i < Appointment.AppointmentsFiltered.Count; i++)
                    {
                        if (Appointment.AppointmentsFiltered[i].ToString().ToUpper().Contains(searchValue.ToUpper()))
                        {
                            searchCount++;
                            dataGridView1.Rows[i].Selected = true;
                        }
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

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reports_FormClosing(object sender, FormClosingEventArgs e)
        {
            HomeMenu.homeMenu.Show();
        }
    }
}
