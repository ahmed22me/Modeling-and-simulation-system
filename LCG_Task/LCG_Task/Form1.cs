using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCG_Task
{
    public partial class Form1 : Form
    { 
       // int[] itration;
        public Form1()
        {
            InitializeComponent();
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void clearData()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.dataGridView1.Rows.Clear();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
        
            long Xo = long.Parse(textBox4.Text); // Seed value
            long m = long.Parse(textBox2.Text); // Modulus parameter
            long a = long.Parse(textBox5.Text); // Multiplier term
            long c = long.Parse(textBox3.Text); // Increment term
          long iterationsofrandam = (long.Parse(textBox1.Text)+1); // Number of Random numbers
            long[] randomNums = new long[iterationsofrandam];
            LCG_Task.lcg.linearCongruentialMethod(Xo, m, a, c, randomNums, iterationsofrandam);

           long con = 0;
            for (long i = 0; i < iterationsofrandam; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[1].Value = randomNums[i];
                row.Cells[0].Value = con++;
                dataGridView1.Rows.Add(row);
          
            }
           long coun=1;
            
            textBox6.Text = LCG_Task.lcg.cyclelenth(Xo, c, m,a, coun, randomNums, iterationsofrandam).ToString();




        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
