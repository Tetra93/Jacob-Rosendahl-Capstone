using Jacob_Rosendahl_C969_Scheduling_Application.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Classes
{
    public class Consultant : User
    {
        public string Specialty { set; get; }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string City { set; get; }

        public string Country { set; get; }

        public static BindingList<Consultant> Consultants = new BindingList<Consultant>();

        public static void PopulateConsultants()
        {
            Consultants.Clear();
            DBConnection.SqlString = @"SELECT u.userID, u.name, u.specialty, a.address, a.phone, a.city, a.country 
                                       FROM user u 
                                       JOIN address a 
                                       ON u.userID = a.addressId
                                       WHERE u.accessLevel = 2";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Reader = DBConnection.Cmd.ExecuteReader();
            if (DBConnection.Reader.HasRows)
            {
                while (DBConnection.Reader.Read())
                {
                    Consultants.Add(new Consultant()
                    {
                        UserId = DBConnection.Reader.GetInt32(0),
                        Name = DBConnection.Reader.GetString(1),
                        Specialty = DBConnection.Reader.GetString(2),
                        Address = DBConnection.Reader.GetString(3),
                        Phone = DBConnection.Reader.GetString(4),
                        City = DBConnection.Reader.GetString(5),
                        Country = DBConnection.Reader.GetString(6)
                    });
                }
            }
            DBConnection.Reader.Close();
        }
    }
}
