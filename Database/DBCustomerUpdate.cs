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
        public static void UpdateCustomer()
        {
            if (DBCustomerChecks.UserCheck(AddUpdateCustomer.UserID) == true)
            {
                DBConnection.SqlString = $"UPDATE customer " +
                    $"SET customerName = \"{AddUpdateCustomer.CustomerName}\", lastUpdate = CURRENT_TIMESTAMP(), lastUpdateBy = \"{Login.UserName}\" " +
                    $"WHERE customerId = {DBCustomerChecks.LastCustomerID}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateAddress()
        {
            if (DBCustomerChecks.AddressCheck(AddUpdateCustomer.UserID) == true)
            {
                DBConnection.SqlString = $"UPDATE address " +
                    $"SET address = \"{AddUpdateCustomer.Address}\", cityId = {DBCustomerChecks.LastCityID}, postalCode = \"{AddUpdateCustomer.PostalCode}\", phone = \"{AddUpdateCustomer.Phone}\", lastUpdate = CURRENT_TIMESTAMP(), lastUpdateBy = \"{Login.UserName}\" " +
                    $"WHERE addressId = {DBCustomerChecks.LastCustomerID}";
                DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
                DBConnection.Cmd.ExecuteNonQuery();
            }
        }
    }
}
