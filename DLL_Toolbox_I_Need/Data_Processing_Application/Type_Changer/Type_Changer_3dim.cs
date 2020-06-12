using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Data_Processing_Application
{
    public partial class Type_Changer
    {

        /// <summary>
        /// Change string[,,] to int[,,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[,,] String_to_Int(string[,,] input)
        {
            int[,,] result = new int[input.GetLength(0), input.GetLength(1), input.GetLength(2)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    for (int k = 0; k < input.GetLength(2); k++)
                    {
                        try
                        {
                            result[i, j, k] = int.Parse(input[i, j, k]);
                        }
                        catch
                        {
                            result[i, j, k] = 0;
                        }
                    }

                }

            }
            return result;
        }

        /// <summary>
        /// Change string[,,] to double[,,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[,,] String_to_Double(string[,,] input)
        {
            double[,,] result = new double[input.GetLength(0), input.GetLength(1), input.GetLength(2)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    for (int k = 0; k < input.GetLength(2); k++)
                    {
                        try
                        {
                            result[i, j, k] = double.Parse(input[i, j, k]);
                        }
                        catch
                        {
                            result[i, j, k] = 0;
                        }
                    }

                }

            }
            return result;
        }

        /// <summary>
        /// Change string[,,] to byte[,,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[,,] String_to_Byte(string[,,] input)
        {
            byte[,,] result = new byte[input.GetLength(0), input.GetLength(1), input.GetLength(2)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    for (int k = 0; k < input.GetLength(2); k++)
                    {
                        try
                        {
                            result[i, j, k] = byte.Parse(input[i, j, k]);
                        }
                        catch
                        {
                            result[i, j, k] = 0;
                        }
                    }

                }

            }
            return result;
        }

        /// <summary>
        /// Change int[,,] to string[,,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[,,] Number_to_String(int[,,] input)
        {
            string[,,] result = new string[input.GetLength(0), input.GetLength(1), input.GetLength(2)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    for (int k = 0; k < input.GetLength(2); k++)
                    {
                        result[i, j, k] = input[i, j, k].ToString();
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// Change double[,,] to string[,,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[,,] Number_to_String(double[,,] input)
        {
            string[,,] result = new string[input.GetLength(0), input.GetLength(1), input.GetLength(2)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    for (int k = 0; k < input.GetLength(2); k++)
                    {
                        result[i, j, k] = Change_String(input[i, j, k]);
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// Change byte[,,] to string[,,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[,,] Number_to_String(byte[,,] input)
        {
            string[,,] result = new string[input.GetLength(0), input.GetLength(1), input.GetLength(2)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    for (int k = 0; k < input.GetLength(2); k++)
                    {
                        result[i, j, k] = input[i, j, k].ToString();
                    }
                }

            }
            return result;
        }




    }
}
