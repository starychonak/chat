using System.Runtime.Serialization;

namespace Library.Contracts.Messaging.Requests
{
    /**
     *  <summary>Класс для отправки запроса на отправку сообщения</summary>
     */
    [DataContract]
    public class SendMessageRequest : Request
    {
        /**
         * <summary>Уникальный идентификатор (id) диалога, в который отправлено сообщение</summary>
         */
        [DataMember] public int DialogId { get; set; }
        
        /**
         * <summary>Текст сообщения</summary>
         */
        [DataMember] public string Text { get; set; }
    }
}