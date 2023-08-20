
namespace Jacob_Rosendahl_C969_Scheduling_Application
{
    partial class HomeMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customerButton = new System.Windows.Forms.Button();
            this.appointmentButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(71, 42);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(120, 35);
            this.customerButton.TabIndex = 0;
            this.customerButton.Text = "&Customer Information";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.CustomerButton_Click);
            // 
            // appointmentButton
            // 
            this.appointmentButton.Location = new System.Drawing.Point(71, 83);
            this.appointmentButton.Name = "appointmentButton";
            this.appointmentButton.Size = new System.Drawing.Size(120, 35);
            this.appointmentButton.TabIndex = 1;
            this.appointmentButton.Text = "&Appointments";
            this.appointmentButton.UseVisualStyleBackColor = true;
            this.appointmentButton.Click += new System.EventHandler(this.AppointmentButton_Click);
            // 
            // reportsButton
            // 
            this.reportsButton.Location = new System.Drawing.Point(71, 124);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(120, 35);
            this.reportsButton.TabIndex = 2;
            this.reportsButton.Text = "Generate &Reports";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(71, 165);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(120, 35);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "&Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(71, 206);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(120, 35);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HomeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(268, 269);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.appointmentButton);
            this.Controls.Add(this.customerButton);
            this.Name = "HomeMenu";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button appointmentButton;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button exitButton;
    }
}