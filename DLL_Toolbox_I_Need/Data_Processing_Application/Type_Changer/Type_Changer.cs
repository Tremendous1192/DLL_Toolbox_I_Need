using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Data_Processing_Application
{
    public partial class Type_Changer
    {
        public static string Change_String(double input)
        {
            return (Math.Round(input * 1000.0 * 1000.0 * 1000.0) / (1000.0 * 1000.0 * 1000.0)).ToString();
        }

    }
}
