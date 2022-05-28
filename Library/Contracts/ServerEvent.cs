using System;
using System.Runtime.Serialization;
using Library.Contracts.DTO;

namespace Library.Contracts
{
    /**
     *<summary>Базовый класс серверных событий</summary>
     */
    [DataContract]
    public class ServerEvent : EventArgs
    {
        [DataMember] public Guid Id { get; set; }

        public ServerEvent(Guid id)
        {
            Id = id;
        }

    }
}