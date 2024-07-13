//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace modelingTASK4
//{
//    internal class LCG_ALGO
//    {
        
//        public List<double> GenerateRandom(double seed_X0, double multiplier, double increment, double modulus, double iteration)
//        {
//            List<double> RandList = new List<double>();
//            double seed_Xi = 0;

//            for (int i = 1; i <= iteration; i++)
//            {
//                if (i == 1)
//                {
//                    seed_Xi = ((multiplier * seed_X0) + increment) % modulus;
//                    RandList.Add(seed_Xi);
//                }
//                else
//                {
//                    seed_Xi = ((multiplier * seed_Xi) + increment) % modulus;
//                    RandList.Add(seed_Xi);
//                }
//            }
//            return RandList;
//        }


//        public double FinalPeriodLength(double multiplier, double increment, double modulus, double x0, int iteration)
//        {

//            //int k = (int)(modulus - 1);
//            //double mul = Math.Pow((double)multiplier, (double)k) % (double)modulus;
//            //double pow = Math.Log(modulus, 2);
//            ////int mydiv = GCD(increment, modulus);
//            //int longest_period = 0;

//            //if (pow % 1 == 0 && increment != 0)
//            //{
//            //    longest_period = (int)modulus;
//            //    return longest_period;
//            //}
//            //else if (pow % 1 == 0 && increment == 0)
//            //{
//            //    longest_period = (int)(modulus / 4);
//            //    return longest_period;
//            //}
//            //else if (IsPrime(modulus) == true && increment == 0)
//            //{

//            //    longest_period = (int)(modulus - 1);
//            //    return longest_period;
//            //}

//            //return longest_period;



//            double LongestPeriod = -1;
//            double k = modulus - 1;
//            bool check1 = true, check2 = true, check3 = true;

//            if (IsPowerOfTwo(modulus) && (increment != 0))
//            {
//                //if (IsRelativelyPrime(increment, modulus) && (multiplier == (1 + 4 * k)))
//               // {
//                    LongestPeriod = modulus;
//                    check1 = false;
//               // }
//            }
//            if (IsPowerOfTwo(modulus) && (increment == 0))
//            {
//                //if (IsSeedOdd(x0) && ((multiplier == (5 + 8 * k)) || (multiplier == (3 + 8 * k))))
//                //{
//                    LongestPeriod = modulus / 4;
//                    check2 = false;
//                //}
//            }
//            if (IsPrime(modulus) && (increment == 0))
//            {
//                //if (IsDivisible((Math.Pow(multiplier, k) - 1), modulus))
//                //{
//                    LongestPeriod = modulus - 1;
//                    check3 = false;
//               // }
//            }
//            if (check1 && check2 && check3)
//            {

//                double LongPeriod = 0;
//                double seed_i = 0;
//                double first_number = ((multiplier * x0) + increment) % modulus;
//                for (int i = 2; i <= modulus; i++)
//                {
//                    if (i == 2)
//                        seed_i = ((multiplier * first_number) + increment) % modulus;
//                    else
//                        seed_i = ((multiplier * seed_i) + increment) % modulus;

//                    LongPeriod++;
//                    if (seed_i == first_number)
//                        return LongPeriod;
//                }
//            }
//            return LongestPeriod;
//        }


//        public bool IsPrime(double modulus)
//        {
//            if (modulus <= 1)
//                return false;

//            //for (int i = 2; i <= Math.Ceiling(Math.Sqrt(modulus)); i++)
//            for (int i = 2; i <= modulus; i++)
//            {
//                if (modulus % i == 0)
//                    return false;

//            }
//            return true;
//        }


//        public bool IsDivisible(double a, double b)
//        {
//            double cDouble = a / b;
//            int cInteger = (int)cDouble;
//            if (cInteger == cDouble)
//                return true;
//            return false;
//        }


//        public bool IsPowerOfTwo(double num)
//        {
//            if (num == 0)
//                return false;
//            while (num != 1)
//            {
//                if (num % 2 != 0)
//                    return false;
//                num = num / 2;
//            }
//            return true;
//        }


//        public bool IsSeedOdd(double seed)
//        {
//            if (seed % 2 != 0)
//                return true;
//            return false;
//        }


//        public bool IsRelativelyPrime(double increment, double modulus)
//        {
//            double num = Math.Min(modulus, increment);
//            for (int i = 2; i <= num; i++)
//            {
//                if (IsDivisible(increment, i) && IsDivisible(modulus, i))
//                    return false;
//            }
//            return true;
//        }

//    }
//}


