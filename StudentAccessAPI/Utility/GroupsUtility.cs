using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using StudentAccessAPI.Models;
using System.Data.SqlClient;

namespace StudentAccessAPI.Utility
{
    public class GroupsUtility
    {

        public static Group getGroupFormReader(SqlDataReader reader)
        {

            Group group = new Group();
            group.Id = reader.GetInt32(0);
            group.Title = reader.GetString(1);
            group.Details = reader.GetString(2);
            group.CreatedOn = reader.GetString(3);
            group.UpdatedOn = reader.GetString(4);
            group.IsVirtuallyDeleted = reader.GetBoolean(5);

            return group;
        }


        internal static bool checkForValidGroup(out string value, Group group)
        {
            if (String.IsNullOrEmpty(group.Title))
            {
                value = "Group Name is Not valid";
                return false;
            }

            if (String.IsNullOrEmpty(group.Details))
            {
                value = "Group Details are not valid";
                return false;
            }

            if (String.IsNullOrEmpty(group.CreatedOn))
            {
                value = "Please enter cerated on";
                return false;
            }


            if (String.IsNullOrEmpty(group.UpdatedOn))
            {
                value = "Please enter updated on";
                return false;
            }


            value = "Successfully checked";
            return true;
        }
    }
}
