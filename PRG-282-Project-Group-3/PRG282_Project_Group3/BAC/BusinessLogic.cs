using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project_Group3.BAC
{
    class BusinessLogic
    {
        public static bool checkDetails(string[] detailsArray, string username, string password)
        {
            bool result = false;
            foreach (string line in detailsArray)
            {
                string[] usernamePass = line.Split(char.Parse(";"));
                if (username == usernamePass[0] && password == usernamePass[1])
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
