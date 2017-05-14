using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StudentAccessAPI.Models;
using StudentAccessAPI.Utility;
using System.Data;


namespace StudentAccessAPI.Database
{
    public class GroupTable
    {
        private static String GROUPS_TABLE = "[dbo].[groups]";
        private static String ID = "id";
        private static String TITLE = "title";
        private static String DETAILS = "details";
        private static String CREATED_ON = "createdOn";
        private static String UPDATED_ON = "updatedOn";
        private static String IS_VIRTUALLY_DELETED = "isVirtuallyDeleted";


        public static Object getAllGroups() {

            String[] list = new String[4];
            List<Group> groupList = null;
            try
            {
                String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sqlQuery = "SELECT * FROM "+ GROUPS_TABLE;
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        groupList = new List<Group>();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.Write(reader.GetString(1));
                                Group group = GroupsUtility.getGroupFormReader(reader);
                                groupList.Add(group);
                            }
                        }
                    }
                }
            }
            catch (InvalidOperationException e){return e;}
            catch (SqlException e){return e;}
            catch (Exception e){return e;}
            return groupList;

        }


        public static Object getGroupForId(int id)
        {
            Group group = null;
            try
            {
                String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sqlQuery = "SELECT * FROM " + GROUPS_TABLE + " WHERE ID = " + id;
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.Write(reader.GetString(1));
                                group = GroupsUtility.getGroupFormReader(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException e){return e;}
            catch (InvalidOperationException e){return e;}
            catch (InvalidCastException e){return e;}
            catch (Exception e){return e;}

            if (null != group)
                return group;
            else return new Exception("Student Not Found");

        }


        public static Object insertGroup(Group group)
        {
            {
                String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
                long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                string query = "INSERT INTO " + GROUPS_TABLE + " ("
                    + TITLE + "," + DETAILS + "," + CREATED_ON + "," + UPDATED_ON + ","
                    + IS_VIRTUALLY_DELETED + ")" +
                    " VALUES (@title, @details, @createdOn, @updatedOn," +
                    " @isVirtuallyDeleted); " +
                    " SELECT CAST(scope_identity() AS int)";
                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.Add("@title", SqlDbType.NVarChar, 50).Value = group.Title ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@details", SqlDbType.NVarChar, 50).Value = group.Details ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@createdOn", SqlDbType.NVarChar, 50).Value = milliseconds;
                        cmd.Parameters.Add("@updatedOn", SqlDbType.NVarChar, 50).Value = milliseconds;
                        cmd.Parameters.Add("@isVirtuallyDeleted", SqlDbType.Bit, 50).Value = group.IsVirtuallyDeleted;

                        int newID;
                        cn.Open();
                        newID = (int)cmd.ExecuteScalar();
                        cn.Close();
                        group.Id = newID;
                        return group;
                    }
                }
                catch (SqlException e){return e;}
                catch (InvalidOperationException e){return e;}
                catch (InvalidCastException e){return e;}
                catch (Exception e){return e;}
            }
        }


        public static Object updateGroup(Group group)
        {
            String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
            long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            string query = "UPDATE " + GROUPS_TABLE + " SET "
                  + TITLE + " = @title, "
                  + DETAILS + " = @details, "
                  + CREATED_ON + " = @createdOn, "
                  + UPDATED_ON + " = @updatedOn, "
                  + IS_VIRTUALLY_DELETED + " = @isVirtuallyDeleted WHERE " + ID + " = @id ;";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@details", SqlDbType.NVarChar, 50).Value = group.Details ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@createdOn", SqlDbType.NVarChar, 50).Value = group.CreatedOn ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@updatedOn", SqlDbType.NVarChar, 50).Value = milliseconds;
                    cmd.Parameters.Add("@isVirtuallyDeleted", SqlDbType.Bit, 50).Value = group.IsVirtuallyDeleted;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = group.Id;

                    cn.Open();
                    int result = cmd.ExecuteNonQuery();
                    cn.Close();
                    if (result > 0)
                        return group;
                    else return new Exception("Group not found for given id " + result);
                }
            }
            catch (SqlException e){return e;}
            catch (InvalidOperationException e){return e;}
            catch (InvalidCastException e){return e;}
            catch (Exception e){return e;}
        }

    }
}
