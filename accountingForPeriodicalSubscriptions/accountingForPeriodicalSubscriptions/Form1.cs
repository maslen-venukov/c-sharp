using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace accountingForPeriodicalSubscriptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int selectedRow;
        public string role;

        public void showErrorMessageBox()
        {
            MessageBox.Show("Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void deleteTableRow(DataGridView dataGridViewName)
        {
            selectedRow = dataGridViewName.CurrentCell.RowIndex;
            dataGridViewName.Rows.RemoveAt(selectedRow);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            this.доставкаTableAdapter.Fill(this.учет_подписки_на_периодические_печатные_изданияDataSet.Доставка);
            this.доставщикTableAdapter.Fill(this.учет_подписки_на_периодические_печатные_изданияDataSet.Доставщик);
            this.вид_изданияTableAdapter.Fill(this.учет_подписки_на_периодические_печатные_изданияDataSet.Вид_издания);
            this.изданияTableAdapter.Fill(this.учет_подписки_на_периодические_печатные_изданияDataSet.Издания);
            this.подпискиTableAdapter.Fill(this.учет_подписки_на_периодические_печатные_изданияDataSet.Подписки);
            this.подписчикиTableAdapter.Fill(this.учет_подписки_на_периодические_печатные_изданияDataSet.Подписчики);
            if (role.Trim() != "Администратор")
            {
                List<Control> controlsToHide = new List<Control>() { addSubscribersButton, updateSubscribersButton, deleteSubscribersButton, saveSubscribersButton, textBoxSubscribersSurname, label2 };
                foreach (Control control in controlsToHide)
                {
                    control.Visible = false;
                }
                tableLayoutPanel2.SetColumnSpan(dataGridViewSubscribers, 3);
            }
        }

        void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.учет_подписки_на_периодические_печатные_изданияDataSet.Подписчики.Rows.Add(((int)dataGridViewSubscribers.Rows[dataGridViewSubscribers.RowCount - 1].Cells[0].Value + 1).ToString(), textBoxSubscribersSurname.Text, textBoxSubscribersName.Text, textBoxSubscribersPatronymic.Text, textBoxSubscribersStreet.Text, textBoxSubscribersHouse.Text, textBoxSubscribersFlat.Text, textBoxSubscribersPhone.Text);
                подписчикиTableAdapter.Update(учет_подписки_на_периодические_печатные_изданияDataSet.Подписчики);
            }
            catch
            {
                showErrorMessageBox();
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (selectedRow != -1)
                {
                    DataGridViewRow row = dataGridViewSubscribers.Rows[selectedRow];
                    textBoxSubscribersSurname.Text = row.Cells[0].Value.ToString();
                    textBoxSubscribersSurname.Text = row.Cells[1].Value.ToString();
                    textBoxSubscribersName.Text = row.Cells[2].Value.ToString();
                    textBoxSubscribersPatronymic.Text = row.Cells[3].Value.ToString();
                    textBoxSubscribersStreet.Text = row.Cells[4].Value.ToString();
                    textBoxSubscribersHouse.Text = row.Cells[5].Value.ToString();
                    textBoxSubscribersFlat.Text = row.Cells[6].Value.ToString();
                    textBoxSubscribersPhone.Text = row.Cells[7].Value.ToString();
                }
            }
            catch
            {
                showErrorMessageBox();
            }
        }

        void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow newDataRow = dataGridViewSubscribers.Rows[selectedRow];
                newDataRow.Cells[1].Value = textBoxSubscribersSurname.Text;
                newDataRow.Cells[2].Value = textBoxSubscribersName.Text;
                newDataRow.Cells[3].Value = textBoxSubscribersPatronymic.Text;
                newDataRow.Cells[4].Value = textBoxSubscribersStreet.Text;
                newDataRow.Cells[5].Value = textBoxSubscribersHouse.Text;
                newDataRow.Cells[6].Value = textBoxSubscribersFlat.Text;
                newDataRow.Cells[7].Value = textBoxSubscribersPhone.Text;
                подписчикиTableAdapter.Update(учет_подписки_на_периодические_печатные_изданияDataSet.Подписчики);
            }
            catch
            {
                showErrorMessageBox();
            }
        }

        void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmDelete = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (confirmDelete == DialogResult.OK)
                {
                    deleteTableRow(dataGridViewSubscribers);
                    подписчикиTableAdapter.Update(учет_подписки_на_периодические_печатные_изданияDataSet.Подписчики);
                }
            }
            catch
            {
                showErrorMessageBox();
            }
        }

        void addSubscriptionsCallButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.Show();
        }

        void deleteSubscriptionsButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmDelete = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (confirmDelete == DialogResult.OK)
                {
                    deleteTableRow(dataGridView2);
                    подпискиTableAdapter.Update(учет_подписки_на_периодические_печатные_изданияDataSet.Подписки);
                }
            }
            catch
            {
                showErrorMessageBox();
            }
        }

        Form3 form3 = new Form3();

        void updateSubscriptionsCallButton_Click(object sender, EventArgs e)
        {
            form3.Owner = this;
            form3.Show();
        }

        void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if(selectedRow != -1)
            {
                DataGridViewRow newDataRow = dataGridView2.Rows[selectedRow];
                form3.textBoxSubscriptionsSubscriberID.Text = newDataRow.Cells[1].Value.ToString();
                form3.textBoxSubscriptionsEditionID.Text = newDataRow.Cells[2].Value.ToString();
                form3.textBoxSubscriptionsDate.Text = newDataRow.Cells[3].Value.ToString();
                form3.textBoxSubscriptionsTerm.Text = newDataRow.Cells[4].Value.ToString();
                form3.textBoxSubscriptionsPrice.Text = newDataRow.Cells[5].Value.ToString();
            }
        }

        void saveSubscribersButton_Click(object sender, EventArgs e)
        {
            подписчикиTableAdapter.Update(учет_подписки_на_периодические_печатные_изданияDataSet.Подписчики);
        }

        void excelSubscribersButton_Click(object sender, EventArgs e)
        {
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridViewSubscribers.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewSubscribers.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridViewSubscribers.Rows[i].Cells[j].Value;
                }
            }

            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;

            string fileCSV = "";

            PdfPTable pdfTable = new PdfPTable(dataGridViewSubscribers.Columns.Count);
            string FONT_LOCATION = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
            BaseFont baseFont = BaseFont.CreateFont(FONT_LOCATION, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font text = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn column in dataGridViewSubscribers.Columns)
            {
                fileCSV += column.HeaderText + ";";
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            fileCSV += "\t\n";

            foreach (DataGridViewRow row in dataGridViewSubscribers.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    fileCSV += cell.Value.ToString() + ";";
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
                fileCSV += "\t\n";
            }

            using(StreamWriter streamWriter = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\{dataGridViewSubscribers.Columns[0].HeaderText.Replace("_ID", "")}.csv", false, Encoding.GetEncoding("windows-1251")))
            {
                streamWriter.Write(fileCSV);
            }

            using (FileStream fileStream = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\{dataGridViewSubscribers.Columns[0].HeaderText.Replace("_ID", "")}.pdf", FileMode.Create))
            {
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDocument, fileStream);
                pdfDocument.Open();
                pdfDocument.Add(pdfTable);
                pdfDocument.Close();
            }
        }

        void saveSubscriptionsButton_Click(object sender, EventArgs e)
        {
            подпискиTableAdapter.Update(учет_подписки_на_периодические_печатные_изданияDataSet.Подписки);
        }

        void findSubscribersButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewSubscribers.RowCount; i++)
            {
                dataGridViewSubscribers.Rows[i].Selected = false;
                for (int j = 0; j < dataGridViewSubscribers.ColumnCount; j++)
                {
                    if (dataGridViewSubscribers.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridViewSubscribers.Rows[i].Cells[j].Value.ToString().Contains(textBoxSubscribersFind.Text))
                        {
                            dataGridViewSubscribers.Rows[i].Selected = true;
                            break;
                        }
                    }
                } 
            }
        }

        void filterSubscribersButton_Click(object sender, EventArgs e)
        {
            подписчикиBindingSource.Filter = $"Фамилия like '{textBoxSubscribersFilter.Text}%'";
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
