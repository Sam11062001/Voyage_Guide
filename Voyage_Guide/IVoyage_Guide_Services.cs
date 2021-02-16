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
        [FaultContract(typeof(Custom_Exception))]
        AuthenticateReply authenticateUser(AuthenticateUser authUserData);
    }

    [ServiceContract]
    public interface IVoyageDataSerrvice
    {
        [OperationContract]
        bool addNewData(VoyageData data);

        [OperationContract]
        byte[] getImage();

        [OperationContract]
        [FaultContract(typeof(Custom_Exception))]
        bool addNewVoyageData(VoyageData data);

        [OperationContract]
        int getResultNumber( string state , string city );

        [OperationContract]
        ImageDataContent[] getImageDataContent(string state, string city , int results );

    }

}
