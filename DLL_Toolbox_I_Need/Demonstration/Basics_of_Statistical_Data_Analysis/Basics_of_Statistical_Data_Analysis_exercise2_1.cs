using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//計算用パッケージの名前空間
using DLL_Toolbox_I_Need.Mathematical_Application;


namespace DLL_Toolbox_I_Need.Demonstration
{
    public partial class Basics_of_Statistical_Data_Analysis
    {

        public static void Exercise_2_1()
        {
            Basics_of_Statistical_Data_Analysis.Quote();

            Console.Write("第2章 単一変数データの記述統計量と視覚的表現");
            Console.WriteLine("演習問題1を解きます。");
            Console.WriteLine("引用(数式は改変)\n");

            Console.Write("本問は,データ変換後に統計量を計算すると,計算が容易になる例を示している.");
            Console.Write("5人の高校生の50m走のタイムx1 , ・・・ , x5 (秒) を6.7 , 6.1 , 7.5 , 7.1 , 6.3 とする.\n\n");

            double[,] design_Matrix_x = new double[5, 1];
            design_Matrix_x[0, 0] = 6.7; design_Matrix_x[1, 0] = 6.1; design_Matrix_x[2, 0] = 7.5;
            design_Matrix_x[3, 0] = 7.1; design_Matrix_x[4, 0] = 6.3;

            Console.WriteLine("(a) 5人の高タイムから6を引いて10倍した数値y1 , ・・・ , y5を求めなさい。");
            double[,] design_Matrix_y = new double[5, 1];
            for (int j = 0; j < design_Matrix_x.GetLength(0); j++)
            {
                design_Matrix_y[j, 0] = Math.Round(10 * (design_Matrix_x[j, 0] - 6));
                Console.WriteLine("y" + (j + 1) + "\t" + design_Matrix_y[j, 0]);
            }
            Console.WriteLine("");

            Console.WriteLine("(b) 上記の5つの数値について,平均,平方和,分散,標準偏差を求めなさい.");
            double[,] summary = Statistics.Summary(design_Matrix_y);

            Console.Write("[3,*] 平均値\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[3, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[6,*] 偏差平方和\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[6, k].ToString("G3") + "\t");
            }
            Console.WriteLine("");

            Console.Write("[7,*] 標本分散\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[7, k].ToString("G3") + "\t");
            }
            Console.WriteLine("");

            Console.Write("[8,*] 標本標準偏差\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[8, k].ToString("G3") + "\t");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("(c) 上記の結果を利用して,この5人の50m走のタイムの平均,平方和,分散,標準偏差を求めなさい.");
            Console.WriteLine("y = 10 ( x - 6 )=10x -60");
            Console.WriteLine("x = y/10 + 6");
            Console.WriteLine("");

            Console.WriteLine("したがって、 E[x] = E[y/10 + 6] = E[y]/10 + 6");
            Console.Write("[3,*] 平均値\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[3, k] / 10 + 6 + "\t");
            }
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("同様に、 S[x] = S[y/10 + 6] = S[y/10] = S[y]/10^2");
            Console.Write("[6,*] 偏差平方和\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write((summary[6, k]/100 ).ToString("G3") + "\t");
            }
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("s2[x] = s2[y/10 + 6] = s2[y/10] = s2[y]/10^2");
            Console.Write("[7,*] 標本分散\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write((summary[7, k]/100).ToString("G3") + "\t");
            }
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("s[x] = s[y/10 + 6] = s[y/10] = s[y]/10");
            Console.Write("[8,*] 標本標準偏差\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write((summary[8, k] / 10).ToString("G3") + "\t");
            }
            Console.WriteLine("");

        }



    }
}
