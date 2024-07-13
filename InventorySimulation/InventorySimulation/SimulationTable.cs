using InventoryModels;
using InventoryTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventorySimulation
{
    public partial class SimulationTable : Form
    {
        public SimulationTable(SimulationSystem system, int caseNo)
        {
            InitializeComponent();
            this.system = system;
            this.caseNo = caseNo;
        }
        SimulationSystem system;
        int caseNo;

        private void SimulationTable_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Day", typeof(int));
            dt.Columns.Add("Cycle", typeof(int));
            dt.Columns.Add("DayWithinCycle", typeof(int));
            dt.Columns.Add("BeginningInventory", typeof(int));
            dt.Columns.Add("RandomDemand", typeof(int));
            dt.Columns.Add("Demand", typeof(int));
            dt.Columns.Add("EndingInventory", typeof(int));
            dt.Columns.Add("ShortageQuantity", typeof(int));
            dt.Columns.Add("OrderQuantity", typeof(int));
            dt.Columns.Add("RandomLeadDays", typeof(int));
            dt.Columns.Add("LeadDays", typeof(int));
            dt.Columns.Add("DaysUntilOrderArrives", typeof(int));

            system.CreateSimulationTable();

            dataGridView1.DataSource = dt;

            textBox1.Text = system.PerformanceMeasures.EndingInventoryAverage.ToString();
            textBox4.Text = system.PerformanceMeasures.ShortageQuantityAverage.ToString();
            foreach (var row in system.SimulationTable)
            {
                dt.Rows.Add(row.Day, row.Cycle, row.DayWithinCycle, row.BeginningInventory, row.RandomDemand, row.Demand, row.EndingInventory, row.ShortageQuantity, row.OrderQuantity, row.RandomLeadDays, row.LeadDays, row.DaysUntilOrderArrives);

                //var row = new int[] { x.Day, x.Cycle, x.DayWithinCycle, x.BeginningInventory, x.RandomDemand, x.Demand, x.EndingInventory,
                //    x.ShortageQuantity, x.OrderQuantity, x.RandomLeadDays, x.LeadDays,
                //    (x.DaysUntilOrderArrives<0) ? 0 : x.DaysUntilOrderArrives };
                //var update = Array.ConvertAll(row, s => s.ToString());
                //dataGridView1.Rows.Add(update);

            }

            if (caseNo == 0)
            {
                string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
                MessageBox.Show(result);
            }
            else if (caseNo == 1)
            {
                string result = TestingManager.Test(system, Constants.FileNames.TestCase2);
                MessageBox.Show(result);
            }
            //else if (caseNo == 2)
            //{
            //    string result = TestingManager.Test(system, Constants.FileNames.TestCase3);
            //    MessageBox.Show(result);
            //}
            //else
            //{
            //    string result = TestingManager.Test(system, Constants.FileNames.TestCase4);
            //    MessageBox.Show(result);
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SimulationTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
