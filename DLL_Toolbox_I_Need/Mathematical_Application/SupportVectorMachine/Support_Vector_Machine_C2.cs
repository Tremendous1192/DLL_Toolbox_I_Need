using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Support_Vector_Machine
    {

        /// <summary>
        /// 計画行列の識別を行う
        /// </summary>
        /// <param name="Label_Y"></param>
        /// <param name="design_Matrix_without_constant"></param>
        /// <param name="iKernel"></param>
        /// <param name="variance_Covariance_Matrix"></param>
        /// <param name="Coefficient_A"></param>
        /// <param name="design_Matrix_for_Classification"></param>
        /// <returns></returns>
        public static double[,] Classification_Design_Matrix(double[,] Label_Y, double[,] design_Matrix_without_constant, IKernel iKernel, double[,] variance_Covariance_Matrix, double[,] Coefficient_A, double[,] design_Matrix_for_Classification)
        {
            double[,] classified = new double[design_Matrix_for_Classification.GetLength(0), 1];

            //カーネルのセット
            iKernel.Set_Variance_Covariance_Matrix(variance_Covariance_Matrix);


            //カーネル用の行列
            double[,] Kernel_Matrix = new double[design_Matrix_without_constant.GetLength(0), 1];

            //識別したい計画行列を1行ずつ計算する
            double[,] row_vector;
            for (int n = 0; n < classified.GetLength(0); n++)
            {
                row_vector = Matrix.Pick_Up_Row_Vector(design_Matrix_for_Classification, n);
                //カーネルを計算する
                double[,] r_j = new double[1, 1];
                for (int j = 0; j < design_Matrix_without_constant.GetLength(0); j++)
                {
                    r_j = Matrix.Pick_Up_Row_Vector(design_Matrix_without_constant, j);
                    Kernel_Matrix[j, 0] = iKernel.Calculate(row_vector, r_j);
                }

                //予測値の計算
                //予測値の符号 = Σ( for j ) 教師ラベル[Y]j * 係数[A]j * カーネル K( x , [X]j )
                double[,] Hadamard = Matrix.Hadamard_product(Label_Y, Coefficient_A);
                Hadamard = Matrix.Hadamard_product(Hadamard, Kernel_Matrix);


                //Σ( for j )
                double sum = 0;
                foreach (double h in Hadamard)
                {
                    sum += h;
                }

                classified[n, 0] = sum;
            }



            return classified;
        }

    }

}
