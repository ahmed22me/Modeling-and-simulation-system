using System;

namespace LCG_Task
{
    internal class lcg
    {
        public static void linearCongruentialMethod(long Xo, long m, long a, long c, long[] rand_no, long n_iterations)
        {
            rand_no[0] = Xo;

            for (long i = 1; i < n_iterations; i++)
            {
                rand_no[i] = (rand_no[i - 1] * a + c) % m;
            }
        }

        public static long cycleLength(long Xo, long c, long m, long a, long longest_period, long[] randomNums, long n_iterations)
        {
            long k = m - 1;

            if (IsRelativePrime(c, m) && a == 4 * k + 1 && power_two(m) && c > 0)
            {
                longest_period = m;
            }
            else if (checkPrime(m) && checkDivisibleM(a, m) && c == 0)
            {
                longest_period = m - 1;
            }
            else if (checkOdd(Xo) && power_two(m) && (a == 5 + 8 * k || a == 3 + 8 * k) && c == 0)
            {
                longest_period = m / 4;
            }
            else
            {
                longest_period = 1;
            }

            return longest_period;
        }

        static bool power_two(long M)
        {
            if (M == 0)
                return false;

            while (M != 1)
            {
                if (M % 2 != 0)
                    return false;
                M = M / 2;
            }
            return true;
        }

       

        public static bool IsRelativePrime(long firstNum, long secondNum)
        {
            if (firstNum == secondNum || firstNum % secondNum == 0 || secondNum % firstNum == 0)
            {
                return false;
            }
            else if (firstNum > secondNum)
            {
                for (long i = 2; i <= secondNum / 2; i++)
                {
                    if (firstNum % i == 0 && secondNum % i == 0)
                        return false;
                }
                return true;
            }
            else
            {
                for (long i = 2; i <= firstNum / 2; i++)
                {
                    if (firstNum % i == 0 && secondNum % i == 0)
                        return false;
                }
                return true;
            }
        }

        // Check if m is a prime number
        public static bool checkPrime(long m)
        {
            if (m < 2)
            {
                return false;
            }

            for (long i = 2; i <= Math.Sqrt(m); i++)
            {
                if (m % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool checkDivisibleM(long a, long m)
        {
            long k = m - 1;
            double div = Math.Pow(a, k) - 1;

            if (div % m == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool checkOdd(long Xo)
        {
            return Xo % 2 != 0;
        }
    }
}
