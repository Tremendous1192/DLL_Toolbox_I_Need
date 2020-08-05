using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public class Gaussian_IScalar : IScalar
    {

        public double Calculate_f_u(double[] input)
        {
            double result = 0.0;

            for (int j=0;j<input.Length;j++)
            {
                result += input[j] * input[j];
            }

            return Math.Exp(-result / 2.0);
        }

        const decimal Napier = 2.718281828459045235360287471352m;

        public decimal Calculate_f_u(decimal[] input)
        {
            decimal index = 0.0m;

            for (int j = 0; j < input.Length; j++)
            {
                index += input[j] * input[j];
            }

            decimal integer = Math.Floor(index / 2m);
            decimal denominator = 1m;
            for (uint j = 0; j < integer; j++)
            {
                denominator *= Napier;
            }

            decimal fraction = index - integer;


            return Taylor_Series_Decimal.Exponential(-fraction)/denominator;

        }

    }

}
