using System.Runtime.Serialization;

namespace Library.Contracts.Dialog.Requests
{
    [DataContract]
    public class Connect2DialogRequest : Request
    {
        [DataMember] public string Name { get; set; }

        [DataMember] public string Password { get; set; }
    }
}