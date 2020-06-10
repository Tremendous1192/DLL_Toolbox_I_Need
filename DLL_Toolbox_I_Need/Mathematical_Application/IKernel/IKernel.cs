using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public interface IKernel
    {
        void Set_Inverse_Variance_Covariance_Matrix(double[,] Inverse_Variance_Covariance_Matrix);

        double Calculate(double[,] row_Vector_1, double[,] row_Vector_2);
    }

}
