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
        /// 行列の跡 .
        /// Trace of Matrix .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double Trace(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new FormatException("Align the number of matrix lines " + matrix.GetLength(0) + " with the number of colmun of matrix " + matrix.GetLength(1));
            }

            double trace = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                trace += matrix[i, i];
            }
            return trace;
        }


        /// <summary>
        /// 転置行列 .
        /// Transposed_Matrix .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Transposed_Matrix(double[,] matrix)
        {
            double[,] transposed = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }

            return transposed;
        }






    }
}
