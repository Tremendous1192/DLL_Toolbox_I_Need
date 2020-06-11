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
        /// 行ベクトルの識別を行う .
        /// Perform row vector identification .
        /// </summary>
        /// <param name="Label_Y"></param>
        /// <param name="design_Matrix_without_constant"></param>
        /// <param name="iKernel"></param>
        /// <param name="Inverse_Variance_Covariance_Matrix"></param>
        /// <param name="Coefficient_A"></param>
        /// <param name="row_vector"></param>
        /// <returns></returns>
        public static double Classification(double[,] Label_Y, double[,] design_Matrix_without_constant, IKernel iKernel, double[,] Inverse_Variance_Covariance_Matrix, double[,] Coefficient_A, double[,] row_vector)
        {

            if (row_vector.GetLength(0) > 1)
            {
                throw new FormatException(nameof(row_vector) + "(" + row_vector.GetLength(0) + ")" + " must be 1 .");
            }

            //カーネルのセット
            iKernel.Set_Inverse_Variance_Covariance_Matrix(Inverse_Variance_Covariance_Matrix);


            //カーネル用の行列
            double[,] Kernel_Matrix = new double[design_Matrix_without_constant.GetLength(0), 1];

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

            return sum;
        }
    }


}
