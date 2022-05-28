using System.Runtime.Serialization;

namespace Library.Contracts.User.Requests
{
    [DataContract]
    public class ChangePasswordRequest : Request
    {
        [DataMember] public string OldPassword { get; set; }

        [DataMember] public string NewPassword { get; set; }
    }
}