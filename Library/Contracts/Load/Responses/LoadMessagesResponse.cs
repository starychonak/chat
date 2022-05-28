using System.Collections.Generic;
using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Load.Responses
{
    /**
     * <summary>Класс, хранящий результат выполнения загрузки сообщений</summary>
     */
    [DataContract]
    public class LoadMessagesResponse : Response
    {
        /**
        * <summary>Загруженные сообщения</summary>
        */
        [DataMember]
        public IEnumerable<MessageDTO> Messages { get; set; }
    }
}