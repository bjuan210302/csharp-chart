﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows;

namespace csharp_chart
{
    public partial class ChartWindow : Form
    {
        string[] labels = { "Municipio", "Isla", "Área no municipalizada" };
        public ChartWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
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

                var control = "";

                int[] instances = {0,0,0}; //Municipio, Isla, Area no Mu

                for (int i = 0; i < dataGrid.Rows.Count; i++) {
                    String dept = dataGrid.Rows[i].Cells[2].Value.ToString();
                    if (!dept.Equals(control))
                    {
                        comboBox1.Items.Add(dept);
                        control = dept;
                    }

                    String type = dataGrid.Rows[i].Cells[4].Value.ToString();
                    for (int j = 0; j < labels.Length; j++)
                    {
                        if (type.Equals(labels[j]))
                        {
                            instances[j]++;
                            break;
                        }
                    }
                    
                }

                for (int i = 0; i < labels.Length; i++)
                {
                    Series serie = chart1.Series.Add(labels[i]);
                    serie.Points.Add(instances[i]);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterField = "Nombre Departamento";
            ((DataTable)dataGrid.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}'", filterField, comboBox1.Text);
        }
    }
}
