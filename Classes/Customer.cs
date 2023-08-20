using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacob_Rosendahl_C969_Scheduling_Application.Database;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Classes
{
    public class Customer
    {
        public static Customer customer = new Customer();

        public int CustomerID { set; get; }

        public string Name { set; get; }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string City { set; get; }

        public string Country { set; get; }

        public static BindingList<Customer> Customers = new BindingList<Customer>();

        public static void PopulateCustomers()
        {
            Customers.Clear();
            DBConnection.SqlString = @"SELECT u.customerID, u.customerName, a.address, a.phone, i.city, o.country 
                                       FROM customer u 
                                       JOIN address a 
                                       ON u.addressID = a.addressId 
                                       JOIN city i 
                                       ON a.cityID = i.cityId 
                                       JOIN country o 
                                       ON i.countryID = o.countryId ";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Reader = DBConnection.Cmd.ExecuteReader();
            if (DBConnection.Reader.HasRows)
            {
                while (DBConnection.Reader.Read())
                {
                    Customers.Add(new Customer()
                    {
                        CustomerID = DBConnection.Reader.GetInt32(0),
                        Name = DBConnection.Reader.GetString(1),
                        Address = DBConnection.Reader.GetString(2),
                        Phone = DBConnection.Reader.GetString(3),
                        City = DBConnection.Reader.GetString(4),
                        Country = DBConnection.Reader.GetString(5)
                    });
                }
            }
            DBConnection.Reader.Close();
        }

        public override string ToString() =>
            $"{CustomerID}, " +
            $"{Name}, " +
            $"{Address}, " +
            $"{Phone}, " +
            $"{City}, " +
            $"{Country}";
    }
}
