using PRG282_Project_Group3.BAC;
using PRG282_Project_Group3.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PRG282_Project_Group3
{
    public partial class CaptureFrm : Form
    {
        private BusinessLogic businessLogic = new BusinessLogic();
        private Datahandler datahandler = new Datahandler();

        private int function = 0;
        
        private Image studentImage;

        public CaptureFrm(int var)
        {
            InitializeComponent();
            function = var;
        }

        public CaptureFrm(int StudentID, string name, string surname, Image img, string dob, char gender, string address, string phone, int function, List<JoiningTable> moduleList)
        {
            InitializeComponent();
            if (function == 1)
                tbxStudentNum.Enabled = false;
            else tbxStudentNum.Enabled = true;
            
            this.function = function;
            tbxStudentNum.Text = StudentID.ToString();
            tbxName.Text = name;
            tbxSurname.Text = surname;
            dtpDOB.Value = DateTime.Parse(dob);
            if (gender == 'M')
            {
                rbtnMale.Checked = true;
            }
            else
            {
                rbtFemale.Checked = true;
            }
            tbxAddress.Text = address;
            tbxPhone.Text = phone;
 
            foreach (JoiningTable element in moduleList)
            {   
                for (int x = 0; x < checkedListBox1.Items.Count; x++)
                {
                    if (checkedListBox1.Items[x].ToString() == element.ModuleID.ToString())
                    {
                        checkedListBox1.SetItemChecked(x, true);
                    }
                }
            }

            studentImage = img;
            btnImgUpload.BackColor = Color.Green;
            btnImgUpload.Text = "Uploaded";
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Pictures\";
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                studentImage = Image.FromFile(ofd.FileName);
                btnImgUpload.BackColor = Color.Green;
                btnImgUpload.Text = "Uploaded";
            }
            else
            {
                btnImgUpload.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string StudentId = tbxStudentNum.Text;
            string name = tbxName.Text;
            string surname = tbxSurname.Text;
            string phone = tbxPhone.Text;
            char gender = 'n';
            string address = tbxAddress.Text;
            string dob = dtpDOB.Text;
            List<string> moduleCodes = new List<string>();

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                moduleCodes.Add(checkedListBox1.CheckedItems[i].ToString());
            }

            if (rbtnMale.Checked == true)
            {
                gender = 'M';
            }
            else if (rbtFemale.Checked == true)
            {
                gender = 'F';
            }

            if (businessLogic.checkCapture(StudentId, name, surname, studentImage, gender, dob, phone, address, moduleCodes, function))
            {
                if (function == 0)
                    MessageBox.Show("User added successfully");

                if (function == 1)
                    MessageBox.Show("User updated successfully");

                this.Hide();
                mainFrm main = new mainFrm();
                main.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Transaction failed");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainFrm mainFrm = new mainFrm();
            mainFrm.ShowDialog();
            this.Close();
        }

        private void CaptureFrm_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}