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
        public void Demo_008_Neural_Network_4()
        {
            Console.WriteLine("Neural Networkのデモンストレーションです");
            Console.WriteLine("4回目です。私も飽きてきましたが、最後です");
            Console.WriteLine("今回は多クラス分類の問題を扱います。\n\n");

            //教師データを設定します。
            //入力は一次元ですが、出力は二次元とします。
            List<double[,]> list_x = new List<double[,]>();
            List<double[,]> list_t = new List<double[,]>();
            for (int j = 0; j < 6; j++)
            {
                double[,] x = new double[1, 1];
                x[0, 0] = j * 1.0;
                list_x.Add(x);

                double[,] t = new double[2, 1];
                if (j < 2 || 3 < j) 
                {
                    t[0, 0] = 1;
                    t[1, 0] = 0;
                }
                else
                {
                    t[0, 0] = 0;
                    t[1, 0] = 1;
                }
                list_t.Add(t);
            }


            Console.WriteLine("今回の入力値xと、答えtです");
            Console.WriteLine("x < 2 , 3 < x のとき、t[0,0]=1 , t[1,0]=0になります。それ以外の場合、逆になります。");
            Console.Write("x\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine("\t");
            Console.Write("t[0,0]\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\t");
            Console.Write("t[1,0]\t");
            foreach (double[,] t in list_t) { Console.Write(t[1, 0] + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("Demo007の結果から、この分布は2層以上のNeural Networkでのみ解くことができます");
            Console.WriteLine("第1層の計数行列はwは2行1列の行列とします");
            Console.WriteLine("活性化関数はSigmoid関数とします");
            double[,] w_1 = new double[2, 1];
            w_1[0, 0] = 10;
            w_1[1, 0] = -10;
            Console.WriteLine("第1層の計数行列 w");
            this.Show_Matrix_Element(w_1);
            double[,] b_1 = new double[2, 1];
            b_1[0, 0] = -20;
            b_1[1, 0] = 20;
            Console.WriteLine("第1層のバイアスベクトル b");
            this.Show_Matrix_Element(b_1);
            //第一層は隠れ層なので、別のクラスです
            Hidden_Layer hd_1 = new Hidden_Layer();
            hd_1.Preset_1_4th_Set_w(w_1);
            hd_1.Preset_2_4th_Set_b(b_1);
            hd_1.Preset_3_4th_Set_Hyper_Parameter(0.1, 0, 0, 0);
            hd_1.Preset_4_4th_Set_activation_Function(new Sigmoid_IFunction());
            Console.WriteLine("\n");

            Console.WriteLine("第2層の計数行列はwは2行2列の行列とします");
            Console.WriteLine("活性化関数はSoftMax関数で固定です");
            double[,] w_2 = new double[2, 2];
            w_2[0, 0] = 3;
            w_2[0, 1] = -3;
            w_2[1, 0] = 1;
            w_2[1, 1] = -2;
            Console.WriteLine("第2層の計数行列 w");
            this.Show_Matrix_Element(w_2);
            double[,] b_2 = new double[2, 1];
            b_2[0, 0] = 2;
            b_2[0, 0] = -1;
            Console.WriteLine("第2層のバイアスベクトル b");
            this.Show_Matrix_Element(b_2);
            Console.WriteLine("\n\n");
            Multiclass_Classification_Final_Layer mcfl = new Multiclass_Classification_Final_Layer();
            mcfl.Preset_1_3rd_Set_w(w_2);
            mcfl.Preset_2_3rd_Set_b(b_2);
            mcfl.Preset_3_3rd_Set_Hyper_Parameter(0.01, 0, 0, 0);
            Console.WriteLine("\n\n");


            Console.WriteLine("学習前のNeural Networkの出力を確認します。");
            Console.WriteLine("これまで途中結果の表示が大切だと考えてきたのですが、画面がごちゃつくだけなので最終層の出力だけ表示します。");
            List<double[,]> list_f_wx_plus_b_2 = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                //順伝搬
                hd_1.Step_1_3rd_Forward_Propagation(list_x[j]);
                mcfl.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                list_f_wx_plus_b_2.Add(mcfl.Get_f_wx_plus_b());
            }

            Console.Write("x\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine("\t");

            Console.Write("t[0,0]\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\t");
            Console.Write("t[1,0]\t");
            foreach (double[,] t in list_t) { Console.Write(t[1, 0] + "\t"); }
            Console.WriteLine("\t");

            Console.Write("y[0,0]\t");
            foreach (double[,] t in list_f_wx_plus_b_2) { Console.Write(t[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine("\t");
            Console.Write("y[1,0]\t");
            foreach (double[,] t in list_f_wx_plus_b_2) { Console.Write(t[1, 0].ToString("G3") + "\t"); }
            Console.WriteLine("\n\n");


            Console.WriteLine("xの値によらず、すべて[0,0]のクラスであると認識したようです。");
            Console.WriteLine("100,000 epoch 学習してみます。");
            Console.WriteLine("\n\n");
            int epoch = 1000 + 1;
            double[] loss = new double[list_x.Count];
            int row_num = 0;
            double maximum_loss = 0;
            for (int j = 0; j < epoch; j++)
            {
                //各条件の誤差を比較する
                for (int k = 0; k < list_x.Count; k++)
                {
                    //順伝搬
                    hd_1.Step_1_3rd_Forward_Propagation(list_x[k]);
                    mcfl.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                    mcfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[k]);
                    loss[k] = mcfl.Get_target_function();
                }


                //誤差が最も大きいx,tの組のみ学習する
                row_num = 0;
                maximum_loss = loss[0];
                for (int k = 1; k < loss.Length; k++)
                {
                    if (maximum_loss < loss[k])
                    {
                        row_num = k;
                        maximum_loss = loss[k];
                    }
                }

                //順伝搬
                hd_1.Step_1_3rd_Forward_Propagation(list_x[row_num]);
                mcfl.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                //逆伝搬
                mcfl.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[row_num]);
                //hd_1.Step_2_3rd_Calculate_Delta(mcfl.Get_w(), mcfl.Get_delta());

                //パラメータの更新
                mcfl.Step_3_3rd_Update();
                //hd_1.Step_3_3rd_Update();
            }


            list_f_wx_plus_b_2 = new List<double[,]>();
            for (int j = 0; j < list_x.Count; j++)
            {
                //順伝搬
                hd_1.Step_1_3rd_Forward_Propagation(list_x[j]);
                mcfl.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                list_f_wx_plus_b_2.Add(mcfl.Get_f_wx_plus_b());
            }

            Console.Write("x\t");
            foreach (double[,] x in list_x) { Console.Write(x[0, 0] + "\t"); }
            Console.WriteLine("\t");

            Console.Write("t[0,0]\t");
            foreach (double[,] t in list_t) { Console.Write(t[0, 0] + "\t"); }
            Console.WriteLine("\t");
            Console.Write("t[1,0]\t");
            foreach (double[,] t in list_t) { Console.Write(t[1, 0] + "\t"); }
            Console.WriteLine("\t");

            Console.Write("y[0,0]\t");
            foreach (double[,] t in list_f_wx_plus_b_2) { Console.Write(t[0, 0].ToString("G3") + "\t"); }
            Console.WriteLine("\t");
            Console.Write("y[1,0]\t");
            foreach (double[,] t in list_f_wx_plus_b_2) { Console.Write(t[1, 0].ToString("G3") + "\t"); }
            Console.WriteLine("\n\n");



            Console.WriteLine("y[0,0] , y[1,0]がともに0.5付近になりました。");
            Console.WriteLine("明らかに、この答えは私たちが求めているものではありません。");
            Console.WriteLine("この解は、誤差逆伝搬法の課題の１つである局所解です。");
            Console.WriteLine("局所解は、計数行列w、バイアスベクトルbの取りうる範囲全体では損失関数が最小ではないが、その値近傍では損失関数が最小になる解のことです。");
            Console.WriteLine("誤差逆伝搬法は損失関数が小さくなる方向にパラメータを更新する手法のため、局所的な最小値に引っ掛かりやすいです。");
            Console.WriteLine("モーメンタム法などの対策法はありますが、効果的なのはデータの前処理でしょう。");
            Console.WriteLine("今回の場合は、2クラス分類なので、Demo007のようにSigmoid関数の回帰分析問題として扱った方が、正解に近づけたでしょう。");




        }


    }
}
