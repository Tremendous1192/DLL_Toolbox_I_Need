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
        /// 行列式.
        /// Determinant .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double Determinant(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new FormatException("Align the number of " + nameof(matrix) + " row (" + matrix.GetLength(0) + ") with the number of colmun of matrix (" + matrix.GetLength(1) + ")");
            }

            //正則化項を加える(絶対値の最小値の1/1,000,000とする)
            double abs_min = Math.Abs(matrix[0, 0]);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    abs_min = Math.Min(abs_min, Math.Abs(matrix[i, j]));
                }
            }
            double scaling = abs_min / 1000.0 / 1000.0;

            double[,] calculated = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    calculated[i,j]= matrix[i, j] + scaling;
                }
            }


            double upper = 1.0;
            double lower = 1.0;

            //掃き出し法の計算
            // [i , i ]を基準とする。
            // [i2 , i ]を掛けて、i2 行を全て引き算する。
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //要素[ i , i ] の成分が 1 になるように、　i 行目の値を除算する
                var this_low = calculated[i, i];
                lower *= matrix[i, i];
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    calculated[i, j] /= this_low;
                }

                // i2 行目の成分に関して、i列目の値が 0になるように、各列の値を減算する
                for (int i2 = 0; i2 < matrix.GetLength(0); i2++)
                {
                    if (i == i2) { }
                    else
                    {
                        double this_subtracter = matrix[i2, i];
                        for (int j = i; j < matrix.GetLength(1); j++)
                        {
                            calculated[i2, j] -= this_subtracter * calculated[i, j];
                        }
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                upper *= calculated[i, i];
            }


            return upper / lower;
        }




    }
}
