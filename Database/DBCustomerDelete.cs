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
        public static void DeleteCustomer()
        {
            if (DBCustomerChecks.UserCheck(Users.ID) == true)
            {
                DBConnection.SqlString = $"DELETE FROM appointment WHERE customerId = {Users.ID}; " +
                    $"DELETE FROM customer WHERE addressId = {Users.ID}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
                Appointment.PopulateAppointments();
            }
        }

        public static void DeleteAddress()
        {
            if (DBCustomerChecks.AddressCheck(Users.ID) == true)
            {
                DBConnection.SqlString = $"DELETE FROM address WHERE addressId = {Users.ID}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }
    }
}
