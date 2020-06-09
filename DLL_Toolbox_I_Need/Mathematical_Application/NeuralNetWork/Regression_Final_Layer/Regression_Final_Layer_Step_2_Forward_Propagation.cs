using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{


    public partial class Regression_Final_Layer
    {

        public void Step_2_5th_Forward_Propagation()
        {
            wx = Matrix.Multiplication(w, input);

            wx_plus_b = Matrix.Addition(wx, b);

            f_wx_plus_b = activation_Function.Calculate_f_u(wx_plus_b);

            f_dash_wx_plus_b = activation_Function.Calculate_f_u_dash(wx_plus_b);

        }
    }

}
