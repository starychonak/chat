using System.Collections.Generic;
using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Load.Responses
{
    /**
     * <summary>Класс, хранящий результат выполнения загрузки online-пользователей </summary>
     */
    [DataContract]
    public class LoadOnlineUsersResponse : Response
    {
        /**
        * <summary>Загруженные online-пользователи</summary>
        */
        [DataMember]
        public IEnumerable<UserDTO> Users { get; set; }
    }
}