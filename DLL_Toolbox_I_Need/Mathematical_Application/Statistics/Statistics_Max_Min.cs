using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Statistics
    {

        /// <summary>
        /// 最大値を計算する。
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double[,] Maximum_Sample(double[,] design_matrix)
        {

            //並べ替え用の配列。
            //design_matrixを計算に用いると参照渡しになるバグがある。
            double[,] sorted = new double[design_matrix.GetLength(0), design_matrix.GetLength(1)];
            for (int j = 0; j < design_matrix.GetLength(0); j++)
            {
                for (int k = 0; k < design_matrix.GetLength(1); k++)
                {
                    sorted[j, k] = design_matrix[j, k];
                }
            }

            //昇順に並び替える
            double buffer = 0.0;
            for (int k = 0; k < sorted.GetLength(1); k++)
            {
                for (int j = 0; j < sorted.GetLength(0); j++)
                {
                    for (int j2 = j + 1; j2 < sorted.GetLength(0); j2++)
                    {
                        if (sorted[j, k] > sorted[j2, k])
                        {
                            buffer = sorted[j, k];
                            sorted[j, k] = sorted[j2, k];
                            sorted[j2, k] = buffer;
                        }
                    }
                }
            }


            double[,] max = new double[1, sorted.GetLength(1)];
            for (int k = 0; k < sorted.GetLength(1); k++)
            {
                max[0, k] = sorted[sorted.GetLength(0) - 1, k];
            }

            return max;

        }



        /// <summary>
        /// 最小値を計算する。
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double[,] Minimum_Sample(double[,] design_matrix)
        {

            //並べ替え用の配列。
            //design_matrixを計算に用いると参照渡しになるバグがある。
            double[,] sorted = new double[design_matrix.GetLength(0), design_matrix.GetLength(1)];
            for (int j = 0; j < design_matrix.GetLength(0); j++)
            {
                for (int k = 0; k < design_matrix.GetLength(1); k++)
                {
                    sorted[j, k] = design_matrix[j, k];
                }
            }

            //昇順に並び替える
            double buffer = 0.0;
            for (int k = 0; k < sorted.GetLength(1); k++)
            {
                for (int j = 0; j < sorted.GetLength(0); j++)
                {
                    for (int j2 = j + 1; j2 < sorted.GetLength(0); j2++)
                    {
                        if (sorted[j, k] > sorted[j2, k])
                        {
                            buffer = sorted[j, k];
                            sorted[j, k] = sorted[j2, k];
                            sorted[j2, k] = buffer;
                        }
                    }
                }
            }



            double[,] max = new double[1, sorted.GetLength(1)];
            for (int k = 0; k < sorted.GetLength(1); k++)
            {
                max[0, k] = sorted[sorted.GetLength(0) - 1, k];
            }

            return max;

        }


    }
}
