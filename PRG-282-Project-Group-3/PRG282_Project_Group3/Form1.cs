using PRG282_Project_Group3.BAC;
using PRG282_Project_Group3.Data_Access_Layer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PRG282_Project_Group3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isUser = BusinessLogic.checkDetails(Filehandler.getUserDetails(), tbUsername.Text, mtbPass.Text);

            if (!Filehandler.getUserDetails().Any<string>())
            {
                MessageBox.Show("No users exist currently. Redirecting to the register page");

                this.Hide();
                RegisterForm registerForm = new RegisterForm();
                registerForm.ShowDialog();
                this.Close();
            }

            if (isUser)
            if (isUser)
            {
                this.Hide();
                mainFrm mainFrm = new mainFrm();
                mainFrm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
   
        }
    }
}