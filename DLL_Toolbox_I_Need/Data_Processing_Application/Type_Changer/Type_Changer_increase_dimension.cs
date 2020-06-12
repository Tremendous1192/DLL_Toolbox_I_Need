using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Data_Processing_Application
{
    public partial class Type_Changer
    {

        /// <summary>
        ///  Chnage double[] to double[,]
        /// </summary>
        /// <param name="input"></param>
        /// <param name="colmun"></param>
        /// <returns></returns>
        public static double[,] Change_Array_1_to_2(double[] input, int colmun)
        {
            int row = input.GetLength(0) / colmun;

            double[,] result = new double[row, colmun];

            int i = 0;
            int j = 0;
            for (int k = 0; k < input.Length; k++)
            {
                i = k / colmun;
                j = k % colmun;
                result[i, j] = input[k];
            }
            return result;
        }

        /// <summary>
        /// Chnage double[] to double[,,]
        /// </summary>
        /// <param name="input"></param>
        /// <param name="colmun"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static double[,,] Change_Array_1_to_3(double[] input, int colmun, int depth)
        {
            int row = input.GetLength(0) / (colmun * depth);


            double[,,] result = new double[row, colmun, depth];

            int i = 0;
            int j = 0;
            int k = 0;
            for (int L = 0; L < input.Length; L++)
            {
                i = L / (colmun * depth);
                j = (L % (colmun * depth)) / depth;
                k = (L % (colmun * depth)) % depth;

                result[i, j, k] = input[L];
            }
            return result;
        }




    }
}
