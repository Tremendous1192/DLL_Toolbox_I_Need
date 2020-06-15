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
        public void Demo_002_Matrix_advance_calculation()
        {
            Console.WriteLine("今回は、少し進んだ行列の計算を紹介します");

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
            double[,] matrix_B = new double[2, 2];
            matrix_B[0, 0] = 2;
            matrix_B[1, 1] = 2;
            this.Show_Matrix_Element(matrix_B);


            Console.ReadKey();


            Console.WriteLine("\n行列の、各要素の絶対値の和を得ます。");
            double scalar = Matrix.Norm_L1(matrix_A);
            Console.WriteLine(scalar);
            Console.ReadKey();

            Console.WriteLine("\n行列の、各要素の二乗和の平方根を得ます。");
            scalar = Matrix.Norm_L2(matrix_A);
            Console.WriteLine(scalar);
            Console.ReadKey();

            Console.WriteLine("\n行列の、各要素の絶対値の最大値を得ます。");
            scalar = Matrix.Norm_Infinity(matrix_A);
            Console.WriteLine(scalar);
            Console.ReadKey();

            Console.WriteLine("\n行列Aの第0行を取り出して、行ベクトルを得ます");
            double[,] result = Matrix.Pick_Up_Row_Vector(matrix_A, 0);
            this.Show_Matrix_Element(result);
            Console.ReadKey();

            Console.WriteLine("\n行列Aの第0列を取り出して、列ベクトルを得ます");
            result = Matrix.Pick_Up_Column_Vector(matrix_A, 0);
            this.Show_Matrix_Element(result);
            Console.ReadKey();

            Console.WriteLine("\n行列Aの第1行から1行、第0列から2列を取り出して、部分行列を得ます");
            result = Matrix.SubMatrix(matrix_A, 1, 1, 0, 2);
            this.Show_Matrix_Element(result);
            Console.ReadKey();

            Console.WriteLine("\n正方行列の跡を得ます。");
            scalar = Matrix.Trace(matrix_B);
            Console.WriteLine(scalar);
            Console.ReadKey();

            Console.WriteLine("\n正方行列の行列式を得ます。");
            scalar = Matrix.Determinant(matrix_B);
            Console.WriteLine(scalar);
            Console.ReadKey();

            Console.WriteLine("\n正方行列の逆行列を得ます。");
            result = Matrix.Inverse_of_a_Matrix(matrix_B);
            this.Show_Matrix_Element(result);
            Console.ReadKey();

            Console.WriteLine("\n逆行列と、元の行列の積は単位行列になることを確認します。");
            result = Matrix.Multiplication(matrix_B, Matrix.Inverse_of_a_Matrix(matrix_B));
            this.Show_Matrix_Element(result);
            Console.ReadKey();


        }
    }
}
