using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modelingTASK4
{
    public partial class Form1 : Form
    {
        //private LCG_ALGO fun;
        public Form1()
        {
            InitializeComponent();
            //fun = new LCG_ALGO();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            randomNumbersTable.Rows.Clear();
            if (seedTextBox.Text.Equals(String.Empty) || multiplierTextBox.Text.Equals(String.Empty) || incrementTextBox.Equals(String.Empty) || modulusTextBox.Equals(String.Empty) || numberOfIterationsTextBox.Equals(String.Empty))
            {
                MessageBox.Show("Invalid Input, Please Enter Valid Input");
            }
            else
            {

                int seed = Int32.Parse(seedTextBox.Text);
                int multiplier = Int32.Parse(multiplierTextBox.Text);
                int increment = Int32.Parse(incrementTextBox.Text);
                int modulus = Int32.Parse(modulusTextBox.Text);
                int iteration = Int32.Parse(numberOfIterationsTextBox.Text);



                int[] randomNumbers = new int[iteration];
                int period = 0;
                Dictionary<int, int> cycleNumbers = new Dictionary<int, int>();
                randomNumbers[0] = (multiplier * seed + increment) % modulus;
                int randNum = randomNumbers[0];
                while (true)
                {
                    if (!cycleNumbers.ContainsKey(randNum))
                    {
                        cycleNumbers.Add(randNum, 1);
                        period++;
                        randNum = (multiplier * randNum + increment) % modulus;
                    }
                    else
                        break;
                }

                // Loop through number of iterations with the LCG
                for (int i = 1; i < iteration; i++)
                    randomNumbers[i] = (multiplier * randomNumbers[i - 1] + increment) % modulus;

                // Add the random numbers to the data grid view
                for (int i = 0; i < iteration; i++)
                {
                    randomNumbersTable.Rows.Add(randomNumbers[i].ToString());
                }

                double k = modulus - 1;

                if (IsPowerOfTwo(modulus) && (increment != 0))
                {
                    if (IsRelativelyPrime(increment, modulus) && (multiplier == (1 + 4 * k)))
                    {
                        period = modulus;
                    }
                }
                if (IsPowerOfTwo(modulus) && (increment == 0))
                {
                    if (IsSeedOdd(seed) && ((multiplier == (5 + 8 * k)) || (multiplier == (3 + 8 * k))))
                    {
                        period = modulus / 4;
                    }
                }
                if (IsPrime(modulus) && (increment == 0))
                {
                    if (IsDivisible((Math.Pow(multiplier, k) - 1), modulus))
                    {
                        period = modulus - 1;
                    }
                }
                cycleLengthTextBox.Text = period.ToString();


            }
        }

        public bool IsPrime(double modulus)
        {
            if (modulus <= 1)
                return false;

            //for (int i = 2; i <= Math.Ceiling(Math.Sqrt(modulus)); i++)
            for (int i = 2; i <= modulus; i++)
            {
                if (modulus % i == 0)
                    return false;

            }
            return true;
        }


        public bool IsDivisible(double a, double b)
        {
            double cDouble = a / b;
            int cInteger = (int)cDouble;
            if (cInteger == cDouble)
                return true;
            return false;
        }


        public bool IsPowerOfTwo(double num)
        {
            if (num == 0)
                return false;
            while (num != 1)
            {
                if (num % 2 != 0)
                    return false;
                num = num / 2;
            }
            return true;
        }


        public bool IsSeedOdd(double seed)
        {
            if (seed % 2 != 0)
                return true;
            return false;
        }


        public bool IsRelativelyPrime(double increment, double modulus)
        {
            double num = Math.Min(modulus, increment);
            for (int i = 2; i <= num; i++)
            {
                if (IsDivisible(increment, i) && IsDivisible(modulus, i))
                    return false;
            }
            return true;
        }
    
    }
}