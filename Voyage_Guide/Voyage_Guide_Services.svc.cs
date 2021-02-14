using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Voyage_Guide.Models;

namespace Voyage_Guide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Voyage_Guide_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Voyage_Guide_Services.svc or Voyage_Guide_Services.svc.cs at the Solution Explorer and start debugging.
    public class Voyage_Guide_Services : IVoyage_Guide_Services,IRegisterService,IAuthService
    {
        public void DoWork()
        {
        }

        //Register Service Implmentation
        public bool registerUser(UserRegister user)
        {
            bool result = false;
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
           
            string query = "INSERT INTO VoyageUser(FirstName,LastName,EmailAddress,userPassword,UserName)VALUES" +
                "(@firstname,@lastname,@emailaddress,@password,@username)";
           
            
            SqlCommand cmd = new SqlCommand(query,con);
  
            cmd.Parameters.AddWithValue("@firstname", user.firstName);
            cmd.Parameters.AddWithValue("@lastname", user.lastName);
            cmd.Parameters.AddWithValue("@emailaddress", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@username", user.username);

            try
            {
               
                con.Open();
                int rows_affected=  cmd.ExecuteNonQuery();

                Console.WriteLine("User is succesfully registered");
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User is not registered" + ex.Message);
                result = false;
            }
            finally
            {
                con.Close();

            }
            return result;
        }

        //Login Service Implmentation
        public bool authenticateUser(string username, string password)
        {
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select UserName,userPassword from VoyageUser where UserName=@username and userPassword=@password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message is:" + ex.Message);
                return false;
            }
            finally
            {
                con.Close();

            }
        }
    }


}
