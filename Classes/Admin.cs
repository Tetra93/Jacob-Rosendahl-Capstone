using Jacob_Rosendahl_Appointed_Program.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacob_Rosendahl_Appointed_Program.Classes
{
    public class Admin : User
    {
        public static List<Admin> Admins = new List<Admin>();

        public static void PopulateAdmins()
        {
            Admins.Clear();

            DBConnection.SqlString = @"SELECT userID, name 
                                       FROM user
                                       WHERE accessLevel = 1";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Reader = DBConnection.Cmd.ExecuteReader();
            if (DBConnection.Reader.HasRows)
            {
                while (DBConnection.Reader.Read())
                {
                    Admins.Add(new Admin()
                    {
                        UserId = DBConnection.Reader.GetInt32(0),
                        Name = DBConnection.Reader.GetString(1)
                    });
                }
            }
            DBConnection.Reader.Close();
        }
        public override string ToString() =>
            $"{UserId}, " +
            $"Admin, " +
            $"{Name}";
    }
}
