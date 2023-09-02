using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Database
{
    class DBCustomerAdd
    {

        public static void AddUser()
        {
            if (DBCustomerChecks.UserCheck(AddUpdateUser.UserID) == false)
            {
               
                DBConnection.SqlString = $"INSERT INTO user (userId, userName, name, createdBy, lastUpdateBy)" +
                    $" VALUES ({AddUpdateUser.UserID}, \"{AddUpdateUser.Username}\", \"{AddUpdateUser.CustomerName}\", \"{Login.UserName}\", \"{Login.UserName}\")";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
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
