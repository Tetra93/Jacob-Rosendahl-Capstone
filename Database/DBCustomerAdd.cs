using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_Appointed_Program.Database
{
    class DBCustomerAdd
    {

        public static void AddUser()
        {
            if (DBCustomerChecks.UserCheck(AddUpdateUser.UserID) == false)
            {
               
                DBConnection.SqlString = $"INSERT INTO user (userId, userName, name, specialty, accessLevel, createdBy, lastUpdateBy)" +
                    $" VALUES ({AddUpdateUser.UserID}, \"{AddUpdateUser.Username}\", \"{AddUpdateUser.Name2}\", @specialty, @accessLevel, \"{Login.UserName}\", \"{Login.UserName}\")";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                if (AddUpdateUser.Role == "Consultant")
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@specialty", AddUpdateUser.CurrentSpecialty);
                    DBConnection.Cmd.Parameters.AddWithValue("@accessLevel", 2);
                }
                else if (AddUpdateUser.Role == "Admin")
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@specialty", DBNull.Value);
                    DBConnection.Cmd.Parameters.AddWithValue("@accessLevel", 1);
                }
                else
                {
                    DBConnection.Cmd.Parameters.AddWithValue("@specialty", DBNull.Value);
                    DBConnection.Cmd.Parameters.AddWithValue("@accessLevel", 3);
                }
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }



        public static void AddAddress()
        {
            {
                DBCustomerChecks.UserCheck(AddUpdateUser.UserID);
                DBConnection.SqlString = $"INSERT INTO address (addressId, address, city, country, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                    $" VALUES ({AddUpdateUser.UserID}, \"{AddUpdateUser.Address}\", \"{AddUpdateUser.CurrentCity}\", \"{AddUpdateUser.CurrentCountry}\", \"{AddUpdateUser.PostalCode}\", \"{AddUpdateUser.Phone}\", CURRENT_TIMESTAMP(), \"{Login.UserName}\", CURRENT_TIMESTAMP(), \"{Login.UserName}\")";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }

        public static void CustomerAddressCorrect()
        {
            if (DBCustomerChecks.UserCheck(AddUpdateUser.UserID) == true)
            {
                DBConnection.SqlString = $"UPDATE user " +
                    $"SET addressId = {DBCustomerChecks.LastCustomerID} " +
                    $"WHERE userId = {DBCustomerChecks.LastCustomerID}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }
    }
}
