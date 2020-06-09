using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{

    public partial class Multiclass_Classification_Final_Layer
    {

        public void Step_4_5th_Calculate_Target_Function_and_Delta()
        {

            double[,] Reciprocal_Number_Output = Matrix.Reciprocal_Number_Matrix(f_wx_plus_b);

            double[,] aa = Matrix.Hadamard_product(teach, Reciprocal_Number_Output);
            error = Matrix.Scalar_Multiplication(aa, -1.0);

            delta = Matrix.Hadamard_product(error, f_wx_plus_b);
            change_w = Matrix.Multiplication(delta, Get_input_Transpose());

            double[,] ln_output = Matrix.Logarithm_LN(f_wx_plus_b);
            double[,] bb = Matrix.Hadamard_product(teach, ln_output);
            target_function = -Matrix.Summation_X(bb);

        }

    }

}
