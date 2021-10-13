using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PRG282_Project_Group3.Data_Access_Layer
{
    internal class Datahandler
    {
        private SqlConnection connection;
        public List<JoiningTable> modules = new List<JoiningTable>();

        public Datahandler()
        {
            string connectionString = @"Data Source=(local);Initial Catalog=PRG282_Project1;Integrated Security=True";
            this.connection = new SqlConnection(connectionString);
        }

        public void insertStudent(string StudentId, string name, string surname, Image studentImg, char gender, string dob, string phone, string address)
        {
            connection.Open();
            string qryimgUpload = string.Format("INSERT INTO Students(StudentID,Name,Surname,StudentImage,Gender,DOB,Phone,StudentAddress) VALUES({0},'{1}','{2}',@P_Image,'{3}','{4}','{5}','{6}')", StudentId, name, surname, gender, dob, phone, address);
            SqlCommand command = new SqlCommand(qryimgUpload, connection);

            Image image = studentImg;
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            byte[] photoArray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photoArray, 0, photoArray.Length);
            command.Parameters.AddWithValue("@P_Image", photoArray);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void insertModule(string StudentId, string ModuleCode)
        {
            connection.Open();
            //below values should be subbed with actual var after validation
            string query = string.Format("INSERT INTO StudentsModules(StudentID,ModuleID) VALUES({0},'{1}')", StudentId, ModuleCode);
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Modules> getModules()
        {
            List<Modules> ModuleList = new List<Modules>();
            string querygetModule = "SELECT * FROM Modules;";
            SqlCommand getModule_cmd = new SqlCommand(querygetModule, connection);
            connection.Open();
            using (var moduleReader = getModule_cmd.ExecuteReader())
            {
                while (moduleReader.Read())
                {
                    if (true)
                    {
                        ModuleList.Add(new Modules(moduleReader[0].ToString(), moduleReader[1].ToString(), moduleReader[2].ToString(), moduleReader[3].ToString()));
                    }
                }

            }
            connection.Close();
            return ModuleList;
        }


        public List<JoiningTable> getJoiningTable(int StudentId)
        {
            List<JoiningTable> StudentModuleList = new List<JoiningTable>();
            string querygetModule = string.Format("SELECT * FROM StudentsModules WHERE StudentID={0};", StudentId);
            SqlCommand getModule_cmd = new SqlCommand(querygetModule, connection);
            connection.Open();
            using (var moduleReader = getModule_cmd.ExecuteReader())
            {
                while (moduleReader.Read())
                {
                        StudentModuleList.Add(new JoiningTable(int.Parse(moduleReader[0].ToString()),int.Parse(moduleReader[1].ToString()), moduleReader[2].ToString()));
                }

            }
            connection.Close();
            return StudentModuleList;
       
        }
        public List<Students> getStudents()
        {
            List<Students> studentsList = new List<Students>();
     
            string query = "SELECT * FROM Students;";

            if (connection.State != ConnectionState.Open)
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

        public void updateStudents(string studentID, string name, string surname, Image img, char gender, string dob, string phone, string address, List<string> modules)
        {
            string mainQry = $"UPDATE Students SET Name='{name}', Surname='{surname}', StudentImage=@P_Image, Gender='{gender}', DOB='{dob}', Phone='{phone}', StudentAddress='{address}' WHERE StudentID={studentID}";
            string deleteModules = $"DELETE StudentsModules WHERE StudentID={studentID}";

            SqlCommand cmd = new SqlCommand(deleteModules, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            cmd.CommandText = mainQry;

            Image image = new Bitmap(img);
            MemoryStream ms = new MemoryStream();

            image.Save(ms, ImageFormat.Jpeg);

            byte[] photoArray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photoArray, 0, photoArray.Length);
            cmd.Parameters.AddWithValue("@P_Image", photoArray);
            cmd.ExecuteNonQuery();
            connection.Close();

            foreach (var item in modules)
            {
                insertModule(studentID, item);
            }
        }

        public void deleteStudent(int StudentID)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();

                string deleteModulequery = $"DELETE FROM StudentsModules WHERE StudentID = {StudentID}";
                SqlCommand cmd = new SqlCommand(deleteModulequery, connection);

                cmd.ExecuteNonQuery();

                string query = $"DELETE FROM Students WHERE StudentID = {StudentID}";
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                ;
            }
            connection.Close();
        }
    }
}

//⠀⠀⠀⠀⣠⣶⡾⠏⠉⠙⠳⢦⡀⠀⠀⠀⢠⠞⠉⠙⠉⠙⠲⡀⠀
//⠀⠀⠀⣴⠿⠏⠀⠀⠀⠀⠀⠀ ⢳⡀⠀⡏⠀⠀⠀⠀ ⠀   ⢷
//⠀⠀⢠⣟⣋⡀⢀⣀⣀⡀⠀⣀⡀⣧⠀⢸⠀⠀⠀⠀⠀     ⡇
//⠀⠀⢸⣯⡭⠁⠸⣛⣟⠆⡴⣻⡲⣿⠀⣸⠀⠀Group 3⠀⡇
//⠀⠀⣟⣿⡭⠀⠀⠀⠀⠀⢱⠀⠀ ⣿⠀⢹⠀⠀⠀Code.⠀ ⡇
//⠀⠀⠙⢿⣯⠄⠀⠀⠀⢀⡀⠀⠀⡿⠀⠀⡇⠀⠀⠀⠀    ⡼
//⠀⠀⠀⠀⠹⣶⠆⠀⠀⠀⠀⠀⡴⠃⠀⠀⠘⠤⣄⣠⣄⣠⣄⠞⠀
//⠀⠀⠀⠀⠀⢸⣷⡦⢤⡤⢤⣞⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⢀⣤⣴⣿⣏⠁⠀⠀⠸⣏⢯⣷⣖⣦⡀⠀⠀⠀⠀⠀⠀
//⢀⣾⣽⣿⣿⣿⣿⠛⢲⣶⣾⢉⡷⣿⣿⠵⣿⠀⠀⠀⠀⠀⠀
//⣼⣿⠍⠉⣿⡭⠉⠙⢺⣇⣼⡏⠀⠀⠀⣄⢸⠀⠀⠀⠀⠀⠀
//⣿⣿⣧⣀⣿.........⣀⣰⣏⣘⣆⣀