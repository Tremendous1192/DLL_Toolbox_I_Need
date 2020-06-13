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
        /// Lerning Liner_Regression .
        /// Return w ( Colmun Vector )
        /// </summary>
        /// <param name="design_Matrix_with_constant_1"></param>
        /// <param name="target_y"></param>
        /// <returns></returns>
        public static double[,] Learning_parameter_w_column_vector(double[,] design_Matrix_with_constant_1, double[,] target_y)
        {
            if (design_Matrix_with_constant_1.GetLength(0) - target_y.GetLength(0) != 0)
            {
                throw new FormatException(nameof(design_Matrix_with_constant_1) + "の行" + design_Matrix_with_constant_1.GetLength(0) + "と、" + nameof(target_y) + "の行" + target_y.GetLength(0) + "が異なります。");
            }

            double[,] X_T = Matrix.Transposed_Matrix(design_Matrix_with_constant_1);
            double[,] X_T_cross_X = Matrix.Multiplication(X_T, design_Matrix_with_constant_1);


            double alpha = 1.0;
            foreach (double d in design_Matrix_with_constant_1) { alpha = Math.Min(alpha, Math.Abs(d)); }
            alpha /= 1000.0;
            alpha /= 1000.0;
            double[,] I = new double[X_T_cross_X.GetLength(0), X_T_cross_X.GetLength(0)];
            for (int j = 0; j < X_T_cross_X.GetLength(0); j++) { I[j, j] = alpha; }
            double[,] X_T_cross_X_add_I = Matrix.Addition(X_T_cross_X, I);

            double[,] X_T_cross_X_Inverse = Matrix.Inverse_of_a_Matrix(X_T_cross_X_add_I);

            double[,] w = Matrix.Multiplication(X_T_cross_X_Inverse, X_T);
            w = Matrix.Multiplication(w, target_y);

            return w;
        }


    }
}
