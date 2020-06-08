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
        /// 共分散行列を計算する。
        /// Calculate the covariance matrix.
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Variance_Covariance_Matrix(double[,] design_Matrix)
        {

            double[,] average = Design_Matrix.Average(design_Matrix);

            double[,] variance_Covariance_Matrix
                = new double[design_Matrix.GetLength(1), design_Matrix.GetLength(1)];

            double[,] row_Vector = new double[1, design_Matrix.GetLength(1)];

            double squar = 0;

            for (int i = 0; i < design_Matrix.GetLength(0); i++)
            {
                //i行目のベクトルと平均値ベクトルとの差分ベクトルを求め、j列目とk列目との積を、共分散行列の要素[j,k]に加える。
                for (int j = 0; j < row_Vector.GetLength(1); j++) 
                {
                    row_Vector[0, j] = design_Matrix[i, j] - average[0, j];
                }
                //row_Vector = Matrix.Subtraction(Matrix.Pick_Up_Row_Vector(design_Matrix, i), average);

                for (int j = 0; j < row_Vector.GetLength(1); j++)
                {
                    for (int k = j; k < row_Vector.GetLength(1); k++)
                    {
                        squar = row_Vector[0, j] * row_Vector[0, k];
                        variance_Covariance_Matrix[j, k] += squar;
                        if (j != k)
                        {
                            variance_Covariance_Matrix[k, j] += squar;
                        }
                    }
                }
            }

            //ベクトルの数で割る
            for (int j = 0; j < variance_Covariance_Matrix.GetLength(0); j++)
            {
                for (int k = 0; k < variance_Covariance_Matrix.GetLength(1); k++)
                {
                    variance_Covariance_Matrix[j, k] /= design_Matrix.GetLength(0);
                }
            }


            return variance_Covariance_Matrix;
        }



    }
}
