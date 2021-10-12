using PRG282_Project_Group3.BAC;
using PRG282_Project_Group3.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Project_Group3
{
    public partial class CaptureFrm : Form
    {
        BusinessLogic businessLogic = new BusinessLogic();
        Datahandler datahandler = new Datahandler();

        int function = 0;
        Image studentImage;
        public CaptureFrm(int var)
        {
            InitializeComponent();
            function = var;
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
                btnImg.BackColor = Color.Green;
                btnImg.Text = "Uploaded";
            }
            else
            {
                btnImg.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //List<Students> students = new List<Students>();
            // students= datahandler.getStudents();
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
            foreach (var item in moduleCodes)
            {
                MessageBox.Show(item.ToString());
            }

            if (rbtnMale.Checked==true)
            {
                gender = 'M';
            }
            else if(rbtnFemale.Checked==true)
            {
                gender = 'F';
            }

            if (businessLogic.checkCapture(StudentId, name, surname, studentImage, gender, dob, phone, address, moduleCodes, function))
            {
                if (function == 0)
                    MessageBox.Show("User added successfully");

                if (function == 1)
                    MessageBox.Show("User updated successfully");

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
