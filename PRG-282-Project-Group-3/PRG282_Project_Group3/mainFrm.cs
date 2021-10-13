using PRG282_Project_Group3.BAC;
using PRG282_Project_Group3.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PRG282_Project_Group3
{
    public partial class mainFrm : Form
    {
        private Datahandler dataHandler = new Datahandler();
        private int displayValue = 0;
      
        private List<Students> studentsList = new List<Students>();
        private List<JoiningTable> studentModules = new List<JoiningTable>();
        private List<Modules> moduleList = new List<Modules>();
        private BindingSource bs = new BindingSource();
        private BusinessLogic businessLogic = new BusinessLogic();
        private Datahandler datahandler = new Datahandler();

        public mainFrm()
        {
            InitializeComponent();
            studentsList = datahandler.getStudents();
            moduleList = datahandler.getModules();
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
            int studID, index;
            string name, surname, dob, address, phone;
            char gender;
            Image img;

            index = dgvMain.CurrentCell.RowIndex;

            studID = studentsList[index].StudentID;
            name = studentsList[index].Name;
            surname = studentsList[index].Surname;
            dob = studentsList[index].Dob;
            address = studentsList[index].StudentAddress;
            gender = studentsList[index].Gender;
            img = studentsList[index].StudentImage;
            phone = studentsList[index].Phone;

            this.Hide();
            CaptureFrm captureFrm = new CaptureFrm(studID, name, surname, img, dob, gender, address, phone,1,studentModules); 
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

            businessLogic.DeleteUser(studentID);
            studentsList.Clear();
            studentsList = dataHandler.getStudents();
            bs.DataSource = studentsList;
            dgvMain.DataSource = bs;
            dgvMain.Refresh();
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (displayValue == 0)
            {
                int index = int.Parse((dgvMain.CurrentCell.RowIndex).ToString());

                studentModules = dataHandler.getJoiningTable(studentsList[index].StudentID);
                rtbxSummary.Clear();
                string modules = "";
                foreach (var item in studentModules)
                {
                    modules += "\n" + item.ModuleID.ToString();
                }
                pbStudent.Image = studentsList[index].StudentImage;
                rtbxSummary.Text = $"Student Number:\t{studentsList[index].StudentID}\nStudent Name:\t{studentsList[index].Name}\nStudent Surname:\t{studentsList[index].Surname}\nStudent Cell:\t{studentsList[index].Phone}\nModules:\n\t{modules}";
            }
            else if (displayValue == 1)
            {
                int index = int.Parse((dgvMain.CurrentCell.RowIndex).ToString());

           
                rtbxSummary.Clear();

                rtbxSummary.Text = $"Module Code:\t{moduleList[index].Code}\nModule Name:\t{moduleList[index].Name}\nModule Link:\t{moduleList[index].Link}\nModule Description:\t{moduleList[index].Description}";
                dgvMain.Focus();
            }
        }

        private void dgvMain_Click(object sender, EventArgs e)
        {
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text) == true)
            {
                MessageBox.Show("Please enter a value into the search bar before beginning search");
                tbSearch.Focus();
            }
            else
            {
                if (displayValue == 0)
                {
                    int searchID = int.Parse(tbSearch.Text);
                    foreach (var item in studentsList)
                    {
                        if (item.StudentID == searchID)
                        {
                            studentModules = dataHandler.getJoiningTable(item.StudentID);
                            string modules = "";
                            foreach (var module in studentModules)
                            {
                                modules += "\n" + module.ModuleID.ToString();
                            }
                            rtbxSummary.Text = $"Student Number:\t{item.StudentID}\nStudent Name:\t{item.Name}\nStudent Surname:\t{item.Surname}\nStudent Cell:\t{item.Phone}\nModules:\n\t{modules}";
                            pbStudent.Image = item.StudentImage;
                        }
                    }
                    tbSearch.Clear();
                }
                else if (displayValue == 1)
                {
                    string searchID = tbSearch.Text.ToUpper();
                    foreach (var item in moduleList)
                    {
                        if (item.Code == searchID)
                        {
                            rtbxSummary.Text = $"Module Code:\t{item.Code}\nModule Name:\t{item.Name}\nModule Link:\t{item.Link}\nModule Description:\t{item.Description}";
                        }
                    }
                    tbSearch.Clear();
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void btnShowStudent_Click(object sender, EventArgs e)
        {
            lblImage.Visible = true;
            bs.DataSource = studentsList;
            dgvMain.DataSource = bs;
            dgvMain.Refresh();
            rtbxSummary.Clear();
            displayValue = 0;
            btnUpdate.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            pbStudent.Image = null;
            lblSearch.Text = "Search by Student ID";
        }

        private void btnShowModule_Click(object sender, EventArgs e)
        {
            lblImage.Visible = false;
            bs.DataSource = moduleList;
            dgvMain.DataSource = bs;
            dgvMain.Refresh();
            rtbxSummary.Clear();
            displayValue = 1;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            pbStudent.Image = null;
            lblSearch.Text = "Search by Module Code";
        }
    }
}