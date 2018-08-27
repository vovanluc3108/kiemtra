using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace kiemtrathuwinform.BussinessLogicLayer
{
    class CommonBL
    {
        public string upload(string fileName)
        {
            if (!Directory.Exists(Application.StartupPath + "\\image"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\image");
            }
            string file = Path.GetFileName(fileName);
            string path = Application.StartupPath + "\\image" + file;
            if (File.Exists(path))
            {
                File.Copy(fileName, path);
            }
            return file;
        }
    }
}
