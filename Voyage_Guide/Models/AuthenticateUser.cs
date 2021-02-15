using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
namespace Voyage_Guide.Models
{
    [MessageContract]
    public class AuthenticateUser
    {
        private string username;
        private string password;

        [MessageHeader]
        public string VoyageUserName
        {
            get { return username; }
            set { username = value; }
        }

        [MessageHeader]
        public string VoyagePassword
        {
            get { return password; }
            set { password = value; }
        }
    }
}