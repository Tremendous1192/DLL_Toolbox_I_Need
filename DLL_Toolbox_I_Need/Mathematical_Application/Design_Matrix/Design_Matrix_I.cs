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
        /// 共分散行列の逆行列
        /// Calculate Inverse of the covariance matrix.
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Inverse_Variance_Covariance_Matrix(double[,] design_Matrix)
        {
            return Matrix.Inverse_of_a_Matrix(Design_Matrix.Variance_Covariance_Matrix(design_Matrix));
        }



    }
}
