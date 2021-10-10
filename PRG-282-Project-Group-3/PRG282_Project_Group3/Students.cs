using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project_Group3
{
    class Students
    {
        int studentID;
        string name;
        string surname;
        Image studentImage;
        char gender;
        DateTime dob;
        string phone;
        string studentAddress;

        public Students(int studentID, string name, string surname, Image studentImage, char gender, DateTime dob, string phone, string studentAddress)
        {
            this.StudentID = studentID;
            this.Name = name;
            this.Surname = surname;
            this.StudentImage = studentImage;
            this.Gender = gender;
            this.Dob = dob;
            this.Phone = phone;
            this.StudentAddress = studentAddress;
        }

        public int StudentID { get => studentID; set => studentID = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public Image StudentImage { get => studentImage; set => studentImage = value; }
        public char Gender { get => gender; set => gender = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Phone { get => phone; set => phone = value; }
        public string StudentAddress { get => studentAddress; set => studentAddress = value; }
    }
}
