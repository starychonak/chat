using System;
using System.Runtime.Serialization;
using Library.Contracts.Messaging.Requests;

namespace Library.Contracts.Messaging.Events
{
    /**
     * <summary>Представляет данные для события удаления сообщения</summary>
     */
    [DataContract]
    public class MessageRemovedEvent : ServerEvent
    {
        [DataMember] public int DialogId { get; set; }

        [DataMember] public long[] MessagesIds { get; set; }

        public MessageRemovedEvent(Guid id, int dialogId, long[] messagesIds)
            : base(id)
        {
            DialogId = dialogId;
            MessagesIds = messagesIds;
        }

        public MessageRemovedEvent(RemoveMessageRequest request)
            : this(request.Id, request.DialogId, request.MessagesIds)
        {
        }
    }
}