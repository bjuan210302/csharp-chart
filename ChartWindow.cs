using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace csharp_chart
{
    public partial class ChartWindow : Form
    {
        public ChartWindow()
        {
            InitializeComponent();
        }

        private void LoadCSVOnDataGridView(string fileName)
        {
            try
            {
                ReadCsv csv = new ReadCsv(fileName);

                try
                {
                    dataGrid.DataSource = csv.readCSV;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadCSVOnDataGridView(openFileDialog1.FileName);

                //Deleting annoying, unnecessary rows at the end of the file
                for (int i = dataGrid.Rows.Count-1; i > 0; i--)
                {
                    var item = dataGrid.Rows[i];
                    if (item.Cells[2].Value == null || item.Cells[2].Value.Equals(""))
                        dataGrid.Rows.RemoveAt(item.Index);
                    else
                        break;
                }
            }
            else
            {
                Console.WriteLine("No file selected");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
