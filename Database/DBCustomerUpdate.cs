using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Database
{
    class DBCustomerUpdate
    {
        public static void UpdateUser(string specialty)
        {
            if (DBCustomerChecks.UserCheck(AddUpdateUser.UserID) == true)
            {
                DBConnection.SqlString = $"UPDATE user " +
                    $"SET name = @name, specialty = @specialty, lastUpdate = CURRENT_TIMESTAMP(), lastUpdateBy = \"{Login.UserName}\" " +
                    $"WHERE userId = {DBCustomerChecks.LastCustomerID}";                        
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.Parameters.AddWithValue("@name", AddUpdateUser.CustomerName);
                if (specialty == "")
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@specialty", DBNull.Value);
                }
                else
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@specialty", AddUpdateUser.CurrentSpecialty);
                }
                DBConnection.Cmd.ExecuteNonQuery();
                
            }
        }

        public static void UpdateAddress()
        {
            if (DBCustomerChecks.AddressCheck(AddUpdateUser.UserID) == true)
            {
                DBConnection.SqlString = $"UPDATE address " +
                    $"SET address = \"{AddUpdateUser.Address}\", postalCode = \"{AddUpdateUser.PostalCode}\", phone = \"{AddUpdateUser.Phone}\", lastUpdate = CURRENT_TIMESTAMP(), lastUpdateBy = \"{Login.UserName}\" " +
                    $"WHERE addressId = {DBCustomerChecks.LastCustomerID}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }
    }
}
