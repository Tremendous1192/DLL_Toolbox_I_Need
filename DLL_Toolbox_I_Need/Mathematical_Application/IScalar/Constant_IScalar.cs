using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public class Constant_IScalar: IScalar
    {
        public double Calculate_f_u(double[] input)
        {
            return 1.0;
        }


        public decimal Calculate_f_u(decimal[] input)
        {
            return 1m;
        }
    }
}
