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

        public void Demo_006_Neural_Network_2()
        {
            Console.WriteLine("Neural Networkのデモンストレーションです");
            Console.WriteLine("前回は入力が1次元で、教師データが0と1でした。");
            Console.WriteLine("今回は教師データを-1と1にした場合、どの程度学習に影響を及ぼすかを調べます。");


            //教師データを設定します。
            //簡単のためf(x)の一次元とします。
            List<double[,]> list_x = new List<double[,]>();
            List<double[,]> list_t = new List<double[,]>();
            for (int j = 0; j < 4; j++)
            {
                double[,] x = new double[1, 1];
                x[0, 0] = j * 1.0;
                list_x.Add(x);

                double[,] t = new double[1, 1];
                if (j > 1) { t[0, 0] = 1; }
                else { t[0, 0] = -1; }
                list_t.Add(t);
            }

            Console.WriteLine("今回の入力値xと、答えtです");
            Console.WriteLine("x > 1 のとき、答えが1になります。それ以外の場合、-1になります。");
            Console.Write("x\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine("\t");
            Console.Write("t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n");


            Console.WriteLine("計数行列Wとバイアスベクトルbを設定します。");
            Console.WriteLine("今回のNeural Networkの層は1層とします。");
            double[,] W = new double[1, 1];
            W[0, 0] = 3;
            double[,] b = new double[1, 1];
            b[0, 0] = 2;
            Console.WriteLine("W[0,0] = " + W[0, 0] + "\t" + "b[0,0] = " + b[0, 0] + "\n\n");


            Console.WriteLine("Neural Netoworkを設定しました。負の数を出力するため、活性化関数はHyperbolic_Tangent関数とします");
            Console.WriteLine("ハイパーパラメータの値は0.01とします。\n");
            Regression_Final_Layer rfl = new Regression_Final_Layer();
            rfl.Preset_1_4th_Set_w(W);
            rfl.Preset_2_4th_Set_b(b);
            rfl.Preset_3_4th_Set_Hyper_Parameter(0.01, 0, 0, 0);
            rfl.Preset_4_4th_Set_activation_Function(new Hyperbolic_Tangent_IFunction());


            Console.WriteLine("学習前のNeural Networkの出力を確認します。");
            Console.WriteLine("f(wx + b)とtの値が近ければ、良い近似であると言えます");
            List<double[,]> list_wx_plus_b = new List<double[,]>();
            List<double[,]> list_f_wx_plus_b = new List<double[,]>();
            List<double[,]> list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("1 Step 学習しました。予測精度がどの程度変わったのかを確認しましょう");
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("10 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 9; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("100 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 90; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("1,000 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 900; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("5,000 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 4000; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("10,000 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 5000; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("20,000 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 10000; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("50,000 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 30000; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("100,000 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 50000; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("1,000,000 Step 学習しました。");
            for (int j = 0; j < list_x.Count * 900000; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                rfl.Step_3_3rd_Update();
            }
            list_wx_plus_b = new List<double[,]>();
            list_f_wx_plus_b = new List<double[,]>();
            list_delta = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                rfl.Step_1_3rd_Forward_Propagation(list_x[j]);
                list_wx_plus_b.Add(rfl.Get_wx_plus_b());
                list_f_wx_plus_b.Add(rfl.Get_f_wx_plus_b());
                rfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j]);
                list_delta.Add(rfl.Get_delta());
            }
            Console.WriteLine("W " + rfl.Get_w()[0, 0] + "\t" + "b " + rfl.Get_b()[0, 0]);
            Console.Write("x\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("wx + b\t\t");
            foreach (double[,] x in list_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("f(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("delta\t\t");
            foreach (double[,] t in list_delta) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("教師データを-1と1にしたとたん、学習効率が格段に落ちました");
            Console.WriteLine("この現象は、学習すべき計数行列とバイアスベクトルの条件が異なることが原因です。\n\n");

            Console.WriteLine("Demo005ではx > 1 のとき1が出力されて、xが1以下のとき0が出力されるようパラメータを学習しました。 ");
            Console.WriteLine("すなわち、Sigmoid( w*1 + b )≒0、Sigmoid( w*2 + b )≒1となるw、bを学習しました。");
            Console.WriteLine("これを満たすw、bの条件は下記となります。");
            Console.WriteLine("01 : w + b << 0");
            Console.WriteLine("02 : 2w + b >> 0");
            Console.WriteLine("\n"+"Sigmoid関数の変数(wx+b)の符号がx=1、2で切り替わりその絶対値が大きいことが条件になります。");
            Console.WriteLine("これを満たすw , bの条件は下記になります。");
            Console.WriteLine("01 : w >> 0");
            Console.WriteLine("02 : b << 0");
            Console.WriteLine("03 : w < |b| < 2w \n\n");

            Console.WriteLine("Demo006ではx > 1 のとき1が出力されて、xが1以下のとき-1が出力されるようパラメータを学習しました。 ");
            Console.WriteLine("すなわち、tanh( w*1 + b )≒-1、tanh( w*2 + b )≒1となるw、bを学習しました。");
            Console.WriteLine("これを満たすw、bの条件は下記となります。");
            Console.WriteLine("01 : w + b << 0");
            Console.WriteLine("02 : 2w + b >> 0");
            Console.WriteLine("03 : -( w + b ) ≒ 2w + b ∵ -tanh( w + b ) ≒ tanh( 2w + b )");
            Console.WriteLine("\n" + "tanh(wx+b)は(wx+b)=1.5を堺に符号が反転することが求められます。");
            Console.WriteLine("これを満たすw , bの条件は下記になります。");
            Console.WriteLine("01 : w >> 0");
            Console.WriteLine("02 : b << 0");
            Console.WriteLine("03 : b ≒ -3w/2 \n\n");

            Console.WriteLine("Demo005とDemo006との差異を下記に示します。");
            Console.WriteLine("Demo005 : w < |b| < 2w");
            Console.WriteLine("Demo006 : b ≒ -3w/2\n");
            Console.WriteLine("Demo006の方がw , bの関係の制約が厳しいです。");
            Console.WriteLine("しかし、w , bを学習するための手法(誤差逆伝搬法)は、それぞれのパラメータを独立に更新する手法です。");
            Console.WriteLine("パラメータ同士の関係が考慮されないため、demo006は学習効率が低かったと考えられます。\n\n");

            Console.WriteLine("学習データの前処理や層の設定などの工夫で、学習効率を上げることができると考えられます");








        }


    }
}
