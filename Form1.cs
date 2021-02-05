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
using System.Data;

namespace csharp_chart
{
    public partial class Form1 : Form
    {

        private String filePath;
        public Form1()
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
                    dataGridView1.DataSource = csv.readCSV;
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
                //Get the path of specified file
                filePath = openFileDialog1.FileName;
                Console.WriteLine(filePath);

                

                

            }

            

            LoadCSVOnDataGridView(filePath);
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
    }
}
