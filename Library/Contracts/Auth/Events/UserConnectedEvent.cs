using System;
using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Auth.Events
{
    /**
     * <summary>Содержит данные о событии, вызванного авторизацией пользователя</summary>
     */
    [DataContract]
    public class UserConnectedEvent : ServerEvent
    {
        /**
         * <summary>Авторизированный пользователь, вызвавший событие</summary>
         */
        [DataMember]
        public UserDTO User { get; set; }

        public UserConnectedEvent(Guid id, UserDTO user) 
            : base(id)
        {
            User = user;
        }
    }
}