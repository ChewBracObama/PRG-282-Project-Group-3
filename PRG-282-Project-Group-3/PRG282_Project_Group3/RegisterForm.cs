using PRG282_Project_Group3.Data_Access_Layer;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PRG282_Project_Group3
{
    public partial class RegisterForm : Form
    {
        private Filehandler fileHandler = new Filehandler();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            createForm1();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string invalidPassChars = "[\"';]";
            Regex invalidChars = new Regex(invalidPassChars);

            bool accountCreated = false;

            string username = tbxUsername.Text;
            string pass = tbxPass.Text;
            string passRepeat = tbxPassRepeat.Text;
            int passlength = tbxPass.Text.Length;

            string file = @".\UserDetails.txt";

            do
            {
                if (string.IsNullOrEmpty(username) == true || string.IsNullOrEmpty(pass) == true || string.IsNullOrEmpty(passRepeat) == true)
                {
                    MessageBox.Show("One or more of the entries is empty");
                    tbxUsername.Clear();
                    tbxPass.Clear();
                    tbxPassRepeat.Clear();
                    break;
                }
                else
                {
                    if (invalidChars.IsMatch(pass) == true || invalidChars.IsMatch(username) == true)
                    {
                        MessageBox.Show("No Semi-Colons (;), Double Quotation Marks (\"\") or Single Quotation Marks ('') allowed in Username or Password");
                        tbxUsername.Clear();
                        tbxPass.Clear();
                        tbxPassRepeat.Clear();
                        break;
                    }
                    else
                    {
                        if (File.Exists(file) == true)
                        {
                            if ((passlength >= 8) && (pass == passRepeat))
                            {
                                accountCreated = fileHandler.RegisterUser(file, username, pass, accountCreated);

                                createForm1();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Invalid details entered. Please try again");
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

                                accountCreated = fileHandler.RegisterUser(file, username, pass, accountCreated);

                                createForm1();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Invalid details entered. Please try again");
                                tbxUsername.Clear();
                                tbxPass.Clear();
                                tbxPassRepeat.Clear();
                                break;
                            }
                        }
                    }
                }
                
            } while (accountCreated == false);
        }

        private void createForm1()
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Close();
        }
    }
}