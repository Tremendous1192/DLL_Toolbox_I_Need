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
        public void Demo_011_Compare_NN_SVM_LR()
        {
            Console.WriteLine("ニューラルネットワーク、サポートベクトルマシン、線形回帰を比較します。");
            Console.WriteLine("WriteLineはPCの処理能力を使うので、裏ですべて計算してから、結果をお見せします。");

            //計算時間
            DateTime start_NN;
            DateTime finish_NN;
            TimeSpan span_NN_epoch_100k;

            DateTime start_SVM;
            DateTime finish_SVM;
            TimeSpan span_SVM;

            DateTime start_LR;
            DateTime finish_LR;
            TimeSpan span_LR;

            List<double[,]> list_x = new List<double[,]>();
            List<double[,]> list_t = new List<double[,]>();
            for (int j = 0; j < 9; j++)
            {
                double[,] x = new double[1, 1];
                x[0, 0] = j;
                list_x.Add(x);

                double[,] t = new double[1, 1];
                if (j < 3 || 5 < j)
                { t[0, 0] = -1; }
                else 
                { t[0, 0] = 1; }
                list_t.Add(t);
            }

            //Console.WriteLine("次は、2層のNeural Networkで試してみます");
            //Console.WriteLine("第1層の計数行列はwは2行1列の行列とします");
            //Console.WriteLine("活性化関数はSigmoid関数とします");
            double[,] w_1 = new double[2, 1];
            w_1[0, 0] = 10;
            w_1[1, 0] = -10;
            //Console.WriteLine("第1層の計数行列 w");
            //this.Show_Matrix_Element(w_1);
            double[,] b_1 = new double[2, 1];
            b_1[0, 0] = -35;
            b_1[1, 0] = 55;
            //Console.WriteLine("第1層のバイアスベクトル b");
            //this.Show_Matrix_Element(b_1);
            //第一層は隠れ層なので、別のクラスです
            Hidden_Layer hd_1 = new Hidden_Layer();
            hd_1.Preset_1_4th_Set_w(w_1);
            hd_1.Preset_2_4th_Set_b(b_1);
            hd_1.Preset_3_4th_Set_Hyper_Parameter(0.01, 0, 0, 0);
            hd_1.Preset_4_4th_Set_activation_Function(new Sigmoid_IFunction());
            //Console.WriteLine("\n");

            //Console.WriteLine("第2層の計数行列はwは1行2列の行列とします");
            //Console.WriteLine("活性化関数は、第2層はHyperbolic_Tangent関数とします");
            double[,] w_2 = new double[1, 2];
            w_2[0, 0] = 20;
            w_2[0, 1] = 20;
            //Console.WriteLine("第2層の計数行列 w");
            //this.Show_Matrix_Element(w_2);
            double[,] b_2 = new double[1, 1];
            b_2[0, 0] = -30;
            //Console.WriteLine("第2層のバイアスベクトル b");
            //this.Show_Matrix_Element(b_2);
            //Console.WriteLine("\n\n");
            Regression_Final_Layer rfl_2 = new Regression_Final_Layer();
            rfl_2.Preset_1_4th_Set_w(w_2);
            rfl_2.Preset_2_4th_Set_b(b_2);
            rfl_2.Preset_3_4th_Set_Hyper_Parameter(0.001, 0, 0, 0);
            rfl_2.Preset_4_4th_Set_activation_Function(new Hyperbolic_Tangent_IFunction());
            //Console.WriteLine("\n\n");

            int epoch = 1000; 
            double[] error = new double[list_x.Count];
            //double max_error = 0;
            //int max_k = 0;
            start_NN = DateTime.Now;
            for (int j = 0; j < list_x.Count* epoch; j++)
            {
                /*
                //Console.WriteLine("epoch" + "\t" + j);
                for (int k = 0; k < list_x.Count; k++)
                {
                    hd_1.Step_1_3rd_Forward_Propagation(list_x[k]);
                    rfl_2.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());
                    error[k] = Math.Abs(rfl_2.Get_f_wx_plus_b()[0, 0] - list_t[k][0, 0]);
                    //Console.WriteLine(k + "\t" + error[k].ToString("G3") + "\t" + list_t[k][0, 0] + "\t" + rfl_2.Get_f_wx_plus_b()[0, 0].ToString("G3") + "\t" + hd_1.Get_f_wx_plus_b()[0, 0].ToString("G3") + "\t" + hd_1.Get_f_wx_plus_b()[1, 0].ToString("G3"));
                }

                max_k = 0;
                max_error = error[0];
                for (int k = 1; k < list_x.Count; k++)
                {
                    if (max_error < error[k])
                    {
                        max_error = error[k];
                        max_k = k;
                    }
                }
                //Console.WriteLine("Max error is No." + max_k);
                //Console.WriteLine(" ");
                */

                //順伝搬
                hd_1.Step_1_3rd_Forward_Propagation(list_x[j % list_x.Count]);
                rfl_2.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                //逆伝搬
                rfl_2.Step_2_3rd_Calculate_Target_Function_and_Delta(list_t[j % list_t.Count]);
                //hd_1.Step_2_3rd_Calculate_Delta(rfl_2.Get_w(), rfl_2.Get_delta());

                //パラメータの更新
                rfl_2.Step_3_3rd_Update();
                //hd_1.Step_3_3rd_Update();


            }
            finish_NN = DateTime.Now;
            span_NN_epoch_100k = finish_NN - start_NN;

            double[,] y_NN = new double[list_x.Count, 1];
            for (int j = 0; j < 9; j++)
            {
                //順伝搬
                hd_1.Step_1_3rd_Forward_Propagation(list_x[j]);
                rfl_2.Step_1_3rd_Forward_Propagation(hd_1.Get_f_wx_plus_b());

                y_NN[j, 0] = rfl_2.Get_f_wx_plus_b()[0, 0];
            }


            //SVM、線形回帰の計画行列を定義します。
            double[,] X = new double[9, 1];
            double[,] t_vec = new double[9, 1];
            //Console.WriteLine("\t" + "入力x\t" + "教師t");
            for (int j = 0; j < 9; j++)
            {
                X[j, 0] = j;
                if (j < 3 || 5 < j)
                {
                    t_vec[j, 0] = -1;
                }
                else
                {
                    t_vec[j, 0] = 1;
                }
                //Console.WriteLine("\t" + X[j, 0] + "\t" + t_vec[j, 0] + "");
            }

            //SVMの学習です
            start_SVM = DateTime.Now;
            double[,] variance_covariance = Design_Matrix.Variance_Covariance_Matrix(X);
            //係数Aを学習する
            double[,] Coefficient_A = Support_Vector_Machine.Learned_Coefficient_A(t_vec, X, new Power_of_10_IKernel(), variance_covariance);
            finish_SVM = DateTime.Now;
            span_SVM = finish_SVM - start_SVM;

            double[,] classified = Support_Vector_Machine.Classification_Design_Matrix(t_vec, X, new Power_of_10_IKernel(), variance_covariance, Coefficient_A, X);



            //線形回帰用の計画行列です。
            double[,] phi_X = new double[9, 3];
            //Console.WriteLine("\t" + "教師t" + "\t" + "exp(-(x-0.5)^2/2 )/√2π" + "\t" + "exp(-(x-2.5)^2/2 )/√2π" + "\t" + "exp(-(x-4.5)^2/2 )/√2π");
            for (int j = 0; j < 9; j++)
            {
                phi_X[j, 0] = Math.Exp(-(X[j, 0] - 1) * (X[j, 0] - 1) / 2.0) / Math.Sqrt(2 * Math.PI);
                phi_X[j, 1] = Math.Exp(-(X[j, 0] - 4) * (X[j, 0] - 4) / 2.0) / Math.Sqrt(2 * Math.PI);
                phi_X[j, 2] = Math.Exp(-(X[j, 0] - 7) * (X[j, 0] - 7) / 2.0) / Math.Sqrt(2 * Math.PI);
                //Console.WriteLine("\t" + t_vec[j, 0] + "\t" + phi_X[j, 0].ToString("G2") + "\t\t\t\t" + phi_X[j, 1].ToString("G2") + "\t\t\t\t" + phi_X[j, 2].ToString("G2"));
            }

            start_LR = DateTime.Now;
            double[,] w = Liner_Regression.Learning_parameter_w_column_vector(phi_X, t_vec);
            finish_LR = DateTime.Now;
            span_LR = finish_LR - start_LR;
            double[,] y_LR = Liner_Regression.Regression_Design_Matrix(phi_X, w);

            Console.WriteLine("入力x" + "\t" + "答えt" + "\t" + "NN" + "\t" + "SVM" + "\t" + "LR");
            for (int j = 0; j < 9; j++)
            {
                Console.Write(X[j, 0] + "\t");
                Console.Write(t_vec[j, 0] + "\t");
                Console.Write(y_NN[j, 0].ToString("G2") + "\t");
                Console.Write(classified[j, 0].ToString("G2") + "\t");
                Console.Write(y_LR[j, 0].ToString("G2") + "\t");
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("NNの計算時間\t\t" + span_NN_epoch_100k.Minutes + "分" + span_NN_epoch_100k.Seconds + "秒");
            Console.WriteLine("SVMの計算時間\t\t" + span_SVM.Minutes + "分" + span_SVM.Seconds + "秒");
            Console.WriteLine("LRの計算時間\t\t" + span_LR.Minutes + "分" + span_LR.Seconds + "秒");



            Console.WriteLine("\n\n"+"NNの精度が良くないですね。");
            Console.WriteLine("計数行列wの初期値や、学習回数、ハイパーパラメータなどを調整したのですが、これが限界でした。");


        }

    }
}
