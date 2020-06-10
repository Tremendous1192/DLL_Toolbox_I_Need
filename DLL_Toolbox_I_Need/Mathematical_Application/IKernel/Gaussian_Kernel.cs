using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public class Gaussian_Kernel : IKernel
    {
        double[,] inverse_Variance_Covariance_Matrix;
        double coefficient;

        public void Set_Inverse_Variance_Covariance_Matrix(double[,] Inverse_Variance_Covariance_Matrix)
        {
            inverse_Variance_Covariance_Matrix = Inverse_Variance_Covariance_Matrix;
            coefficient = Math.Pow(2 * Math.PI, Inverse_Variance_Covariance_Matrix.GetLength(1) / 2.0);
        }

        public double Calculate(double[,] row_Vector_1, double[,] row_Vector_2)
        {
            double[,] delta_row = Matrix.Subtraction(row_Vector_1, row_Vector_2);
            double[,] delta_column = Matrix.Transposed_Matrix(delta_row);

            double[,] product = Matrix.Multiplication(delta_row, inverse_Variance_Covariance_Matrix);
            product = Matrix.Multiplication(product, delta_column);

            return Math.Exp(-product[0, 0] / 2.0) / coefficient;
        }
    }



}
