using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Voyage_Guide.Models
{
  [DataContract]
    public class UserRegister
    {
       [DataMember]
        public string username;

        [DataMember]
        public string firstName;

        [DataMember]
        public string lastName;

        [DataMember]
        public string password;

        [DataMember]
        public string email;
    }
}