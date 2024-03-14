namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            FirstName = new TextBox();
            LastName = new TextBox();
            label2 = new Label();
            Phone = new TextBox();
            label3 = new Label();
            Email = new TextBox();
            label4 = new Label();
            Save = new Button();
            ErrorMessage = new Label();
            label5 = new Label();
            placeOfResidenceTextBox = new TextBox();
            label6 = new Label();
            genderTextBox = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 121);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // FirstName
            // 
            FirstName.Location = new Point(113, 149);
            FirstName.Margin = new Padding(1);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(260, 27);
            FirstName.TabIndex = 1;
            // 
            // LastName
            // 
            LastName.Location = new Point(401, 149);
            LastName.Margin = new Padding(1);
            LastName.Name = "LastName";
            LastName.Size = new Size(260, 27);
            LastName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 120);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 2;
            label2.Text = "Last Name";
            // 
            // Phone
            // 
            Phone.Location = new Point(401, 223);
            Phone.Margin = new Padding(1);
            Phone.Name = "Phone";
            Phone.Size = new Size(260, 27);
            Phone.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(401, 193);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 6;
            label3.Text = "Phone";
            // 
            // Email
            // 
            Email.Location = new Point(112, 223);
            Email.Margin = new Padding(1);
            Email.Name = "Email";
            Email.Size = new Size(260, 27);
            Email.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(112, 194);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 4;
            label4.Text = "Email";
            // 
            // Save
            // 
            Save.Location = new Point(113, 389);
            Save.Margin = new Padding(1);
            Save.Name = "Save";
            Save.Size = new Size(548, 41);
            Save.TabIndex = 8;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // ErrorMessage
            // 
            ErrorMessage.AutoSize = true;
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Location = new Point(34, 440);
            ErrorMessage.Margin = new Padding(1, 0, 1, 0);
            ErrorMessage.Name = "ErrorMessage";
            ErrorMessage.Size = new Size(0, 20);
            ErrorMessage.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(33, 440);
            label5.Margin = new Padding(1, 0, 1, 0);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 17;
            // 
            // placeOfResidenceTextBox
            // 
            placeOfResidenceTextBox.Location = new Point(401, 312);
            placeOfResidenceTextBox.Margin = new Padding(1);
            placeOfResidenceTextBox.Name = "placeOfResidenceTextBox";
            placeOfResidenceTextBox.Size = new Size(260, 27);
            placeOfResidenceTextBox.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(401, 283);
            label6.Margin = new Padding(1, 0, 1, 0);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 15;
            label6.Text = "Place of residence";
            // 
            // genderTextBox
            // 
            genderTextBox.Location = new Point(113, 312);
            genderTextBox.Margin = new Padding(1);
            genderTextBox.Name = "genderTextBox";
            genderTextBox.Size = new Size(260, 27);
            genderTextBox.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(113, 282);
            label7.Margin = new Padding(1, 0, 1, 0);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 13;
            label7.Text = "Gender";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 653);
            Controls.Add(label5);
            Controls.Add(placeOfResidenceTextBox);
            Controls.Add(label6);
            Controls.Add(genderTextBox);
            Controls.Add(label7);
            Controls.Add(ErrorMessage);
            Controls.Add(Save);
            Controls.Add(Phone);
            Controls.Add(label3);
            Controls.Add(Email);
            Controls.Add(label4);
            Controls.Add(LastName);
            Controls.Add(label2);
            Controls.Add(FirstName);
            Controls.Add(label1);
            Margin = new Padding(1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox FirstName;
        private TextBox LastName;
        private Label label2;
        private TextBox Phone;
        private Label label3;
        private TextBox Email;
        private Label label4;
        private Button Save;
        private Label ErrorMessage;
        private Label label5;
        private TextBox placeOfResidenceTextBox;
        private Label label6;
        private TextBox genderTextBox;
        private Label label7;
    }
}