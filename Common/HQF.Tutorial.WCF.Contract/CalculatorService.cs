using HQF.Tutorial.WCF.Contract.Interface;

namespace HQF.Tutorial.WCF.Contract
{
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x*y;
        }

        public double Divide(double x, double y)
        {
            return x/y;
        }
    }
}