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
        /// 各要素を逆数に変換した行列 .
        /// Matrix with each element converted to reciprocal .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Reciprocal_Number_Matrix(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];

            //0割にならないように、補正値を加える(絶対値の最小値の1/1,000,000とする)
            double abs_min = Math.Max(1.0 / 1000.0, Math.Abs(matrix[0, 0]));
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //要素が零ではない場合、最小値の更新を行う。
                    if (matrix[i, j]!=0)
                    {
                        abs_min = Math.Min(abs_min, Math.Abs(matrix[i, j]));
                    }
                }
            }
            double scaling = abs_min / 1000.0 / 1000.0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //result[i, j] = 1.0 / matrix[i, j];
                    result[i, j] = 1.0 / (matrix[i, j] + scaling);

                }
            }

            return result;
        }



    }
}
