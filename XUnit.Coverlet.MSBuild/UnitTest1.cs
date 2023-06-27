using System;
using SquareEquationLib;

namespace XUnit.Coverlet
{
    public class CheckQuality
    {
        [Theory]
        [InlineData(1, -4, 4)] //1 корень
        [InlineData(1, 3, -4)] //2 корня
        [InlineData(1, -5, 9)] //нет корней
        [InlineData(0, 1, 1)] // a = 0
        [InlineData(1, double.NaN, 4)] // один - неопределенность
        [InlineData(1, 23, double.PositiveInfinity)] // один - бесконечность
        [InlineData(double.NaN, double.NegativeInfinity, double.PositiveInfinity)]
        public void Substituting_Roots_Into_The_Equation(double a, double b, double c)
        {
            double eps = 1e-9;
            bool equation = true;
            try
            {
                double[] result = SquareEquationLib.SquareEquation.Solve(a, b, c);
                if (result.Length == 1)
                {
                    equation = Math.Abs(a * result[0] * result[0] + b * result[0] + c) < eps;
                }
                else if (result.Length == 2)
                {
                    equation = (Math.Abs(a * result[0] * result[0] + b * result[0] + c) < eps) && (Math.Abs(a * result[1] * result[1] + b * result[1] + c) < eps);
                }
            }
            catch (ArgumentException) { }
            Assert.True(equation, $"Корни найдены неправильно");
        }
    }
}
