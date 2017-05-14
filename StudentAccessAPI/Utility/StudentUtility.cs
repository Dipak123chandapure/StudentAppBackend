using System;
using StudentAccessAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace StudentAccessAPI.Utility
{
    public class StudentUtility
    {
        public static Student getStudentFormReader(SqlDataReader reader) {

            Student student = new Student();
            student.Form1Entity1 = reader[1] as string; 
            student.Form1Entity2 = reader[2] as string; 
            student.Form1Entity3 = reader[3] as string; 
            student.Form1Entity4 = reader[4] as string; 

            student.Form2Entity1Id = (reader[5] as int?) ?? null;
            student.Form2Entity2Id = (reader[6] as int?) ?? null;
            student.Form2Entity3Id = (reader[7] as int?) ?? null;
            student.Form2Entity4Id = (reader[8] as int?) ?? null;

            student.Form3Entity1Id = (reader[9] as int?) ?? null;
            student.Form3Entity2Id = (reader[10] as int?) ?? null;
            student.Form3Entity3Id = (reader[11] as int?) ?? null;
            student.Form3Entity4Id = (reader[12] as int?) ?? null;
            student.Form3Entity5 = reader[13] as string ;
            student.Form3Entity6 = reader[14] as string ;
            student.Form3Entity7 = reader[15] as string ;

            student.Form4Entity1Id = (reader[16] as int?) ?? null;
            student.Form4Entity2Id = (reader[17] as int?) ?? null;
            student.Form4Entity3Id = (reader[18] as int?) ?? null;
            student.Form4Entity4Id = (reader[19] as int?) ?? null;
            student.Form4Entity5 = reader[20] as string;
            student.Form4Entity6 = reader[21] as string;
            student.Form4Entity7 = reader[22] as string;

            return student;
        }

        internal static bool checkForValidStudent(out string value, Student student)
        {
            if (student.Form1Entity1 == null) {
                value = "First Name is Not valid";
                return false;
            }

            if (student.Form1Entity3 == null || !student.Form1Entity3.Contains("@"))
            {
                value = "Email is Not valid";
                return false;
            }

            if (student.Form1Entity4 == null || !(student.Form1Entity4.Length != 10))
            {
                value = "Email is Not valid";
                return false;
            }


            if (student.Form2Entity1Id == null )
            {
                value = "Form2Entity1Id is Not valid";
                return false;
            }

            if (student.Form2Entity2Id == null)
            {
                value = "Form2Entity2Id is Not valid";
                return false;
            }

            if (student.Form2Entity2Id == null)
            {
                value = "Form2Entity3Id is Not valid";
                return false;
            }

            if (student.Form2Entity4Id == null)
            {
                value = "Form2Entity4Id is Not valid";
                return false;
            }

            value = "Successfully checked";
            return true;
        }
    }
}
