using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Monte_Carlo_Method
    {
        public static void Monte_Carlo_Metropolis_Hastings
         (ref decimal result, ref decimal numerator, ref decimal denominator
              , ref decimal partition_function
              , uint calculation_count_epoch
              , decimal[] initial_x ,ref decimal[] final_x
              , IAction iaction, decimal[] step_half_width, uint[] seeds_for_step
              , uint seed_for_judge
              , IScalar iscalar
            )
        {
            //ジャンプの幅の乱数の種の次元をそろえる
            if (step_half_width.Length != seeds_for_step.Length)
            {
                throw new FormatException("Length of " + nameof(step_half_width) + "(" + step_half_width.Length + ")"
                    + " with that of " + nameof(seeds_for_step) + "(" + seeds_for_step.Length + ")");
            }
            //初期位置と乱数の種の次元をそろえる
            if (initial_x.Length != seeds_for_step.Length)
            {
                throw new FormatException("Length of " + nameof(initial_x) + "(" + initial_x.Length + ")"
                    + " with that of " + nameof(seeds_for_step) + "(" + seeds_for_step.Length + ")");
            }

            //ジャンプの幅を正の数にしておく
            decimal[] abs_step_half_width = new decimal[step_half_width.Length];
            for (int j = 0; j < step_half_width.Length; j++)
            {
                abs_step_half_width[j] = Math.Abs(step_half_width[j]);
            }

            //一様乱数のclassを生成する
            List<Uniform_Distribution> list_ud = new List<Uniform_Distribution>();
            for (int j = 0; j < step_half_width.Length; j++)
            {
                list_ud.Add(new Uniform_Distribution(seeds_for_step[j]));
            }
            Uniform_Distribution judge = new Uniform_Distribution(seed_for_judge);


            //初期設定を行う
            decimal[] xs = new decimal[step_half_width.Length];
            decimal[] xs_candidate = new decimal[step_half_width.Length];
            for (int k = 0; k < step_half_width.Length; k++)
            {
                xs[k] = initial_x[k];
                xs_candidate[k] = xs[k];
            }

            decimal action = 0m;
            decimal action_candidate = 0m;
            action = iaction.Calculate_f_u(xs);
            action_candidate = action;


            //計算を行う
            for (int j = 0; j < calculation_count_epoch; j++)
            {
                //新しいxの候補を計算する。
                for (int k = 0; k < step_half_width.Length; k++)
                {
                    //xの値を1次元だけ動かす
                    xs_candidate[k] = xs[k] + list_ud[k].NextDecimal(abs_step_half_width[k], -abs_step_half_width[k]);
                }
                action_candidate = iaction.Calculate_f_u(xs_candidate);


                //更新できる場合
                if (judge.NextDecimal() < Taylor_Series_Decimal.Exponential(action - action_candidate))
                {
                    //被積分関数の値を足す
                    numerator += iscalar.Calculate_f_u(xs_candidate);

                    //分配関数に確率値を加える。
                    partition_function += Taylor_Series_Decimal.Exponential(-action_candidate);

                    for (int k = 0; k < step_half_width.Length; k++)
                    {
                        //xの値を更新する。
                        xs[k] = xs_candidate[k];
                    }

                    //作用を更新する。
                    action = action_candidate;
                }
                else
                {
                }

                denominator++;

            }

            result = numerator / denominator;

            for (int j=0;j<initial_x.Length;j++)
            {
                final_x[j] = xs[j];
            }

        }



    }
}
