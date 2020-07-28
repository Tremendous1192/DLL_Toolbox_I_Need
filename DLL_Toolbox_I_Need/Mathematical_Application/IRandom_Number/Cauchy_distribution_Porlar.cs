using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public class Cauchy_distribution_Porlar : IRandom_Number
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
        public uint Get_Seed_1() { return seed_1; }
        public uint Get_Seed_2() { return seed_2; }
        private void Update_Seed()
        {
            seed_1 = ud1.Get_Seed();
            seed_2 = ud2.Get_Seed();
        }

        /// <summary>
        /// constructor
        /// </summary>
        public Cauchy_distribution_Porlar()
        {
            seed_1 = (uint)Math.Abs(DateTime.Now.Millisecond);
            seed_2 = seed_1 + 1;
            ud1 = new Uniform_Distribution(seed_1);
            ud2 = new Uniform_Distribution(seed_2);

        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="the_seed_1"></param>
        public Cauchy_distribution_Porlar(uint the_seed_1, uint the_seed_2)
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
        /// 位置母数(location parameter) 0
        /// 尺度母数(scale parameter) 1
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
        retry_point:

            double u1 = ud1.NextDouble();
            double u2 = ud2.NextDouble();
            if (u2 == 0.5) { goto retry_point; }

            double v1 = 2 * u1 - 1;
            double v2 = 2 * u2 - 1;
            double w = v1 * v1 + v2 * v2;

            if (1 <= w) { goto retry_point; }

            double y = v1 / v2;

            result = y;

            return result;
        }


        /// <summary>
        /// 乱数を生成する
        /// 位置母数(location parameter) location
        /// 尺度母数(scale parameter) scale
        /// </summary>
        /// <returns></returns>
        public double NextDouble(double location, double scale)
        {
        retry_point:

            double u1 = ud1.NextDouble();
            double u2 = ud2.NextDouble();
            if (u2 == 0.5) { goto retry_point; }

            double v1 = 2 * u1 - 1;
            double v2 = 2 * u2 - 1;
            double w = v1 * v1 + v2 * v2;

            if (1 <= w) { goto retry_point; }

            double y = v1 / v2;

            result = location + Math.Abs(scale) * y;

            return result;
        }
    }

}
