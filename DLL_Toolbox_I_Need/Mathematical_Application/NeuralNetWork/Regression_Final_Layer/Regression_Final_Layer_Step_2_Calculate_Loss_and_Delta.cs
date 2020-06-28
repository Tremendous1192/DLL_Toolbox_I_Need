using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{


    public partial class Regression_Final_Layer
    {


        /// <summary>
        /// 損失関数の計算とパラメータ更新のためのdeltaを計算する。
        /// </summary>
        /// <param name="Teach"></param>
        public void Step_2_3rd_Calculate_Target_Function_and_Delta(double[,] Teach)
        {
            teach = Teach;

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
