using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StudentAccessAPI.Models;
using StudentAccessAPI.Utility;
using System.Data;

namespace StudentAccessAPI.Database
{
    public class StudentActivitiesTable
    {
        private static String STUDENT_ACTIVITIES_TABLE = "[dbo].[studentActivities]";
        private static String ID = "id";
        private static String ACTIVITY_TYPE_ID = "activityTypeId";
        private static String STUDENT_ID = "studentId";
        private static String COMMENT = "Comment";
        private static String CONTENT = "Content";
        private static String ACTION_TIME = "actionTime";
        private static String CREATED_ON = "createdOn";
        private static String UPDATED_ON = "updatedOn";
        private static String IS_DONE = "isDone";


        public static Object getStudentActivitiesForId(int id)
        {

            String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
            List<StudentActivities> studentActivitiesList = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String sqlQuery = "SELECT * FROM " + STUDENT_ACTIVITIES_TABLE + " WHERE " + STUDENT_ID + " = " + id;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        studentActivitiesList = new List<StudentActivities>();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentActivities activity = StudentActivitiesUtility.getStudentActivitiesFormReader(reader);
                                studentActivitiesList.Add(activity);
                            }
                        }
                    }
                }
                catch (InvalidOperationException e) { return e; }
                catch (SqlException e) { return e; }
                catch (Exception e) { return e; }
            }
            return studentActivitiesList;
        }



        public static Object insertStudentActivity(StudentActivities activity)
        {
            {
                String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");

                // define INSERT query with parameters
                string query = "INSERT INTO " + STUDENT_ACTIVITIES_TABLE + " ("
                    + ACTIVITY_TYPE_ID + "," + STUDENT_ID + "," + COMMENT + "," + CONTENT + ","
                    + ACTION_TIME + "," + CREATED_ON + "," + UPDATED_ON + ","
                    + IS_DONE + ")" +
                    " VALUES (@activityTypeId, @studentId, @Comment, @Content," +
                    " @actionTime, @createdOn, @updatedOn," +
                    " @isDone); " +
                    " SELECT CAST(scope_identity() AS int)";
                try
                {
                    //create connection and command
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                        // define parameters and their values
                        cmd.Parameters.Add("@activityTypeId", SqlDbType.NVarChar, 50).Value = activity.ActivityTypeId ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@studentId", SqlDbType.NVarChar, 50).Value = activity.StudentId ?? (object)DBNull.Value;

                        cmd.Parameters.Add("@Comment", SqlDbType.NVarChar, 50).Value = activity.Comment ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@Content", SqlDbType.NVarChar, 50).Value = activity.Content ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@actionTime", SqlDbType.NVarChar, 50).Value = activity.ActionTime ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@createdOn", SqlDbType.NVarChar, 50).Value = milliseconds ;
                        cmd.Parameters.Add("@updatedOn", SqlDbType.NVarChar, 50).Value = milliseconds ;

                        cmd.Parameters.Add("@isDone", SqlDbType.Bit, 50).Value = activity.IsDone ?? false;
                        int newID;
                        cn.Open();
                        newID = (int)cmd.ExecuteScalar();
                        cn.Close();
                        activity.Id = newID;
                        return activity;
                    }
                }
                catch (SqlException e){return e;}
                catch (InvalidOperationException e){return e;}
                catch (InvalidCastException e){return e;}
                catch (Exception e){return e;}
            }
        }
    }  
}
