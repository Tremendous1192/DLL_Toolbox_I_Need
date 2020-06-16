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
        /// k-分割交差検証
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <param name="K_fold"></param>
        /// <param name="ordinal_number"></param>
        /// <param name="test_data_design_matrix"></param>
        /// <param name="training_data_design_matrix"></param>
        public static void Prepare_k_fold_cross_validation
            (double[,] design_matrix, int K_fold, int ordinal_number, ref double[,] test_data_design_matrix, ref double[,] training_data_design_matrix)
        {

            int k_fold_modified = Math.Min(Math.Max(K_fold, 2), design_matrix.GetLength(0));
            int ordinal_number_modified = Math.Min(Math.Max(ordinal_number, 0), k_fold_modified - 1);
            int group_quantity = design_matrix.GetLength(0) / k_fold_modified;


            int initial_group_k = ordinal_number_modified * group_quantity;
            int end_gropu_k = Math.Min((ordinal_number_modified + 1) * group_quantity - 1, design_matrix.GetLength(0) - 1);
            group_quantity = end_gropu_k - initial_group_k + 1;


            training_data_design_matrix = new double[design_matrix.GetLength(0) - group_quantity, design_matrix.GetLength(1)];
            test_data_design_matrix = new double[group_quantity, design_matrix.GetLength(1)];


            for (int j = 0; j < initial_group_k; j++)
            {
                for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                {
                    training_data_design_matrix[j, k] = design_matrix[j, k];
                }
            }
            for (int j = 0; j < test_data_design_matrix.GetLength(0); j++)
            {
                for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                {
                    test_data_design_matrix[j, k] = design_matrix[j + initial_group_k, k];
                }
            }
            for (int j = end_gropu_k + 1; j < design_matrix.GetLength(0); j++)
            {
                for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                {
                    training_data_design_matrix[j - group_quantity, k] = design_matrix[j, k];
                }
            }
        }




    }
}
