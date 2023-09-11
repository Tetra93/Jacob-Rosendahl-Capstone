using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacob_Rosendahl_C969_Scheduling_Application.Database;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Classes
{
    public class User
    {
        public int UserId { set; get; }

        public string UserName { set; get; }

        public string Name { set; get; }

        public string Password { set; get; }

        public int AccessLevel { get; set; }

        public static bool success = false;

        public static List<string> userList = new List<string>();

        public static List<User> allUsers = new List<User>();

        public static void UserLogin()
        {
            userList.Clear();
            DBConnection.SqlString = @"SELECT userId, userName, name, password, accessLevel FROM user";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Reader = DBConnection.Cmd.ExecuteReader();
            if (DBConnection.Reader.HasRows)
            {
                while (DBConnection.Reader.Read())
                {
                    userList.Add(DBConnection.Reader.GetString(0));
                    
                    User DBUser = new User()
                    {
                        UserId = DBConnection.Reader.GetInt32(0),
                        UserName = DBConnection.Reader.GetString(1),
                        Name = DBConnection.Reader.GetString(2),
                        Password = DBConnection.Reader.GetString(3),
                        AccessLevel = DBConnection.Reader.GetInt32(4)
                    };
                    //I'm using two lambdas here to validate the username and password.
                    //They compare what was entered to the database record and return whether
                    //or not they match. Each one returns a bool value and if both are true,
                    //the login attempt was successful. It makes it easier to read so I don't have
                    //two long comparison expressions inside the following if statement
                    Func<User, bool> correctUsername = u => u.UserName == Login.UserName;
                    Func<User, bool> correctPassword = u => u.Password == Login.Password;

                    if (correctUsername(DBUser) && correctPassword(DBUser))
                    {
                        Login.loginSuccessful = true;
                        Login.CurrentUser = DBUser;
                    }
                }
            }
            DBConnection.Reader.Close();
        }

        public static void PopulateUsers ()
        {

            allUsers.Clear();
            DBConnection.SqlString = @"SELECT userId, userName, name, accessLevel FROM user";
            DBConnection.Cmd = new MySqlCommand(DBConnection.SqlString, DBConnection.Conn);
            DBConnection.Reader = DBConnection.Cmd.ExecuteReader();
            if (DBConnection.Reader.HasRows)
            {
                while (DBConnection.Reader.Read())
                {
                    userList.Add(DBConnection.Reader.GetString(0));
                    User DBUser = new User()
                    {
                        UserId = DBConnection.Reader.GetInt32(0),
                        UserName = DBConnection.Reader.GetString(1),
                        Name = DBConnection.Reader.GetString(2),
                        AccessLevel = DBConnection.Reader.GetInt32(3)
                    };
                    allUsers.Add(DBUser);
                    Users.LastId = 1;
                    if (DBUser.UserId > Users.LastId)
                    {
                        Users.LastId = DBUser.UserId;
                    }
                }
            }
            DBConnection.Reader.Close();
        }
    }
}
