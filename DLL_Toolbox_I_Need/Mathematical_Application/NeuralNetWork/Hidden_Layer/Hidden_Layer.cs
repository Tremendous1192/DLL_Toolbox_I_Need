using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Hidden_Layer
    {


        /// <summary>
        /// 入力ベクトル
        /// </summary>
        double[,] input;
        /// <summary>
        /// 入力ベクトル
        /// </summary>
        /// <returns></returns>
        public double[,] Get_input() { return input; }
        /// <summary>
        /// 入力ベクトルの転置行列
        /// </summary>
        /// <returns></returns>
        public double[,] Get_input_Transpose()
        {
            double[,] result = new double[input.GetLength(1), input.GetLength(0)];
            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    result[k, j] = input[j, k];
                }
            }
            return result;
        }

        /// <summary>
        /// 行列 W
        /// </summary>
        double[,] w;
        /// <summary>
        /// 行列 W
        /// </summary>
        /// <returns></returns>
        public double[,] Get_w() { return w; }
        /// <summary>
        /// 行列 Wの転置行列
        /// </summary>
        /// <returns></returns>
        public double[,] Get_w_Transpose()
        {
            double[,] result = new double[w.GetLength(1), w.GetLength(0)];
            for (int j = 0; j < w.GetLength(0); j++)
            {
                for (int k = 0; k < w.GetLength(1); k++)
                {
                    result[k, j] = w[j, k];
                }
            }
            return result;
        }


        /// <summary>
        /// バイアスベクトル
        /// </summary>
        double[,] b;
        /// <summary>
        /// バイアスベクトル
        /// </summary>
        /// <returns></returns>
        public double[,] Get_b() { return b; }

        /// <summary>
        /// 途中計算
        /// </summary>
        double[,] wx;
        /// <summary>
        /// 途中計算
        /// </summary>
        public double[,] Get_wx { get { return wx; } }

        /// <summary>
        /// 途中計算
        /// </summary>
        double[,] wx_plus_b;
        /// <summary>
        /// 途中計算
        /// </summary>
        public double[,] Get_wx_plus_b { get { return wx_plus_b; } }

        /// <summary>
        /// 計算結果
        /// </summary>
        double[,] f_wx_plus_b;
        /// <summary>
        /// 計算結果
        /// </summary>
        public double[,] Get_f_wx_plus_b { get { return f_wx_plus_b; } }
        /// <summary>
        /// 計算結果の転置行列
        /// </summary>
        public double[,] Get_f_wx_plus_b_Transpose()
        {
            double[,] f_wx_plus_b_t = new double[f_wx_plus_b.GetLength(1), f_wx_plus_b.GetLength(0)];
            for (int i = 0; i < f_wx_plus_b.GetLength(0); i++)
            {
                for (int j = 0; j < f_wx_plus_b.GetLength(1); j++)
                {
                    f_wx_plus_b_t[j, i] = f_wx_plus_b_t[i, j];
                }
            }
            return f_wx_plus_b;
        }


        /// <summary>
        /// 計算結果の導関数
        /// </summary>
        double[,] f_dash_wx_plus_b;
        /// <summary>
        /// 計算結果の導関数
        /// </summary>
        public double[,] Get_f_dash_wx_plus_b() { return f_dash_wx_plus_b; }

        /// <summary>
        /// 誤差逆伝播法の δ。
        /// Bを更新するベクトルでもある。
        /// </summary>
        double[,] delta;
        /// <summary>
        /// 誤差逆伝播法の δ。
        /// Bを更新するベクトルでもある。
        /// </summary>
        public double[,] Get_delta() { return delta; }

        /// <summary>
        /// W を更新する行列
        /// </summary>
        double[,] change_w;
        /// <summary>
        /// W を更新する行列
        /// </summary>
        public double[,] Get_change_w() { return change_w; }

        /// <summary>
        /// 教師ベクトル
        /// </summary>
        double[,] teach;
        /// <summary>
        /// 教師ベクトル
        /// </summary>
        public double[,] Get_teach() { return teach; }

        /// <summary>
        /// ハイパーパラメーター
        /// </summary>
        double gamma, L_1, L_2, drop_out;

        /// <summary>
        /// 誤差
        /// </summary>
        double[,] error;
        /// <summary>
        /// 誤差
        /// </summary>
        public double[,] Get_error() { return error; }

        /// <summary>
        /// 目的関数
        /// </summary>
        double target_function;
        /// <summary>
        /// 目的関数
        /// </summary>
        public double Get_target_function() { return target_function; }

        /// <summary>
        /// 代数計算用のインスタンス
        /// </summary>
        //Matrix_Algebra MA;


        /// <summary>
        /// 活性化関数
        /// </summary>
        IFunction activation_Function;

    }

}
