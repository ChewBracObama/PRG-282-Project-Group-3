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
        public CaptureFrm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Datahandler datahandler = new Datahandler();
          
            //List<Students> students = new List<Students>();
            // students= datahandler.getStudents();

            BusinessLogic businessLogic = new BusinessLogic();
            string StudentId = textBox1.Text;
            string name = textBox2.Text;
            string phone = textBox3.Text;
            char gender = 'n';
            string address = textBox4.Text;
            string dob = dateTimePicker1.Text;
           
            if (radioButton1.Checked==true)
            {
                gender = 'M';
            }
            else if(radioButton2.Checked==true)
            {
                gender = 'F';
            }

            Image image = Image.FromFile(@"C:\Users\Martin\Documents\Belguim\2nd Year\PRG282\saved_images\martin.jpg");
            MessageBox.Show(businessLogic.checkCapture(StudentId, name, "Erasmus", image, gender, dob, phone, address, "PRG282").ToString());
            //mainFrm mainFrm = new mainFrm(students); //test passing StudentList
            // mainFrm mainFrm = new mainFrm();
            // mainFrm.ShowDialog();
            // this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainFrm mainFrm = new mainFrm();
            mainFrm.ShowDialog();
            this.Close();
        }
    }
}
