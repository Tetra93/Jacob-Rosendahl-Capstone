using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jacob_Rosendahl_C969_Scheduling_Application.Database;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Classes
{
    public class Customer : User
    {
        public string Address { set; get; }

        public string Phone { set; get; }

        public string City { set; get; }

        public string Country { set; get; }

        public string PostalCode { set; get; }

        public static BindingList<Customer> Customers = new BindingList<Customer>();

        public static void PopulateCustomers()
        {
            Customers.Clear();
            DBConnection.SqlString = @"SELECT u.userID, u.name, a.address, a.phone, a.city, a.country, a.postalCode
                                       FROM user u 
                                       JOIN address a 
                                       ON u.userID = a.addressId
                                       WHERE u.accessLevel = 3";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Reader = DBConnection.Cmd.ExecuteReader();
            if (DBConnection.Reader.HasRows)
            {
                while (DBConnection.Reader.Read())
                {
                    Customers.Add(new Customer()
                    {
                        UserId = DBConnection.Reader.GetInt32(0),
                        Name = DBConnection.Reader.GetString(1),
                        Address = DBConnection.Reader.GetString(2),
                        Phone = DBConnection.Reader.GetString(3),
                        City = DBConnection.Reader.GetString(4),
                        Country = DBConnection.Reader.GetString(5),
                        PostalCode = DBConnection.Reader.GetString(6)
                    });
                }
            }
            DBConnection.Reader.Close();
        }

        public override string ToString() =>
            $"{UserId}, " +
            $"{Name}, " +
            $"{Address}, " +
            $"{Phone}, " +
            $"{City}, " +
            $"{Country}";
    }
}
