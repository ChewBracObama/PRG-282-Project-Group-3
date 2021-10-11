using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG282_Project_Group3.BAC;
using PRG282_Project_Group3.Data_Access_Layer;

namespace PRG282_Project_Group3
{
    public partial class mainFrm : Form
    {
        Datahandler dataHandler = new Datahandler();


        string[] modules = { "PRG281","DBD281","MAT282","WPR181","STA281","LPR282","MAT281"};
        List<Students> studentsList = new List<Students>();
        //public mainFrm(List<Students> students)
        //{
        //    studentsList = students;                               // testing list pass from capture
        //    Image image = studentsList[0].StudentImage;
        //    pbStudent.Bit = image;
        //    MessageBox.Show(image.ToString());
        //    InitializeComponent();
        //}
        public mainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaptureFrm captureFrm = new CaptureFrm();
            captureFrm.ShowDialog();
            this.Close();
        }

        private void btnUploadImg_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaptureFrm captureFrm = new CaptureFrm();
            captureFrm.ShowDialog();
            this.Close();
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            studentsList = dataHandler.getStudents();
        }

        private void pbStudent_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dgvMain.CurrentCell.RowIndex;
            int studentID = int.Parse(dgvMain[0,index].ToString());

            
        }
    }
}
