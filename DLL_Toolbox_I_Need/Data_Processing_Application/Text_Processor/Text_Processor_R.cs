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
        /// txtデータを読み込む。string[]を読み込む。
        /// </summary>
        /// <param name="txt_file_name"></param>
        /// <returns></returns>
        public string[] Read_text(string txt_file_name)
        {
            string path = System.IO.Path.Combine(this.Get_Current_Directory(), txt_file_name);

            //.Net CoreでShift_JISを使用するため
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(txt_file_name);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            List<string> temp = new List<string>();

            System.IO.StreamReader file;
            try
            {
                //file = new System.IO.StreamReader(stream, sjisEnc);
                file = File.OpenText(path);

                string line = "";
                // test.txtを1行ずつ読み込んでいき、末端(何もない行)までtempに格納する
                while ((line = file.ReadLine()) != null)
                {
                    temp.Add(line);
                }
                file.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
                var a = new string[1];
                a[0] = "No data";
                return a;
            }


            if (temp[temp.Count - 1] == "")
            {
                temp.RemoveAt(temp.Count - 1);
            }
            return temp.ToArray();
        }


        /// <summary>
        /// txtデータを読み込む。string[,]を読み込む。
        /// カンマ , 区切りでデータを取り出す。
        /// </summary>
        /// <param name="txt_file_name"></param>
        /// <returns></returns>
        public string[,] Read_text_2dim_Split_by_camma(string txt_file_name)
        {
            string path = System.IO.Path.Combine(this.Get_Current_Directory(), txt_file_name);

            //.Net CoreでShift_JISを使用するため
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(txt_file_name);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            List<string> temp = new List<string>();

            System.IO.StreamReader file;
            try
            {
                //file = new System.IO.StreamReader(stream, sjisEnc);
                file = File.OpenText(path);

                string line = "";
                // test.txtを1行ずつ読み込んでいき、末端(何もない行)までtempに格納する
                while ((line = file.ReadLine()) != null)
                {
                    temp.Add(line);
                }
                file.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
                var a = new string[1, 1];
                a[0, 0] = "No data";
                return a;
            }


            if (temp[temp.Count - 1] == "")
            {
                temp.RemoveAt(temp.Count - 1);
            }

            int max_column = 1;
            for (int j = 0; j < temp.Count; j++)
            {
                max_column = Math.Max(max_column, temp[j].Split(',').Length);
            }

            string[,] result = new string[temp.Count, max_column];
            for (int j = 0; j < temp.Count; j++)
            {
                string[] row = temp[j].Split(',');
                for (int k = 0; k < row.Length; k++)
                {
                    result[j, k] = row[k];
                }
            }
            return result;
        }




    }
}
