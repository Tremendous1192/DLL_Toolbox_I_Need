using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Liner_Regression
    {


        /// <summary>
        /// 線形回帰 X_T × w ( w : Colmun_Vector )
        /// </summary>
        /// <param name="row_vector_or_design_matrix_with_constant_1"></param>
        /// <param name="column_Vector_coefficient_w"></param>
        /// <returns></returns>
        public static double[,] Regression_Design_Matrix(double[,] row_vector_or_design_matrix_with_constant_1, double[,] column_Vector_coefficient_w)
        {
            return Matrix.Multiplication(row_vector_or_design_matrix_with_constant_1, column_Vector_coefficient_w);
        }




        /// <summary>
        /// Ridge回帰のパラメータ学習
        /// </summary>
        /// <param name="design_matrix_with_constant_1"></param>
        /// <param name="target_y"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static double[,] Ridge_Learning_parameter_w_column_vector(double[,] design_matrix_with_constant_1, double[,] target_y,double alpha)
        {
            if (design_matrix_with_constant_1.GetLength(0) - target_y.GetLength(0) != 0)
            {
                throw new FormatException(nameof(design_matrix_with_constant_1) + "の行" + design_matrix_with_constant_1.GetLength(0) + "と、" + nameof(target_y) + "の行" + target_y.GetLength(0) + "が異なります。");
            }

            double[,] X_T = Matrix.Transposed_Matrix(design_matrix_with_constant_1);
            double[,] X_T_cross_X = Matrix.Multiplication(X_T, design_matrix_with_constant_1);

            double hyper_parameter= Math.Abs(alpha);

            double[,] I = new double[X_T_cross_X.GetLength(0), X_T_cross_X.GetLength(0)];
            for (int j = 0; j < X_T_cross_X.GetLength(0); j++) { I[j, j] = hyper_parameter; }
            double[,] X_T_cross_X_add_I = Matrix.Addition(X_T_cross_X, I);

            double[,] X_T_cross_X_Inverse = Matrix.Inverse_of_a_Matrix(X_T_cross_X_add_I);

            double[,] w = Matrix.Multiplication(X_T_cross_X_Inverse, X_T);
            w = Matrix.Multiplication(w, target_y);

            return w;
        }


    }
}
