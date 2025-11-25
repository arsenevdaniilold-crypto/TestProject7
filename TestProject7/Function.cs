using System;

namespace TestProject7
{
    public class Function
    {
        public double Execute(double x)
        {
            if (x <= 0)
            {
                // f(x) = √(sin(x) * cos(ln(|x|))) для x ≤ 0
                double sinValue = Maths.Sin(x);
                double absX = Maths.Abs(x);
                double lnAbsX = Maths.Ln(absX);
                double cosLnValue = Maths.Cos(lnAbsX);
                double product = sinValue * cosLnValue;
                
                if (product < 0)
                {
                    throw new ArithmeticException("Корень из отрицательного числа");
                }
                
                return Maths.Sqrt(product);
            }
            else
            {
                // f(x) = (1 - cos(x)) / sin(x) для x > 0
                double oneMinusCos = 1 - Maths.Cos(x);
                double sinValue = Maths.Sin(x);
                
                if (Maths.Abs(sinValue) < 1e-10)
                {
                    throw new ArithmeticException("Деление на ноль");
                }
                
                return oneMinusCos / sinValue;
            }
        }
    }
}