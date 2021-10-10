using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PRG282_Project_Group3.Data_Access_Layer
{
    class Filehandler
    {
        public static string[] getUserDetails()
        {
            string path = @".\UserDetails.txt";

            if (checkFileExists(path))
            {
                string[] details = File.ReadAllLines(path);

                return details;
            }
            return new string[] { };

        }
        private static bool checkFileExists(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            return File.Exists(path);
        }
    }
}
