using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accountingForPeriodicalSubscriptions
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        public int counter = 0;
        public bool isDisabled = false;
        Timer timer = new Timer();

        void TimerEventProcessor(object sender, EventArgs e)
        {
            logInButton.Enabled = true;
            blockedLabel.Visible = false;
            timer.Stop();
            isDisabled = true;
        }

        void logInButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-JQD9UTD\SQLEXPRESS;Initial Catalog=Учет_подписки_на_периодические_печатные_издания; Integrated Security=True");
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select Count (*) From Пользователи where Логин = '{loginTextBox.Text}' and Пароль = '{passwordTextBox.Text}'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            if (counter == 3)
            {
                logInButton.Enabled = false;
                blockedLabel.Visible = true;

                timer.Tick += new EventHandler(TimerEventProcessor);
                timer.Interval = 60000;
                timer.Start();

                while (isDisabled == false)
                {
                    Application.DoEvents();
                }

                counter = 0;
            }
            else
            {
                if (dataTable.Rows[0][0].ToString() == "1")
                {
                    dataAdapter = new SqlDataAdapter($"Select Аватарка, Название From Пользователи Join Роли On Роли.Роли_ID = Пользователи.Роли_ID Where Логин = '{loginTextBox.Text}'", connection);
                    DataTable userData = new DataTable();
                    dataAdapter.Fill(userData);
                    //MessageBox.Show($"{userData.Rows[0][0].ToString()}, {userData.Rows[0][1].ToString()}");

                    PersonalAreaForm personalAreaForm = new PersonalAreaForm();
                    personalAreaForm.Owner = this;
                    personalAreaForm.Show();

                    personalAreaForm.avatarPictureBox.Image = System.Drawing.Image.FromFile(userData.Rows[0][0].ToString());
                    personalAreaForm.loginLabel.Text = loginTextBox.Text;
                    personalAreaForm.passwordLabel.Text = passwordTextBox.Text;
                    personalAreaForm.roleLabel.Text = userData.Rows[0][1].ToString();
                    if (userData.Rows[0][1].ToString().Trim() != "Администратор")
                    {
                        personalAreaForm.addNewUserButton.Visible = false;
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    counter++;
                }
            }
        }

        void cancelButton_Click(object sender, EventArgs e)
        {
            TimerEventProcessor(sender, e);
            Application.Exit();
        }
    }
}
