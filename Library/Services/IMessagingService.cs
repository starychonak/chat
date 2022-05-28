using System.ServiceModel;
using Library.Contracts;
using Library.Contracts.Messaging.Events;
using Library.Contracts.Messaging.Requests;
using Library.Contracts.Messaging.Responses;

namespace Library.Services
{
    public partial interface IService
    {
        [OperationContract]
        SendMessageResponse SendMessage(SendMessageRequest request);

        [OperationContract]
        Response EditMessage(EditMessageRequest request);

        [OperationContract]
        Response RemoveMessage(RemoveMessageRequest request);
    }

    public partial interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnMessageSend(MessageSendEvent args);

        [OperationContract(IsOneWay = true)]
        void OnMessageEdited(MessageEditedEvent args);

        [OperationContract(IsOneWay = true)]
        void OnMessageRemoved(MessageRemovedEvent args);
    }
}