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
            if (DBCustomerChecks.UserCheck(AddUpdateCustomer.UserID) == false)
            {
                DBConnection.SqlString = $"INSERT INTO user (userId, userName, createdBy, lastUpdateBy)" +
                    $" VALUES ({DBCustomerChecks.LastCustomerID + 1}, \"{AddUpdateCustomer.CustomerName}\", {DBCustomerChecks.LastCustomerID}, \"{Login.UserName}\", \"{Login.UserName}\")";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }



        public static void AddAddress()
        {
            if (DBCustomerChecks.AddressCheck(AddUpdateCustomer.UserID) == false)
            {
                DBCustomerChecks.UserCheck(AddUpdateCustomer.UserID);
                DBConnection.SqlString = $"INSERT INTO address (addressId, address, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                    $" VALUES ({DBCustomerChecks.LastCustomerID}, \"{AddUpdateCustomer.Address}\", {DBCustomerChecks.LastCityID}, \"{AddUpdateCustomer.PostalCode}\", \"{AddUpdateCustomer.Phone}\", CURRENT_TIMESTAMP(), \"{Login.UserName}\", CURRENT_TIMESTAMP(), \"{Login.UserName}\")";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }

        public static void CustomerAddressCorrect()
        {
            if (DBCustomerChecks.UserCheck(AddUpdateCustomer.UserID) == true)
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
