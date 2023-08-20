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
    public partial class AddUpdateAppointments : Form
    {
        public static string CustomerName { set; get; }

        public static string AppointmentType { set; get; }

        public static string ConsultantName { set; get; }

        public static DateTime Date { set; get; }

        public static DateTime StartTime { set; get; }

        public static DateTime EndTime { set; get; }

        public static int CustomerID { set; get; }

        public static int ConsultantID { set; get; }


        public AddUpdateAppointments()
        {
            InitializeComponent();
        }

        private void AddUpdateAppointments_Load(object sender, EventArgs e)
        {
            foreach (Customer customer in Customer.Customers)
            {
                customerName.Items.Add(customer.Name);
            }
            typeBox.Items.Add("Presentation");
            typeBox.Items.Add("Scrum");
            typeBox.Items.Add("Planning");
            typeBox.Items.Add("Review");

            foreach (string user in User.userList)
            {
                consultantName.Items.Add(user);
            }
            if (this.Text == "New Appointment")
            {
                datePicker.MinDate = DateTime.Now;
                startTimePicker.MinDate = DateTime.Now;
                endTimePicker.MinDate = DateTime.Now;
            }
            else if (this.Text == "Update Appointment")
            {
                customerName.Text = Appointment.AllAppointments[Appointments.CurrentID].Customer;
                CustomerName = customerName.Text;
                typeBox.Text = Appointment.AllAppointments[Appointments.CurrentID].Type;
                AppointmentType = typeBox.Text;
                consultantName.Text = Appointment.AllAppointments[Appointments.CurrentID].Consultant;
                ConsultantName = consultantName.Text;
                datePicker.Value = Appointment.AllAppointments[Appointments.CurrentID].Date;
                Date = datePicker.Value.Date;
                startTimePicker.Value = DateTime.Parse(Appointment.AllAppointments[Appointments.CurrentID].StartTime.ToString()).AddDays(1);
                StartTime = startTimePicker.Value;
                endTimePicker.Value = DateTime.Parse(Appointment.AllAppointments[Appointments.CurrentID].EndTime.ToString()).AddDays(1);
                EndTime = endTimePicker.Value;
            }
        }

        private void CustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerName = customerName.Text;
            foreach (Customer customer in Customer.Customers)
            {
                if (customer.Name == CustomerName)
                {
                    CustomerID = customer.CustomerID;
                }
            }
        }

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppointmentType = typeBox.Text;
        }

        private void ConsultantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultantID = consultantName.SelectedIndex + 1;
            ConsultantName = consultantName.Text;
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            Date = datePicker.Value;
            startTimePicker.Value = Date.AddSeconds(1);
            endTimePicker.Value = Date.AddSeconds(2);
        }

        private void StartTimePicker_ValueChanged(object sender, EventArgs e)
        {
            StartTime = startTimePicker.Value;
            endTimePicker.MinDate = startTimePicker.Value.AddSeconds(1);
        }

        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndTime = endTimePicker.Value;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("Please specify the appointment type.", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (string.IsNullOrWhiteSpace(comboBox.Text))
                    {
                        MessageBox.Show("Please select both a customer and consultant", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    if (dateTimePicker.Name == "datePicker" && (dateTimePicker.Value.Date < DateTime.Now.Date))
                    {
                        MessageBox.Show("Date cannot be earlier than the current date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (dateTimePicker.Name.Contains("Time") && ((dateTimePicker.Value.TimeOfDay.Hours > 20) || (dateTimePicker.Value.TimeOfDay.Hours < 8)))
                    {
                        MessageBox.Show("Please select appointment times within business hours. Business are from 8AM to 8PM", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            if (Appointment.AppointmentOverlapCheck() == true)
            {
                return;
            }
            if (this.Text == "New Appointment")
            {
                DBAppointment.AddAppointment();
            }
            else if (this.Text == "Update Appointment")
            {
                DBAppointment.UpdateAppointment();
            }
            Appointment.PopulateAppointments();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUpdateAppointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            Appointments.appointments.Show();
        }

    }
}
