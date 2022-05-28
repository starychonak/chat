using System;
using System.Runtime.Serialization;

namespace Library.Contracts.Dialog.Events
{
    /**
     * <summary>Содержит данные о событии добавдения пользователя в диалог</summary>
     */
    [DataContract]
    public class RemoveDialogEvent : ServerEvent
    {
        [DataMember] public int DialogId { get; set; }

        public RemoveDialogEvent(Guid id, int dialogId)
            : base(id)
        {
            DialogId = dialogId;
        }
    }
}