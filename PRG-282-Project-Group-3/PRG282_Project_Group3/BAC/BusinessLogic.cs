﻿using PRG282_Project_Group3.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool checkCapture(string StudentId,string name,string surname,Image studentImg,char gender,string dob, string phone,string address,string ModuleCode)
        {
            Regex regexNum = new Regex("^[0-9]+$");
            Regex regexWords = new Regex(@"^[a-zA-Z]+$");
            if (regexNum.IsMatch(StudentId)==true)
            {
                if ((regexWords.IsMatch(name)==true && name!=null)&& (regexWords.IsMatch(surname) == true && surname != null))
                {
                    if ((regexNum.IsMatch(phone) == true)&& (phone.Length==10)&& phone!=null)
                    {
                        if (studentImg!=null && gender!='n' && address !="" && ModuleCode!="")
                        {
                            Datahandler datahandler =new Datahandler();
                            datahandler.insertStudent(StudentId, name, "Erasmus", studentImg, gender,dob, phone, address);
                            datahandler.insertModule(StudentId, ModuleCode);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }
    }
}
