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
                    $"SET name = @name, specialty = @specialty, accessLevel = @accessLevel, lastUpdate = CURRENT_TIMESTAMP(), lastUpdateBy = \"{Login.UserName}\" " +
                    $"WHERE userId = {DBCustomerChecks.LastCustomerID}";                        
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.Parameters.AddWithValue("@name", AddUpdateUser.Name2);
                if (specialty == "")
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@specialty", DBNull.Value);
                }
                else
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@specialty", AddUpdateUser.CurrentSpecialty);

                }
                if (AddUpdateUser.Role == "Admin")
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@accessLevel", 1);
                }
                else if (AddUpdateUser.Role == "Consultant")
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@accessLevel", 2);
                }
                else
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@accessLevel", 3);
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

        public static void UpdatePassword(string password)
        {
            DBConnection.SqlString = $"UPDATE user " +
                $"SET password = \"{password}\", lastUpdate = CURRENT_TIMESTAMP(), lastUpdateBy = \"{Login.UserName}\" " +
                $"WHERE userId = {Login.CurrentUser.UserId}";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Cmd.ExecuteNonQuery();
        }
    }
}
