using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryModels;
using InventoryTesting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventorySimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimulationSystem system = new SimulationSystem();

        

        private void buttonSimulation_Click(object sender, EventArgs e)
        {
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Test Case 1");
            comboBox1.Items.Add("Test Case 2");
            //comboBox1.Items.Add("Test Case 3");
            //comboBox1.Items.Add("Test Case 4");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //}

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            string path = "";

            if (comboBox1.SelectedIndex == 0)
            {
                path = "../../TestCases/TestCase1.txt";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                path = "../../TestCases/TestCase2.txt";
            }
            //else if (comboBox1.SelectedIndex == 2)
            //{
            //    path = "../../TestCases/TestCase3.txt";
            //}
            //else
            //{
            //    path = "../../TestCases/TestCase4.txt";
            //}
            system.ReadTestcases(path);
            DataTable dt = new DataTable();
            dt.Columns.Add("OrderUpTo", typeof(int));
            dt.Columns.Add("ReviewPeriod", typeof(int));
            dt.Columns.Add("StartInventoryQuantity", typeof(decimal));
            dt.Columns.Add("StartLeadDays", typeof(decimal));
            dt.Columns.Add("StartOrderQuantity", typeof(decimal));
            dt.Columns.Add("NumberOfDays", typeof(decimal));

            dt.Rows.Add(system.OrderUpTo, system.ReviewPeriod, system.StartInventoryQuantity, system.StartLeadDays, system.StartOrderQuantity, system.NumberOfDays);
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Lead Time ", typeof(int));
            dt2.Columns.Add("Probability", typeof(decimal));
            for (int i = 0; i < system.LeadDaysDistribution.Count; i++)
            {
                dt2.Rows.Add((int)system.LeadDaysDistribution[i].Value, system.LeadDaysDistribution[i].Probability);
            }
            dataGridView2.DataSource = dt2;

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("Demand", typeof(int));
            dt3.Columns.Add("probability", typeof(decimal));

            for (int i = 0; i < system.DemandDistribution.Count; i++)
            {
                dt3.Rows.Add(system.DemandDistribution[i].Value, system.DemandDistribution[i].Probability);
            }
            dataGridView3.DataSource = dt3;
        }

        private void buttonSimulation_Click_1(object sender, EventArgs e)
        {
            SimulationTable res = new SimulationTable(system, comboBox1.SelectedIndex);
            this.Hide();
            res.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
