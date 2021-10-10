using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Project_Group3.Data_Access_Layer
{
    class Datahandler
    {
        SqlConnection connection;

        public Datahandler()
        {
            string connectionString = @"Data Source=DESKTOP-DMOGBGT\MSSQLSERVERBLG;Initial Catalog=PRG282_Project1;Integrated Security=True";
            this.connection = new SqlConnection(connectionString); ;
        }

        public void getStudents()
        {
            List<Students> studentsList = new List<Students>();
            string query = "SELECT * FROM Students;";
            if (connection.State!=ConnectionState.Open)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using(var reader = command.ExecuteReader())
                {
                    byte[] imgData = (byte[])reader["StudentImage"];
                    Image studentImage;
                    using (MemoryStream ms= new MemoryStream(imgData))
                    {
                        studentImage = Image.FromStream(ms);
                    }
                        studentsList.Add(new Students(
                            int.Parse(reader[0].ToString()),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            studentImage,
                            char.Parse(reader[4].ToString()),
                            DateTime.Parse(reader[5].ToString()),
                            reader[6].ToString(),
                            reader[7].ToString()
                            ));
                }

            }

        }
    }
}
