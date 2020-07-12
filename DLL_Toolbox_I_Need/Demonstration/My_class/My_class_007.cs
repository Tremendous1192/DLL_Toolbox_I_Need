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
        public void Demo_007_Neural_Network_3()
        {
            Console.WriteLine("Neural Networkのデモンストレーションです");
            Console.WriteLine("今回は1層では学習できない例を紹介します\n\n");


            //教師データを設定します。
            //簡単のためf(x)の一次元とします。
            List<double[,]> list_x = new List<double[,]>();
            List<double[,]> list_t = new List<double[,]>();
            for (int j = 0; j < 6; j++)
            {
                double[,] x = new double[1, 1];
                x[0, 0] = j * 1.0;
                list_x.Add(x);

                double[,] t = new double[1, 1];
                if (j < 2 || 3 < j) { t[0, 0] = 1; }
                else { t[0, 0] = 0; }
                list_t.Add(t);
            }

            Console.WriteLine("今回の入力値xと、答えtです");
            Console.WriteLine("x < 2 , 3 < x のとき、答えが1になります。それ以外の場合、0です。");
            Console.Write("x\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine("\t");
            Console.Write("t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("まずは1層のNeural Networkで試してみます");
            Console.WriteLine("計数行列Wとバイアスベクトルbを設定します。");
            double[,] W_f = new double[1, 1];
            W_f[0, 0] = 3;
            double[,] b_f = new double[1, 1];
            b_f[0, 0] = 2;
            Console.WriteLine("W[0,0] = " + W_f[0, 0] + "\t" + "b[0,0] = " + b_f[0, 0] + "\n\n");


            Console.WriteLine("Neural Netoworkを設定しました。今回の活性化関数はSigmoid関数とします");
            Console.WriteLine("ハイパーパラメータの値は0.1とします。\n");
            Regression_Final_Layer rfl = new Regression_Final_Layer();
            rfl.Preset_1_4th_Set_w(W_f);
            rfl.Preset_2_4th_Set_b(b_f);
            rfl.Preset_3_4th_Set_Hyper_Parameter(0.3, 0, 0.01, 0);
            rfl.Preset_4_4th_Set_activation_Function(new Sigmoid_IFunction());


            Console.WriteLine("学習前のNeural Networkの出力を確認します。");
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


            Console.WriteLine("100,000 epoch 学習しました。");
            int epoch = 100000;
            for (int j = 0; j < list_x.Count * epoch; j++)
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
            Console.WriteLine("\n\n\n");




            Console.WriteLine("次は、2層のNeural Networkで試してみます");
            Console.WriteLine("第1層の計数行列はwは2行1列の行列とします");
            Console.WriteLine("活性化関数はSwish関数とします");
            double[,] w_1 = new double[2, 1];
            w_1[0, 0] = 3;
            w_1[1, 0] = -3;
            Console.WriteLine("第1層の計数行列 w");
            this.Show_Matrix_Element(w_1);
            double[,] b_1 = new double[2, 1];
            b_1[0, 0] = 2;
            b_1[1, 0] = -2;
            Console.WriteLine("第1層のバイアスベクトル b");
            this.Show_Matrix_Element(b_1);
            //第一層は隠れ層なので、別のクラスです
            Hidden_Layer hd_1 = new Hidden_Layer();
            hd_1.Preset_1_4th_Set_w(w_1);
            hd_1.Preset_2_4th_Set_b(b_1);
            hd_1.Preset_3_4th_Set_Hyper_Parameter(0.15, 0, 0, 0);
            hd_1.Preset_4_4th_Set_activation_Function(new Swish_IFunction());
            Console.WriteLine("\n");

            Console.WriteLine("第2層の計数行列はwは1行2列の行列とします");
            Console.WriteLine("活性化関数は、第2層はSigmoid関数とします");
            double[,] w_2 = new double[1, 2];
            w_2[0, 0] = 3;
            w_2[0, 1] = -3;
            Console.WriteLine("第2層の計数行列 w");
            this.Show_Matrix_Element(w_2);
            double[,] b_2 = new double[1, 1];
            b_2[0, 0] = 2;
            Console.WriteLine("第2層のバイアスベクトル b");
            this.Show_Matrix_Element(b_2);
            Console.WriteLine("\n\n");
            Regression_Final_Layer rfl_2 = new Regression_Final_Layer();
            rfl_2.Preset_1_4th_Set_w(w_2);
            rfl_2.Preset_2_4th_Set_b(b_2);
            rfl_2.Preset_3_4th_Set_Hyper_Parameter(0.15, 0, 0, 0);
            rfl_2.Preset_4_4th_Set_activation_Function(new Sigmoid_IFunction());
            Console.WriteLine("\n\n");


            Console.WriteLine("学習前のNeural Networkの出力を確認します。");
            List<double[,]> list_wx_plus_b_1 = new List<double[,]>();
            List<double[,]> list_f_wx_plus_b_1 = new List<double[,]>();
            List<double[,]> list_wx_plus_b_2 = new List<double[,]>();
            List<double[,]> list_f_wx_plus_b_2 = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                //順伝搬
                hd_1.Step_1_3rd_Forward_Propagation(list_x[j]);
                rfl_2.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                list_wx_plus_b_1.Add(hd_1.Get_wx_plus_b());
                list_f_wx_plus_b_1.Add(hd_1.Get_f_wx_plus_b());

                list_wx_plus_b_2.Add(rfl_2.Get_wx_plus_b());
                list_f_wx_plus_b_2.Add(rfl_2.Get_f_wx_plus_b());
            }
            Console.WriteLine("第1層のW ");
            this.Show_Matrix_Element(hd_1.Get_w());
            Console.WriteLine("第1層のb ");
            this.Show_Matrix_Element(hd_1.Get_b());
            Console.Write("x\t\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("第1層の(wx + b)\t\t");
            foreach (double[,] x in list_wx_plus_b_1) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.Write("\n \t\t\t");
            foreach (double[,] x in list_wx_plus_b_1) { Console.Write(x[1, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("第1層のf(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b_1) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.Write("\n \t\t\t");
            foreach (double[,] x in list_f_wx_plus_b_1) { Console.Write(x[1, 0].ToString("G3") + "\t"); }
            Console.WriteLine("\n");

            Console.WriteLine("第2層のW ");
            this.Show_Matrix_Element(rfl_2.Get_w());
            Console.WriteLine("第2層のb ");
            this.Show_Matrix_Element(rfl_2.Get_b());
            Console.Write("第2層の(wx + b)\t\t");
            foreach (double[,] x in list_wx_plus_b_2) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("第2層のf(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b_2) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");

            Console.WriteLine("100,000 epoch 学習しました。");
            epoch = 100000;
            for (int j = 0; j < list_x.Count * epoch; j++)
            {
                //順伝搬
                hd_1.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl_2.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                //逆伝搬
                rfl_2.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_x.Count]);
                hd_1.Step_2_3rd_Calculate_Delta(rfl_2.Get_w(), rfl_2.Get_delta());

                //パラメータの更新
                rfl_2.Step_3_3rd_Update();
                hd_1.Step_3_3rd_Update();
            }

            list_wx_plus_b_1 = new List<double[,]>();
            list_f_wx_plus_b_1 = new List<double[,]>();
            list_wx_plus_b_2 = new List<double[,]>();
            list_f_wx_plus_b_2 = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                //順伝搬
                hd_1.Step_1_3rd_Forward_Propagation(list_x[j]);
                rfl_2.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                list_wx_plus_b_1.Add(hd_1.Get_wx_plus_b());
                list_f_wx_plus_b_1.Add(hd_1.Get_f_wx_plus_b());

                list_wx_plus_b_2.Add(rfl_2.Get_wx_plus_b());
                list_f_wx_plus_b_2.Add(rfl_2.Get_f_wx_plus_b());
            }
            Console.WriteLine("第1層のW ");
            this.Show_Matrix_Element(hd_1.Get_w());
            Console.WriteLine("第1層のb ");
            this.Show_Matrix_Element(hd_1.Get_b());
            Console.Write("x\t\t\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine(" ");
            Console.Write("第1層の(wx + b)\t\t");
            foreach (double[,] x in list_wx_plus_b_1) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.Write("\n \t\t\t");
            foreach (double[,] x in list_wx_plus_b_1) { Console.Write(x[1, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("第1層のf(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b_1) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.Write("\n \t\t\t");
            foreach (double[,] x in list_f_wx_plus_b_1) { Console.Write(x[1, 0].ToString("G3") + "\t"); }
            Console.WriteLine("\n");

            Console.WriteLine("第2層のW ");
            this.Show_Matrix_Element(rfl_2.Get_w());
            Console.WriteLine("第2層のb ");
            this.Show_Matrix_Element(rfl_2.Get_b());
            Console.Write("第2層の(wx + b)\t\t");
            foreach (double[,] x in list_wx_plus_b_2) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("第2層のf(wx + b)\t");
            foreach (double[,] x in list_f_wx_plus_b_2) { Console.Write(x[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine(" ");
            Console.Write("t\t\t\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\n\n");


        }


    }
}
