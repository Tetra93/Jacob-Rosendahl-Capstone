using Jacob_Rosendahl_C969_Scheduling_Application.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jacob_Rosendahl_C969_Scheduling_Application
{
    public partial class ChangePassword : Form
    {
        private string OldPassword {  get; set; }

        private string NewPassword { get; set; }

        public ChangePassword()
        {
            InitializeComponent();
            if (Login.CurrentUser.Password == "password")
            {
                currentPasswordLabel.Visible = false;
                oldPasswordTextBox.Visible = false;
            }
        }

        private void OldPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            OldPassword = oldPasswordTextBox.Text;
        }

        private void NewPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            NewPassword = newPasswordTextBox.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (Login.CurrentUser.Password != "password")
            {
                if (OldPassword != Login.CurrentUser.Password)
                {
                    MessageBox.Show("Current password is incorrect", "Incorrect password", MessageBoxButtons.OK);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(NewPassword))
            {
                DBCustomerUpdate.UpdatePassword(NewPassword);
                MessageBox.Show("Password changed", "Password changed", MessageBoxButtons.OK);
                Login.CurrentUser.Password = NewPassword;
                this.Close();
            }
            else
            {
                MessageBox.Show("New password cannot be blank", "Please enter a password", MessageBoxButtons.OK);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeMenu.homeMenu.Show();
        }
    }
}
