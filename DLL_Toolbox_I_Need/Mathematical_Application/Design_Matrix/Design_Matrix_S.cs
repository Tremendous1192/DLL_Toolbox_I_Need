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
        /// 各要素の標準偏差を計算する
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Standard_Deviation(double[,] design_Matrix)
        {
            double[,] average = Design_Matrix.Average(design_Matrix);
            double[,] average_square = new double[1, design_Matrix.GetLength(1)];

            for (int k = 0; k < design_Matrix.GetLength(1); k++)
            {
                for (int j = 0; j < design_Matrix.GetLength(0); j++)
                {
                    average_square[0, k] += design_Matrix[j, k] * design_Matrix[j, k];
                }
                average_square[0, k] /= design_Matrix.GetLength(0);
            }

            double[,] result = new double[1, design_Matrix.GetLength(1)];

            for (int k = 0; k < design_Matrix.GetLength(1); k++)
            {
                result[0, k] = Math.Sqrt(average_square[0, k] - average[0, k] * average[0, k]);
            }

            return result;
        
        }

    }
}
