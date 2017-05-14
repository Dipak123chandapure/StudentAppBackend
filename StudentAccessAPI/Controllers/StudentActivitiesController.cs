using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentAccessAPI.Database;
using StudentAccessAPI.Models;
using StudentAccessAPI.Utility;


namespace StudentAccessAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/StudentActivities")]
    public class StudentActivitiesController : Controller
    {
        // GET: api/StudentActivities
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }

        
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Object result = StudentActivitiesTable.getStudentActivitiesForId(id);
            if (result.GetType() == typeof(List<StudentActivities>)){return Ok(result);}
            else {return NotFound(result);}
        }
        
       
        [HttpPost]
        public ActionResult Post([FromBody]StudentActivities activity)
        {

            String error;
            if (StudentActivitiesUtility.checkForValidStudent(out error, activity))
            {
                Object result = StudentActivitiesTable.insertStudentActivity(activity);
                StudentActivities activity1 = result as StudentActivities;
                if (null != activity1) return Ok(activity1);
                else return NotFound(result);
            }
            else
            {
                return NotFound(new ErrorText(error));
            }

        }
        
        // PUT: api/StudentActivities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
