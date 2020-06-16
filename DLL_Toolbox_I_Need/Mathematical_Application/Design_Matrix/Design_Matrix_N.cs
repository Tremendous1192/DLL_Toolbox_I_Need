using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Design_Matrix
    {

        /// <summary>
        /// 各行ベクトルのL2ノルムを得る
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double[,] Norm_L2_Array(double[,] design_matrix)
        {
            double[,] result = new double[design_matrix.GetLength(0), 1];

            double norm = 0;

            for (int j = 0; j < design_matrix.GetLength(0); j++)
            {
                norm = 0;
                for (int k = 0; k < design_matrix.GetLength(1); k++)
                {
                    norm += design_matrix[j, k] * design_matrix[j, k];
                }
                norm = Math.Sqrt(norm / design_matrix.GetLength(1));

                result[j, 0] = norm;
            }

            return result;
        }


    }
}
