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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void closeSubscriptionsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void updateSubscriptionsButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
            if (form1 != null)
            {
                try
                {
                    DataGridViewRow newDataRow = form1.dataGridView2.Rows[form1.selectedRow];
                    newDataRow.Cells[1].Value = textBoxSubscriptionsSubscriberID.Text;
                    newDataRow.Cells[2].Value = textBoxSubscriptionsEditionID.Text;
                    newDataRow.Cells[3].Value = textBoxSubscriptionsDate.Text;
                    newDataRow.Cells[4].Value = textBoxSubscriptionsTerm.Text;
                    newDataRow.Cells[5].Value = textBoxSubscriptionsPrice.Text;
                    form1.подпискиTableAdapter.Update(form1.учет_подписки_на_периодические_печатные_изданияDataSet.Подписки);
                    this.Hide();
                }
                catch
                {
                    form1.showErrorMessageBox();
                }
            }
        }
    }
}
