using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StudentAccessAPI.Models;
using StudentAccessAPI.Utility;
using System.Data;


namespace StudentAccessAPI.Database
{
    public class StudentTable
    {
        private static String STUDENT_TABLE = "[dbo].[student]";
        private static String ID = "id";
        private static String FORM_1_ENTITY_1 = "form1entity1";
        private static String FORM_1_ENTITY_2 = "form1entity2";
        private static String FORM_1_ENTITY_3 = "form1entity3";
        private static String FORM_1_ENTITY_4 = "form1entity4";

        private static String FORM_2_ENTITY_1_ID = "form2entity1Id";
        private static String FORM_2_ENTITY_2_ID = "form2entity2Id";
        private static String FORM_2_ENTITY_3_ID = "form2entity3Id";
        private static String FORM_2_ENTITY_4_ID = "form2entity4Id";

        private static String FORM_3_ENTITY_1_ID = "form3entity1Id";
        private static String FORM_3_ENTITY_2_ID = "form3entity2Id";
        private static String FORM_3_ENTITY_3_ID = "form3entity3Id";
        private static String FORM_3_ENTITY_4_ID = "form3entity4Id";
        private static String FORM_3_ENTITY_5 = "form3entity5";
        private static String FORM_3_ENTITY_6 = "form3entity6";
        private static String FORM_3_ENTITY_7 = "form3entity7";

        private static String FORM_4_ENTITY_1_ID = "form4entity1Id";
        private static String FORM_4_ENTITY_2_ID = "form4entity2Id";
        private static String FORM_4_ENTITY_3_ID = "form4entity3Id";
        private static String FORM_4_ENTITY_4_ID = "form4entity4Id";
        private static String FORM_4_ENTITY_5 = "form4entity5";
        private static String FORM_4_ENTITY_6 = "form4entity6";
        private static String FORM_4_ENTITY_7 = "form4entity7";

        private static String IS_VIRTUALLY_DELETED = "isVirtuallyDeleted";



        public static Object getStudents() {
            String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
            List<Student> studentList = null;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                String sqlQuery = "SELECT * FROM  [dbo].[student]";
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        studentList = new List<Student>();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.Write(reader.GetString(1));
                                Student student = StudentUtility.getStudentFormReader(reader);
                                studentList.Add(student);
                            }
                        }
                    }
                }
                catch (InvalidOperationException e)
                {
                    return e;
                }
                catch (SqlException e)
                {
                    return e;
                }
                catch (Exception e)
                {
                    return e;
                }
            }

            return studentList;
        }


        public static Object getStudentForId(int id) {
            Student student = null;
            try
            {
                String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sqlQuery = "SELECT * FROM  [dbo].[student] WHERE ID = " + id;
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.Write(reader.GetString(1));
                                student = StudentUtility.getStudentFormReader(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                return e;
            }
            catch (InvalidOperationException e)
            {
                return e;
            }
            catch (InvalidCastException e)
            {
                return e;
            }
            catch (Exception e) {
                return e;
            }

            if (null != student)
                return student;
            else return new Exception("Student Not Found");

        }


        public static Object insertStudent(Student student)
        {
            {
                String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");

                // define INSERT query with parameters
                string query = "INSERT INTO "+ STUDENT_TABLE +" (" 
                    + FORM_1_ENTITY_1      + "," + FORM_1_ENTITY_2    + "," + FORM_1_ENTITY_3    + "," + FORM_1_ENTITY_4    + ","
                    + FORM_2_ENTITY_1_ID   + "," + FORM_2_ENTITY_2_ID + "," + FORM_2_ENTITY_3_ID + "," + FORM_2_ENTITY_4_ID + ","
                    + FORM_3_ENTITY_1_ID   + "," + FORM_3_ENTITY_2_ID + "," + FORM_3_ENTITY_3_ID + "," + FORM_3_ENTITY_4_ID + "," + FORM_3_ENTITY_5 + "," + FORM_3_ENTITY_6 + "," + FORM_3_ENTITY_7 + ","
                    + FORM_4_ENTITY_1_ID   + "," + FORM_4_ENTITY_2_ID + "," + FORM_4_ENTITY_3_ID + "," + FORM_4_ENTITY_4_ID + "," + FORM_4_ENTITY_5 + "," + FORM_4_ENTITY_6 + "," + FORM_4_ENTITY_7 + ","
                    + IS_VIRTUALLY_DELETED + ")" +
                    " VALUES (@form1entity1, @form1entity2, @form1entity3, @form1entity4," +
                    " @form2entity1Id, @form2entity2Id, @form2entity3Id, @form2entity4Id," +
                    " @form3entity1Id, @form3entity2Id, @form3entity3Id, @form3entity4Id, @form3entity5, @form3entity6, @form3entity7," +
                    " @form4entity1Id, @form4entity2Id, @form4entity3Id, @form4entity4Id, @form4entity5, @form4entity6, @form4entity7," +
                    " @isVirtuallyDeleted); " +
                    " SELECT CAST(scope_identity() AS int)";
                try
                {
                    //create connection and command
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        // define parameters and their values
                        cmd.Parameters.Add("@form1entity1", SqlDbType.NVarChar, 50).Value = student.Form1Entity1 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form1entity2", SqlDbType.NVarChar, 50).Value = student.Form1Entity2 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form1entity3", SqlDbType.NVarChar, 50).Value = student.Form1Entity3 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form1entity4", SqlDbType.NVarChar, 50).Value = student.Form1Entity4 ?? (object)DBNull.Value;

                        cmd.Parameters.Add("@form2entity1Id", SqlDbType.Int).Value = student.Form2Entity1Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form2entity2Id", SqlDbType.Int).Value = student.Form2Entity2Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form2entity3Id", SqlDbType.Int).Value = student.Form2Entity3Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form2entity4Id", SqlDbType.Int).Value = student.Form2Entity4Id ?? (object)DBNull.Value;

                        cmd.Parameters.Add("@form3entity1Id", SqlDbType.Int).Value = student.Form3Entity1Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form3entity2Id", SqlDbType.Int).Value = student.Form3Entity2Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form3entity3Id", SqlDbType.Int).Value = student.Form3Entity3Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form3entity4Id", SqlDbType.Int).Value = student.Form3Entity4Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form3entity5", SqlDbType.NVarChar, 50).Value = student.Form3Entity5 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form3entity6", SqlDbType.NVarChar, 50).Value = student.Form3Entity6 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form3entity7", SqlDbType.NVarChar, 50).Value = student.Form3Entity7 ?? (object)DBNull.Value;

                        cmd.Parameters.Add("@form4entity1Id", SqlDbType.Int).Value = student.Form4Entity1Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form4entity2Id", SqlDbType.Int).Value = student.Form4Entity2Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form4entity3Id", SqlDbType.Int).Value = student.Form4Entity3Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form4entity4Id", SqlDbType.Int).Value = student.Form4Entity4Id ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form4entity5", SqlDbType.NVarChar, 50).Value = student.Form4Entity5 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form4entity6", SqlDbType.NVarChar, 50).Value = student.Form4Entity6 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@form4entity7", SqlDbType.NVarChar, 50).Value = student.Form4Entity7 ?? (object)DBNull.Value;

                        cmd.Parameters.Add("@isVirtuallyDeleted", SqlDbType.Bit, 50).Value = student.IsVirtuallyDeleted;
                        int newID;
                        cn.Open();
                        newID = (int)cmd.ExecuteScalar();
                        cn.Close();
                        student.Id = newID;
                        return student;
                    }
                }
                catch (SqlException e)
                {
                    return e;
                }
                catch (InvalidOperationException e)
                {
                    return e;
                }
                catch (InvalidCastException e)
                {
                    return e;
                }
                catch (Exception e)
                {
                    return e;
                }
            }
        }



        public static Object updateStudent(Student student) {
            String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");

            string query = "UPDATE " + STUDENT_TABLE + " SET "
                  + FORM_1_ENTITY_1 + " = @form1entity1, " 
                  + FORM_1_ENTITY_2 + " = @form1entity2, " 
                  + FORM_1_ENTITY_3 + " = @form1entity3, " 
                  + FORM_1_ENTITY_4 + " = @form1entity4, "
                  
                  + FORM_2_ENTITY_1_ID + " = @form2entity1Id, " 
                  + FORM_2_ENTITY_2_ID + " = @form2entity2Id, "
                  + FORM_2_ENTITY_3_ID + " = @form2entity3Id, "
                  + FORM_2_ENTITY_4_ID + " = @form2entity4Id, "

                  + FORM_3_ENTITY_1_ID + " = @form3entity1Id, "
                  + FORM_3_ENTITY_2_ID + " = @form3entity2Id, "
                  + FORM_3_ENTITY_3_ID + " = @form3entity3Id, "
                  + FORM_3_ENTITY_4_ID + " = @form3entity4Id, "
                  + FORM_3_ENTITY_5 + " = @form3entity5, "
                  + FORM_3_ENTITY_6 + " = @form3entity6, "
                  + FORM_3_ENTITY_7 + " = @form3entity7, "

                  + FORM_4_ENTITY_1_ID + " = @form4entity1Id, "
                  + FORM_4_ENTITY_2_ID + " = @form4entity2Id, "
                  + FORM_4_ENTITY_3_ID + " = @form4entity3Id, "
                  + FORM_4_ENTITY_4_ID + " = @form4entity4Id, "
                  + FORM_4_ENTITY_5 + " = @form4entity5, "
                  + FORM_4_ENTITY_6 + " = @form4entity6, "
                  + FORM_4_ENTITY_7 + " = @form4entity7, "

                  + IS_VIRTUALLY_DELETED + " = @isVirtuallyDeleted WHERE "+ ID + " = @id ;";

            try
            {
                //create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // define parameters and their values
                    cmd.Parameters.Add("@form1entity1", SqlDbType.NVarChar, 50).Value = student.Form1Entity1 ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form1entity2", SqlDbType.NVarChar, 50).Value = student.Form1Entity2 ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form1entity3", SqlDbType.NVarChar, 50).Value = student.Form1Entity3 ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form1entity4", SqlDbType.NVarChar, 50).Value = student.Form1Entity4 ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@form2entity1Id", SqlDbType.Int).Value = student.Form2Entity1Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form2entity2Id", SqlDbType.Int).Value = student.Form2Entity2Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form2entity3Id", SqlDbType.Int).Value = student.Form2Entity3Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form2entity4Id", SqlDbType.Int).Value = student.Form2Entity4Id ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@form3entity1Id", SqlDbType.Int).Value = student.Form3Entity1Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form3entity2Id", SqlDbType.Int).Value = student.Form3Entity2Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form3entity3Id", SqlDbType.Int).Value = student.Form3Entity3Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form3entity4Id", SqlDbType.Int).Value = student.Form3Entity4Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form3entity5", SqlDbType.NVarChar, 50).Value = student.Form3Entity5 ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form3entity6", SqlDbType.NVarChar, 50).Value = student.Form3Entity6 ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form3entity7", SqlDbType.NVarChar, 50).Value = student.Form3Entity7 ?? (object)DBNull.Value;


                    cmd.Parameters.Add("@form4entity1Id", SqlDbType.Int).Value = student.Form4Entity1Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form4entity2Id", SqlDbType.Int).Value = student.Form4Entity2Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form4entity3Id", SqlDbType.Int).Value = student.Form4Entity3Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form4entity4Id", SqlDbType.Int).Value = student.Form4Entity4Id ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form4entity5", SqlDbType.NVarChar, 50).Value = student.Form4Entity5 ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form4entity6", SqlDbType.NVarChar, 50).Value = student.Form4Entity6 ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@form4entity7", SqlDbType.NVarChar, 50).Value = student.Form4Entity7 ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@isVirtuallyDeleted", SqlDbType.Bit).Value = student.IsVirtuallyDeleted;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
                  
                    cn.Open();
                    int result = cmd.ExecuteNonQuery();
                    cn.Close();
                    if (result > 0)
                        return student;
                    else return new Exception("Student not found for given id "+result);
                }
            }
            catch (SqlException e)
            {
                return e;
            }
            catch (InvalidOperationException e)
            {
                return e;
            }
            catch (InvalidCastException e)
            {
                return e;
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }   
}
