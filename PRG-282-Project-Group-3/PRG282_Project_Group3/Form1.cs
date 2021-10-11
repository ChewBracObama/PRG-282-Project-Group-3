using PRG282_Project_Group3.Data_Access_Layer;
using PRG282_Project_Group3.BAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
    }
}
