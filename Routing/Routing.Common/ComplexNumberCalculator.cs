using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Common
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

            z.Real = x.Real * y.Real - x.Imaginary * y.Imaginary;
            z.Imaginary = x.Real * y.Imaginary + x.Imaginary * y.Real;

            return z;
        }

        public Complex Divide(Complex x, Complex y)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Divide");

            var z = new Complex();

            var modulusY = this.Modulus(y);

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

            var argumentX = Math.Atan(x.Imaginary / x.Real);

            return argumentX;
        }

        public Complex Recipocal(Complex x)
        {
            Console.WriteLine("Invoked ComplexNumberCalculator Operation: Recipocal");

            var z = new Complex();

            var modulusX = this.Modulus(x);
            var conjugateX = this.Conjugate(x);

            z.Real = conjugateX.Real / (modulusX * modulusX);
            z.Imaginary = conjugateX.Imaginary / (modulusX * modulusX);

            return z;
        }
    }

}
