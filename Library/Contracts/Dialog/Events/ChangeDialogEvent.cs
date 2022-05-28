using System;
using System.Runtime.Serialization;
using Library.Contracts.Dialog.Requests;

namespace Library.Contracts.Dialog.Events
{
    /**
     * <summary>Содержит данные о событии смене диалога пользователем</summary>
     */
    [DataContract]
    public class ChangeDialogEvent : ServerEvent
    {
        [DataMember] public ChangeDialogRequest ChangedInfo { get; set; }
        
        public ChangeDialogEvent(Guid id, ChangeDialogRequest changedInfo) 
            : base(id)
        {
            ChangedInfo = changedInfo;
        }
    }
}