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


        public static void Example_2_3()
        {
            Basics_of_Statistical_Data_Analysis.Quote();

            Console.WriteLine("例題2.3を解きます。");
            Console.WriteLine("引用(は例題に関係するNo.1から16のみ記載)\n");
            Console.Write("表2.2のうち,No.1から16のデータについて,メジアン,第1四分位数点,第3四分位数点を求めなさい.");
            Console.Write("\n\n");

            double[,] design_Matrix = new double[16, 1];
            design_Matrix[0, 0] = 565; design_Matrix[1, 0] = 685; design_Matrix[2, 0] = 714;
            design_Matrix[3, 0] = 743; design_Matrix[4, 0] = 779; design_Matrix[5, 0] = 823;
            design_Matrix[6, 0] = 824; design_Matrix[7, 0] = 945; design_Matrix[8, 0] = 967;

            design_Matrix[9, 0] = 996; design_Matrix[10, 0] = 1056; design_Matrix[11, 0] = 1089;
            design_Matrix[12, 0] = 1102; design_Matrix[13, 0] = 1147; design_Matrix[14, 0] = 1152;
            design_Matrix[15, 0] = 1255;

            for (int j = 0; j < design_Matrix.GetLength(0); j++)
            {
                for (int k = 0; k < design_Matrix.GetLength(1); k++)
                {
                    Console.Write(design_Matrix[j, k] + "\t");
                }
                Console.WriteLine("");
            }


            Console.WriteLine("\n\n引用終わり\n");


            double[,] summary = Statistics.Summary(design_Matrix);

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


            Console.Write("[4,*] 第三四分位数\t");
            for (int k = 0; k < summary.GetLength(1); k++)
            {
                Console.Write(summary[4, k] + "\t");
            }
            Console.WriteLine("");


        }




    }
}
