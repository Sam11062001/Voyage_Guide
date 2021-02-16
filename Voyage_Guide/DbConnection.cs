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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kaman\Desktop\Voyage_Guide\Voyage_Guide\App_Data\VoyageDatabase.mdf;Integrated Security=True");

          
            //returning the  connection object 
            return con;

        }
    }
}