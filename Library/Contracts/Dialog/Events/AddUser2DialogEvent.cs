using System;
using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Dialog.Events
{
    /**
     * <summary>Содержит данные о событии добавдения пользователя в диалог</summary>
     */
    [DataContract]
    public class AddUser2DialogEvent : ServerEvent
    {
        [DataMember] public int DialogId { get; set; }
        [DataMember] public UserDTO AddedUser { get; set; }

        public AddUser2DialogEvent(Guid id, int dialogId, UserDTO addedUser) 
            : base(id)
        {
            DialogId = dialogId;
            AddedUser = addedUser;
        }
    }
}