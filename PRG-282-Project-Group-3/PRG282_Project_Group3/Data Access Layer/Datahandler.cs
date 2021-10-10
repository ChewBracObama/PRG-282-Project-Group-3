using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project_Group3.Data_Access_Layer
{
    class Datahandler
    {
        SqlConnection connection;

        public Datahandler()
        {
            string connectionString = @"Data Source=DESKTOP-DMOGBGT\MSSQLSERVERBLG;Initial Catalog=PRG282_Project1;Integrated Security=True";
            this.connection = new SqlConnection(connectionString);
        }
        
        public void insertStudent()
        {
            connection.Open();
            //below values should be subbed with actual var after validation
            string qryimgUpload = "INSERT INTO Students(Name,Surname,StudentImage,Gender,DOB,Phone,StudentAddress) VALUES('Martin','Erasmus',@P_Image,'M','17/09/1999','0817219965','15 Fourth Rd Bredell')";
            SqlCommand command = new SqlCommand(qryimgUpload, connection);

            Image image = Image.FromFile(@"C:\Users\Martin\Documents\Belguim\2nd Year\PRG282\saved_images\0.jpg");
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            byte[] photoArray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photoArray, 0, photoArray.Length);
            command.Parameters.AddWithValue("@P_Image", photoArray);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Students> getStudents()
        {
            

            List<Students> studentsList = new List<Students>();
            string query = "SELECT * FROM Students;";
            if (connection.State!=ConnectionState.Open)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] imgData = (byte[])reader["StudentImage"];
                        Image studentImage;
                        using (MemoryStream ms = new MemoryStream(imgData))
                        {
                            studentImage = Image.FromStream(ms);
                        }
                        studentsList.Add(new Students(
                            int.Parse(reader[0].ToString()),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            studentImage,
                            char.Parse(reader[4].ToString()),
                            reader[5].ToString(),
                            reader[6].ToString(),
                            reader[7].ToString()
                            ));
                    }
                }

            }
            connection.Close();
            return studentsList;

        }
    }
}
