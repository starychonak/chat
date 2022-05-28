using System.Runtime.Serialization;

namespace Library.Contracts.User.Requests
{
    [DataContract]
    public class ChangeUsernameRequest : Request
    {
        [DataMember] public string NewName { get; set; }
    }
}