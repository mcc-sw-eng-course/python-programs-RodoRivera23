using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPowerList
{
    public class myPowerList
    {
        public string ReadFromTexFile(string filename)
        {
            String text = "";
            try
            {
                string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(desktop_path + "\\" + filename))
                {
                    text = sr.ReadToEnd();
                }
                return text;
            }
            catch (IOException e)
            {
                return "Error al tratar de leer el archivo";
            }

        }
    }
}
