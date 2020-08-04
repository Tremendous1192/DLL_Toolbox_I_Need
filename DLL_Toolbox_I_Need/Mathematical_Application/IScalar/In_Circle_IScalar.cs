using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public class In_Circle_IScalar : IScalar
    {

        public double Calculate_f_u(double[] input)
        {
            double result = 0.0;

            for (int j = 0; j < input.Length; j++)
            {
                result += input[j] * input[j];
            }

            if (result > 1) { return 0.0; }
            return 1.0;
        }


        public decimal Calculate_f_u(decimal[] input)
        {
            decimal result = 0.0m;

            for (int j = 0; j < input.Length; j++)
            {
                result += input[j] * input[j];
            }

            if (result > 1) { return 0.0m; }
            return 1.0m;
        }

    }
}
