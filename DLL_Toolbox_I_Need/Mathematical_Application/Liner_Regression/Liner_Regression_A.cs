using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Liner_Regression
    {
        /// <summary>
        /// 計画行列に、定数項 1 を加える。
        /// </summary>
        /// <param name="design_matrix_without_constant"></param>
        /// <returns></returns>
        public static double[,] Add_Constant_1(double[,] design_matrix_without_constant)
        {
            double[,] design_matrix_with_constant_1 = new double[design_matrix_without_constant.GetLength(0)
                , design_matrix_without_constant.GetLength(1) + 1];

            for (int j = 0; j < design_matrix_without_constant.GetLength(0); j++)
            {
                design_matrix_with_constant_1[j, 0] = 1.0;
                for (int k = 0; k < design_matrix_without_constant.GetLength(1); k++)
                {
                    design_matrix_with_constant_1[j, k + 1] = design_matrix_without_constant[j, k];
                }
            }

            return design_matrix_with_constant_1;

        }

    }
}
