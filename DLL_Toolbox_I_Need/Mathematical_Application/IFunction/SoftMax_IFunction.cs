using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{


    class SoftMax_IFunction : IFunction
    {


        public double[,] Calculate_f_u(double[,] input)
        {

            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            double max = input[0, 0];
            foreach (double i in input)
            {
                max = Math.Max(max, i);
            }


            double exp = 1.0;
            double sum = 0;
            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    exp = Math.Exp(input[j, k] - max);
                    result[j, k] = exp;
                    sum += exp;
                }
            }

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    result[j, k] /= sum;
                }
            }

            return result;
        }

        public double[,] Calculate_f_u_dash(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            double max = input[0, 0];
            foreach (double i in input)
            {
                max = Math.Max(max, i);
            }


            double exp = 1.0;
            double sum = 0;
            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    exp = Math.Exp(input[j, k] - max);
                    result[j, k] = exp;
                    sum += exp;
                }
            }


            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    result[j, k] /= sum;
                    result[j, k] = result[j, k] * (1 - result[j, k]);
                }
            }


            return result;
        }


    }


}
