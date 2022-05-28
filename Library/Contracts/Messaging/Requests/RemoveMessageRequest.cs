using System.Runtime.Serialization;

namespace Library.Contracts.Messaging.Requests
{
    /**
     *  <summary>Класс для отправки запроса на удаления сообщения</summary>
     */
    [DataContract]
    public class RemoveMessageRequest : Request
    {
        /**
         * <summary>Уникальный идентификатор (id) диалога, в который отправлено сообщение</summary>
         */
        [DataMember] public int DialogId { get; set; }

        /**
         * <summary>Список уникальных идентификаторов (id) сообщений диалога</summary>
         */
        [DataMember] public long[] MessagesIds { get; set; }
    }
}