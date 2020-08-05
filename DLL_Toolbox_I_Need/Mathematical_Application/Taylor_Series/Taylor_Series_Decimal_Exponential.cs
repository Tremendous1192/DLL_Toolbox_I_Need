using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Taylor_Series_Decimal
    {
        public static decimal Napier { get { return 2.718281828459045235360287471352m; } }


        public static decimal Exponential(decimal input)
        {

            decimal a = Math.Round(input);
            decimal e_a = 1m;
            if (a==0m) { }
            else if(a>0)
            {
                for (uint j=0;j<a;j++)
                {
                    e_a *= Taylor_Series_Decimal.Napier;
                }
            }
            else
            {
                for (uint j = 0; j < a; j++)
                {
                    e_a /= Taylor_Series_Decimal.Napier;
                }
            }

            decimal delta = input - a;

            decimal numerator = delta;
            decimal denominator = 1m;

            decimal result = 1m + delta;

            for (uint j = 2; j <= 10; j++)
            {
                numerator *= delta;
                denominator *= j;
                result += numerator / denominator;
            }

            return e_a * result;

        }



    }
}
