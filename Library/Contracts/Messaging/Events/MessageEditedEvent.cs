using System;
using System.Runtime.Serialization;
using Library.Contracts.Messaging.Requests;

namespace Library.Contracts.Messaging.Events
{
    /**
     * <summary>Представляет данные для события редактирования сообщения</summary>
     */
    [DataContract]
    public class MessageEditedEvent : ServerEvent
    {
        [DataMember] public int DialogId { get; set; }

        [DataMember] public long MessageId { get; set; }

        [DataMember] public string NewText { get; set; }

        public MessageEditedEvent(Guid id, int dialogId, long messageId, string newText)
            : base(id)
        {
            DialogId = dialogId;
            MessageId = messageId;
            NewText = newText;
        }

        public MessageEditedEvent(EditMessageRequest request)
            : this(request.Id, request.DialogId, request.MessageId, request.NewText)
        {
        }
    }
}