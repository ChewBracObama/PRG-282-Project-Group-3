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
    public partial class mainFrm : Form
    {
        string[] modules = { "PRG281","DBD281","MAT282","WPR181","STA281","LPR282","MAT281"};
        public mainFrm()
        {
            InitializeComponent();
            clbModules.Items.AddRange(modules);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaptureFrm captureFrm = new CaptureFrm();
            captureFrm.ShowDialog();
            this.Close();
        }

        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Pictures\";
            ofd.ShowDialog();

            pbStudent.ImageLocation = ofd.FileName;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Close();
        }
    }
}
