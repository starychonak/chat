using System;
using System.Runtime.Serialization;

namespace Library.Contracts.Dialog.Requests
{
    [DataContract]
    public class RemoveDialogRequest : Request
    {
        [DataMember] public int DialogId { get; set; }

        [DataMember] public string Password { get; set; }
    }
}