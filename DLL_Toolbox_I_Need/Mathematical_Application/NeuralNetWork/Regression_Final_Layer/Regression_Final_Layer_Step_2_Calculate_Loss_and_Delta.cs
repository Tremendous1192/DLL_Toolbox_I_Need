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
            //損失関数の計算
            teach = Teach;

            error = Matrix.Subtraction(f_wx_plus_b, teach);
            target_function = error[0, 0] * error[0, 0] / 2;

            //誤差逆伝搬法のδの計算
            delta = Matrix.Hadamard_product(error, f_wx_plus_b);
            change_w = Matrix.Multiplication(delta, Get_input_Transpose());

        }





    }

}
