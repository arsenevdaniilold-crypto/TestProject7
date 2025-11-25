using System;

namespace TestProject7
{
    public static class Maths
    {
        private const int PRECISION = 10;

        public static double Cos(double x)
        {
            return CommonCalculate(i => Pow(-1, i) * Pow(x, 2 * i) / Factorial(2 * i));
        }

        public static double Sin(double x)
        {
            return CommonCalculate(i => Pow(-1, i) * Pow(x, 2 * i + 1) / Factorial(2 * i + 1));
        }

        public static double Ln(double x)
        {
            if (x <= 0)
            {
                throw new ArgumentException("ln(x) не определен для x <= 0");
            }
            
            double y = (x - 1) / (x + 1);
            return CommonCalculate(i => Pow(y, 2 * i + 1) / (2 * i + 1)) * 2;
        }

        private static double CommonCalculate(Func<int, double> calculateFunction)
        {
            double result = 0.0;
            for (int i = 0; i < PRECISION; i++)
            {
                result += calculateFunction(i);
            }
            return result;
        }

        public static double Pow(double baseValue, int exponent)
        {
            double result = 1.0;
            bool isNegativeExponent = exponent < 0;
            exponent = (int)Abs(exponent);
            
            for (int i = 0; i < exponent; i++)
            {
                result *= baseValue;
            }
            
            return isNegativeExponent ? 1.0 / result : result;
        }

        public static double Abs(double x)
        {
            return x < 0 ? -x : x;
        }

        public static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double Sqrt(double x)
        {
            if (x < 0)
            {
                throw new ArgumentException("Корень из отрицательного числа");
            }
            if (x == 0)
            {
                return 0;
            }

            double guess = x / 2;
            for (int i = 0; i < PRECISION; i++)
            {
                guess = (guess + x / guess) / 2;
            }
            return guess;
        }
    }
}