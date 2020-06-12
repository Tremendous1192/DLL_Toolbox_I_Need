using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace DLL_Toolbox_I_Need.Data_Processing_Application
{
    public partial class Text_Processor
    {

        /// <summary>
        /// 現在のDirectoryにあるファイル名を全て取得する
        /// </summary>
        /// <returns></returns>
        public string[] Get_File_Name_All_type()
        {
            string[] files = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory());
            if (files.Length < 1) { Console.WriteLine("No file is here ."); return new string[1]; }

            for (int i = 0; i < files.GetLength(0); i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]) + Path.GetExtension(files[i]);
            }
            return files;
        }



        /// <summary>
        /// 現在のDirectoryにあるtxtデータのファイル名を全て取得する
        /// </summary>
        /// <returns></returns>
        public string[] Get_File_Name_txt_type()
        {
            string[] files = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory());
            if (files.Length < 1) { Console.WriteLine("No file is here ."); return new string[1]; }

            List<string> temp_List = new List<string>();
            for (int i = 0; i < files.GetLength(0); i++)
            {
                if (Path.GetExtension(files[i]) == ".txt")
                {
                    temp_List.Add(Path.GetFileNameWithoutExtension(files[i]) + Path.GetExtension(files[i]));
                }
            }

            if (temp_List.Count < 1) { Console.WriteLine("No .txt file is here ."); return new string[1]; }

            return temp_List.ToArray();
        }


        /// <summary>
        /// 現在のdirectoryを取得する。
        /// </summary>
        /// <returns></returns>
        public string Get_Current_Directory()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }


    }
}
