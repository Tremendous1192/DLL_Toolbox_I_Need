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
        /// leave-one-out 交差検証
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <param name="number"></param>
        /// <param name="test_data_row_vector"></param>
        /// <param name="training_data_design_matrix"></param>
        public static void Prepare_lLeave_one_out_cross_validation
            (double[,] design_matrix, int number, ref double[,] test_data_row_vector, ref double[,] training_data_design_matrix)
        {


            training_data_design_matrix = new double[design_matrix.GetLength(0) - 1, design_matrix.GetLength(1)];
            test_data_row_vector = new double[1, design_matrix.GetLength(1)];


            int number_modified = Math.Min(Math.Max(0, number), design_matrix.GetLength(0) - 1);


            for (int j = 0; j < number_modified; j++)
            {
                for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                {
                    training_data_design_matrix[j, k] = design_matrix[j, k];
                }
            }
            for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
            {
                test_data_row_vector[number_modified, k] = design_matrix[number_modified, k];
            }
            for (int j = number_modified + 1; j < training_data_design_matrix.GetLength(0); j++)
            {
                for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                {
                    training_data_design_matrix[j, k] = design_matrix[j + 1, k];
                }
            }


        }





    }
}
