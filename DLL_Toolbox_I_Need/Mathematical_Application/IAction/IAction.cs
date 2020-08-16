using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public interface IAction
    {

        double Calculate_f_u(double[] input);

        decimal Calculate_f_u(decimal[] input);


    }
}
