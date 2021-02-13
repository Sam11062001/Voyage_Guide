using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voyage_Guide.Models
{
    public class User
    {
        //this the class that rerprsents the actual user data stored in the datbase
        private int id { get; set; }
        private string UserName { get; set; }
        private string password { get; set; }

        private string email { get; set; }
        private string fName { get; set; }

        private string lName { get; set; }
    }
}