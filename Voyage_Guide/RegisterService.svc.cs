using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Voyage_Guide.Models;

namespace Voyage_Guide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RegisterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RegisterService.svc or RegisterService.svc.cs at the Solution Explorer and start debugging.
    public class RegisterService : IRegisterService
    {
        public void registerUser(User user)
        {
            
        }
    }
}
