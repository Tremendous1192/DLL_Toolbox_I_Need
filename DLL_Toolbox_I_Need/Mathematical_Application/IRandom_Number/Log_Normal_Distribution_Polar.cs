using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    class Log_Normal_Distribution_Polar : IRandom_Number
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

        Normal_Distribution_Polar nd;

        /// <summary>
        /// 種
        /// </summary>
        uint seed_1, seed_2;
        public uint Get_Seed_1() { return seed_1; }
        public uint Get_Seed_2() { return seed_2; }
        private void Update_Seed()
        {
            seed_1 = nd.Get_Seed_1();
            seed_2 = nd.Get_Seed_2();
        }

        /// <summary>
        /// constructor
        /// </summary>
        public Log_Normal_Distribution_Polar()
        {
            seed_1 = (uint)Math.Abs(DateTime.Now.Millisecond);
            seed_2 = seed_1 + 1;
            nd = new Normal_Distribution_Polar(seed_1, seed_2);
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="the_seed_1"></param>
        public Log_Normal_Distribution_Polar(uint the_seed_1, uint the_seed_2)
        {
            seed_1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed_2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed_2 = the_seed_1 + 1; }
            else { seed_2 = the_seed_2; }

            nd = new Normal_Distribution_Polar(seed_1, seed_2);
        }


        /// <summary>
        /// 種を設定する
        /// </summary>
        /// <param name="the_seed"></param>
        public void Set_Seed(uint the_seed_1, uint the_seed_2)
        {
            seed_1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed_2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed_2 = the_seed_1 + 1; }
            else { seed_2 = the_seed_2; }

            nd = new Normal_Distribution_Polar(seed_1, seed_2);
        }


        /// <summary>
        /// 乱数を生成する
        /// 正規分布の平均値 0
        /// 正規分布の標準偏差 1
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
            result = Math.Exp(nd.NextDouble());

            return result;
        }

        /// <summary>
        /// 乱数を生成する
        /// 正規分布の平均値 average
        /// 正規分布の標準偏差 std
        /// </summary>
        /// <param name="average"></param>
        /// <param name="std"></param>
        /// <returns></returns>
        public double NextDouble(double average, double std)
        {
            result = Math.Exp(nd.NextDouble(average, std));

            return result;

        }

    }

}
