using System;
using System.Runtime.Serialization;

namespace Library.Contracts.Dialog.Events
{
    /**
     * <summary>Содержит данные о событии добавдения пользователя в диалог</summary>
     */
    [DataContract]
    public class UserLeaveFromDialogEvent : ServerEvent
    {
        [DataMember]
        public int DialogId { get; set; }
        
        public UserLeaveFromDialogEvent(Guid id, int dialogId) 
            : base(id)
        {
            DialogId = dialogId;
        }
    }
}