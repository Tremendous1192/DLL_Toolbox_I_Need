﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Statistics
    {
        /// <summary>
        /// 四分位数を計算する。
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double[,] Lower_Quartile_Sample(double[,] design_matrix)
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


            double[,] lower_quartile = new double[1, design_matrix.GetLength(1)];

            //四分位数は、要素数を4で割ったときのあまりで計算が異なる。
            int lower_quartile_point = design_matrix.GetLength(0) / 4;
            if (design_matrix.GetLength(0) % 4<2)
            {
                for (int k = 0; k < design_matrix.GetLength(1); k++)
                {
                    lower_quartile[0, k] = (design_matrix[lower_quartile_point, k] + design_matrix[Math.Max(lower_quartile_point - 1, 0), k]) / 2;
                }
            }
            else
            {
                for (int k = 0; k < design_matrix.GetLength(1); k++)
                {
                    lower_quartile[0, k] = design_matrix[lower_quartile_point, k];
                }
            }

            return lower_quartile;

        }

    }
}
