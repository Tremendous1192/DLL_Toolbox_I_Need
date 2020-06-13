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
            //昇順に並び替える
            double buffer = 0.0;
            for (int k = 0; k < design_matrix.GetLength(1); k++)
            {
                for (int j = 0; j < design_matrix.GetLength(0); j++)
                {
                    for (int j2 = j + 1; j2 < design_matrix.GetLength(0); j2++)
                    {
                        if (design_matrix[j, k] > design_matrix[j2, k])
                        {
                            buffer = design_matrix[j, k];
                            design_matrix[j, k] = design_matrix[j2, k];
                            design_matrix[j2, k] = buffer;
                        }
                    }
                }
            }


            double[,] max = new double[1, design_matrix.GetLength(1)];
            for (int k = 0; k < design_matrix.GetLength(1); k++)
            {
                max[0, k] = design_matrix[design_matrix.GetLength(0) - 1, k];
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
            //昇順に並び替える
            double buffer = 0.0;
            for (int k = 0; k < design_matrix.GetLength(1); k++)
            {
                for (int j = 0; j < design_matrix.GetLength(0); j++)
                {
                    for (int j2 = j + 1; j2 < design_matrix.GetLength(0); j2++)
                    {
                        if (design_matrix[j, k] > design_matrix[j2, k])
                        {
                            buffer = design_matrix[j, k];
                            design_matrix[j, k] = design_matrix[j2, k];
                            design_matrix[j2, k] = buffer;
                        }
                    }
                }
            }


            double[,] max = new double[1, design_matrix.GetLength(1)];
            for (int k = 0; k < design_matrix.GetLength(1); k++)
            {
                max[0, k] = design_matrix[0, k];
            }

            return max;

        }


    }
}
