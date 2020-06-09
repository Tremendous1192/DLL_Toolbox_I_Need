using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Regression_Final_Layer
    {

        public void Step_4_5th_Calculate_Target_Function_and_Delta()
        {
            error = Matrix.Subtraction(f_wx_plus_b, teach);

            delta = Matrix.Hadamard_product(error, f_wx_plus_b);
            change_w = Matrix.Multiplication(delta, Get_input_Transpose());

            target_function = error[0, 0] * error[0, 0] / 2;
        }
    }

}
