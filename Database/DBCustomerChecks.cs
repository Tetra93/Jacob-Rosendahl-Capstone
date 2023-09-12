using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_Appointed_Program.Database
{
    class DBCustomerChecks
    {
        public static int LastCustomerID { set; get; }

        public static string PostalCode { set; get; }

        public static bool UserCheck(int inputID)
        {
            bool userExists = false;
            DBConnection.SqlString = "SELECT userId FROM user";
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
                            userExists = true;
                            break;
                        }
                    }
                }
            }
            return userExists;
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
                        if (!DBConnection.Reader.IsDBNull(DBConnection.Reader.GetOrdinal("postalCode")))
                        {
                            PostalCode = DBConnection.Reader.GetString(2);
                        }
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
