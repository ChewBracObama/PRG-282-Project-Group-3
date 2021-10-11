﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PRG282_Project_Group3.Data_Access_Layer
{
    internal class Datahandler
    {
        private SqlConnection connection;

        public Datahandler()
        {
            string connectionString = @"Data Source=DESKTOP-T23DGMJ\SQLEXPRESS;Initial Catalog=PRG282_Project1;Integrated Security=True";
            this.connection = new SqlConnection(connectionString);
        }

        public void insertStudent(string StudentId, string name, string surname, Image studentImg, char gender, string dob, string phone, string address, string ModuleCode)
        {
            connection.Open();
            //below values should be subbed with actual var after validation
            string qryimgUpload = string.Format("INSERT INTO Students(Name,Surname,StudentImage,Gender,DOB,Phone,StudentAddress) VALUES('{0}','{1}',@P_Image,'{2}','{3}','{4}','{5}')", name, surname, gender, dob, phone, address);
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
                            
                    }
                }
            }
            connection.Close();
            return studentsList;
        }
    }
}