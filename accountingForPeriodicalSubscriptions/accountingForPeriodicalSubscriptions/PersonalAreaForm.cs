using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accountingForPeriodicalSubscriptions
{
    public partial class PersonalAreaForm : Form
    {
        public PersonalAreaForm()
        {
            InitializeComponent();
        }

    void openDatabaseButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Owner = this;
            form1.role = roleLabel.Text;
            form1.Show();
            this.Hide();
        }

        void PersonalAreaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void addNewUserButton_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.Owner = this;
            addUserForm.Show();
            this.Hide();
        }
    }
}
