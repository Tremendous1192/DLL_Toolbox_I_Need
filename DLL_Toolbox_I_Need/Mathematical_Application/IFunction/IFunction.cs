using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public interface IFunction
    {
        double[,] Calculate_f_u(double[,] input);

        double[,] Calculate_f_u_dash(double[,] input);

        bool Bool_The_Least_Squares_Method();
    }


}
