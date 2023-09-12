using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jacob_Rosendahl_Appointed_Program.Classes;

namespace Jacob_Rosendahl_Appointed_Program
{
	public partial class Login : Form
	{
        public static string UserName { set; get; }

        public static string Password { set; get; }

        public static User CurrentUser { set; get; }

        public static int AccessLevel { set; get; }

        public static bool canClose = false;
        public static bool loginSuccessful = false;
        public static bool appointmentSoon = false;
        public static Login login;
        const string fileName = "Logins.txt";

		public Login()
		{
			InitializeComponent();
            if (!File.Exists(fileName))
            {
                using (FileStream file = File.Create(fileName)) { } ;
            }
            if (Program.language == "es")
            {
                label1.Text = "Usuario";
                label2.Text = "Contraseña";
                this.Text = "Acceso";
                loginButton.Text = "Acceso";
                exitButton.Text = "Salida";
            }
            canClose = false;
            loginSuccessful = false;
            login = this;            
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            User.UserLogin();
            if (loginSuccessful == true)
            {
                TrimLogFile();
                Appointment.UserFilter(UserName);
                appointmentSoon = Appointment.TimeCheck();
                HomeMenu homeMenu = new HomeMenu();
                homeMenu.Show();
                Close();
                using (StreamWriter logs = new StreamWriter(fileName, true))
                {
                    logs.WriteLine($"{DateTime.Now} {TimeZone.CurrentTimeZone.StandardName}: Successful login by {UserName}");
                }
            }
            else
            {
                using (StreamWriter logs = new StreamWriter(fileName, true))
                {
                    logs.WriteLine($"{DateTime.Now} {TimeZone.CurrentTimeZone.StandardName}: Unsuccessful login attempt by {UserName}");
                }
                if (Program.language == "es")
                {
                    MessageBox.Show("Combinación de nombre de usuario y contraseña no válidos", "Inicio de sesión no válido", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Invalid username and password combination", "Invalid login", MessageBoxButtons.OK);
                }
            }
        }

        private void TrimLogFile()
        {
            int maxLines = 49;
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            if (lines.Count > maxLines)
            {
                lines.RemoveRange(0, lines.Count - maxLines);
            }
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (string trimmedLines  in lines)
                {
                    writer.WriteLine(trimmedLines);
                }
            }
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            UserName = usernameTextBox.Text.ToString();
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            Password = passwordTextBox.Text.ToString();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loginSuccessful == true)
            {
            }
            else if (canClose == false && Program.language == "es")
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea cerrar la aplicación?", "¿Cierra la aplicación?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    canClose = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else if (canClose == false && (Program.language != "es"))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the application?", "Close application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    canClose = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (loginSuccessful == true)
            {
                this.Hide();
                if (Program.language == "es")
                {
                    MessageBox.Show("Inicio de sesión exitoso");
                    if (appointmentSoon == true)
                    {
                        MessageBox.Show($"Tiene una cita con {Appointment.CustomerName} que comienza dentro de los próximos 15 minutos");
                    }
                }
                else
                {
                    MessageBox.Show("Login successful");
                    if (appointmentSoon == true)
                    {
                        MessageBox.Show($"You have an appointment with {Appointment.CustomerName} starting within the next 15 minutes");
                    }
                }
                Password = string.Empty;
            }
        }
    }
}
