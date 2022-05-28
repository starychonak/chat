using System.Runtime.Serialization;

namespace Library.Contracts.Dialog.Requests
{
    [DataContract]
    public class LeaveFromDialogRequest : Request
    {
        [DataMember] public int DialogId { get; set; }
    }
}