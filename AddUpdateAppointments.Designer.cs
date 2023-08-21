
namespace Jacob_Rosendahl_C969_Scheduling_Application
{
    partial class AddUpdateAppointments
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
            this.customerName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.consultantName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.otherTypeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            // 
            // customerName
            // 
            this.customerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerName.FormattingEnabled = true;
            this.customerName.Location = new System.Drawing.Point(153, 35);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(121, 21);
            this.customerName.TabIndex = 1;
            this.customerName.SelectedIndexChanged += new System.EventHandler(this.CustomerName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type of Appointment";
            // 
            // consultantName
            // 
            this.consultantName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.consultantName.FormattingEnabled = true;
            this.consultantName.Location = new System.Drawing.Point(153, 62);
            this.consultantName.Name = "consultantName";
            this.consultantName.Size = new System.Drawing.Size(121, 21);
            this.consultantName.TabIndex = 4;
            this.consultantName.SelectedIndexChanged += new System.EventHandler(this.ConsultantName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Consultant Name";
            // 
            // endTimePicker
            // 
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimePicker.Location = new System.Drawing.Point(153, 193);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(121, 20);
            this.endTimePicker.TabIndex = 6;
            this.endTimePicker.ValueChanged += new System.EventHandler(this.EndTimePicker_ValueChanged);
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(153, 141);
            this.datePicker.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(121, 20);
            this.datePicker.TabIndex = 7;
            this.datePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(153, 167);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(121, 20);
            this.startTimePicker.TabIndex = 8;
            this.startTimePicker.ValueChanged += new System.EventHandler(this.StartTimePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "End Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Start Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(84, 235);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(178, 235);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(153, 88);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 21);
            this.typeBox.TabIndex = 14;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
            // 
            // otherTypeTextBox
            // 
            this.otherTypeTextBox.ForeColor = System.Drawing.Color.Gray;
            this.otherTypeTextBox.Location = new System.Drawing.Point(153, 115);
            this.otherTypeTextBox.Name = "otherTypeTextBox";
            this.otherTypeTextBox.Size = new System.Drawing.Size(121, 20);
            this.otherTypeTextBox.TabIndex = 15;
            this.otherTypeTextBox.Text = "Other appointment type";
            this.otherTypeTextBox.Visible = false;
            this.otherTypeTextBox.Enter += new System.EventHandler(this.OtherTypeTextBox_Enter);
            this.otherTypeTextBox.Leave += new System.EventHandler(this.OtherTypeTextBox_Leave);
            // 
            // AddUpdateAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(445, 312);
            this.Controls.Add(this.otherTypeTextBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.consultantName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.label1);
            this.Name = "AddUpdateAppointments";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddUpdateAppointments_FormClosed);
            this.Load += new System.EventHandler(this.AddUpdateAppointments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox customerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox consultantName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.TextBox otherTypeTextBox;
    }
}