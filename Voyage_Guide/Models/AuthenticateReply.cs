using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace Voyage_Guide.Models
{
    //This is the message cintract used to return to the user on the authenticate request
    [MessageContract]
    public class AuthenticateReply
    {
        private int UserId;
        private bool isAuthenticated;

        [MessageHeader]
        public int VoyageUserId
        {
            get { return UserId; }
            set
            {
                UserId = value;
            }
        }

        [MessageBodyMember]
        public bool VoyageisAuthenticated
        {
            get { return isAuthenticated; }
            set
            {
                isAuthenticated = value;
            }
        }
    }
}