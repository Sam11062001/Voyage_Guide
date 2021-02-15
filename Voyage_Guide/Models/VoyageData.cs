using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace Voyage_Guide.Models
{
    [DataContract]
    public class VoyageData
    {
       
        [DataMember]
        public int UserId { get; set; }
        
        [DataMember]
        public byte[] imageData { get; set; }

        [DataMember]
        public string VoyageContent { get; set; }

        [DataMember]
        public string VoyageState { get; set; }

        [DataMember]
        public string VoyageCity { get; set; }

    }
}