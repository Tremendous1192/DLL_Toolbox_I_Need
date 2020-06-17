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
                Standard_Error[0, k] = Math.Sqrt(Standard_Error[0, k]/ design_Matrix.GetLength(0));
            }

            return Standard_Error;
        }


    }
}
