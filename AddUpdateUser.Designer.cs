
namespace Jacob_Rosendahl_C969_Scheduling_Application
{
    partial class AddUpdateUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.countryTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.postalLabel = new System.Windows.Forms.Label();
            this.postalTextBox = new System.Windows.Forms.TextBox();
            this.specialtyLabel = new System.Windows.Forms.Label();
            this.specialtyTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Enabled = false;
            this.IDTextBox.Location = new System.Drawing.Point(135, 60);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.IDTextBox.TabIndex = 3;
            this.IDTextBox.TabStop = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(135, 87);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(135, 139);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(100, 20);
            this.addressTextBox.TabIndex = 3;
            this.addressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(135, 165);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(100, 20);
            this.cityTextBox.TabIndex = 4;
            this.cityTextBox.TextChanged += new System.EventHandler(this.CityTextBox_TextChanged);
            // 
            // countryTextBox
            // 
            this.countryTextBox.Location = new System.Drawing.Point(135, 217);
            this.countryTextBox.Name = "countryTextBox";
            this.countryTextBox.Size = new System.Drawing.Size(100, 20);
            this.countryTextBox.TabIndex = 6;
            this.countryTextBox.TextChanged += new System.EventHandler(this.CountryTextBox_TextChanged);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(135, 243);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex = 7;
            this.phoneTextBox.TextChanged += new System.EventHandler(this.PhoneTextBox_TextChanged);
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(35, 142);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 9;
            this.addressLabel.Text = "Address";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(35, 246);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(78, 13);
            this.phoneLabel.TabIndex = 10;
            this.phoneLabel.Text = "Phone Number";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(35, 168);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(24, 13);
            this.cityLabel.TabIndex = 11;
            this.cityLabel.Text = "City";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(35, 220);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(43, 13);
            this.countryLabel.TabIndex = 12;
            this.countryLabel.Text = "Country";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(38, 295);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(135, 295);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // postalLabel
            // 
            this.postalLabel.AutoSize = true;
            this.postalLabel.Location = new System.Drawing.Point(35, 194);
            this.postalLabel.Name = "postalLabel";
            this.postalLabel.Size = new System.Drawing.Size(64, 13);
            this.postalLabel.TabIndex = 13;
            this.postalLabel.Text = "Postal Code";
            // 
            // postalTextBox
            // 
            this.postalTextBox.Location = new System.Drawing.Point(135, 191);
            this.postalTextBox.Name = "postalTextBox";
            this.postalTextBox.Size = new System.Drawing.Size(100, 20);
            this.postalTextBox.TabIndex = 5;
            this.postalTextBox.TextChanged += new System.EventHandler(this.PostalTextBox_TextChanged);
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.AutoSize = true;
            this.specialtyLabel.Location = new System.Drawing.Point(35, 116);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(50, 13);
            this.specialtyLabel.TabIndex = 15;
            this.specialtyLabel.Text = "Specialty";
            // 
            // specialtyTextBox
            // 
            this.specialtyTextBox.Location = new System.Drawing.Point(135, 113);
            this.specialtyTextBox.Name = "specialtyTextBox";
            this.specialtyTextBox.Size = new System.Drawing.Size(100, 20);
            this.specialtyTextBox.TabIndex = 2;
            this.specialtyTextBox.TextChanged += new System.EventHandler(this.SpecialtyTextBox_TextChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(35, 37);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 16;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(135, 34);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBox_TextChanged);
            // 
            // AddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(266, 330);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.specialtyLabel);
            this.Controls.Add(this.specialtyTextBox);
            this.Controls.Add(this.postalTextBox);
            this.Controls.Add(this.postalLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.countryTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddUpdateUser";
            this.Text = "Add Customer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddUpdateCustomer_FormClosed);
            this.Load += new System.EventHandler(this.AddModifyCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label postalLabel;
        private System.Windows.Forms.TextBox postalTextBox;
        private System.Windows.Forms.Label specialtyLabel;
        private System.Windows.Forms.TextBox specialtyTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
    }
}