using System;
using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Messaging.Events
{
    /**
     * <summary>Представляет данные для события отправки сообщения</summary>
     */
    [DataContract]
    public class MessageSendEvent : ServerEvent
    {
        [DataMember] public MessageDTO Message { get; set; }

        public MessageSendEvent(Guid id, MessageDTO message)
            : base(id)
        {
            Message = message;
        }
    }
}