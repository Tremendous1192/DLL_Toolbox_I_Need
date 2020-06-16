﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Matrix
    {

        /// <summary>
        /// 列ベクトルを取り出す.
        /// Get column vector.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="column_index"></param>
        /// <returns></returns>
        public static double[,] Pick_Up_Column_Vector(double[,] matrix, int column_index)
        {
            if (column_index < 0)
            {
                throw new FormatException("column " + column_index + " must be equal or higer than 0 ");
            }
            else if (column_index >= matrix.GetLength(1))
            {
                throw new FormatException("column " + column_index + " must be less than matrix colmun " + matrix.GetLength(1));
            }

            double[,] result = new double[matrix.GetLength(0), 1];
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                result[j, 0] = matrix[j, column_index];
            }

            return result;
        }

        /// <summary>
        /// 行ベクトルを取り出す.
        /// Get row vector
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row_index"></param>
        /// <returns></returns>
        public static double[,] Pick_Up_Row_Vector(double[,] matrix, int row_index)
        {
            if (row_index < 0)
            {
                throw new FormatException("row " + row_index + " must be equal or higer than 0 ");
            }
            else if (row_index >= matrix.GetLength(0))
            {
                throw new FormatException("row " + row_index + " must be less than matrix row " + matrix.GetLength(0));
            }

            double[,] result = new double[1, matrix.GetLength(1)];
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                result[0, k] = matrix[row_index, k];
            }

            return result;
        }



    }
}
