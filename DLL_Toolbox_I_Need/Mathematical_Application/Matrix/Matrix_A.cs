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
        /// 行列の足し算.
        /// Addition of 2 matrixes.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static double[,] Addition(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(0) != m2.GetLength(0))
            {
                throw new FormatException("Align Row length of " + nameof(m1) + "(" + m1.GetLength(0) + ")" + " with that of " + nameof(m2) + "(" + m2.GetLength(0) + ")");
            }
            else if (m1.GetLength(1) != m2.GetLength(1))
            {
                throw new FormatException("Align column length of " + nameof(m1) + "(" + m1.GetLength(1) + ")" + " with that of " + nameof(m2) + "(" + m2.GetLength(1) + ")");
            }

            double[,] result = new double[m1.GetLength(0), m1.GetLength(1)];

            for (int j = 0; j < m1.GetLength(0); j++)
            {
                for (int k = 0; k < m1.GetLength(1); k++)
                {
                    result[j, k] = m1[j, k] + m2[j, k];
                }
            }
            return result;
        }

    }
}
