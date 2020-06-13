using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{

    public partial class Hidden_Layer
    {

        public void Step_4_5th_Calculate_Target_Function_and_Delta(double[,] w_next, double[,] delta_next)
        {
            double[,] w_T = Matrix.Transposed_Matrix(w_next);
            double[,] w_T_x_delta = Matrix.Multiplication(w_T, delta_next);

            delta = Matrix.Hadamard_product(w_T_x_delta, f_dash_wx_plus_b);
            change_w = Matrix.Multiplication(delta, Get_input_Transpose());

        }

    }

}
