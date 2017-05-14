using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentAccessAPI.Database;
using StudentAccessAPI.Models;
using StudentAccessAPI.Utility;


namespace StudentAccessAPI.Controllers.wwwroot
{
    [Produces("application/json")]
    [Route("api/Groups")]
    public class GroupsController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            Object result = GroupTable.getAllGroups();
            if (result.GetType() == typeof(List<Student>)) { return Ok(result); }
            else { return NotFound(result); }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Object result = GroupTable.getGroupForId(id);
            Group group = result as Group;
            if (null != group) { return Ok(result); }
            else { return NotFound(result); }

        }

        [HttpPost]
        public ActionResult Post([FromBody]Group group)
        {
            String error;
            if (GroupsUtility.checkForValidGroup(out error, group))
            {
                Object result = GroupTable.insertGroup(group);
                Group student1 = result as Group;
                if (null != student1) return Ok(result);
                else return NotFound(result);
           }
            else
            {
               return NotFound(new ErrorText(error));
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody]Group group)
        {
            String error;
            if (GroupsUtility.checkForValidGroup(out error, group))
            {
                Object result = GroupTable.updateGroup(group);
                Group group1 = result as Group;
                if (null != group1)
                    return Ok(result);
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

