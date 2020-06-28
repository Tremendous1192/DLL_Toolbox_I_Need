using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{


    class Swish_IFunction : IFunction
    {


        public double[,] Calculate_f_u(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            double sigmoid = 1.0;

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    sigmoid = 1.0 / (1.0 + Math.Exp(-input[j, k]));
                    result[j, k] = input[j, k] * sigmoid;
                }
            }

            return result;
        }

        public double[,] Calculate_f_u_dash(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            double sigmoid = 1.0;

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    sigmoid = 1.0 / (1.0 + Math.Exp(-input[j, k]));
                    result[j, k] = sigmoid * (1.0 + input[j, k] * (1 - sigmoid));
                }
            }

            return result;
        }




    }




}
