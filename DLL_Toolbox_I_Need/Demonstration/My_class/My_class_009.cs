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
        public void Demo_009_Support_Vector_Machine()
        {


            Console.WriteLine("Support Vector Machineのデモンストレーションです");
            Console.WriteLine("データ数が少ない場合、ニューラルネットワークよりも有利です。\n\n");

            //教師データを設定します。
            //SVMは計画行列を使用します。
            //入力値が1次元データの場合、計画行列は列ベクトルになります
            double[,] X = new double[6,1];
            double[,] t_vec= new double[6, 1];
            Console.WriteLine("\t" + "入力x\t" + "教師t");
            for (int j = 0; j < 6; j++)
            {
                X[j, 0] = j;
                if (j < 2 || 3 < j)
                {
                    t_vec[j, 0] = -1;
                }
                else
                {
                    t_vec[j, 0] = 1;
                }
                Console.WriteLine("\t" + X[j, 0] + "\t" + t_vec[j, 0] + "");
            }

            double[,] variance_covariance = Design_Matrix.Variance_Covariance_Matrix(X);
            Console.WriteLine("\n\n");


            //係数Aを学習する
            double[,] Coefficient_A = Support_Vector_Machine.Learned_Coefficient_A(t_vec, X, new Power_of_10_IKernel(), variance_covariance);


            //データを学習する
            //ニューラルネットワークよりプログラムの行数は短いです。
            double[,] classified = Support_Vector_Machine.Classification_Design_Matrix(t_vec, X, new Power_of_10_IKernel(), variance_covariance, Coefficient_A, X);

            Console.WriteLine("学習結果を表示します。");
            Console.WriteLine("教師データtが1の場合は分類の値も1で、tが-1の場合分類の値はマイナスです");
            Console.WriteLine("ニューラルネットワークに比べて精度よく分類できていると言えます。");
            Console.WriteLine("\t" + "入力x\t" + "教師t\t"+"分類y");
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine("\t" + X[j, 0] + "\t" + t_vec[j, 0] + "\t" + classified[j, 0].ToString("G2"));
            }


        }


    }
}
