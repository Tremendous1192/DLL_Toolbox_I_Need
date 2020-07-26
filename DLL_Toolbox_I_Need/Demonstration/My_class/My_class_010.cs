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

        public void Demo_010_Liner_Regression()
        {

            Console.WriteLine("線形回帰のデモンストレーションです");
            Console.WriteLine("y = ax + bはとても素朴ですが、工夫するとニューラルネットワークに匹敵する性能を得られます。\n\n");

            Console.WriteLine("今回の入力と答えの関係は下記のとおりです。");
            double[,] X = new double[6, 1];
            double[,] t_vec = new double[6, 1];
            Console.WriteLine("\t" + "教師t\t" + "入力x");
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
                Console.WriteLine("\t" + t_vec[j, 0] + "\t" + X[j, 0]);
            }

            Console.WriteLine("\n\n"+"今回の例は明らかに y = ax + b では解けないです。");
            Console.WriteLine("そこで、入力xの代わりに、ベクトルφ(x)^Tを計画行列とします。");
            Console.WriteLine("ベクトルφ(x)^T = ( exp(-(x-0.5)^2/2 )/√2π , exp(-(x-2.5)^2/2 )/√2π , exp(-(x-4.5)^2/2 )/√2π )");
            double[,] phi_X = new double[6, 3];
            Console.WriteLine("\t" + "教師t" + "\t" + "exp(-(x-0.5)^2/2 )/√2π" + "\t" + "exp(-(x-2.5)^2/2 )/√2π" + "\t" + "exp(-(x-4.5)^2/2 )/√2π");
            for (int j = 0; j < 6; j++)
            {
                phi_X[j, 0] = Math.Exp(-(X[j, 0] - 0.5) * (X[j, 0] - 0.5) / 2.0) / Math.Sqrt(2 * Math.PI);
                phi_X[j, 1] = Math.Exp(-(X[j, 0] - 1.5) * (X[j, 0] - 2.5) / 2.0) / Math.Sqrt(2 * Math.PI);
                phi_X[j, 2] = Math.Exp(-(X[j, 0] - 2.5) * (X[j, 0] - 4.5) / 2.0) / Math.Sqrt(2 * Math.PI);
                Console.WriteLine("\t" + t_vec[j, 0] + "\t" + phi_X[j, 0].ToString("G2") + "\t\t\t\t" + phi_X[j, 1].ToString("G2") + "\t\t\t\t" + phi_X[j, 2].ToString("G2"));
            }
            Console.WriteLine("\n\n");


            Console.WriteLine("学習結果を表示します。");
            Console.WriteLine("ニューラルネットワークに比べて精度よく推定できていると言えます。");
            double[,] w = Liner_Regression.Learning_parameter_w_column_vector(phi_X, t_vec);
            double[,] y = Liner_Regression.Regression_Design_Matrix(phi_X, w);
            Console.WriteLine("\t" + "教師t\t" + "予想y");
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine("\t" + t_vec[j, 0] + "\t" + y[j, 0].ToString("G2"));
            }






        }

    }
}
