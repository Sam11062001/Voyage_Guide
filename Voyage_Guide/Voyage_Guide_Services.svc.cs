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
    public class Voyage_Guide_Services : IVoyage_Guide_Services,IRegisterService,IAuthService,IVoyageDataSerrvice
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
        public AuthenticateReply authenticateUser(AuthenticateUser authUserData)
        {
            //Creating the instance of the Message Contract Typw which is required to send to the user
            AuthenticateReply authenticateReply = new AuthenticateReply();
            authenticateReply.VoyageisAuthenticated = false;
            //creating the instance of the Conenction
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            //Creating the instance of the Sql Command Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //Parameterized query for the Database to authenticate the user
            cmd.CommandText = "Select Id,UserName,userPassword from VoyageUser where UserName=@username and userPassword=@password";
            cmd.Parameters.AddWithValue("@username", authUserData.VoyageUserName);
            cmd.Parameters.AddWithValue("@password", authUserData.VoyagePassword);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    
                    authenticateReply.VoyageisAuthenticated = true;
                    authenticateReply.VoyageUserId = Int32.Parse(rdr["Id"].ToString());
                    rdr.Close();
                }
                //rdr.Close();
            }
            catch (Exception ex)
            {
                //creating the custom exception so that the client can be awared about the exception occured on the service side.
                Console.WriteLine("Error Message is:" + ex.Message);
                Custom_Exception exception = new Custom_Exception();
                exception.Title = "Error Occured While authenticating the Voyage User";
                exception.ExceptionMessage = ex.Message;
                throw new FaultException<Custom_Exception>(exception);
            }
            finally
            {
                //finally closing the Database Connection
                con.Close();

            }
            return authenticateReply;
        }

        public bool addNewData(VoyageData data)
        {
            bool result = false;
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO VoyageData(VoyageUserID,ImageData,VoyageContent,VoyageState,VoyageCity)" +
                "VALUES(@userId,@image,@content,@state,@city)";

            cmd.Parameters.AddWithValue("@userId", data.UserId);
            cmd.Parameters.AddWithValue("@image", data.imageData);
            cmd.Parameters.AddWithValue("@content", data.VoyageContent);
            cmd.Parameters.AddWithValue("@state", data.VoyageState);
            cmd.Parameters.AddWithValue("@city", data.VoyageCity);

            try
            {
                con.Open();
                int rows_affected = cmd.ExecuteNonQuery();
                result = true;
            }
           catch(Exception ex)
            {
                Console.WriteLine("Error Occured:" + ex.Message);
                result = false;
            }
            finally
            {
                con.Close();

            }
            return result;


        }

        public byte[] getImage()
        {
            byte[] image = { 0 };
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select ImageData from VoyageData where VoyageUserID=1";
            try
            {
                con.Open();
                image = (byte[])cmd.ExecuteScalar();
               

            }
            catch(Exception ex)
            {
                Console.WriteLine("Some Error Occured:" + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return image;
        }

        public bool addNewVoyageData(VoyageData data)
        {
            bool result = false;
            //creating the connection to the database
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            //create the instance to the SqlCommand Object
            SqlCommand cmd = new SqlCommand();
            //Command Object population to the connection and providing the Query string to the sql command object
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO VoyageData(VoyageUserID,ImageData,VoyageContent,VoyageState,VoyageCity)" +
                "VALUES(@userId,@image,@content,@state,@city)";
            //using the parameterized query
            cmd.Parameters.AddWithValue("@userId", data.UserId);
            cmd.Parameters.AddWithValue("@image", data.imageData);
            cmd.Parameters.AddWithValue("@content", data.VoyageContent);
            cmd.Parameters.AddWithValue("@state", data.VoyageState);
            cmd.Parameters.AddWithValue("@city", data.VoyageCity);

            //try block starting
            try
            {
                //open the connection to database
                con.Open();
                //returns the number of rows affected in the database
                int rows_affected = cmd.ExecuteNonQuery();
                //return the result of the operation
                result = true;
            }
            //starting of the catch block
            catch (Exception ex)
            {
                //just for checking for the developer purpose 
                Console.WriteLine("Error Occured:" + ex.Message);
                //using the custom exception to return the error message at the client side 
                Custom_Exception custom_Exception = new Custom_Exception();
                //Giving the appropriate values to the custom exception object
                custom_Exception.Title = "Voyage_Guide Custom Exception Message";
                custom_Exception.ExceptionMessage = ex.Message;
                //throwthe fault exception 
                throw new FaultException<Custom_Exception>(custom_Exception);
               
            }
            finally
            {
                //Closing the Database Connection
                con.Close();

            }
            return result;

        }

        public int getResultNumber(string state, string city)
        {
            int count = 0;
            //creating the instance of the Conenction
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            //Creating the instance of the Sql Command Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //Parameterized query for the Database to authenticate the user
            cmd.CommandText = "Select COUNT(*) from VoyageData where VoyageState=@state and VoyageCity=@city";
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@city", city);
            try
            {
                con.Open();
                count = (Int32)cmd.ExecuteScalar();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured:" + ex.Message);
                
            }
            finally
            {
                con.Close();

            }

            return count;

        }

        public ImageDataContent[] getImageDataContent(string state, string city , int results)
        {
            ImageDataContent[] imageDataContentResult = new ImageDataContent[results];
            //creating the instance of the Conenction
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            //Creating the instance of the Sql Command Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //Parameterized query for the Database to authenticate the user
            cmd.CommandText = "Select VoyageUserID,ImageData,VoyageContent from VoyageData where VoyageState=@state and VoyageCity=@city";
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@city", city);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    int i = 0;
                    while (rdr.Read())
                    {
                        imageDataContentResult[i] = new ImageDataContent();
                        imageDataContentResult[i].UserId = (Int32)rdr["VoyageUserID"];
                        imageDataContentResult[i].imageData = (byte[])rdr["ImageData"];
                        imageDataContentResult[i].VoyageContent = (String)rdr["VoyageContent"];
                        i++;
                    }
                    rdr.Close();

                    for (int j = 0; j < results; j++)
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = con;
                        //Parameterized query for the Database to authenticate the user
                        cmd1.CommandText = "Select FirstName,LastName from VoyageUser where Id=@userId";
                        cmd1.Parameters.AddWithValue("@userId", imageDataContentResult[j].UserId);
                        SqlDataReader rdr1 = cmd1.ExecuteReader();
                        rdr1.Read();
                        imageDataContentResult[j].firstName = (string)rdr1["FirstName"];
                        imageDataContentResult[j].lastName = (string)rdr1["LastName"];
                        rdr1.Close();

                    }
                    
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured:" + ex.Message);

            }
            finally
            {
                con.Close();
            }

            return imageDataContentResult;
        }
    }


}
