namespace accountingForPeriodicalSubscriptions
{
    partial class AddUserForm
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
            this.newUserLoginTextBox = new System.Windows.Forms.TextBox();
            this.newUserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addNewUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newUserLoginTextBox
            // 
            this.newUserLoginTextBox.Location = new System.Drawing.Point(67, 83);
            this.newUserLoginTextBox.Name = "newUserLoginTextBox";
            this.newUserLoginTextBox.Size = new System.Drawing.Size(100, 20);
            this.newUserLoginTextBox.TabIndex = 2;
            // 
            // newUserPasswordTextBox
            // 
            this.newUserPasswordTextBox.Location = new System.Drawing.Point(67, 135);
            this.newUserPasswordTextBox.Name = "newUserPasswordTextBox";
            this.newUserPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.newUserPasswordTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // addNewUserButton
            // 
            this.addNewUserButton.Location = new System.Drawing.Point(67, 197);
            this.addNewUserButton.Name = "addNewUserButton";
            this.addNewUserButton.Size = new System.Drawing.Size(100, 23);
            this.addNewUserButton.TabIndex = 6;
            this.addNewUserButton.Text = "Добавить";
            this.addNewUserButton.UseVisualStyleBackColor = true;
            this.addNewUserButton.Click += new System.EventHandler(this.addNewUserButton_Click);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(234, 311);
            this.Controls.Add(this.addNewUserButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newUserPasswordTextBox);
            this.Controls.Add(this.newUserLoginTextBox);
            this.MaximumSize = new System.Drawing.Size(250, 350);
            this.MinimumSize = new System.Drawing.Size(250, 350);
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление нового пользователя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUserForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox newUserLoginTextBox;
        private System.Windows.Forms.TextBox newUserPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addNewUserButton;
    }
}