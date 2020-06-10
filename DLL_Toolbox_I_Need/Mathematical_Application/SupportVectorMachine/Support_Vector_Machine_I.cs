using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Support_Vector_Machine
    {
        public static double[,] Inference(double[,] Label_Y, double[,] design_Matrix, IKernel iKernel, double[,] Inverse_Variance_Covariance_Matrix, double[,] Coefficient_A, double[,] design_Matrix_for_Inference)
        {
            double[,] inference = new double[design_Matrix_for_Inference.GetLength(0), 1];

            //カーネルのセット
            iKernel.Set_Inverse_Variance_Covariance_Matrix(Inverse_Variance_Covariance_Matrix);


            //カーネル用の行列
            double[,] Kernel_Matrix = new double[design_Matrix.GetLength(0), 1];

            //識別したい計画行列を1行ずつ計算する
            double[,] row_vector;
            for (int n = 0; n < inference.GetLength(0); n++)
            {
                row_vector = Matrix.Pick_Up_Row_Vector(design_Matrix_for_Inference, n);
                //カーネルを計算する
                double[,] r_j = new double[1, 1];
                for (int j = 0; j < design_Matrix.GetLength(0); j++)
                {
                    r_j = Matrix.Pick_Up_Row_Vector(design_Matrix, j);
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

                inference[n, 0] = sum;
            }



            return inference;
        }

    }

}
