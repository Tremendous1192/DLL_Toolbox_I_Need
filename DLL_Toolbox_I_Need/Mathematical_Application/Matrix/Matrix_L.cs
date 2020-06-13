using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Matrix
    {
        /// <summary>
        /// 行列の各要素の自然対数をとる。
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Logarithm_LN(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = Math.Log(matrix[i, j]);
                }
            }

            return result;

        }

    }
}
