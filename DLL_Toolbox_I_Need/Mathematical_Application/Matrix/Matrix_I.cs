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
        /// 逆行列.
        /// Inverse matrix .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Inverse_of_a_Matrix(double[,] matrix)
        {


            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new FormatException("Align the number of " + nameof(matrix) + " row (" + matrix.GetLength(0) + ") with the number of colmun of matrix (" + matrix.GetLength(1) + ")");
            }


            //掃き出し法で計算する行列の生成
            double[,] sweeped = new double[matrix.GetLength(0), matrix.GetLength(1) * 2];


            //正則化項を加える(絶対値の最小値の1%とする)
            double abs_min = Math.Abs(matrix[0, 0]);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    abs_min = Math.Min(abs_min, Math.Abs(matrix[i, j]));
                }
            }
            double scaling = abs_min * 0.01;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sweeped[i, j] = matrix[i, j] + scaling;
                }
                sweeped[i, i + matrix.GetLength(1)] = 1.0;
            }




            //掃き出し法の計算
            // [i , i ]を基準とする。
            // [i2 , i ]を掛けて、i2 行を全て引き算する。
            for (int i = 0; i < sweeped.GetLength(0); i++)
            {
                //要素[ i , i ] の成分が 1 になるように、　i 行目の値を除算する
                var this_low = sweeped[i, i];
                for (int j = i; j < sweeped.GetLength(1); j++)
                {
                    sweeped[i, j] /= this_low;
                }

                // i2 行目の成分に関して、i列目の値が 0になるように、各列の値を減算する
                for (int i2 = 0; i2 < sweeped.GetLength(0); i2++)
                {
                    if (i == i2) { }
                    else
                    {
                        double this_subtracter = sweeped[i2, i];
                        for (int j = i; j < sweeped.GetLength(1); j++)
                        {
                            sweeped[i2, j] -= this_subtracter * sweeped[i, j];
                        }
                    }
                }
            }


            //戻り値は、matrix.GetLength(1)列目以降の行列
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = sweeped[i, j + matrix.GetLength(1)];
                }
            }


            return matrix;
        }




    }
}
