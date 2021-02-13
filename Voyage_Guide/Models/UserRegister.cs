using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Voyage_Guide.Models
{
  [MessageContract]
    public class UserRegister
    {
        [MessageBodyMember]
        public string username;

        [MessageBodyMember]
        public string firstName;

        [MessageBodyMember]
        public string lastName;

        [MessageBodyMember]
        public string password;

        [MessageBodyMember]
        public string email;
    }
}