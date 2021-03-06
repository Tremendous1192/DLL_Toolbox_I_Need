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
        /// 標本平均を計算する。
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double[,] Mean_Sample(double[,] design_matrix)
        {
            double[,] mean = new double[1, design_matrix.GetLength(1)];
            for (int j = 0; j < design_matrix.GetLength(1); j++)
            {
                for (int i = 0; i < design_matrix.GetLength(0); i++)
                {
                    mean[0, j] += design_matrix[i, j];
                }
                mean[0, j] /= design_matrix.GetLength(0);
            }

            return mean;

        }


        /// <summary>
        /// 中央値を計算する
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double[,] Median_Sample(double[,] design_matrix)
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


            double[,] median = new double[1, sorted.GetLength(1)];

            //中央値は、要素数を2で割ったときのあまりで計算が異なる。
            int median_point = sorted.GetLength(0) / 2;
            if (sorted.GetLength(0) % 2 == 0)
            {
                for (int k = 0; k < sorted.GetLength(1); k++)
                {
                    median[0, k] = (sorted[median_point, k] + sorted[Math.Max(median_point - 1, 0), k]) / 2;
                }
            }
            else
            {
                for (int k = 0; k < sorted.GetLength(1); k++)
                {
                    median[0, k] = sorted[median_point, k];
                }
            }

            return median;


        }




    }
}
