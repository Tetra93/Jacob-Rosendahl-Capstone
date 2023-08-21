using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Database
{
    class DBAppointment
    {
        public static int AppointmentID { set; get; }

        public static bool CheckAppointment(int inputID)
        {
            bool appointmentExists = false;
            DBConnection.SqlString = "SELECT appointmentID FROM appointment ORDER BY appointmentId";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            using (DBConnection.Reader = DBConnection.Cmd.ExecuteReader())
            {
                if (DBConnection.Reader.HasRows)
                {
                    while (DBConnection.Reader.Read())
                    {
                        int ID = DBConnection.Reader.GetInt32(0);
                        AppointmentID = ID;
                        if (ID == inputID)
                        {
                            appointmentExists = true;
                            break;
                        }
                    }
                }
            }
            if( appointmentExists == false)
            {
                AppointmentID++;
            }
            return appointmentExists;
        }

        public static void AddAppointment()
        {
            CheckAppointment(-1);
            DBConnection.SqlString = $"INSERT INTO appointment (appointmentId, customerId, consultantId, type, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                $" VALUES ({AppointmentID}, {AddUpdateAppointments.CustomerID}, {AddUpdateAppointments.ConsultantID}, \"{AddUpdateAppointments.AppointmentType}\", \"{AddUpdateAppointments.StartTime.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss")}\", \"{AddUpdateAppointments.EndTime.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss")}\", CURRENT_TIMESTAMP(), \"{Login.UserName}\", CURRENT_TIMESTAMP(), \"{Login.UserName}\")";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Cmd.ExecuteNonQuery();
        }

        public static void UpdateAppointment()
        {
            if (CheckAppointment(Appointments.AppointmentID) == true)
            {
                DBConnection.SqlString = $"UPDATE appointment " +
                    $"SET customerId = {AddUpdateAppointments.CustomerID}, consultantId = {AddUpdateAppointments.ConsultantID}, type = \"{AddUpdateAppointments.AppointmentType}\", start = \"{AddUpdateAppointments.StartTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}\", end = \"{AddUpdateAppointments.EndTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}\", lastUpdate = CURRENT_TIMESTAMP(), lastUpdateBy = \"{Login.UserName}\" " +
                    $"WHERE appointmentId = {AppointmentID}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteAppointment()
        {
            if (CheckAppointment(Appointments.AppointmentID) == true)
            {
                DBConnection.SqlString = $"DELETE FROM appointment " +
                    $"WHERE appointmentId = {AppointmentID}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }
    }
}
