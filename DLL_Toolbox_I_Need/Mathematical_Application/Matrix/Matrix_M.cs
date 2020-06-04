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
        /// 行列の掛け算.
        /// Matrix multiplication .
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static double[,] Multiplication(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(1) != m2.GetLength(0))
            {
                throw new FormatException("Align columns of " + nameof(m1) + " (" + m1.GetLength(1) + ")" + " with row of " + nameof(m2) + " (" + m2.GetLength(0) + ")");
            }


            double[,] result = new double[m1.GetLength(0), m2.GetLength(1)];
            double h = 0.0;
            for (int j = 0; j < result.GetLength(0); j++)
            {
                for (int k = 0; k < result.GetLength(1); k++)
                {
                    h = 0.0;
                    for (int L = 0; L < m1.GetLength(1); L++)
                    {
                        h += m1[j, L] * m2[L, k];
                    }
                    result[j, k] = h;
                }
            }

            return result;
        }


    }
}
