using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jacob_Rosendahl_Appointed_Program.Classes;
using Jacob_Rosendahl_Appointed_Program.Database;

namespace Jacob_Rosendahl_Appointed_Program
{
    public partial class Appointments : Form
    {
        public static Appointments appointments;

        public static int CurrentIndex { set; get; }

        public static int AppointmentID { set; get; }

        public Appointments()
        {
            InitializeComponent();
            if (Login.CurrentUser.AccessLevel == 3)
            {
                newButton.Enabled = false;
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            dataGridView1.DataSource = null;
            if (Login.CurrentUser.AccessLevel == 3 || Login.CurrentUser.AccessLevel == 2)
            {
                Appointment.UserFilter(Login.CurrentUser.Name);
                dataGridView1.DataSource = Appointment.AppointmentsUserFiltered;
            }
            else
            {
                dataGridView1.DataSource = Appointment.AllAppointments;
            }
            allRadio.Checked = true;
            appointments = this;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void AllRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (allRadio.Checked)
            {
                fromDate.Enabled = false;
                toDate.Enabled = false;
                if (Login.CurrentUser.AccessLevel == 3 || Login.CurrentUser.AccessLevel == 2)
                {
                    Appointment.UserFilter(Login.CurrentUser.Name);
                    dataGridView1.DataSource = Appointment.AppointmentsUserFiltered;
                }
                else
                {
                    dataGridView1.DataSource = Appointment.AllAppointments;
                }
            }
        }

        private void CurrentWeekRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (currentWeekRadio.Checked)
            {
                fromDate.Enabled = false;
                toDate.Enabled = false;
                Appointment.AppointmentsDateFiltered.Clear();
                if (Login.CurrentUser.AccessLevel == 1)
                {
                    foreach (Appointment appointment in Appointment.AllAppointments)
                        if (appointment.Date.Year == DateTime.Now.Year)
                        {
                            int appointmentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(appointment.Date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                            int currentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                            if (appointmentWeek == currentWeek)
                            {
                                Appointment.AppointmentsDateFiltered.Add(appointment);
                            }
                        }
                }
                else
                {
                    foreach (Appointment appointment in Appointment.AppointmentsUserFiltered)
                        if (appointment.Date.Year == DateTime.Now.Year)
                        {
                            int appointmentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(appointment.Date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                            int currentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                            if (appointmentWeek == currentWeek)
                            {
                                Appointment.AppointmentsDateFiltered.Add(appointment);
                            }
                        }
                }
                dataGridView1.DataSource = Appointment.AppointmentsDateFiltered;
            }
        }

        private void CurrentMonthRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (currentMonthRadio.Checked)
            {
                fromDate.Enabled = false;
                toDate.Enabled = false;
                Appointment.AppointmentsDateFiltered.Clear();
                if (Login.CurrentUser.AccessLevel == 1)
                {
                    foreach (Appointment appointment in Appointment.AllAppointments)
                        if (appointment.Date.Year == DateTime.Now.Year)
                        {
                            int appointmentMonth = appointment.Date.Month;
                            int currentMonth = DateTime.Now.Month;
                            if (appointmentMonth == currentMonth)
                            {
                                Appointment.AppointmentsDateFiltered.Add(appointment);
                            }
                        }
                }
                else
                {
                    foreach (Appointment appointment in Appointment.AppointmentsUserFiltered)
                        if (appointment.Date.Year == DateTime.Now.Year)
                        {
                            int appointmentMonth = appointment.Date.Month;
                            int currentMonth = DateTime.Now.Month;
                            if (appointmentMonth == currentMonth)
                            {
                                Appointment.AppointmentsDateFiltered.Add(appointment);
                            }
                        }
                }
                dataGridView1.DataSource = Appointment.AppointmentsDateFiltered;
            }
        }

        private void OtherRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (otherRadio.Checked)
            {
                fromDate.Visible = true;
                toDate.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                fromDate.Enabled = true;
                toDate.Enabled = true;
                if (Login.CurrentUser.AccessLevel == 1)
                {
                    if (Appointment.AllAppointments.Count > 0)

                    {
                        fromDate.MinDate = Appointment.AllAppointments[0].Date;
                        fromDate.Value = Appointment.AllAppointments[0].Date;
                        toDate.MaxDate = Appointment.AllAppointments[0].Date;
                        toDate.Value = Appointment.AllAppointments[0].Date;
                    }
                    foreach (Appointment appointment in Appointment.AllAppointments)
                    {
                        if (appointment.Date < fromDate.MinDate)
                        {
                            fromDate.MinDate = appointment.Date;
                            fromDate.Value = appointment.Date;
                        }
                        if (appointment.Date > toDate.MaxDate)
                        {
                            toDate.MaxDate = appointment.Date;
                            toDate.Value = appointment.Date;
                        }
                    }
                }
                else
                {
                    if (Appointment.AppointmentsUserFiltered.Count > 0)
                    {
                        fromDate.MinDate = Appointment.AppointmentsUserFiltered[0].Date;
                        fromDate.Value = Appointment.AppointmentsUserFiltered[0].Date;
                        toDate.MaxDate = Appointment.AppointmentsUserFiltered[0].Date;
                        toDate.Value = Appointment.AppointmentsUserFiltered[0].Date;
                    }
                    foreach (Appointment appointment in Appointment.AppointmentsUserFiltered)
                    {
                        if (appointment.Date < fromDate.MinDate)
                        {
                            fromDate.MinDate = appointment.Date;
                            fromDate.Value = appointment.Date;
                        }
                        if (appointment.Date > toDate.MaxDate)
                        {
                            toDate.MaxDate = appointment.Date;
                            toDate.Value = appointment.Date;
                        }
                    }
                }
            }
            else
            {
                fromDate.Visible = false;
                toDate.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                fromDate.Enabled = false;
                toDate.Enabled = false;
            }
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            toDate.MinDate = fromDate.Value;

            if (otherRadio.Checked == false)
            {
                return;
            }
            Appointment.AppointmentsDateFiltered.Clear();
            try
            {
                if (fromDate.Value > toDate.Value)
                {
                    fromDate.Value = toDate.Value;
                    throw new Exception("Starting date cannot be later than the ending date");
                }
                if (Login.CurrentUser.AccessLevel == 1)
                {
                    foreach (Appointment appointment in Appointment.AllAppointments)
                    {
                        if (appointment.Date.Date >= fromDate.Value.Date && appointment.Date.Date <= toDate.Value.Date)
                        {
                            Appointment.AppointmentsDateFiltered.Add(appointment);
                        }
                    }
                }
                else
                {
                    foreach (Appointment appointment in Appointment.AppointmentsUserFiltered)
                        if (appointment.Date.Date >= fromDate.Value.Date && appointment.Date.Date <= toDate.Value.Date)
                        {
                            Appointment.AppointmentsDateFiltered.Add(appointment);
                        }
                }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Appointment.AppointmentsDateFiltered;
                    dataGridView1.Refresh();
                }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            fromDate.MaxDate = toDate.Value;

            if (otherRadio.Checked == false)
            {
                return;
            }
            Appointment.AppointmentsDateFiltered.Clear();
            try
            {
                if (fromDate.Value > toDate.Value)
                {
                    toDate.Value = fromDate.Value;
                    throw new Exception("Starting date cannot be later than the ending date");
                }
                if (Login.CurrentUser.AccessLevel == 1)
                {
                    foreach (Appointment appointment in Appointment.AllAppointments)
                    {
                        if (appointment.Date.Date >= fromDate.Value.Date && appointment.Date.Date <= toDate.Value.Date)
                        {
                            Appointment.AppointmentsDateFiltered.Add(appointment);
                        }
                    }
                }
                else
                {
                    foreach (Appointment appointment in Appointment.AppointmentsUserFiltered)
                    {
                        if (appointment.Date.Date >= fromDate.Value.Date && appointment.Date.Date <= toDate.Value.Date)
                        {
                            Appointment.AppointmentsDateFiltered.Add(appointment);
                        }
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Appointment.AppointmentsDateFiltered;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Login.CurrentUser.AccessLevel == 3)
            {
                newButton.Enabled = false;
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
                return;
            }
            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    CurrentIndex = dataGridView1.CurrentRow.Index;
                    AppointmentID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
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

        private void NewButton_Click(object sender, EventArgs e)
        {
            AddUpdateAppointments addUpdateAppointments = new AddUpdateAppointments();
            DBAppointment.AppointmentID = Appointment.AllAppointments.Last().AppointmentID;
            addUpdateAppointments.Text = "New Appointment";
            addUpdateAppointments.Show();
            this.Hide();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            AddUpdateAppointments addUpdateAppointments = new AddUpdateAppointments();
            addUpdateAppointments.Text = "Update Appointment";
            addUpdateAppointments.Show();
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Delete appointment?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                DBAppointment.DeleteAppointment();
                Appointment.PopulateAppointments();
                if (Login.CurrentUser.AccessLevel == 2)
                {
                    Appointment.UserFilter(Login.CurrentUser.Name);
                }
                if (allRadio.Checked == true)
                {
                    if (Login.CurrentUser.AccessLevel == 1)
                    {
                        dataGridView1.DataSource = Appointment.AllAppointments;
                    }
                    else
                    {
                        Appointment.UserFilter(Login.CurrentUser.Name);
                        dataGridView1.DataSource = Appointment.AppointmentsUserFiltered;
                    }
                }

                else if (currentWeekRadio.Checked == true)
                {
                    CurrentWeekRadio_CheckedChanged(null, null);
                }
                else if (currentMonthRadio.Checked == true)
                {
                    CurrentMonthRadio_CheckedChanged(null, null);
                }
                else if (otherRadio.Checked == true)
                {
                    OtherRadio_CheckedChanged(null, null);
                }                
                
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Appointments_FormClosing(object sender, FormClosingEventArgs e)
        {
            HomeMenu.homeMenu.Show();
        }

        //private void Appointments_Activated(object sender, EventArgs e)
        //{
        //    if (this.Visible == true)
        //    {
        //        return;
        //    }
        //    if (Login.CurrentUser.AccessLevel == 2)
        //    {
        //        Appointment.UserFilter(Login.CurrentUser.Name);
        //    }
        //    if (allRadio.Checked == true)
        //    {
        //        if (Login.CurrentUser.AccessLevel == 1)
        //        {
        //            dataGridView1.DataSource = Appointment.AllAppointments;
        //        }
        //        else
        //        {
        //            Appointment.UserFilter(Login.CurrentUser.Name);
        //            dataGridView1.DataSource = Appointment.AppointmentsUserFiltered;
        //        }
        //    }

        //    else if (currentWeekRadio.Checked == true)
        //    {
        //        CurrentWeekRadio_CheckedChanged(null, null);
        //    }
        //    else if (currentMonthRadio.Checked == true)
        //    {
        //        CurrentMonthRadio_CheckedChanged(null, null);
        //    }
        //    else if (otherRadio.Checked == true)
        //    {
        //        OtherRadio_CheckedChanged(null, null);
        //    }
        //}

        private void Appointments_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) 
            {
                return;
            }
            Appointment.PopulateAppointments();
            if (Login.CurrentUser.AccessLevel == 2)
            {
                Appointment.UserFilter(Login.CurrentUser.Name);
            }
            if (allRadio.Checked == true)
            {
                if (Login.CurrentUser.AccessLevel == 1)
                {
                    dataGridView1.DataSource = Appointment.AllAppointments;
                }
                else
                {
                    Appointment.UserFilter(Login.CurrentUser.Name);
                    dataGridView1.DataSource = Appointment.AppointmentsUserFiltered;
                }
            }

            else if (currentWeekRadio.Checked == true)
            {
                CurrentWeekRadio_CheckedChanged(null, null);
            }
            else if (currentMonthRadio.Checked == true)
            {
                CurrentMonthRadio_CheckedChanged(null, null);
            }
            else if (otherRadio.Checked == true)
            {
                OtherRadio_CheckedChanged(null, null);
            }
        }
    }
}
