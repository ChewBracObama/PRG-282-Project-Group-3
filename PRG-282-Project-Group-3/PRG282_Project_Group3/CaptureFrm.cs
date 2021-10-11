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

        Image studentImage;
        public CaptureFrm()
        {
            InitializeComponent();
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
                button1.BackColor = Color.Green;
                button1.Text = "Uploaded";
            }
            else
            {
                button1.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //List<Students> students = new List<Students>();
            // students= datahandler.getStudents();
            string StudentId = textBox1.Text;
            string name = textBox2.Text;
            string surname = surnameTbox.Text;
            string phone = textBox3.Text;
            char gender = 'n';
            string address = textBox4.Text;
            string dob = dateTimePicker1.Text;
            string moduleCode = comboBox1.Text;
           
            if (radioButton1.Checked==true)
            {
                gender = 'M';
            }
            else if(radioButton2.Checked==true)
            {
                gender = 'F';
            }

        
            MessageBox.Show(businessLogic.checkCapture(StudentId, name, surname, studentImage, gender, dob, phone, address,moduleCode).ToString());
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
    }
}
