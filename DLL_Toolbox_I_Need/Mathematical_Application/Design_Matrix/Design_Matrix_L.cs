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
        /// <param name="ordinal_number"></param>
        /// <param name="test_data_row_vector"></param>
        /// <param name="training_data_design_matrix"></param>
        public static void Prepare_Leave_one_out_cross_validation
            (double[,] design_matrix, int ordinal_number, ref double[,] test_data_row_vector, ref double[,] training_data_design_matrix)
        {


            training_data_design_matrix = new double[design_matrix.GetLength(0) - 1, design_matrix.GetLength(1)];
            test_data_row_vector = new double[1, design_matrix.GetLength(1)];


            int ordinal_number_modified = Math.Min(Math.Max(0, ordinal_number), design_matrix.GetLength(0) - 1);

            for (int j=0;j<design_matrix.GetLength(0);j++)
            {
                if (j==ordinal_number_modified)
                {
                }
                else if (j<ordinal_number)
                {
                    for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                    {
                        training_data_design_matrix[j, k] = design_matrix[j, k];
                    }
                }
                else
                {
                    for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                    {
                        training_data_design_matrix[j-1, k] = design_matrix[j , k];
                    }
                }
            }
            for (int k = 0; k < design_matrix.GetLength(1); k++)
            {
                test_data_row_vector[0, k] = design_matrix[ordinal_number_modified, k];
            }


        }





    }
}
