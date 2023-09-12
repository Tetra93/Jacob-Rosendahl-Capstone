namespace Jacob_Rosendahl_Appointed_Program
{
    partial class ChangePassword
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
            this.currentPasswordLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oldPasswordTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentPasswordLabel
            // 
            this.currentPasswordLabel.AutoSize = true;
            this.currentPasswordLabel.Location = new System.Drawing.Point(29, 26);
            this.currentPasswordLabel.Name = "currentPasswordLabel";
            this.currentPasswordLabel.Size = new System.Drawing.Size(90, 13);
            this.currentPasswordLabel.TabIndex = 0;
            this.currentPasswordLabel.Text = "Current Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Password";
            // 
            // oldPasswordTextBox
            // 
            this.oldPasswordTextBox.Location = new System.Drawing.Point(126, 23);
            this.oldPasswordTextBox.Name = "oldPasswordTextBox";
            this.oldPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.oldPasswordTextBox.TabIndex = 3;
            this.oldPasswordTextBox.UseSystemPasswordChar = true;
            this.oldPasswordTextBox.TextChanged += new System.EventHandler(this.OldPasswordTextBox_TextChanged);
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Location = new System.Drawing.Point(126, 49);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.newPasswordTextBox.TabIndex = 4;
            this.newPasswordTextBox.UseSystemPasswordChar = true;
            this.newPasswordTextBox.TextChanged += new System.EventHandler(this.NewPasswordTextBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(32, 97);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(151, 97);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(238, 154);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.oldPasswordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentPasswordLabel);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChangePassword_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentPasswordLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oldPasswordTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}