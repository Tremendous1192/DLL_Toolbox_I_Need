using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Regression_Final_Layer
    {

        public Regression_Final_Layer()
        {
            ud = new Uniform_Distribution();
        }


        public void Preset_1_4th_Set_w(double[,] W)
        {
            w = W;
        }
        public void Preset_1_4th_Set_w(int input_dimension, int output_dimension)
        {
            w = new double[output_dimension, input_dimension];

            Random r = new Random();
            for (int j = 0; j < w.GetLength(0); j++)
            {
                for (int k = 0; k < w.GetLength(1); k++)
                {
                    w[j, k] = (r.NextDouble() - 0.5) * 2.0;
                }
            }

        }

        public void Preset_2_4th_Set_b(double[,] B)
        {
            b = B;
        }
        public void Preset_2_4th_Set_b(int output_dimension)
        {
            b = new double[output_dimension, 1];

            Random r = new Random();
            for (int j = 0; j < b.GetLength(0); j++)
            {
                b[j, 0] = (r.NextDouble() - 0.5) * 2.0;
            }
        }

        public void Preset_3_4th_Set_Hyper_Parameterw(double Gamma, double L1, double L2, double Drop_out)
        {
            gamma = Math.Max(Gamma, 1.0 / 1000 / 1000);
            L_1 = Math.Max(L1, 0);
            L_2 = Math.Max(L2, 0);
            drop_out = Math.Min(Math.Max(Drop_out, 0), 1);
        }

        public void Preset_4_4th_Set_activation_Function(IFunction Activation_Function)
        {
            activation_Function = Activation_Function;
        }




    }

}
