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
            if (input == 0m) { return 1m; }
            else if (input==decimal.MinValue) { return 0m; }

            decimal a = Math.Round(input);
            decimal e_a = 1m;
            if (a == 0m) { }
            else if (a > 0)
            {
                try 
                {
                    for (uint j = 0; j < a; j++)
                    {
                        e_a *= Taylor_Series_Decimal.Napier;
                    }
                }
                catch
                {
                    return decimal.MaxValue;
                }
            }
            else
            {
                try
                {
                    for (uint j = 0; j < -a; j++)
                    {
                        e_a /= Taylor_Series_Decimal.Napier;
                    }
                }
                catch 
                {
                    return 0m;
                }  
            }

            decimal delta = input - a;

            decimal numerator = delta;
            decimal denominator = 1m;

            decimal result = 1m + delta;

            for (uint j = 2; j <= 6; j++)
            {
                numerator *= delta;
                denominator *= j;
                result += numerator / denominator;
            }

            return e_a * result;

        }



    }
}
