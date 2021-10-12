using System.IO;
using System.Windows.Forms;

namespace PRG282_Project_Group3.Data_Access_Layer
{
    internal class Filehandler
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

        public bool RegisterUser(string file, string username, string pass, bool accountCreated)
        {
            using (StreamWriter writer = new StreamWriter(file, append: true))
            {
                writer.WriteLine($"{username};{pass}");
                writer.Close();
                accountCreated = true;
                MessageBox.Show("Created");
                return accountCreated;
            }
        }
    }
}