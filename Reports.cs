using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jacob_Rosendahl_C969_Scheduling_Application.Classes;
using MySqlX.XDevAPI.Relational;

namespace Jacob_Rosendahl_C969_Scheduling_Application
{
    public partial class Reports : Form
    {
        public static List<string> specialties = new List<string>();

        public static bool typeFound = false;
        public Reports()
        {
            InitializeComponent();
            reportTypeBox.Items.Clear();
            reportTypeBox.Items.Add("Appointment types by month");
            reportTypeBox.Items.Add("Consultant appointments by month");
            reportTypeBox.Items.Add("Consultant schedules");
            reportTypeBox.Items.Add("Customer schedules");
            if (Login.CurrentUser.AccessLevel == 1)
            {
                reportTypeBox.Items.Add("Login attempts");
            }
        }


        private void ReportTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (reportTypeBox.SelectedItem.ToString() == "Appointment types by month")
            {
                searchButton.Visible = false;
                searchTextBox.Visible = false;
                specialties.Clear();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Month", "Month");
                foreach (Consultant consultant in Consultant.Consultants)
                {
                    if (!specialties.Contains(consultant.Specialty))
                    {
                        specialties.Add(consultant.Specialty);
                        dataGridView1.Columns.Add(consultant.Specialty, consultant.Specialty);
                        dataGridView1.Columns[consultant.Specialty].ValueType = typeof(int);
                    }
                }

                dataGridView1.Columns.Add("Other", "Other");
                for (int month = 0;month < DateTimeFormatInfo.CurrentInfo.MonthNames.Length - 1; month++)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewTextBoxCell { Value = DateTimeFormatInfo.CurrentInfo.MonthNames[month] });
                    for (int i = 0; i < specialties.Count + 1; i++)
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = 0 });
                    }
                    dataGridView1.Rows.Add(row);
                }
                foreach (Appointment appointment in Appointment.AllAppointments)
                {
                    typeFound = false;
                    int appointmentMonth = appointment.Date.Month - 1;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if (column.Name == appointment.Type)
                        {
                            typeFound = true;
                            int currentValue = Convert.ToInt32(dataGridView1.Rows[appointmentMonth].Cells[column.Name].Value);
                            currentValue++;
                            dataGridView1.Rows[appointmentMonth].Cells[column.Name].Value = currentValue;
                        }
                    }
                    if (!typeFound)
                    {
                        int currentValue = Convert.ToInt32(dataGridView1.Rows[appointmentMonth].Cells["Other"].Value);
                        currentValue++;
                        dataGridView1.Rows[appointmentMonth].Cells["Other"].Value = currentValue;
                    }
                }

                peopleListBox.Visible = false;
            }
            else if (reportTypeBox.SelectedItem.ToString() == "Consultant appointments by month")
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                searchButton.Visible = false;
                searchTextBox.Visible = false;
                specialties.Clear();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Month", "Month");
                foreach (Consultant consultant in Consultant.Consultants)
                {
                    dataGridView1.Columns.Add(consultant.Name, consultant.Name);
                }
                for (int month = 0; month < DateTimeFormatInfo.CurrentInfo.MonthNames.Length - 1; month++)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewTextBoxCell { Value = DateTimeFormatInfo.CurrentInfo.MonthNames[month] });
                    for (int i = 0; i < Consultant.Consultants.Count; i++)
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = 0 });
                    }
                    dataGridView1.Rows.Add(row);
                }
                foreach (Appointment appointment in Appointment.AllAppointments)
                {
                    int appointmentMonth = appointment.Date.Month - 1;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if (column.Name == appointment.Consultant)
                        {
                            int currentValue = Convert.ToInt32(dataGridView1.Rows[appointmentMonth].Cells[column.Name].Value);
                            currentValue++;
                            dataGridView1.Rows[appointmentMonth].Cells[column.Name].Value = currentValue;
                        }
                    }
                }

                peopleListBox.Visible = false;
            }

            else if (reportTypeBox.SelectedItem.ToString() == "Consultant schedules")
            {
                searchButton.Visible = true;
                searchTextBox.Visible = true;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Columns.Clear();
                peopleListBox.Items.Clear();
                foreach (Consultant consultant in Consultant.Consultants)
                {
                    peopleListBox.Items.Add(consultant.Name);
                }
                peopleListBox.Visible = true;
            }
            else if (reportTypeBox.SelectedItem.ToString() == "Customer schedules")
            {
                searchButton.Visible = true;
                searchTextBox.Visible = true;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Columns.Clear();
                peopleListBox.Items.Clear();
                foreach (Customer customer in Customer.Customers)
                {
                    peopleListBox.Items.Add(customer.Name);
                }
                peopleListBox.Visible = true;
            }
            else if (reportTypeBox.SelectedItem.ToString() == "Login attempts")
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Timestamp", "Timestamp");
                dataGridView1.Columns.Add("Successful", "Successful");
                dataGridView1.Columns.Add("Username", "Username");
                using (StreamReader reader = new StreamReader("Logins.txt"))
                {
                    string timestamp = string.Empty;
                    string username = string.Empty;
                    string successful = string.Empty;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int splitIndex = line.IndexOf(":", line.IndexOf("Time"));
                        string[] halves = new string[] { line.Substring(0, splitIndex), line.Substring(splitIndex + 1) };
                        timestamp = halves[0].Trim();
                        if (halves[1].Contains("Successful login by"))
                        {
                            successful = "Yes";
                            username = halves[1].Replace("Successful login by", "").Trim();
                        }
                        else if (halves[1].Contains("Unsuccessful login attempt by"))
                        {
                            successful = "No";
                            username = halves[1].Replace("Unsuccessful login attempt by", "").Trim();
                        }

                        DataGridViewRow row = new DataGridViewRow();
                        dataGridView1.Rows.Add(row);
                        int lastIndex = dataGridView1.Rows.Count - 1;
                        dataGridView1.Rows[lastIndex].Cells["Timestamp"].Value = timestamp;
                        dataGridView1.Rows[lastIndex].Cells["Successful"].Value = successful;
                        dataGridView1.Rows[lastIndex].Cells["Username"].Value = username; 
                    }
                }
                peopleListBox.Visible = false;
            }
        }

        private void PeopleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportTypeBox.SelectedItem.ToString() == "Consultant schedules")
            {
                string user = peopleListBox.SelectedItem.ToString();
                Appointment.UserFilter(user);
                dataGridView1.DataSource = Appointment.AppointmentsUserFiltered;
                dataGridView1.Refresh();
            }
            else if (reportTypeBox.SelectedItem.ToString() == "Customer schedules")
            {
                string customer = peopleListBox.SelectedItem.ToString();
                Appointment.CustomerFilter(customer);
                dataGridView1.DataSource = Appointment.AppointmentsUserFiltered;
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
                if (dataGridView1.DataSource == Appointment.AppointmentsUserFiltered)
                {
                    for (int i = 0; i < Appointment.AppointmentsUserFiltered.Count; i++)
                    {
                        if (Appointment.AppointmentsUserFiltered[i].ToString().ToUpper().Contains(searchValue.ToUpper()))
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
