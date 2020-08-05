using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Taylor_Series_Decimal
    {

        public static decimal Exponential(decimal input)
        {

            decimal a = Math.Round(input);
            decimal delta = input - a;

            decimal numerator = delta;
            decimal denominator = 1m;

            decimal result = 1m + numerator / denominator;

            for (uint j = 2; j <= 10; j++)
            {
                numerator *= delta;
                denominator *= j;
                result += numerator / denominator;
            }

            return (decimal)Math.Exp((double)a) * result;

        }

    }
}
