using System;
using System.Runtime.Serialization;

namespace Library.Contracts.Dialog.Requests
{
    [DataContract]
    public class AddUser2DialogRequest : Request
    {
        [DataMember]
        public int DialogId { get; set; }

        [DataMember] public Guid AddedId { get; set; }
    }
}