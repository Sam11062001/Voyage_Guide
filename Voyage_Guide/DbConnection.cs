using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
namespace Voyage_Guide
{
    public class DbConnection
    {
        public SqlConnection connectToDatabase()
        {
            //create the instance of the connection string 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["VoyageGuideDb"].ConnectionString;

            //returning the  connection object 
            return con;

        }
    }
}