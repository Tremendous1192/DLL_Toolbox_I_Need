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
        /// 標準偏差を計算する。
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Standard_Deviation_Sample(double[,] design_Matrix)
        {

            //ベクトルの総和を計算する。
            double[] sum = new double[design_Matrix.GetLength(1)];
            for (int n = 0; n < design_Matrix.GetLength(0); n++)
            {
                for (int k = 0; k < design_Matrix.GetLength(1); k++)
                {
                    sum[k] += design_Matrix[n, k];
                }
            }


            double[,] Standard_Deviation
                     = new double[1, design_Matrix.GetLength(1)];

            //標準偏差のk次元目を計算する。
            for (int k = 0; k < design_Matrix.GetLength(1); k++)
            {

                //j次元目とk次元目の積の総和を計算する。 Σxy
                for (int n = 0; n < design_Matrix.GetLength(0); n++)
                {
                    Standard_Deviation[0, k] += design_Matrix[n, k] * design_Matrix[n, k];
                }

                //j次元目の総和とk次元目の総和の積を、要素数で割った値を引く。-(Σx)(Σy)/N
                Standard_Deviation[0, k] -= sum[k] * sum[k] / design_Matrix.GetLength(0);

                //( 要素数 - 1 )で割る
                Standard_Deviation[0, k] /= design_Matrix.GetLength(0) - 1;

                //平方根を取る
                Standard_Deviation[0, k] = Math.Sqrt(Standard_Deviation[0, k]);
            }

            return Standard_Deviation;
        }



        /// <summary>
        /// 標準誤差を計算する。
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Standard_Error_Sample(double[,] design_Matrix)
        {

            //ベクトルの総和を計算する。
            double[] sum = new double[design_Matrix.GetLength(1)];
            for (int n = 0; n < design_Matrix.GetLength(0); n++)
            {
                for (int k = 0; k < design_Matrix.GetLength(1); k++)
                {
                    sum[k] += design_Matrix[n, k];
                }
            }


            double[,] Standard_Error
                     = new double[1, design_Matrix.GetLength(1)];

            //標準偏差のk次元目を計算する。
            for (int k = 0; k < design_Matrix.GetLength(1); k++)
            {

                //j次元目とk次元目の積の総和を計算する。 Σxy
                for (int n = 0; n < design_Matrix.GetLength(0); n++)
                {
                    Standard_Error[0, k] += design_Matrix[n, k] * design_Matrix[n, k];
                }

                //j次元目の総和とk次元目の総和の積を、要素数で割った値を引く。-(Σx)(Σy)/N
                Standard_Error[0, k] -= sum[k] * sum[k] / design_Matrix.GetLength(0);

                //( 要素数 - 1 )で割る
                Standard_Error[0, k] /= design_Matrix.GetLength(0) - 1;

                //要素数で割って、平方根を取る
                Standard_Error[0, k] = Math.Sqrt(Standard_Error[0, k] / design_Matrix.GetLength(0));
            }

            return Standard_Error;
        }


        /// <summary>
        /// [0,*] 最小値
        /// [1,*] 第一四分位数
        /// [2,*] 中央値
        /// [3,*] 平均値
        /// [4,*] 第三四分位数
        /// [5,*] 最大値
        /// [6,*] 偏差平方和
        /// [7,*] 標本分散
        /// [8,*] 標本標準偏差
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Summary(double[,] design_matrix)
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


            double[,] summary = new double[9, sorted.GetLength(1)];


            //[0,*] 最小値 and [5,*] 最大値
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                summary[0, k] = sorted[0, k];
                summary[5, k] = sorted[sorted.GetLength(0) - 1, k];
            }

            //[3,*] 平均値
            for (int k = 0; k < sorted.GetLength(1); k++)
            {
                for (int j = 0; j < sorted.GetLength(0); j++)
                {
                    summary[3, k] += sorted[j, k];
                }
                summary[3, k] /= sorted.GetLength(0);
            }

            //[2,*] 中央値
            int median_point = sorted.GetLength(0) / 2;
            if (sorted.GetLength(0) % 2 == 0)
            {
                for (int k = 0; k < sorted.GetLength(1); k++)
                {
                    summary[2, k] = (sorted[median_point, k] + sorted[Math.Max(median_point - 1, 0), k]) / 2;
                }
            }
            else
            {
                for (int k = 0; k < sorted.GetLength(1); k++)
                {
                    summary[2, k] = sorted[median_point, k];
                }
            }

            //[1,*] 第一四分位数
            //[4,*] 第三四分位数
            int lower_quartile_point = sorted.GetLength(0) / 4;
            int upper_quartile_point = Math.Max(sorted.GetLength(0) - sorted.GetLength(0) / 4, 0);
            if (sorted.GetLength(0) % 4 < 2)
            {
                for (int k = 0; k < sorted.GetLength(1); k++)
                {
                    summary[1, k] = (sorted[lower_quartile_point, k] + sorted[Math.Max(lower_quartile_point - 1, 0), k]) / 2;
                    summary[4, k] = (sorted[upper_quartile_point, k] + sorted[Math.Max(upper_quartile_point - 1, 0), k]) / 2;
                }
            }
            else
            {
                upper_quartile_point = Math.Max(upper_quartile_point - 1, 0);
                for (int k = 0; k < sorted.GetLength(1); k++)
                {
                    summary[1, k] = sorted[lower_quartile_point, k];
                    summary[4, k] = sorted[upper_quartile_point, k];
                }
            }

            //[6,*] 偏差平方和
            for (int j = 0; j < design_matrix.GetLength(0); j++)
            {
                for (int k = 0; k < design_matrix.GetLength(1); k++)
                {
                    summary[6, k] += (design_matrix[j, k] - summary[3, k]) * (design_matrix[j, k] - summary[3, k]);
                }
            }

            //[7,*] 標本分散
            //[8,*] 標本標準偏差
            for (int k = 0; k < design_matrix.GetLength(1); k++)
            {
                summary[7, k] = summary[6, k] / (design_matrix.GetLength(0) - 1);
                summary[8, k] = Math.Sqrt(summary[7, k]);
            }


            return summary;
        }



    }
}
