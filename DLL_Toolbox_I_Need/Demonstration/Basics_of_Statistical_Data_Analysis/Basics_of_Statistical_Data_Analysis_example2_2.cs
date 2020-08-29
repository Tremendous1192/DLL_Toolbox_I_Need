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

        public static void Example_2_2()
        {
            Basics_of_Statistical_Data_Analysis.Quote();

            Console.WriteLine("例題2.2を解きます。");
            Console.WriteLine("引用(数式は改変)\n");
            Console.Write("次のデータ(a)について,平均x_average,メジアンx_median,偏差平方和S,分散s^2,標準偏差sを計算しなさい。");
            Console.Write("次にデータ(b)から(d)のそれぞれについて,x_average,x_median,S,s^2,sを求めなさい。");
            Console.Write("その際、(b)のデータは(a)のデータに100を加えている。");
            Console.Write("(c)のデータは平均からの偏差が倍であるなどの特徴に着目して計算しなさい。\n\n");

            double[,] design_Matrix = new double[9, 4];
            design_Matrix[0, 0] = 53; design_Matrix[1, 0] = 55; design_Matrix[2, 0] = 52;
            design_Matrix[3, 0] = 57; design_Matrix[4, 0] = 51; design_Matrix[5, 0] = 56;
            design_Matrix[6, 0] = 58; design_Matrix[7, 0] = 59; design_Matrix[8, 0] = 54;

            design_Matrix[0, 1] = 153; design_Matrix[1, 1] = 155; design_Matrix[2, 1] = 152;
            design_Matrix[3, 1] = 157; design_Matrix[4, 1] = 151; design_Matrix[5, 1] = 156;
            design_Matrix[6, 1] = 158; design_Matrix[7, 1] = 159; design_Matrix[8, 1] = 154;

            design_Matrix[0, 2] = 51; design_Matrix[1, 2] = 55; design_Matrix[2, 2] = 49;
            design_Matrix[3, 2] = 59; design_Matrix[4, 2] = 47; design_Matrix[5, 2] = 57;
            design_Matrix[6, 2] = 61; design_Matrix[7, 2] = 63; design_Matrix[8, 2] = 53;

            design_Matrix[0, 3] = 53; design_Matrix[1, 3] = 55; design_Matrix[2, 3] = 52;
            design_Matrix[3, 3] = 57; design_Matrix[4, 3] = 51; design_Matrix[5, 3] = 56;
            design_Matrix[6, 3] = 58; design_Matrix[7, 3] = 149; design_Matrix[8, 3] = 54;


            Console.WriteLine("(a)\t(b)\t(c)\t(d)");
            for (int j = 0; j < design_Matrix.GetLength(0); j++)
            {
                for (int k = 0; k < design_Matrix.GetLength(1); k++)
                {
                    Console.Write(design_Matrix[j, k] + "\t");
                }
                Console.WriteLine("");
            }


            Console.WriteLine("\n\n引用終わり(数式は改変)\n");


            double[,] summary = Statistics.Summary(design_Matrix);
            Console.Write("[0,*] 最小値\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[0, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[1,*] 第一四分位数\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[1, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[2,*] 中央値\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[2, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[3,*] 平均値\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[3, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[4,*] 第三四分位数\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[4, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[5,*] 最大値\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[5, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[6,*] 偏差平方和\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[6, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[7,*] 標本分散\t\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[7, k] + "\t");
            }
            Console.WriteLine("");

            Console.Write("[8,*] 標本標準偏差\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[8, k].ToString("G3") + "\t");
            }
            Console.WriteLine("");


        }

    }
}
