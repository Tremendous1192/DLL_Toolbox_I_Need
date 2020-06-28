using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{

    public partial class Hidden_Layer
    {


        /// <summary>
        /// パラメータを更新する
        /// </summary>
        public void Step_3_3rd_Update()
        {
            //wの更新
            double[,] w_d_gamma = Matrix.Scalar_Multiplication(change_w, gamma);

            double[,] bb = w_d_gamma;
            if (L_1 > 0 && L_1 <= 1)
            {
                double[,] aa = Matrix.Sign_Element(change_w);
                double[,] w_d_L_1 = Matrix.Scalar_Multiplication(aa, L_1);
                bb = Matrix.Addition(bb, w_d_L_1);
            }
            if (L_2 > 0 && L_2 <= 1)
            {
                double[,] w_d_L_2 = Matrix.Scalar_Multiplication(w, L_2);
                bb = Matrix.Addition(bb, w_d_L_2);
            }
            if (drop_out > 0 && drop_out < 1)
            {
                for (int j = 0; j < bb.GetLength(0); j++)
                {
                    for (int k = 0; k < bb.GetLength(1); k++)
                    {
                        if (ud.NextDouble() < drop_out)
                        {
                            bb[j, k] = 0;
                        }
                    }
                }
            }

            w = Matrix.Subtraction(w, bb);


            //bの更新
            double[,] b_d_gamma = Matrix.Scalar_Multiplication(delta, gamma);

            double[,] dd = b_d_gamma;
            if (L_1 > 0 && L_1 <= 1)
            {
                double[,] cc = Matrix.Sign_Element(delta);
                double[,] b_d_L_1 = Matrix.Scalar_Multiplication(cc, L_1);
                dd = Matrix.Addition(dd, b_d_L_1);
            }
            if (L_2 > 0 && L_2 <= 1)
            {
                double[,] b_d_L_2 = Matrix.Scalar_Multiplication(b, L_2);
                dd = Matrix.Addition(dd, b_d_L_2);
            }
            if (drop_out > 0 && drop_out < 1)
            {
                for (int j = 0; j < dd.GetLength(0); j++)
                {
                    if (ud.NextDouble() < drop_out)
                    {
                        dd[j, 0] = 0;
                    }
                }
            }

            b = Matrix.Subtraction(b, dd);


        }





    }

}
