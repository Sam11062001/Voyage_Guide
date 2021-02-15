using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace Voyage_Guide.Models
{
    [DataContract]
    public class Custom_Exception
    {
        [DataMember()]
        public string Title;
        [DataMember()]
        public string ExceptionMessage;
      
    }
}