using System.ServiceModel;
using Library.Contracts;
using Library.Contracts.Dialog;
using Library.Contracts.Dialog.Events;
using Library.Contracts.Dialog.Requests;
using Library.Contracts.Dialog.Responses;

namespace Library.Services
{
    public partial interface IService
    {
        [OperationContract]
        CreateDialogResponse CreateDialog(CreateDialogRequest request);

        [OperationContract]
        Response RemoveDialog(RemoveDialogRequest request);

        [OperationContract]
        Response ChangeDialog(ChangeDialogRequest request);

        [OperationContract]
        ConnectToDialogResponse ConnectToDialog(Connect2DialogRequest request);

        [OperationContract]
        Response LeaveFromDialog(LeaveFromDialogRequest request);
    }

    public partial interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnCreatedDialog(CreateDialogEvent args);

        [OperationContract(IsOneWay = true)]
        void OnAddedUserToDialog(AddUser2DialogEvent args);

        [OperationContract(IsOneWay = true)]
        void OnChangedDialog(ChangeDialogEvent args);

        [OperationContract(IsOneWay = true)]
        void OnUserLeavedFromDialog(UserLeaveFromDialogEvent args);

        [OperationContract(IsOneWay = true)]
        void OnDialogRemoved(RemoveDialogEvent args);
    }
}