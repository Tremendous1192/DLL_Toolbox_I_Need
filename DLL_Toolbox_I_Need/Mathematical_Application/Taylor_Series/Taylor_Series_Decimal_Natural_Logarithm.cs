using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Taylor_Series_Decimal
    {
        public static decimal Natural_Logarithm(decimal input)
        {
            if (input == 0m) { return decimal.MinValue; }

            decimal a = 1m;
            if (input >= 1m)
            {
                a = Math.Round(input);
            }

            decimal delta = input - a;

            decimal numerator = delta;
            decimal denominator = a;

            decimal result = (decimal)Math.Log((double)a) + numerator / denominator;


            for (uint j=2;j<=10;j++)
            {
                numerator *= delta;
                denominator *= j * a;
                result += numerator / denominator;
            }

            return result;

        }

    }
}
