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
        /// 標本分散・標本共分散行列を計算する
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Variance_Covariance_Matrix_Sample(double[,] design_Matrix)
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


            double[,] variance_Covariance_Matrix
                     = new double[design_Matrix.GetLength(1), design_Matrix.GetLength(1)];

            //標本分散・共分散行列の要素[j,k]を計算する。
            for (int j = 0; j < design_Matrix.GetLength(1); j++)
            {
                for (int k = j; k < design_Matrix.GetLength(1); k++)
                {

                    //j次元目とk次元目の積の和を計算する。 Σxy
                    for (int n = 0; n < design_Matrix.GetLength(0); n++)
                    {
                        variance_Covariance_Matrix[j, k] += design_Matrix[n, j] * design_Matrix[n, k];
                    }

                    //j次元目の和とk次元目の和の積を、要素数で割った値を引く。-(Σx)(Σy)/N
                    variance_Covariance_Matrix[j, k] -= sum[j] * sum[k] / design_Matrix.GetLength(0);

                    //( 要素数 - 1 )で割る
                    variance_Covariance_Matrix[j, k] /= design_Matrix.GetLength(0) - 1;


                    //j , kを入れ替えても値は同じ
                    variance_Covariance_Matrix[k, j] = variance_Covariance_Matrix[j, k];
                }
            }

            return variance_Covariance_Matrix;

        }





    }
}
