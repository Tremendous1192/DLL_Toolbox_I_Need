using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Toolbox_I_Need.Mathematical_Application
{
    public partial class Support_Vector_Machine
    {
        /// <summary>
        /// 係数Aを学習する .
        /// Learn coefficient A .
        /// </summary>
        /// <param name="Label_Y"></param>
        /// <param name="design_Matrix"></param>
        /// <param name="iKernel"></param>
        /// <param name="Inverse_Variance_Covariance_Matrix"></param>
        /// <returns></returns>
        public static double[,] Learned_Coefficient_A(double[,] Label_Y, double[,] design_Matrix, IKernel iKernel, double[,] Inverse_Variance_Covariance_Matrix)
        {
            //カーネルのセット
            iKernel.Set_Inverse_Variance_Covariance_Matrix(Inverse_Variance_Covariance_Matrix);

            //係数の最大値
            double Hyper_Parameter_C = 1.0;// Math.Min(1.0, 1.0 / design_Matrix.GetLength(0));

            //カーネル行列
            double[,] kernel_Matrix = new double[design_Matrix.GetLength(0), design_Matrix.GetLength(0)];

            //行ベクトル
            double[,] r_j = new double[1, 1];
            double[,] r_k = new double[1, 1];

            //カーネルを計算しておく
            double k_jk = 0;
            for (int j = 0; j < design_Matrix.GetLength(0); j++)
            {
                r_j = Matrix.Pick_Up_Row_Vector(design_Matrix, j);
                for (int k = j; k < design_Matrix.GetLength(0); k++)
                {
                    r_k = Matrix.Pick_Up_Row_Vector(design_Matrix, k);

                    k_jk = iKernel.Calculate(r_j, r_k);

                    kernel_Matrix[j, k] = k_jk;
                    kernel_Matrix[k, j] = k_jk;
                }
            }


            //係数の初期化
            double[,] coefficient_Matrix_A = new double[design_Matrix.GetLength(0), 1];
            double initial_a = 0.0;// 1.0 / design_Matrix.GetLength(0) / design_Matrix.GetLength(0);
            for (int j = 0; j < coefficient_Matrix_A.GetLength(0); j++)
            { coefficient_Matrix_A[j, 0] = initial_a; }

            //更新用の小数のインスタンス
            double a_j = 0;
            double a_k = 0;
            double predict_j = 0;
            double predict_k = 0;
            double min = 0;
            double max = 0;


            //学習
            //2点のデータを選択する
            for (int j = 0; j < design_Matrix.GetLength(0); j++)
            {
                //計画行列からj行目のベクトルを取り出す
                r_j = Matrix.Pick_Up_Row_Vector(design_Matrix, j);
                for (int k = j + 1; k < design_Matrix.GetLength(0); k++)
                {
                    //計画行列からk行目のベクトルを取り出す
                    r_k = Matrix.Pick_Up_Row_Vector(design_Matrix, k);

                    //ベクトルr_j r_kの予測計算を行う
                    predict_j = 0;
                    for (int j2 = 0; j2 < kernel_Matrix.GetLength(1); j2++)
                    { predict_j += coefficient_Matrix_A[j2, 0] * Label_Y[j2, 0] * kernel_Matrix[j, j2]; }
                    predict_k = 0;
                    for (int k2 = 0; k2 < kernel_Matrix.GetLength(1); k2++)
                    { predict_k += coefficient_Matrix_A[k2, 0] * Label_Y[k2, 0] * kernel_Matrix[k, k2]; }


                    //ベクトルk の係数(仮)を計算する
                    a_k = coefficient_Matrix_A[k, 0]
                        + Label_Y[k, 0] *
                        (
                        (predict_j - Label_Y[j, 0])
                        - (predict_k - Label_Y[k, 0])
                        )
                        / (kernel_Matrix[j, j] + kernel_Matrix[k, k] - 2 * kernel_Matrix[j, k]);


                    //場合分け
                    if (Label_Y[j, 0] * Label_Y[k, 0] > 0)
                    {
                        min = Math.Min(Hyper_Parameter_C
                            , coefficient_Matrix_A[j, 0] + coefficient_Matrix_A[k, 0]);
                        max = Math.Max(0
                            , coefficient_Matrix_A[j, 0] + coefficient_Matrix_A[k, 0]
                            - Hyper_Parameter_C);
                        if (min < coefficient_Matrix_A[k, 0])
                        {
                            a_k = min;
                        }
                        else if (max < a_k && a_k < min)
                        {
                            //a_k = a_k;
                        }
                        else
                        {
                            a_k = max;
                        }
                    }
                    else
                    {
                        min = Math.Min(Hyper_Parameter_C
                            , Hyper_Parameter_C
                            - coefficient_Matrix_A[j, 0] + coefficient_Matrix_A[k, 0]);
                        max = Math.Max(0
                            , -coefficient_Matrix_A[j, 0] + coefficient_Matrix_A[k, 0]);
                        if (min < a_k)
                        {
                            a_k = min;
                        }
                        else if (max < a_k && a_k < min)
                        {
                            //a_k = a_k;
                        }
                        else
                        {
                            a_k = max;
                        }
                    }

                    a_j = coefficient_Matrix_A[j, 0]
                        + Label_Y[j, 0]
                        * Label_Y[k, 0]
                        * (coefficient_Matrix_A[k, 0] - a_k);

                    //係数の更新
                    coefficient_Matrix_A[j, 0] = a_j;
                    coefficient_Matrix_A[k, 0] = a_k;
                }
            }
            //学習終わり



            return coefficient_Matrix_A;

        }
    }

}
