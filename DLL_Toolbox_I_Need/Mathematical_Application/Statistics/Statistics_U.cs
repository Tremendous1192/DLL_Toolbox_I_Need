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
        /// 第3四分位数を計算する。
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double[,] Upper_Quartile_Sample(double[,] design_matrix)
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


            double[,] upper_quartile = new double[1, sorted.GetLength(1)];

            //第3四分位数は、要素数を4で割ったときのあまりで計算が異なる。
            int upper_quartile_point = Math.Max(sorted.GetLength(0) - sorted.GetLength(0) / 4, 0);
            if (sorted.GetLength(0) % 4 < 2)
            {
                for (int k = 0; k < sorted.GetLength(1); k++)
                {
                    upper_quartile[0, k] = (sorted[upper_quartile_point, k] + sorted[Math.Max(upper_quartile_point - 1, 0), k]) / 2;
                }
            }
            else
            {
                upper_quartile_point = Math.Max(upper_quartile_point - 1, 0);
                for (int k = 0; k < sorted.GetLength(1); k++)
                {
                    upper_quartile[0, k] = sorted[upper_quartile_point, k];
                }
            }

            return upper_quartile;

        }


    }
}
