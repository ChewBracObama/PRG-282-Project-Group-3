using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project_Group3
{
    public class JoiningTable
    {
        int studentsModulesID;
        int studentID;
        string moduleID;

        public JoiningTable(int studentsModulesID, int studentID, string moduleID)
        {
            this.StudentsModulesID = studentsModulesID;
            this.StudentID = studentID;
            this.ModuleID = moduleID;
        }
        public JoiningTable()
        {


        }

        public int StudentsModulesID { get => studentsModulesID; set => studentsModulesID = value; }
        public int StudentID { get => studentID; set => studentID = value; }
        public string ModuleID { get => moduleID; set => moduleID = value; }
    }
}
