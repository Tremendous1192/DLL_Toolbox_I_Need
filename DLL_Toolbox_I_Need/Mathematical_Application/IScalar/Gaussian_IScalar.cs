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

    }

}
