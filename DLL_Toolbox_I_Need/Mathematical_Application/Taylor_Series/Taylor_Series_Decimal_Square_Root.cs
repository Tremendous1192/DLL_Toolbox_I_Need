using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Taylor_Series_Decimal
    {
        public static decimal Square_Root(decimal input)
        {

            if (input == 0m) { return decimal.Zero; }

            decimal a = 1m;
            if (input >= 1m)
            {
                a = Math.Round(input);
            }

            decimal delta = input - a;

            decimal root = (decimal)Math.Sqrt((double)a);
            decimal unit = delta / 2m / root;


            decimal result = root + unit;


            decimal numerator = 1m;
            decimal denominator = 1m;



            for (uint j = 2; j <= 5; j++)
            {
                numerator *= ((j - 2) * 2m + 1) * delta;
                denominator *= 2 * a * j;
                if (j%2==0)
                {
                    result -= unit * numerator / denominator;
                }
                else
                {
                    result += unit * numerator / denominator;
                }
            }

            return result;
        }

    }
}
