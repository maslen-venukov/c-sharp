using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace winForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int selectedRowIndex;

        int GetRandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 999999);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDatabaseDataSet.TestTable". При необходимости она может быть перемещена или удалена.
            this.testTableTableAdapter.Fill(this.testDatabaseDataSet.TestTable);

        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            nameTextBox.Text = selectedRow.Cells[1].Value.ToString();
            surnameTextBox.Text = selectedRow.Cells[2].Value.ToString();
            ageTextBox.Text = selectedRow.Cells[3].Value.ToString();
        }

        void addBtn_Click(object sender, EventArgs e)
        {
            this.testDatabaseDataSet.TestTable.Rows.Add(GetRandomNumber(), nameTextBox.Text, surnameTextBox.Text, int.Parse(ageTextBox.Text));
            this.testTableTableAdapter.Update(this.testDatabaseDataSet.TestTable);
        }

        void updateBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            selectedRow.Cells[1].Value = nameTextBox.Text;
            selectedRow.Cells[2].Value = surnameTextBox.Text;
            selectedRow.Cells[3].Value = ageTextBox.Text;
            this.testTableTableAdapter.Update(this.testDatabaseDataSet.TestTable);
        }

        void deleteBtn_Click(object sender, EventArgs e)
        {
            selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selectedRowIndex);
            this.testTableTableAdapter.Update(this.testDatabaseDataSet.TestTable);
        }

        void findTextBox_TextChanged(object sender, EventArgs e)
        {
            if (findTextBox.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(findTextBox.Text))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                dataGridView1.ClearSelection();
            }
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (sortTextBox.Text != "")
            {
                int number;
                if (!int.TryParse(sortTextBox.Text, out number))
                {
                    testTableBindingSource.Filter = $"Surname like '%{sortTextBox.Text}%' Or Name like '%{sortTextBox.Text}%'";
                }
                else
                {
                    testTableBindingSource.Filter = $"Surname like '%{sortTextBox.Text}%' Or Name like '%{sortTextBox.Text}%' Or Age = {sortTextBox.Text}";
                }
            }
            else
            {
                testTableBindingSource.Filter = "";
            }
        }

        void exportBtn_Click(object sender, EventArgs e)
        {
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (i == 0)
                    {
                        ExcelApp.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;
                    }

                    ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }

            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
