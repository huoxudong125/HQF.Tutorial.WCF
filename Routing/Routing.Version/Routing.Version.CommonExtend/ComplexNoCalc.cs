using System;

namespace Routing.Version.CommonExtend
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


        public double Modulus(ComplexNumber x)
        {
            Console.WriteLine("Invoked MODULUS operation.");

            var modX = Math.Sqrt(x.Real * x.Real + x.Imaginary * x.Imaginary);

            return modX;
        }

        public double Argument(ComplexNumber x)
        {
            Console.WriteLine("Invoked ARGUMENT operation.");

            var argumentX = Math.Atan(x.Imaginary / x.Real);

            return argumentX;
        }

        public ComplexNumber Conjugate(ComplexNumber x)
        {
            Console.WriteLine("Invoked CONJUGATE Operation.");

            var z = new ComplexNumber();

            z.Real = x.Real;
            z.Imaginary = -1 * x.Imaginary;

            return z;
        }

        public ComplexNumber Reciprocal(ComplexNumber x)
        {
            Console.WriteLine("Invoked RECIPROCAL operation.");

            var z = new ComplexNumber();
            var conjugateX = new ComplexNumber();

            var modulusX = Math.Sqrt(x.Real * x.Real + x.Imaginary * x.Imaginary);

            conjugateX.Real = x.Real;
            conjugateX.Imaginary = -1 * x.Imaginary;

            z.Real = conjugateX.Real / (modulusX * modulusX);
            z.Imaginary = conjugateX.Imaginary / (modulusX * modulusX);

            return z;
        }
    }
}
