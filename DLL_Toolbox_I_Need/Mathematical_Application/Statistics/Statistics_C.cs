using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Statistics
    {


        public static double[,] Correlation_Matrix_Sample(double[,] design_Matrix)
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


            double[,] Correlation_Matrix
                     = new double[design_Matrix.GetLength(1), design_Matrix.GetLength(1)];

            //標本分散・共分散行列の要素[j,k]を計算する。
            for (int j = 0; j < design_Matrix.GetLength(1); j++)
            {
                for (int k = j; k < design_Matrix.GetLength(1); k++)
                {

                    //j次元目とk次元目の積の和を計算する。 Σxy
                    for (int n = 0; n < design_Matrix.GetLength(0); n++)
                    {
                        Correlation_Matrix[j, k] += design_Matrix[n, j] * design_Matrix[n, k];
                    }

                    //j次元目の和とk次元目の和の積を、要素数で割った値を引く。-(Σx)(Σy)/N
                    Correlation_Matrix[j, k] -= sum[j] * sum[k] / design_Matrix.GetLength(0);

                    //( 要素数 - 1 )で割る
                    Correlation_Matrix[j, k] /= design_Matrix.GetLength(0) - 1;


                    //j , kを入れ替えても値は同じ
                    Correlation_Matrix[k, j] = Correlation_Matrix[j, k];
                }
            }


            //標準偏差計算する
            double[] std = new double[design_Matrix.GetLength(1)];
            for (int j = 0; j < Correlation_Matrix.GetLength(0); j++)
            {
                std[j] = Math.Sqrt(Correlation_Matrix[j, j]);
            }

            //相関係数を計算する。
            for (int j = 0; j < Correlation_Matrix.GetLength(0); j++)
            {
                for (int k = 0; k < Correlation_Matrix.GetLength(1); k++)
                {
                    Correlation_Matrix[j, k] /= std[j] * std[k];
                }
            }

            return Correlation_Matrix;

        }



    }
}
