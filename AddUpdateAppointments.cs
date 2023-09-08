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

        public static Consultant currentConsultant = new Consultant();

        public static string CustomerName { set; get; }

        public static string AppointmentType { set; get; }

        public static string ConsultantName { set; get; }

        public static DateTime Date { set; get; }

        public static DateTime StartTime { set; get; }

        public static DateTime EndTime { set; get; }

        public static int CustomerID { set; get; }

        public static int ConsultantID { set; get; }

        private TimeSpan OpeningTime = new TimeSpan(8, 0, 0);

        private TimeSpan ClosingTime = new TimeSpan(20, 0, 0);

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

            if (Login.CurrentUser.AccessLevel == 1)
            {
            foreach (Consultant consultant in Consultant.Consultants)
            {
                consultantName.Items.Add(consultant.Name);
            }
            }
            else
            {
                consultantName.Items.Add(Login.CurrentUser.Name);
                consultantName.SelectedItem = Login.CurrentUser.Name;
                typeBox.SelectedIndex = 0;
            }
            if (this.Text == "New Appointment")
            {
                datePicker.MinDate = DateTime.Now.Date;
                endTimePicker.MinDate = DateTime.Now.AddMinutes(1);
                endTimePicker.Value = DateTime.Now.AddMinutes(30);
                startTimePicker.MinDate = DateTime.Now;
            }
            else if (this.Text == "Update Appointment")
            {
                
                if (Login.CurrentUser.AccessLevel == 2)
                {
                    var startTime = Appointment.AppointmentsUserFiltered[Appointments.CurrentIndex].StartTime;
                    var endTime = Appointment.AppointmentsUserFiltered[Appointments.CurrentIndex].EndTime;
                    customerName.Text = Appointment.AppointmentsUserFiltered[Appointments.CurrentIndex].Customer;
                    consultantName.Text = Appointment.AppointmentsUserFiltered[Appointments.CurrentIndex].Consultant;
                    if (!typeBox.Items.Contains(Appointment.AppointmentsUserFiltered[Appointments.CurrentIndex].Type))
                    {
                        typeBox.SelectedIndex = 1;
                        otherTypeTextBox.Text = Appointment.AppointmentsUserFiltered[Appointments.CurrentIndex].Type;
                        otherTypeTextBox.ForeColor = Color.Black;
                        AppointmentType = otherTypeTextBox.Text;
                    }
                    else
                    {
                        typeBox.Text = Appointment.AppointmentsUserFiltered[Appointments.CurrentIndex].Type;
                        AppointmentType = typeBox.Text;
                    }
                    datePicker.Value = Appointment.AppointmentsUserFiltered[Appointments.CurrentIndex].Date;
                    startTimePicker.Value = datePicker.Value.Date + startTime;
                    endTimePicker.Value = datePicker.Value.Date + endTime;
                }
                else
                {
                    var startTime = Appointment.AllAppointments[Appointments.CurrentIndex].StartTime;
                    var endTime = Appointment.AllAppointments[Appointments.CurrentIndex].EndTime;
                    customerName.Text = Appointment.AllAppointments[Appointments.CurrentIndex].Customer;
                    consultantName.Text = Appointment.AllAppointments[Appointments.CurrentIndex].Consultant;
                    if (!typeBox.Items.Contains(Appointment.AllAppointments[Appointments.CurrentIndex].Type))
                    {
                        typeBox.SelectedIndex = 1;
                        otherTypeTextBox.Text = Appointment.AllAppointments[Appointments.CurrentIndex].Type;
                        otherTypeTextBox.ForeColor = Color.Black;
                        AppointmentType = otherTypeTextBox.Text;
                    }
                    else
                    {
                        typeBox.Text = Appointment.AllAppointments[Appointments.CurrentIndex].Type;
                        AppointmentType = typeBox.Text;
                    }
                    datePicker.Value = Appointment.AllAppointments[Appointments.CurrentIndex].Date.Date;
                    startTimePicker.Value = datePicker.Value.Date + startTime;
                    endTimePicker.Value = datePicker.Value.Date + endTime;
                }
                CustomerName = customerName.Text;
                ConsultantName = consultantName.Text;
                Date = datePicker.Value.Date;
                StartTime = startTimePicker.Value;
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
                    CustomerID = customer.UserId;
                }
            }
        }

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeBox.Text == "Other")
            {
                otherTypeTextBox.Visible = true;
            }
            else
            {
                otherTypeTextBox.Visible = false;
                AppointmentType = typeBox.Text;
            }
        }

        private void ConsultantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Login.CurrentUser.AccessLevel == 2)
            {
                foreach (Consultant consultant in Consultant.Consultants)
                {
                    if (consultant.Name == Login.CurrentUser.Name)
                    {
                        currentConsultant = consultant;
                    }
                }
            }
            else
            {
                currentConsultant = Consultant.Consultants[consultantName.SelectedIndex];
            }
            ConsultantID = currentConsultant.UserId;
            ConsultantName = currentConsultant.Name;
            typeBox.Items.Clear();
            typeBox.Items.Add(currentConsultant.Specialty);
            typeBox.Items.Add("Other");
            typeBox.SelectedIndex = 0;
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            Date = datePicker.Value.Date;
            startTimePicker.Value = datePicker.Value.Date + startTimePicker.Value.TimeOfDay;
            endTimePicker.Value = datePicker.Value.Date + endTimePicker.Value.TimeOfDay;
            if (Date == DateTime.Now.Date && StartTime.TimeOfDay == DateTime.Now.TimeOfDay)
            {
                startTimePicker.Value = DateTime.Now;
            }
            else if (Date == DateTime.Now.Date && EndTime.TimeOfDay == DateTime.Now.TimeOfDay)
            {
                endTimePicker.Value = DateTime.Now.AddMinutes(30);
            }
            if (datePicker.Value.Date == DateTime.Now.Date)
            {
                startTimePicker.MinDate = DateTime.Now;
                endTimePicker.MinDate = DateTime.Now.AddMinutes(30);
            }
            else
            {
                startTimePicker.MinDate = DateTimePicker.MinimumDateTime;
                endTimePicker.MinDate = DateTimePicker.MinimumDateTime;
            }
        }

        private void StartTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startTimePicker.Value >= endTimePicker.Value)
            {
                endTimePicker.Value = startTimePicker.Value.AddMinutes(1);
            }
            StartTime = startTimePicker.Value;
        }

        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (endTimePicker.Value <= startTimePicker.Value)
            {
                endTimePicker.Value = startTimePicker.Value.AddMinutes(1);
            }
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
                    else if (dateTimePicker.Name.Contains("Time") && ((dateTimePicker.Value.TimeOfDay > ClosingTime) || (dateTimePicker.Value.TimeOfDay < OpeningTime)))
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

        private void OtherTypeTextBox_Enter(object sender, EventArgs e)
        {
            if (otherTypeTextBox.Text == "Other appointment type" && otherTypeTextBox.ForeColor == Color.Gray)
            {
                otherTypeTextBox.Text = "";
                otherTypeTextBox.ForeColor = Color.Black;
            }
        }

        private void OtherTypeTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(otherTypeTextBox.Text)) 
            {
                otherTypeTextBox.Text = "Other appointment type";
                otherTypeTextBox.ForeColor = Color.Gray;
            }
            else
            {
                AppointmentType = otherTypeTextBox.Text;
            }
        }
    }
}
