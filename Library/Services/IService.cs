using System;
using System.ServiceModel;
using Library.Contracts;

namespace Library.Services
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public partial interface IService
    {
        [OperationContract]
        Guid Connect();

        [OperationContract]
        void Disconnect(Guid id);

        [OperationContract]
        Guid LogOut(Guid id);
    }

    public partial interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnUserDiconnected(ServerEvent args);
    }
}