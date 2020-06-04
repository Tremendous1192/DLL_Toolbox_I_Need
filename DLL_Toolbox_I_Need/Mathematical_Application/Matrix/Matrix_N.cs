using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Matrix
    {


        /// <summary>
        /// 絶対値の最大値を返す.
        /// Returns the maximum absolute value .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double Norm_Infinity(double[,] matrix)
        {
            double norm = 0.0;
            foreach (double d in matrix)
            {
                norm = Math.Max(norm, Math.Abs(d));
            }

            return norm;
        }


        /// <summary>
        /// 絶対値の和。Manhattan norm
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double Norm_L1(double[,] matrix)
        {
            double norm = 0;
            foreach (double d in matrix)
            {
                norm += Math.Abs(d);
            }

            return norm;
        }

        /// <summary>
        /// 二乗和の平方根。Euclid norm
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double Norm_L2(double[,] matrix)
        {
            double norm = 0;
            foreach (double d in matrix)
            {
                norm += d * d;
            }

            return Math.Sqrt(norm);
        }






    }
}
