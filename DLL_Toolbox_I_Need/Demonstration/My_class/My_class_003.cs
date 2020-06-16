using DLL_Toolbox_I_Need.Mathematical_Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;


namespace DLL_Toolbox_I_Need.Demonstration
{
    public partial class My_class
    {
        public void Demo_003_Design_Matrix_calculation()
        {
            Console.WriteLine("今回は、少し進んだ行列の計算を紹介します");

            Console.WriteLine("\nまず、計算に使用する計画行列を表示します");

            Uniform_Distribution ud = new Uniform_Distribution(1);

            Console.WriteLine("\n計画行列A");
            double[,] matrix_A = new double[6, 2];
            for (int j = 0; j < matrix_A.GetLength(0); j++)
            {
                for (int k = 0; k < matrix_A.GetLength(1); k++)
                {
                    matrix_A[j, k] = Math.Round(100.0 * (2 * j + 3.0 * k + 1 + ud.NextDouble(2, -2))) / 100.0;
                }
            }
            this.Show_Matrix_Element(matrix_A);
            Console.ReadKey();

            Console.WriteLine("\n計画行列Aの平均ベクトルμ^T");
            double[,] result = Design_Matrix.Average(matrix_A);
            this.Show_Matrix_Element(result);
            Console.ReadKey();

            Console.WriteLine("\n計画行列Aの第3行の行ベクトルを得る");
            result = Design_Matrix.Pick_Up_Row_Vector(matrix_A, 3);
            this.Show_Matrix_Element(result);
            Console.ReadKey();

            Console.WriteLine("\n計画行列Aの各行ベクトルのL2ノルムを得る");
            result = Design_Matrix.Norm_L2_Array(matrix_A);
            this.Show_Matrix_Element(result);
            Console.ReadKey();

            Console.WriteLine("\n計画行列Aの行ベクトルの中で、L2ノルムの最大値を得る");
            double scalar = Design_Matrix.Maximum_Norm_L2(matrix_A);
            Console.WriteLine(scalar);

            Console.WriteLine("\n計画行列Aの行ベクトルの中で、L2ノルム最大の行番号を得る");
            int integer = Design_Matrix.Maximum_Norm_L2_Index(matrix_A);
            Console.WriteLine(integer);
            Console.ReadKey();

            Console.WriteLine("\n計画行列Aの行ベクトルの中で、L2ノルムの最小値値を得る");
            scalar = Design_Matrix.Minimum_Norm_L2(matrix_A);
            Console.WriteLine(scalar);

            Console.WriteLine("\n計画行列Aの行ベクトルの中で、L2ノルム最小の行番号を得る");
            integer = Design_Matrix.Minimum_Norm_L2_Index(matrix_A);
            Console.WriteLine(integer);
            Console.ReadKey();


            Console.WriteLine("\n計画行列Aの標準偏差");
            result = Design_Matrix.Standard_Deviation(matrix_A);
            this.Show_Matrix_Element(result);

            Console.WriteLine("\n計画行列Aの分散・共分散行列");
            result = Design_Matrix.Variance_Covariance_Matrix(matrix_A);
            this.Show_Matrix_Element(result);

            Console.WriteLine("\n計画行列Aの分散・共分散行列の逆行列");
            result = Design_Matrix.Inverse_Variance_Covariance_Matrix(matrix_A);
            this.Show_Matrix_Element(result);

            Console.WriteLine("\n計画行列Aの分散・共分散行列と、逆行列の積が単位行列になることを確認する。");
            result = Matrix.Multiplication(Design_Matrix.Variance_Covariance_Matrix(matrix_A), Design_Matrix.Inverse_Variance_Covariance_Matrix(matrix_A));
            this.Show_Matrix_Element(result);
            Console.ReadKey();


            Console.WriteLine("\n計画行列Aの相関係数の行列を得る");
            result = Design_Matrix.Corelation_Matrix(matrix_A);
            this.Show_Matrix_Element(result);
            Console.ReadKey();



            double[,] result2 = new double[1, 2];
            Console.WriteLine("\n計画行列を3分割して、第0グループをテストデータにする。残りは訓練データにする");
            Design_Matrix.Prepare_k_fold_cross_validation(matrix_A, 3, 0, ref result, ref result2);
            Console.WriteLine("\nテストデータ");
            this.Show_Matrix_Element(result);
            Console.WriteLine("\n訓練データ");
            this.Show_Matrix_Element(result2);
            Console.ReadKey();

            Console.WriteLine("\n計画行列Aを6分割して、第1行をテストデータにする。残りは訓練データにする");
            Design_Matrix.Prepare_Leave_one_out_cross_validation(matrix_A, 1, ref result, ref result2);
            Console.WriteLine("\nテストデータ");
            this.Show_Matrix_Element(result);
            Console.WriteLine("\n訓練データ");
            this.Show_Matrix_Element(result2);
            Console.ReadKey();


        }

    }
}
