using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{

    public class Gaussian_IFunction : IFunction
    {
        public bool Bool_The_Least_Squares_Method()
        {
            return true;
        }

        public double[,] Calculate_f_u(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            double in_exp = 1.0;
            double divider = Math.Sqrt(2 * Math.PI);

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    in_exp = -input[j, k] * input[j, k] / 2;
                    result[j, k] = Math.Exp(in_exp) / divider;
                }
            }

            return result;
        }

        public double[,] Calculate_f_u_dash(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            double in_exp = 1.0;
            double divider = Math.Sqrt(2 * Math.PI);

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    in_exp = -input[j, k] * input[j, k] / 2;
                    result[j, k] = -input[j, k] * Math.Exp(in_exp) / divider;
                }
            }

            return result;
        }


    }



}
