using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentAccessAPI.Database;
using StudentAccessAPI.Models;
using StudentAccessAPI.Utility;

namespace StudentAccessAPI.Controllers.wwwroot
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            Object result =  StudentTable.getStudents();
            if (result.GetType() == typeof(List<Student>)){ return Ok(result);}
            else { return  NotFound(result);}
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Object result = StudentTable.getStudentForId(id);
            Student student = result as Student;
            if (null != student){return Ok(result);}
            else { return NotFound(result); }
        }

        
        [HttpPost]
        public ActionResult Post([FromBody]Student student)
        {
            String error;
            if (StudentUtility.checkForValidStudent(out error, student))
            {
                Object result = StudentTable.insertStudent(student);
                Student student1 = result as Student;
                if(null != student1) return Ok(result);
                else return NotFound(result);
            }
            else
            {
                return NotFound(new ErrorText(error));
            }
        }

        
        [HttpPut]
        public ActionResult Put([FromBody]Student student)
        {
            String error;
            if (StudentUtility.checkForValidStudent(out error, student))
            {
                Object result = StudentTable.updateStudent(student);
                Student student1 = result as Student;
                if (null != student1) return Ok(result);
                else return NotFound(result);
            }
            else
            {
                return NotFound(new ErrorText(error));
            }
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
