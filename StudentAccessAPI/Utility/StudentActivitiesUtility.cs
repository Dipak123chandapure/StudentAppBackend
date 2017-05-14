using System;
using System.Data.SqlClient;
using StudentAccessAPI.Models;

namespace StudentAccessAPI.Utility
{
    public class StudentActivitiesUtility
    {
        internal static StudentActivities getStudentActivitiesFormReader(SqlDataReader reader)
        {
            StudentActivities activity = new StudentActivities();

            activity.Id = (reader[0] as int?) ?? null;
            activity.ActivityTypeId = (reader[1] as int?) ?? null;
            activity.StudentId = (reader[2] as int?) ?? null;

            activity.Comment = reader[3] as string;
            activity.Content = reader[4] as string;
            activity.ActionTime = reader[5] as string;
            activity.CreatedOn = reader[6] as string;
            activity.UpdatedOn = reader[7] as string;
            return activity;
        }

        internal static bool checkForValidStudent(out string error, StudentActivities activity)
        {
            if (activity.ActivityTypeId == null || activity.Id < 1) {
                error = "Activity type is not valid";
                return false;
            }

            if (String.IsNullOrEmpty(activity.ActionTime))
            {
                error = "Acti";
                return false;
            }

            error = "successful";
            return true;
        }
    }
}
