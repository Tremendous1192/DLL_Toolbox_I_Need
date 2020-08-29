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
        public static void Example_2_1()
        {
            Basics_of_Statistical_Data_Analysis.Quote();

            Console.WriteLine("例題2.1を解きます。");
            Console.WriteLine("引用(数式は改変)\n");
            Console.Write("下記は,2015年度の都道府県別栽培きのこ類生産量(単位千円)である。");
            Console.Write("このデータについて、平均x_average,メジアンx_medianを計算しなさい。\n");

            string[,] Label = new string[7, 1];
            Label[0, 0] = "大阪\t";
            Label[1, 0] = "佐賀\t";
            Label[2, 0] = "山口\t";
            Label[3, 0] = "東京\t";
            Label[4, 0] = "山梨\t";
            Label[5, 0] = "神奈川\t";
            Label[6, 0] = "長野\t";
            for (int j=0;j<Label.GetLength(0);j++) { Console.Write(Label[j, 0] + "\t"); }
            Console.Write("\n");

            double[,] design_Matrix = new double[7, 1];
            design_Matrix[0, 0] = 14;
            design_Matrix[1, 0] = 21;
            design_Matrix[2, 0] = 22;
            design_Matrix[3, 0] = 23;
            design_Matrix[4, 0] = 25;
            design_Matrix[5, 0] = 39;
            design_Matrix[6, 0] = 4955;
            for (int j = 0; j < design_Matrix.GetLength(0); j++) { Console.Write(design_Matrix[j, 0] + "\t\t"); }
            Console.Write("\n");

            Console.WriteLine("\n引用終わり(数式は改変)\n");

            double[,] summary = Statistics.Summary(design_Matrix);
            Console.WriteLine("[0,*] 最小値\t\t" + summary[0, 0]);
            Console.WriteLine("[1,*] 第一四分位数\t" + summary[1, 0]);
            Console.WriteLine("[2,*] 中央値\t\t" + summary[2, 0]);
            Console.WriteLine("[3,*] 平均値\t\t" + summary[3, 0]);
            Console.WriteLine("[4,*] 第三四分位数\t" + summary[4, 0]);
            Console.WriteLine("[5,*] 最大値\t\t" + summary[5, 0]);


        }



    }
}
