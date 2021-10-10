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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool accountCreated = false;
            

            string file = @".\UserDetails.txt";

            do
            {
                string username = tbxUsername.Text;
                string pass = tbxPass.Text;
                string passRepeat = tbxPassRepeat.Text;
                int passlength = tbxPass.Text.Length;

                if (File.Exists(file) == true)
                {
                    if ((passlength >= 8) && (pass == passRepeat))
                    {
                        using (StreamWriter writer = new StreamWriter(file, append: true))
                        {
                            writer.WriteLine($"{username};{pass}");
                            writer.Close();
                            accountCreated = true;
                            MessageBox.Show("Created");

                            this.Hide();
                            Form1 login = new Form1();
                            login.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("naught");
                        tbxUsername.Clear();
                        tbxPass.Clear();
                        tbxPassRepeat.Clear();
                        break;
                    }
                }
                else
                {
                    if ((passlength >= 8) && (pass == passRepeat))
                    {
                        File.Create(file);
                        using (StreamWriter writer = new StreamWriter(file, append: true))
                        {
                            writer.WriteLine($"{username};{pass}");
                            writer.Close();
                            accountCreated = true;
                            MessageBox.Show("Created");

                            this.Hide();
                            Form1 login = new Form1();
                            login.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("naught");
                        tbxUsername.Clear();
                        tbxPass.Clear();
                        tbxPassRepeat.Clear();
                        break;
                    }
                }
            } while (accountCreated == false);
           
        }
    }
}
