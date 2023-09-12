using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Jacob_Rosendahl_Appointed_Program
{
    public partial class Intro : Form
    {
        public static bool canClose = false;
        public Intro()
        {
            InitializeComponent();
            if(Program.language == "es")
            {
                label1.Text = "Bienvenida";
                this.Text = "Bienvenida";
                loginButton.Text = "Acceso";
                exitButton.Text = "Salida";
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        { 
            
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Intro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Visible == true)
            {

                if (canClose == false && Program.language == "es")
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
                else if (canClose == false && Program.language != "es")
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
        }
    }
}
