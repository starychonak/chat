using System.Runtime.Serialization;

namespace Library.Contracts.Load.Requests
{
    /**
     * <summary>Класс запроса для загрузки сообщений</summary>
     */
    [DataContract]
    public class LoadMessagesRequest : Request
    {
        /**
         * <summary>Уникальный идентификатор (id) диалога для загрузки сообщений</summary>
         */
        [DataMember]
        public int DialogId { get; set; }
        
        /**
         * <summary>Последнее сообщение, загруженное у пользователя</summary>
         */
        [DataMember]
        public long? LastMessageId { get; set; }
    }
}