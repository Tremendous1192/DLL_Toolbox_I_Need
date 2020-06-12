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
        /// Directoryを変更する。
        /// デスクトップはEnvironment.GetFolderPath(Environment.SpecialFolder.Desktop)
        /// </summary>
        /// <param name="New_Directory"></param>
        public void Change_Directory(string New_Directory)
        {
            System.IO.Directory.SetCurrentDirectory(New_Directory);
        }

        /// <summary>
        /// Directoryを変更する。
        /// デスクトップはEnvironment.GetFolderPath(Environment.SpecialFolder.Desktop)
        /// </summary>
        /// <param name="New_Directory"></param>
        public void Change_Directory_to_DeskTop()
        {
            System.IO.Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }




    }
}
