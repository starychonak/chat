using System.ServiceModel;
using Library.Contracts;
using Library.Contracts.User.Events;
using Library.Contracts.User.Requests;

namespace Library.Services
{
    public partial interface IService
    {
        [OperationContract]
        Response ChangePassword(ChangePasswordRequest request);

        [OperationContract]
        Response ChangeUsername(ChangeUsernameRequest request);
    }

    public partial interface IServiceCallback
    {
        [OperationContract]
        void OnUsernameChanged(ChangeUsernameEvent args);
    }
}