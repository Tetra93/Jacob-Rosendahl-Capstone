
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(73, 88);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(120, 35);
            this.customerButton.TabIndex = 0;
            this.customerButton.Text = "&Customer Information";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.CustomerButton_Click);
            // 
            // appointmentButton
            // 
            this.appointmentButton.Location = new System.Drawing.Point(73, 129);
            this.appointmentButton.Name = "appointmentButton";
            this.appointmentButton.Size = new System.Drawing.Size(120, 35);
            this.appointmentButton.TabIndex = 1;
            this.appointmentButton.Text = "&Appointments";
            this.appointmentButton.UseVisualStyleBackColor = true;
            this.appointmentButton.Click += new System.EventHandler(this.AppointmentButton_Click);
            // 
            // reportsButton
            // 
            this.reportsButton.Location = new System.Drawing.Point(73, 170);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(120, 35);
            this.reportsButton.TabIndex = 2;
            this.reportsButton.Text = "Generate &Reports";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(73, 211);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(120, 35);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "&Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(73, 252);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(120, 35);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(104, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(35, 13);
            this.welcomeLabel.TabIndex = 5;
            this.welcomeLabel.Text = "label1";
            this.welcomeLabel.UseMnemonic = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.welcomeLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 30);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // HomeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(268, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.appointmentButton);
            this.Controls.Add(this.customerButton);
            this.Name = "HomeMenu";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeMenu_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button appointmentButton;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}