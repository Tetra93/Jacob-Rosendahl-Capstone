using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacob_Rosendahl_C969_Scheduling_Application.Classes;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Database
{
    class DBCustomerDelete
    {
        public static void DeleteUser()
        {
            if (DBCustomerChecks.UserCheck(Users.Id) == true)
            {
                DBConnection.SqlString = $"DELETE FROM appointment WHERE customerId = {Users.Id}; " +
                    $"DELETE FROM appointment WHERE consultantId = {Users.Id}; " +
                    $"DELETE FROM user WHERE userId = {Users.Id}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
                Appointment.PopulateAppointments();
            }
        }

        public static void DeleteAddress()
        {
            if (DBCustomerChecks.AddressCheck(Users.Id) == true)
            {
                DBConnection.SqlString = $"DELETE FROM address WHERE addressId = {Users.Id}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }
    }
}
