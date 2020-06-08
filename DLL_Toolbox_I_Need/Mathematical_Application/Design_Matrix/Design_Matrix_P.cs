﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Design_Matrix
    {


        /// <summary>
        /// 行ベクトルを取り出す.
        /// Get row vector
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static double[,] Pick_Up_Row_Vector(double[,] design_matrix, int row)
        {
            if (row < 0)
            {
                throw new FormatException("row " + row + " must be equal or higer than 0 ");
            }
            else if (row >= design_matrix.GetLength(0))
            {
                throw new FormatException("row " + row + " must be less than " + nameof(design_matrix) + " row " + design_matrix.GetLength(0));
            }

            double[,] result = new double[1, design_matrix.GetLength(1)];
            for (int k = 0; k < design_matrix.GetLength(1); k++)
            {
                result[0, k] = design_matrix[row, k];
            }

            return result;
        }






    }
}
