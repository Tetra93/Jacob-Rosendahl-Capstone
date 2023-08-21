using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jacob_Rosendahl_C969_Scheduling_Application.Database;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Classes
{
    public class Appointment
    {
        public static Appointment appointment = new Appointment();

        public static string CustomerName { set; get; }

        public int AppointmentID { set; get; }

        public string Type { set; get; }

        public int CustomerID { set; get; }

        public string Customer { set; get; }

        public string Consultant { set; get; }

        public DateTime Date { set; get; }

        public TimeSpan StartTime { set; get; }

        public TimeSpan EndTime { set; get; }

        public static BindingList<Appointment> AllAppointments = new BindingList<Appointment>();

        public static BindingList<Appointment> AppointmentsFiltered = new BindingList<Appointment>();

        public static void PopulateAppointments()
        {
            AllAppointments.Clear();
            DBConnection.SqlString = @"SELECT a.appointmentId, a.type, u1.userName, u2.userName, a.start, a.end
                                       FROM appointment a
                                       JOIN user u1 ON a.customerId = u1.userID
                                       JOIN user u2 ON a.consultantId = u2.userId
                                       ORDER BY a.appointmentId";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Reader = DBConnection.Cmd.ExecuteReader();
            if (DBConnection.Reader.HasRows)
            {
                while (DBConnection.Reader.Read())
                {
                    //I'm using a lambda here to convert UTC to local time so I don't need to create
                    //multiple variables or methods for changing the DateTime to UTC then changing
                    //that to a TimeSpan to display only the time. The lambda returns only the 
                    //TimeOfDay of the DateTime argument. The DateTime is given to it in local time.
                    Func<DateTime, TimeSpan> localTime = d => d.TimeOfDay;
                    DateTime date = DBConnection.Reader.GetDateTime(5);
                    if(date.Date != date.Date.ToLocalTime())
                    {
                        date = date.ToLocalTime();
                    }
                    AllAppointments.Add(new Appointment()
                    {
                        AppointmentID = DBConnection.Reader.GetInt32(0),
                        Type = DBConnection.Reader.GetString(1),
                        Customer = DBConnection.Reader.GetString(2),
                        Consultant = DBConnection.Reader.GetString(3),
                        Date = date,
                        StartTime = localTime(DBConnection.Reader.GetDateTime(4).ToLocalTime()),
                        EndTime = localTime(DBConnection.Reader.GetDateTime(5).ToLocalTime()),
                    });
                }
            }
            DBConnection.Reader.Close();
        }

        public static void UserFilter (string user)
        {
            AppointmentsFiltered.Clear();
            foreach (Appointment appointment in AllAppointments)
                if (appointment.Consultant == user)
                {
                    AppointmentsFiltered.Add(appointment);
                }
        }

        public static void CustomerFilter (string customer)
        {
            AppointmentsFiltered.Clear();
            foreach (Appointment appointment in AllAppointments)
            {
                if (appointment.Customer == customer)
                {
                    AppointmentsFiltered.Add(appointment);
                }
            }
        }

        public static bool AppointmentOverlapCheck()
        {
            bool overlap = false;
            TimeSpan startTime = AddUpdateAppointments.StartTime.TimeOfDay;
            TimeSpan endTime = AddUpdateAppointments.EndTime.TimeOfDay;
            foreach (Appointment appointment in Appointment.AllAppointments)
            {
                if (appointment.AppointmentID != Appointments.AppointmentID)
                {
                    if (appointment.Date.ToShortDateString() == AddUpdateAppointments.Date.ToShortDateString())
                    {
                        if ((((startTime >= appointment.StartTime) && (startTime <= appointment.EndTime)) || 
                            ((endTime >= appointment.StartTime) && (endTime <= appointment.EndTime))) ||
                            (((appointment.StartTime >= startTime) && (appointment.StartTime <= endTime)) ||
                            ((appointment.EndTime >= startTime) && (appointment.EndTime <= endTime))))
                        {
                            
                            if (appointment.Customer == AddUpdateAppointments.CustomerName)
                            {
                                MessageBox.Show($"Appointment time for {appointment.Customer} overlaps with AppointmentID #{appointment.AppointmentID} which is from {appointment.StartTime} to {appointment.EndTime}. Please choose a different time.");
                                overlap = true;
                                break;
                            }
                            else if (appointment.Consultant == AddUpdateAppointments.ConsultantName)
                            {
                                MessageBox.Show($"Appointment time for {appointment.Consultant} overlaps with AppointmentID #{appointment.AppointmentID} which is from {appointment.StartTime} to {appointment.EndTime}. Please choose a different time.");
                                overlap = true;
                                break;
                            }
                        }
                    }
                }
            }
            return overlap;
        }
        public static bool TimeCheck()
        {
            bool doAlert = false;
            foreach (Appointment appointment in AllAppointments)
            {
                if (appointment.Consultant == Login.UserName)
                {
                    DateTime date = appointment.Date;
                    if (date.Date == DateTime.Now.Date)
                    {
                        TimeSpan time = appointment.StartTime - DateTime.Now.TimeOfDay;
                        if (time.TotalMinutes <= 15 && time.TotalMinutes > 0)
                        {
                            CustomerName = appointment.Customer;
                            doAlert = true;
                            break;
                        }
                    }
                }
            }
            return doAlert;
        }
        public override string ToString() =>
            $"{AppointmentID}, " +
            $"{Type}, " +
            $"{CustomerID}, " +
            $"{CustomerName}, " +
            $"{Consultant}, " +
            $"{StartTime}, " +
            $"{EndTime}";
    }
}
