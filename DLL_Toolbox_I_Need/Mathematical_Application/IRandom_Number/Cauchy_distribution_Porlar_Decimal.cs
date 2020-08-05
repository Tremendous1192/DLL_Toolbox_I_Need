using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Cauchy_distribution_Porlar : IRandom_Number
    {
        /// <summary>
        /// 計算結果
        /// </summary>
        decimal result_decimal;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public decimal Result_Decimal()
        {
            Update_Seed();
            return result_decimal;
        }


        /// <summary>
        /// 乱数を生成する
        /// 位置母数(location parameter) 0
        /// 尺度母数(scale parameter) 1
        /// </summary>
        /// <returns></returns>
        public decimal NextDecimal()
        {
        retry_point:

            decimal u1 = ud1.NextDecimal();
            decimal u2 = ud2.NextDecimal();
            if (u2 == 0.5m) { goto retry_point; }

            decimal v1 = 2 * u1 - 1;
            decimal v2 = 2 * u2 - 1;
            decimal w = v1 * v1 + v2 * v2;

            if (1 <= w) { goto retry_point; }

            decimal y = v1 / v2;

            result_decimal = y;

            return result_decimal;
        }


        /// <summary>
        /// 乱数を生成する
        /// 位置母数(location parameter) location
        /// 尺度母数(scale parameter) scale
        /// </summary>
        /// <returns></returns>
        public decimal NextDecimal(decimal location, decimal scale)
        {
            result_decimal = location + Math.Abs(scale) * NextDecimal();
            return result_decimal;
        }

    }
}
