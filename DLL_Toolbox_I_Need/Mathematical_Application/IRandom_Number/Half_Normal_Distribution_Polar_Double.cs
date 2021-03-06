﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Half_Normal_Distribution_Polar : IRandom_Number
    {



        /// <summary>
        /// 計算結果
        /// </summary>
        double result_double;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public double Result_Double()
        {
            Update_Seed();
            return result_double;
        }

        /// <summary>
        /// 一様分布
        /// </summary>
        Uniform_Distribution ud1, ud2;

        /// <summary>
        /// 種
        /// </summary>
        uint seed_1, seed_2;
        public uint Get_Seed_1() { return seed_1; }
        public uint Get_Seed_2() { return seed_2; }
        private void Update_Seed()
        {
            seed_1 = ud1.Get_Seed();
            seed_2 = ud2.Get_Seed();
        }

        /// <summary>
        /// 計算回数
        /// </summary>
        bool even;

        /// <summary>
        /// constructor
        /// </summary>
        public Half_Normal_Distribution_Polar()
        {
            seed_1 = (uint)Math.Abs(DateTime.Now.Millisecond);
            seed_2 = seed_1 + 1;
            ud1 = new Uniform_Distribution(seed_1);
            ud2 = new Uniform_Distribution(seed_2);

            even = true;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="the_seed"></param>
        public Half_Normal_Distribution_Polar(uint the_seed_1, uint the_seed_2)
        {
            seed_1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed_2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed_2 = the_seed_1 + 1; }
            else { seed_2 = the_seed_2; }

            ud1 = new Uniform_Distribution(seed_1);
            ud2 = new Uniform_Distribution(seed_2);

            even = true;
        }

        /// <summary>
        /// 種を設定する
        /// </summary>
        /// <param name="the_seed_1"></param>
        public void Set_Seed(uint the_seed_1, uint the_seed_2)
        {
            seed_1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed_2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed_2 = the_seed_1 + 1; }
            else { seed_2 = the_seed_2; }

            ud1 = new Uniform_Distribution(seed_1);
            ud2 = new Uniform_Distribution(seed_2);
        }

        /// <summary>
        /// 乱数を生成する
        /// 標準偏差 1
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
        retry_point:

            double u1 = ud1.NextDouble();
            double u2 = ud2.NextDouble();

            double v = u1 * u1 + u2 * u2;

            if (v <= 0 || 1 <= v)
            {
                goto retry_point;
            }

            double w = Math.Sqrt(-2 * Math.Log(v) / v);

            double y1 = u1 * w;
            double y2 = u2 * w;

            if (even)
            {
                result_double = y1;
                even = false;
            }
            else
            {
                result_double = y2;
                even = true;
            }

            return result_double;
        }



        /// <summary>
        /// 乱数を生成する
        /// 標準偏差 std
        /// </summary>
        /// <param name="std"></param>
        /// <returns></returns>
        public double NextDouble(double std)
        {
            return NextDouble() * Math.Abs(std);
        }

    }

}
