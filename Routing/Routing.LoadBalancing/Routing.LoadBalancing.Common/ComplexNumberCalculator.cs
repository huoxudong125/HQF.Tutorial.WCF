using System;

namespace Routing.LoadBalancing.Common
{
    public class ComplexNumberCalculator : IComplexNumber
    {
        public Complex Add(Complex x, Complex y)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Add");

            var z = new Complex();

            z.Real = x.Real + y.Real;
            z.Imaginary = x.Imaginary + y.Imaginary;

            return z;
        }

        public Complex Subtract(Complex x, Complex y)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Subtract");

            var z = new Complex();

            z.Real = x.Real - y.Real;
            z.Imaginary = x.Imaginary - y.Imaginary;

            return z;
        }

        public Complex Multiply(Complex x, Complex y)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Multiply");

            var z = new Complex();

            z.Real = x.Real * y.Real - x.Imaginary * y.Imaginary ;
            z.Imaginary = x.Real * y.Imaginary + x.Imaginary * y.Real;

            return z;
        }

        public Complex Divide(Complex x, Complex y)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Divide");

            var z = new Complex();

            var modulusY = Math.Sqrt(y.Real * y.Real + y.Imaginary * y.Imaginary);

            z.Real = (x.Real * y.Real + x.Imaginary * y.Imaginary) / (modulusY * modulusY);
            z.Imaginary = (x.Imaginary * y.Real - x.Real * y.Imaginary) / (modulusY * modulusY);

            return z;
        }

        public double Modulus(Complex x)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Modulus");

            var modX = Math.Sqrt(x.Real * x.Real + x.Imaginary * x.Imaginary);

            return modX;
        }

        public Complex Conjugate(Complex x)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Conjugate");

            var z = new Complex();

            z.Real = x.Real;
            z.Imaginary = -1 * x.Imaginary;

            return z;
        }

        public double Argument(Complex x)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Argument");

            var argumentX = Math.Atan(x.Imaginary/x.Real);

            return argumentX;
        }

        public Complex Reciprocal(Complex x)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Recipocal");

            var z = new Complex();
            var conjugateX = new Complex();

            var modulusX = Math.Sqrt(x.Real * x.Real + x.Imaginary * x.Imaginary);

            conjugateX.Real = x.Real;
            conjugateX.Imaginary = -1 * x.Imaginary;

            z.Real = conjugateX.Real / (modulusX * modulusX);
            z.Imaginary = conjugateX.Imaginary / (modulusX * modulusX);

            return z;
        }
    }
}
