using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{

    public partial class Uniform_Distribution : IRandom_Number
    {

        /// <summary>
        /// 計算結果
        /// </summary>
        double result_double;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public double Result_Double()
        { return result_double; }


        /// <summary>
        /// 種
        /// </summary>
        uint seed, X, Y, Z, W, T;
        public uint Get_Seed() { return seed; }

        /// <summary>
        /// 計算回数
        /// </summary>
        bool[] counter_array;
        const uint counter_dim_max = 19937;


       const double denominator_double = uint.MaxValue;

        /// <summary>
        /// constructor
        /// </summary>
        public Uniform_Distribution()
        {
            seed = (uint)Math.Abs(DateTime.Now.Millisecond);
            X = 123456789;
            Y = (UInt32)(seed >> 32) & 0xFFFFFFFF;
            Z = (UInt32)(seed & 0xFFFFFFFF);
            W = X ^ Z;

            counter_array = new bool[counter_dim_max];

        }

        /// <summary>
        /// constructor
        /// </summary>
        public Uniform_Distribution(uint the_seed)
        {
            seed = the_seed;
            X = 123456789;
            Y = (UInt32)(seed >> 32) & 0xFFFFFFFF;
            Z = (UInt32)(seed & 0xFFFFFFFF);
            W = X ^ Z;

            counter_array = new bool[counter_dim_max];

        }

        /// <summary>
        /// 種を設定する
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        public void Set_Seed(uint the_seed)
        {
            seed = (uint)Math.Abs(the_seed);
            X = 123456789;
            Y = (UInt32)(seed >> 32) & 0xFFFFFFFF;
            Z = (UInt32)(seed & 0xFFFFFFFF);
            W = X ^ Z;

            counter_array = new bool[counter_dim_max];
        }

        /// <summary>
        /// 乱数を生成する
        /// 値域  :[ 0 , 1 ]
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
            T = (X ^ (X << 11));
            X = Y;
            Y = Z;
            Z = W;
            W = (W = (W ^ (W >> 19)) ^ (T ^ (T >> 8)));

            double numerator =  W;

            result_double = numerator / denominator_double;
            //result /= uint.MaxValue;

            Count_Up();

            return result_double;
        }

        /// <summary>
        /// 乱数を生成する
        /// 値域  :[ min , max ]
        /// </summary>
        /// <returns></returns>
        public double NextDouble(double max, double min)
        {
            result_double = min + (max - min) * NextDouble();
            return result_double;
        }





        /// <summary>
        /// メルセンヌツイスターの周期2^19937-1 回毎に種をリセットする
        void Count_Up()
        {

            uint back = 0;
            for (uint j = 0; j < counter_dim_max; j++)
            {
                if (!counter_array[counter_dim_max - 1 - j])
                {
                    back = j;
                    break;
                }
            }

            for (int j = 0; j < counter_dim_max - back; j++)
            {
                if (!counter_array[j])
                {
                    counter_array[j] = true;
                    return;
                }
                else 
                {
                    counter_array[j] = false;
                    continue;
                }
            }


            bool finish = counter_array[0];
            foreach (bool b in counter_array)
            {
                finish = finish == true && b == true;
            }
            if (finish) 
            {
                counter_array = new bool[counter_dim_max];

                if (seed == uint.MaxValue) { seed = 0; }
                else { seed++; }
                Set_Seed(seed);
            }
        }




    }


}
