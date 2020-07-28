using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public class Normal_Distribution_Polar : IRandom_Number
    {

        /// <summary>
        /// 計算結果
        /// </summary>
        double result;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public double Result()
        {
            Update_Seed();
            return result;
        }

        /// <summary>
        /// 一様分布
        /// </summary>
        Uniform_Distribution ud1, ud2;

        /// <summary>
        /// 種
        /// </summary>
        uint seed_1, seed_2;
        public uint Get_Seed_1() 
        {
            seed_1 = ud1.Get_Seed();
            return seed_1; 
        }
        public uint Get_Seed_2() 
        {
            seed_2 = ud2.Get_Seed();
            return seed_2; 
        }
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
        public Normal_Distribution_Polar()
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
        /// <param name="the_seed_1"></param>
        public Normal_Distribution_Polar(uint the_seed_1, uint the_seed_2)
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
        /// 平均値 0
        /// 標準偏差 1
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
        retry_point:

            double u1 = ud1.NextDouble();
            double u2 = ud2.NextDouble();

            double v1 = 2 * u1 - 1;
            double v2 = 2 * u2 - 1;
            double v = v1 * v1 + v2 * v2;

            if (v <= 0 || 1 <= v)
            {
                goto retry_point;
            }

            double w = Math.Sqrt(-2 * Math.Log(v) / v);

            double y1 = v1 * w;
            double y2 = v2 * w;


            if (even)
            {
                result = y1;
                even = false;
            }
            else
            {
                result = y2;
                even = true;
            }

            return result;
        }



        /// <summary>
        /// 乱数を生成する
        /// 平均値 average
        /// 標準偏差 std
        /// </summary>
        /// <param name="average"></param>
        /// <param name="std"></param>
        /// <returns></returns>
        public double NextDouble(double average, double std)
        {
        retry_point:

            double u1 = ud1.NextDouble();
            double u2 = ud2.NextDouble();

            double v1 = 2 * u1 - 1;
            double v2 = 2 * u2 - 1;
            double v = v1 * v1 + v2 * v2;

            if (v <= 0 || 1 <= v)
            {
                goto retry_point;
            }

            double w = Math.Sqrt(-2 * Math.Log(v) / v);

            double y1 = v1 * w;
            double y2 = v2 * w;

            if (even)
            {
                result = y1;
                even = false;
            }
            else
            {
                result = y2;
                even = true;
            }

            return result * Math.Abs(std) + average;
        }

    }

}
