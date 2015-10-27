using System;

namespace Routing.Version.Common
{
    public class ComplexNoCalc : IComplexNumber
    {
        public ComplexNumber Add(ComplexNumber x, ComplexNumber y)
        {
            Console.WriteLine("Invoked ADD operation.");

            var z = new ComplexNumber();

            z.Real = x.Real + y.Real;
            z.Imaginary = x.Imaginary + y.Imaginary;

            return z;
        }

        public ComplexNumber Subtract(ComplexNumber x, ComplexNumber y)
        {
            Console.WriteLine("Invoked SUBTRACT operation.");

            var z = new ComplexNumber();

            z.Real = x.Real - y.Real;
            z.Imaginary = x.Imaginary - y.Imaginary;

            return z;
        }

        public ComplexNumber Multiply(ComplexNumber x, ComplexNumber y)
        {
            Console.WriteLine("Invoked MULTIPLY Operation.");

            var z = new ComplexNumber();

            z.Real = x.Real * y.Real - x.Imaginary * y.Imaginary;
            z.Imaginary = x.Real * y.Imaginary + x.Imaginary * y.Real;

            return z;
        }

        public ComplexNumber Divide(ComplexNumber x, ComplexNumber y)
        {
            Console.WriteLine("Invoked DIVIDE Operation.");

            var z = new ComplexNumber();

            var modulusY = Math.Sqrt(y.Real * y.Real + y.Imaginary * y.Imaginary);

            z.Real = (x.Real * y.Real + x.Imaginary * y.Imaginary) / (modulusY * modulusY);
            z.Imaginary = (x.Imaginary * y.Real - x.Real * y.Imaginary) / (modulusY * modulusY);

            return z;
        }
    }
}
