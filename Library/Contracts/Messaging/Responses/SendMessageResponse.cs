using System.Runtime.Serialization;

namespace Library.Contracts.Messaging.Responses
{
    /**
     * <summary>Класс, хранящий результат отправки сообщения</summary>
     */
    [DataContract]
    public class SendMessageResponse : Response
    {
        /**
         * Уникальный идентификатор (id) сообщения
         */
        [DataMember] public long MessageId { get; set; }
    }
}