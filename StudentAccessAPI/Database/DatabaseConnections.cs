using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentAccessAPI.Database
{
    public class DatabaseConnections
    {
        public static String getConnectionString(String ClientID) {
            switch (ClientID) {
                case "AZURE_DATABASE":
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "your server";
                builder.UserID = "youruserid";
                builder.Password = "your password";
                builder.Encrypt = true;
                builder.InitialCatalog = "your database name";
                return builder.ConnectionString;

                case "LOCAL_DATABASE":
                    return "Data Source=DESKTOP-BOTBIL6\\SQL2016TRAINING;Initial Catalog=StudentDataBase;Integrated Security=True;";

                case "NARAYANA_CLIENT":
                    return "Data Source=DESKTOP-BOTBIL6\\SQL2016TRAINING;Initial Catalog=Client_Narayana;Integrated Security=True;";

                case "RESONANCE_CLIENT":
                    return "Data Source=DESKTOP-BOTBIL6\\SQL2016TRAINING;Initial Catalog=Client_Resonance;Integrated Security=True;";

                case "SPARK_CLIENT":
                    return "Data Source=DESKTOP-BOTBIL6\\SQL2016TRAINING;Initial Catalog=Client_Spark;Integrated Security=True;";


                default: return null;
        }
        }
    }
}
