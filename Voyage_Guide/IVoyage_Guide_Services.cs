using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Voyage_Guide.Models;
namespace Voyage_Guide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVoyage_Guide_Services" in both code and config file together.
    [ServiceContract]
    public interface IVoyage_Guide_Services
    {
        [OperationContract]
        void DoWork();
    }

    [ServiceContract]
    public interface IRegisterService
    {
        [OperationContract]
        bool registerUser(UserRegister user);
    }

    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool authenticateUser(string username, string password);
    }
}
