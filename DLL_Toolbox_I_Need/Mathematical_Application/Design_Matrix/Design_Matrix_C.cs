using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Design_Matrix
    {

        /// <summary>
        /// 相関係数の行列を得る
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Corelation_Matrix(double[,] design_Matrix)
        {

            double[,] average = Design_Matrix.Average(design_Matrix);

            double[,] corelation_Matrix
                     = new double[design_Matrix.GetLength(1), design_Matrix.GetLength(1)];

            //分散・共分散行列の要素[j,k]を計算する。
            for (int j = 0; j < design_Matrix.GetLength(1); j++)
            {
                for (int k = j; k < design_Matrix.GetLength(1); k++)
                {

                    //j次元目とk次元目の積の平均値を計算する。 E[XY]
                    for (int n = 0; n < design_Matrix.GetLength(0); n++)
                    {
                        corelation_Matrix[j, k] += design_Matrix[n, j] * design_Matrix[n, k];
                    }
                    corelation_Matrix[j, k] /= design_Matrix.GetLength(0);

                    //j次元目の平均値とk次元目の平均値の積を引く。-E[X]E[Y]
                    corelation_Matrix[j, k] -= average[0, j] * average[0, k];

                    //j , kを入れ替えても値は同じ
                    corelation_Matrix[k, j] = corelation_Matrix[j, k];
                }
            }


            //対角成分は正の数
            bool minus = false;
            for (int j = 0; j < corelation_Matrix.GetLength(0); j++)
            {
                if (corelation_Matrix[j, j] < 0) { minus = true; break; }
            }
            if (minus)
            {
                for (int j = 0; j < corelation_Matrix.GetLength(0); j++)
                {
                    for (int k = 0; k < corelation_Matrix.GetLength(1); k++)
                    {
                        corelation_Matrix[j, k] *= -1;
                    }
                }
            }

            double[] std = new double[corelation_Matrix.GetLength(0)];
            for (int j=0;j<corelation_Matrix.GetLength(0);j++)
            {
                std[j] = Math.Sqrt(corelation_Matrix[j, j]);
            }
            for (int j=0;j<corelation_Matrix.GetLength(0);j++)
            {
                for (int k=0;k<corelation_Matrix.GetLength(1);k++)
                {
                    corelation_Matrix[j, k] /= std[j] * std[k];
                }
            }

            return corelation_Matrix;

        }

    }
}
