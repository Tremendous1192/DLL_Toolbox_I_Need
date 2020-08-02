using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;


namespace DLL_Toolbox_I_Need.Data_Processing_Application
{
    public partial class Text_Processor
    {


        /// <summary>
        /// txt に書き足す。stringを記録する
        /// </summary>
        /// <param name="txt_file_name"></param>
        /// <param name="WrittenText"></param>
        /// <returns></returns>
        public void Write_text_Add(string txt_file_name, string WrittenText)
        {
            string path = System.IO.Path.Combine(this.Get_Current_Directory(), txt_file_name + ".txt");

            //.Net CoreでShift_JISを使用するため
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(txt_file_name);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter sw;
            try
            {
                //sw = new System.IO.StreamWriter(stream, sjisEnc,512,false);
                sw = File.AppendText(path);
                sw.AutoFlush = true;

                sw.WriteLine(WrittenText);
                //閉じる
                sw.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
            }

        }


        /// <summary>
        /// txt に書き足す。string[]を記録する
        /// </summary>
        /// <param name="txt_file_name"></param>
        /// <param name="WrittenText"></param>
        /// <returns></returns>
        public void Write_text_Add(string txt_file_name, string[] WrittenText)
        {
            string path = System.IO.Path.Combine(this.Get_Current_Directory(), txt_file_name + ".txt");

            //.Net CoreでShift_JISを使用するため
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(txt_file_name);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter sw;
            try
            {
                //sw = new System.IO.StreamWriter(stream, sjisEnc,512,false);
                sw = File.AppendText(path);
                sw.AutoFlush = true;

                for (int i = 0; i < WrittenText.GetLength(0); i++)
                {
                    sw.WriteLine(WrittenText[i]);
                }
                //閉じる
                sw.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
            }

        }




        /// <summary>
        /// txt に書き足す。string[ , ]を記録する
        /// </summary>
        /// <param name="txt_file_name"></param>
        /// <param name="WrittenText"></param>
        /// <returns></returns>
        public void Write_text_Add(string txt_file_name, string[,] WrittenText)
        {
            string path = System.IO.Path.Combine(this.Get_Current_Directory(), txt_file_name + ".txt");

            //.Net CoreでShift_JISを使用するため
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(txt_file_name);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter sw;
            try
            {
                //sw = new System.IO.StreamWriter(stream, sjisEnc,512,false);
                sw = File.AppendText(path);
                sw.AutoFlush = true;

                for (int i = 0; i < WrittenText.GetLength(0); i++)
                {
                    for (int j = 0; j < WrittenText.GetLength(1) - 1; j++)
                    {
                        sw.Write(WrittenText[i, j] + ",");
                    }
                    sw.WriteLine(WrittenText[i, WrittenText.GetLength(1) - 1]);
                }
                //閉じる
                sw.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
            }

        }





    }
}
