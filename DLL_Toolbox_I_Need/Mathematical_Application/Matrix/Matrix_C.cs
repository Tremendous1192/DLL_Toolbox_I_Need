using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Matrix
    {

        /// <summary>
        /// 同じ要素を持つインスタンスの生成.
        /// Creating instances with the same elements as input .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Clone(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int j=0;j<matrix.GetLength(0);j++)
            {
                for (int k=0;k<matrix.GetLength(1);k++)
                {
                    result[j, k] = matrix[j, k];
                }
            }
            return result;
        }


    }
}
