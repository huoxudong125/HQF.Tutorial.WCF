﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Common
{
    [ServiceContract]
    public interface IComplexNumber
    {
        [OperationContract]
        Complex Add(Complex x, Complex y);

        [OperationContract]
        Complex Subtract(Complex x, Complex y);

        [OperationContract]
        Complex Multiply(Complex x, Complex y);

        [OperationContract]
        Complex Divide(Complex x, Complex y);

        [OperationContract]
        double Modulus(Complex x);

        [OperationContract]
        double Argument(Complex x);

        [OperationContract]
        Complex Conjugate(Complex x);

        [OperationContract]
        Complex Recipocal(Complex x);
    }
}
