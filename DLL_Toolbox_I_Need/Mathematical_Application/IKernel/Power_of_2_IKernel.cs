﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{


    public class Power_of_2_IKernel : IKernel
    {


        bool set;
        double[,] inverse_Variance_Covariance_Matrix;
        double coefficient;

        public void Set_Variance_Covariance_Matrix(double[,] variance_Covariance_Matrix)
        {
            set = true;

            inverse_Variance_Covariance_Matrix = Matrix.Inverse_of_a_Matrix(variance_Covariance_Matrix);

            double determinant = Math.Sqrt(Math.Abs(Matrix.Determinant(variance_Covariance_Matrix)));
            coefficient = Math.Pow(2 * Math.PI, variance_Covariance_Matrix.GetLength(1) / 2.0) * determinant;
        }

        public double Calculate(double[,] row_Vector_1, double[,] row_Vector_2)
        {
            double[,] delta_row = Matrix.Subtraction(row_Vector_1, row_Vector_2);

            if (set)
            {
                double[,] delta_column = Matrix.Transposed_Matrix(delta_row);

                double[,] product = Matrix.Multiplication(delta_row, inverse_Variance_Covariance_Matrix);
                product = Matrix.Multiplication(product, delta_column);

                double norm = Math.Abs(product[0, 0]);

                if (norm <= 1) { return 1 - norm * norm; }
                else { return 0.0; }

            }
            else
            {
                double norm = Matrix.Norm_L2(delta_row);

                if (norm <= 1) { return 1 - norm * norm; }
                else { return 0.0; }
            }
        }




    }




}
