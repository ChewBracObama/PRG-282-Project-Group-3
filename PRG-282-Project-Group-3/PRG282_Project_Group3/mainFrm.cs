using PRG282_Project_Group3.BAC;
using PRG282_Project_Group3.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PRG282_Project_Group3
{
    public partial class mainFrm : Form
    {
        private Datahandler dataHandler = new Datahandler();

        private string[] modules = { "PRG281", "DBD281", "MAT282", "WPR181", "STA281", "LPR282", "MAT281" };
        private List<Students> studentsList = new List<Students>();
        private BindingSource bs = new BindingSource();
        private BusinessLogic businessLogic = new BusinessLogic();
        private Datahandler datahandler = new Datahandler();

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
            studentsList = datahandler.getStudents();
            bs.DataSource = studentsList;
            dgvMain.DataSource = bs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaptureFrm captureFrm = new CaptureFrm(0);
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
            CaptureFrm captureFrm = new CaptureFrm(1);
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
            int studentID = int.Parse(studentsList[index].StudentID.ToString());
            MessageBox.Show(studentID.ToString());

            businessLogic.DeleteUser(studentID);
            studentsList.Clear();
            studentsList = dataHandler.getStudents();
            bs.DataSource = studentsList;
            dgvMain.DataSource = bs;
            dgvMain.Refresh();
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string name, surname, gender, dob, phone, address;
            string[] modules;
            pbStudent.Image = studentsList[dgvMain.CurrentCell.RowIndex].StudentImage;
            rtbxSummary.Text = studentsList[dgvMain.CurrentCell.RowIndex].Name;
        }

        private void dgvMain_Click(object sender, EventArgs e)
        {
            //Consider changing RichTextBox to a listview to display easier
            string studID,name, surname, gender, dob, phone, address;

            rtbxSummary.Clear();
            rtbxSummary.Text = studentsList[dgvMain.CurrentCell.RowIndex].StudentID.ToString();
        }
    }
}