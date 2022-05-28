using System;
using System.ServiceModel;
using Library.Contracts.Load.Requests;
using Library.Contracts.Load.Responses;

namespace Library.Services
{
    public partial interface IService
    {
        [OperationContract]
        LoadMessagesResponse LoadMessages(LoadMessagesRequest request);

        [OperationContract]
        LoadDialogsResponse LoadDialogs(LoadDialogsRequest request);

        [OperationContract]
        LoadOnlineUsersResponse LoadOnlineUsers(Guid id);
    }
}