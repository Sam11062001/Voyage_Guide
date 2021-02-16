using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Voyage_Guide.Models
{
    [MessageContract]
    public class ImageDataContent
    {
        [MessageHeader]
        public int UserId { get; set; }

        [MessageBodyMember]
        public string firstName { get; set; }

        [MessageBodyMember]
        public string lastName { get; set; }

        [MessageBodyMember]
        public byte[] imageData { get; set; }

        [MessageBodyMember]
        public string VoyageContent { get; set; }
    }
}