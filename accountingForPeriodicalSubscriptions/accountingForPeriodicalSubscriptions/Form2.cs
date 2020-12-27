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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        void closeSubscriptionsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void addSubscriptionsButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
            if (form1 != null)
            {
                try
                {
                    form1.учет_подписки_на_периодические_печатные_изданияDataSet.Подписки.Rows.Add(((int)form1.dataGridView2.Rows[form1.dataGridView2.RowCount - 1].Cells[0].Value + 1).ToString(), textBoxSubscriptionsSubscriberID.Text, textBoxSubscriptionsEditionID.Text, textBoxSubscriptionsDate.Text, textBoxSubscriptionsTerm.Text, textBoxSubscriptionsPrice.Text);
                    form1.подпискиTableAdapter.Update(form1.учет_подписки_на_периодические_печатные_изданияDataSet.Подписки);
                    textBoxSubscriptionsSubscriberID.Text = "";
                    textBoxSubscriptionsEditionID.Text = "";
                    textBoxSubscriptionsDate.Text = "";
                    textBoxSubscriptionsTerm.Text = "";
                    textBoxSubscriptionsPrice.Text = "";
                }
                catch
                {
                    form1.showErrorMessageBox();
                }
            }

        }
    }
}
