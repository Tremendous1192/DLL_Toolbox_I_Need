using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DLL_Toolbox_I_Need.Mathematical_Application;

namespace DLL_Toolbox_I_Need.Demonstration
{
    public partial class My_class
    {
        public void Demo_001_Matrix_basic_calculation()
        {
            Console.WriteLine("今回は、行列の基本計算を紹介します");

            Console.WriteLine("\nまず、計算に使用する行列を表示します");

            Console.WriteLine("\n行列A");
            double[,] matrix_A = new double[2, 3];
            for (int j = 0; j < matrix_A.GetLength(0); j++)
            {
                for (int k = 0; k < matrix_A.GetLength(1); k++)
                {
                    matrix_A[j, k] = j + k + 1;
                }
            }
            this.Show_Matrix_Element(matrix_A);


            Console.WriteLine("\n行列 B");
            double[,] matrix_B = new double[2, 3];
            for (int j = 0; j < matrix_B.GetLength(0); j++)
            {
                for (int k = 0; k < matrix_B.GetLength(1); k++)
                {
                    matrix_B[j, k] = 2 * j + k;
                }
            }
            this.Show_Matrix_Element(matrix_B);


            Console.WriteLine("\n行列 C");
            double[,] matrix_C = new double[3, 1];
            for (int j = 0; j < matrix_C.GetLength(0); j++)
            {
                for (int k = 0; k < matrix_C.GetLength(1); k++)
                {
                    matrix_C[j, k] = 1 + j * 2;
                }
            }
            this.Show_Matrix_Element(matrix_C);

            Console.ReadKey();


            //Matrix_A.cs
            Console.WriteLine("\n\n行列の足し算を行います");
            Console.WriteLine("A + B");
            double[,] result = Matrix.Addition(matrix_A, matrix_B);
            for (int j = 0; j < result.GetLength(0); j++)
            {
                for (int k = 0; k < result.GetLength(1); k++)
                {
                    Console.Write(result[j, k] + " ");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();


            //Matrix_S.cs
            Console.WriteLine("\n\n行列の引き算を行います");
            Console.WriteLine("A - B");
            result = Matrix.Subtraction(matrix_A, matrix_B);
            for (int j = 0; j < result.GetLength(0); j++)
            {
                for (int k = 0; k < result.GetLength(1); k++)
                {
                    Console.Write(result[j, k] + " ");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();


            //Matrix_S.cs
            Console.WriteLine("\n\n行列のスカラー積を行います");
            Console.WriteLine("3A");
            result = Matrix.Scalar_Multiplication(matrix_A, 3.0);
            for (int j = 0; j < result.GetLength(0); j++)
            {
                for (int k = 0; k < result.GetLength(1); k++)
                {
                    Console.Write(result[j, k] + " ");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();


            //Matrix_H.cs
            Console.WriteLine("\n\n行列のアダマール積を行います");
            Console.WriteLine("A ○ B");
            result = Matrix.Hadamard_product(matrix_A, matrix_B);
            this.Show_Matrix_Element(result);
            Console.ReadKey();


            Console.WriteLine("\n\n行列A");
            this.Show_Matrix_Element(matrix_A);

            Console.WriteLine("\n行列 C");
            this.Show_Matrix_Element(matrix_C);

            //Matrix_M.cs
            Console.WriteLine("\n\n行列の掛け算を行います");
            Console.WriteLine("AC");
            result = Matrix.Multiplication(matrix_A, matrix_C);
            this.Show_Matrix_Element(result);
            Console.ReadKey();


            //Matrix_R.cs
            Console.WriteLine("\n\n行列の各要素を逆数にします");
            Console.WriteLine("1/A");
            result = Matrix.Reciprocal_Number_Matrix(matrix_A);
            this.Show_Matrix_Element(result);
            Console.ReadKey();


            //Matrix_T.cs
            Console.WriteLine("\n\n転置行列を得ます");
            Console.WriteLine("A^T");
            result = Matrix.Transposed_Matrix(matrix_A);
            this.Show_Matrix_Element(result);
            Console.ReadKey();


            //Matrix_Z.cs
            Console.WriteLine("\n\n行列Aと同じ要素数の零行列を得ます");
            result = Matrix.Zero_Matrix(matrix_A);
            this.Show_Matrix_Element(result);
            Console.ReadKey();


        }


        private void Show_Matrix_Element(double[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[j, k] + " ");
                }
                Console.WriteLine("");
            }
        }

    }
}
