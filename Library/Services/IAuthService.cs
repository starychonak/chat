using System.ServiceModel;
using Library.Contracts.Auth.Events;
using Library.Contracts.Auth.Requests;
using Library.Contracts.Auth.Responses;

namespace Library.Services
{
    public partial interface IService
    {
        [OperationContract]
        AuthResponse Registration(AuthRequest request);

        [OperationContract]
        AuthResponse Authorization(AuthRequest request);
    }
    
    public partial interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnUserConnected(UserConnectedEvent args);
    }
}