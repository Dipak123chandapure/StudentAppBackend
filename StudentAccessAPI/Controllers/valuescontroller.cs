using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using StudentAccessAPI.Database;
using StudentAccessAPI.Models;
using StudentAccessAPI.Utility;

namespace StudentAccessAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            String[] list = new String[4];
            List<Student> studentList = new List<Student>();
            try
            {
                String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sqlQuery = "SELECT * FROM  [dbo].[student]";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
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
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                list[1] = e.ToString();
            }
            return studentList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            Student student = null;
            try
            {
                String connectionString = DatabaseConnections.getConnectionString("NARAYANA_CLIENT");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sqlQuery = "SELECT * FROM  [dbo].[student] WHERE ID = "+id;
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
                Console.WriteLine(e.ToString());
               
            }
            if(null != student)
            return Ok(student);
            else return NotFound(new ErrorText("Student Not Found"));

        }

        //POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class ErrorText {
        public ErrorText(String error) {
            this.errorText = error;
        }
        public String errorText { get; set; }
    }
}


