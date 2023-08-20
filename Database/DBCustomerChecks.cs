using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Database
{
    class DBCustomerChecks
    {
        public static int LastCustomerID { set; get; }

        public static string PostalCode { set; get; }

        public static int LastCityID { set; get; }

        public static int LastCountryID { set; get; }

        public static bool UserCheck(int inputID)
        {
            bool customerExists = false;
            DBConnection.SqlString = "SELECT customerID FROM customer";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            using (DBConnection.Reader = DBConnection.Cmd.ExecuteReader())
            {
                if (DBConnection.Reader.HasRows)
                {
                    while (DBConnection.Reader.Read())
                    {
                        int ID = DBConnection.Reader.GetInt32(0);
                        LastCustomerID = ID;
                        if (ID == inputID)
                        {
                            customerExists = true;
                            break;
                        }
                    }
                }
            }
            return customerExists;
        }

        //public static bool UserCheck()

        public static bool AddressCheck(int inputID)
        {
            bool addressExists = false;
            DBConnection.SqlString = "SELECT * FROM address";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            using (DBConnection.Reader = DBConnection.Cmd.ExecuteReader())
            {
                if (DBConnection.Reader.HasRows)
                {
                    while (DBConnection.Reader.Read())
                    {
                        int ID = DBConnection.Reader.GetInt32(0);
                        LastCustomerID = ID;
                        PostalCode = DBConnection.Reader.GetString(3);
                        if (ID == inputID)
                        {
                            addressExists = true;
                            break;
                        }
                    }
                }
            }
            return addressExists;
        }

    }
}
