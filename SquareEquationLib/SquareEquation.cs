namespace SquareEquationLib;

public class SquareEquation
{
    public static bool HasNotValue(double value)
    {
        return Double.IsNaN(value) || Double.IsInfinity(value);
    }
    public static double[] Solve(double a, double b, double c)
    {
        double[] solution;
        double eps = 1e-9;
        if ((a < eps && a > -eps)||HasNotValue(a)||HasNotValue(b)||HasNotValue(c))
        {
            throw new System.ArgumentException();
        }
        if (Math.Abs(b) > eps)
        {
            b = b/a; c = c/a;
            double d = b * b - 4 * c;
            
            
            if (d < -eps) { solution = new double[0]; } //D < 0
            else if (d < eps && d > -eps) //D = 0
            {
                solution = new double[1];
                solution[0] = -b / 2;
            }
            else//D > 0
            {
                solution = new double[2];
                solution[0] = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
                solution[1] = c / solution[0];
            }
        }
        else if (c <= eps)
        {
            solution = new double[2];
            solution[0] = Math.Pow(Math.Abs(c),0.5);
            solution[1] = -Math.Pow(Math.Abs(c),0.5);
        }
        else
        {
            solution = new double[0];
        }
        return solution;
    }
}
