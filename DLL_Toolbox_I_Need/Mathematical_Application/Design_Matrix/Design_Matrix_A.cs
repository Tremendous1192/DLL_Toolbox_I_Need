using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Design_Matrix
    {
        /// <summary>
        /// 行ベクトルの平均ベクトル .
        /// Mean vector of row vectors .
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double[,] Average(double[,] design_matrix)
        {
            double[,] average = new double[1, design_matrix.GetLength(1)];
            for (int j = 0; j < design_matrix.GetLength(1); j++)
            {
                for (int i = 0; i < design_matrix.GetLength(0); i++)
                {
                    average[0, j] += design_matrix[i, j];
                }
                average[0, j] /= design_matrix.GetLength(1);
            }

            return average;
        }


    }
}
