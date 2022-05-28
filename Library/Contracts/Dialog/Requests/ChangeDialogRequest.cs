using System.Runtime.Serialization;

namespace Library.Contracts.Dialog.Requests
{
    [DataContract]
    public class ChangeDialogRequest : Request
    {
        [DataMember] public int DialogId { get; set; }

        [DataMember]
        public string NewName { get; set; }

        [DataMember] public string NewPassword { get; set; }
    }
}