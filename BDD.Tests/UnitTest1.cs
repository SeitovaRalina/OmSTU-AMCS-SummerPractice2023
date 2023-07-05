using SquareEquationLib;
using TechTalk.SpecFlow;
namespace UnitTes1
{
    [Binding]
    public class BDD
    {
        ScenarioContext scenarioContext;
        double a, b, c;
        delegate double[] Equation(double a, double b, double c);
        Equation solve = (double a, double b, double c) => SquareEquation.Solve(a,b,c);
        
        double[] result;
        public BDD(ScenarioContext input)
        {
            scenarioContext = input;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void InputWithRealNumbers(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
        public void InputWithFirstNan(double b, double c)
        {
            a = double.NaN;
            this.b = b;
            this.c = c;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
        public void InputWithSecondNan(double a, double c)
        {
            this.a = a;
            b = double.NaN;
            this.c = c;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
        public void InputWithThirdNan(double a, double b)
        {
            this.a = a;
            this.b = b;
            c = double.NaN;
        }
        [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
        public void InputWithFirstNI(double b, double c)
        {
            a = double.NegativeInfinity;
            this.b = b;
            this.c = c;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
        public void InputWithSecondNI(double a, double c)
        {
            this.a = a;
            b = double.NegativeInfinity;
            this.c = c;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
        public void InputWithThirdNI(double a, double b)
        {
            this.a = a;
            this.b = b;
            c = double.NegativeInfinity;
        }
        [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
        public void InputWithFirstPI(double b, double c)
        {
            a = double.PositiveInfinity;
            this.b = b;
            this.c = c;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
        public void InputWithSecondPI(double a, double c)
        {
            this.a = a;
            b = double.PositiveInfinity;
            this.c = c;
        }
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
        public void InputWithThirdPI(double a, double b)
        {
            this.a = a;
            this.b = b;
            c = double.PositiveInfinity;
        }
        [When(@"вычисляются корни квадратного уравнения")]
        public void TryToSolve()
        {
            try
            { result = solve(a, b, c);}
            catch {}
        }
        [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void TwoRoots(double p0, double p1)
        {
            double[] expected = {p0, p1};
            Array.Sort(result);
            Array.Sort(expected);
            Assert.Equal(result, expected);
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
         public void OneRoot(double p0)
         {
            double[] expected = {p0};
            Assert.Equal(result, expected);
         }

         [Then(@"множество корней квадратного уравнения пустое")]
         public void NoRoots()
         {
            Assert.Empty(result);
         }

         [Then(@"выбрасывается исключение ArgumentException")]
         public void Exception()
         {
            Assert.Throws<System.ArgumentException>(() => solve(a, b, c));
         }
    }
}