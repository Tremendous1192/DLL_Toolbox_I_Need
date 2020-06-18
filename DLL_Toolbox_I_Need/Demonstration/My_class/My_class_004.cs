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
        public void Demo_004_Random_Number_Calculation()
        {
            Console.WriteLine("今回は、乱数の計算を紹介します");
            Console.WriteLine("幹葉表示風のヒストグラムで、分布を確認します。");


            //頻度
            string count = "\t";
            for (int j = 0; j < 15; j++) { count += "        " + (j + 1) * 10; }



            Console.WriteLine("\n一様乱数を最大値299 , 最小値0で計算します。");
            Uniform_Distribution ud = new Uniform_Distribution(1);
            string[] histgram = new string[30];
            for (int j = 0; j < histgram.Length; j++)
            {
                histgram[j] = j *10+ "\t" + "|";
            }

            int integer = 0;
            for (int j = 0; j < 2500; j++)
            {
                integer = (int)(Math.Round(ud.NextDouble(299, 0)));
                histgram[integer / 10] += integer % 10;
            }
            Console.WriteLine(count);
            foreach (string s in histgram)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();


            Console.WriteLine("\nPolar法で生成した正規分布乱数を平均値150 , 標準偏差50で計算します。");
            Normal_Distribution_Polar ndp = new Normal_Distribution_Polar(1, 2);
            histgram = new string[30];
            for (int j = 0; j < histgram.Length; j++)
            {
                histgram[j] = j * 10 + "\t" + "|";
            }
            for (int j = 0; j < 1000; j++)
            {
                integer = (int)(Math.Round(ndp.NextDouble(150, 50)));
                if (integer < 0 || histgram.Length * 10 - 1 < integer) { continue; }
                else
                {
                    histgram[integer / 10] += integer % 10;
                }
            }
            Console.WriteLine(count);
            foreach (string s in histgram)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();


            Console.WriteLine("\nPolar法で生成した半正規分布乱数を標準偏差50で計算します。");
            Half_Normal_Distribution_Polar hndp = new Half_Normal_Distribution_Polar(1, 2);
            histgram = new string[30];
            for (int j = 0; j < histgram.Length; j++)
            {
                histgram[j] = j * 10 + "\t" + "|";
            }
            for (int j = 0; j < 500; j++)
            {
                integer = (int)(Math.Round(hndp.NextDouble(50)));
                if (integer < 0 || histgram.Length * 10 - 1 < integer) { continue; }
                else
                {
                    histgram[integer / 10] += integer % 10;
                }
            }
            Console.WriteLine(count);
            foreach (string s in histgram)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();


            Console.WriteLine("\nPolar法で生成した対数正規分布乱数を、正規分布の平均値150 , 標準偏差50で計算します。");
            Log_Normal_Distribution_Polar lndp = new Log_Normal_Distribution_Polar(1, 2);
            histgram = new string[30];
            for (int j = 0; j < histgram.Length; j++)
            {
                histgram[j] = j * 10 + "\t" + "|";
            }
            for (int j = 0; j < 1000*100; j++)
            {
                integer = (int)(Math.Round(lndp.NextDouble(150, 50)));
                if (integer < 0 || histgram.Length * 10 - 1 < integer) { continue; }
                else
                {
                    histgram[integer / 10] += integer % 10;
                }
            }
            Console.WriteLine(count);
            foreach (string s in histgram)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();


            Console.WriteLine("\nPolar法で生成した対数正規分布乱数を位置母数150 , 尺度母数50で計算します。");
            Cauchy_distribution_Porlar cdp = new Cauchy_distribution_Porlar(1, 2);
            histgram = new string[30];
            for (int j = 0; j < histgram.Length; j++)
            {
                histgram[j] = j * 10 + "\t" + "|";
            }
            for (int j = 0; j < 1000; j++)
            {
                integer = (int)(Math.Round(cdp.NextDouble(150, 50)));
                if (integer < 0 || histgram.Length * 10 - 1 < integer) { continue; }
                else
                {
                    histgram[integer / 10] += integer % 10;
                }
            }
            Console.WriteLine(count);
            foreach (string s in histgram)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();



        }



    }
}
