using System;
using System.Runtime.Serialization;

namespace Library.Contracts.User.Events
{
    [DataContract]
    public class ChangeUsernameEvent : ServerEvent
    {
        [DataMember] public string NewName { get; set; }

        public ChangeUsernameEvent(Guid id, string newName)
            : base(id)
        {
            NewName = newName;
        }
    }
}