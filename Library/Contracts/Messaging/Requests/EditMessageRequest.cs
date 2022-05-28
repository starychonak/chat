using System.Runtime.Serialization;

namespace Library.Contracts.Messaging.Requests
{
    /**
     *  <summary>Класс для отправки запроса на редактирование сообщения</summary>
     */
    [DataContract]
    public class EditMessageRequest : Request
    {
        /**
         * <summary>Уникальный идентификатор (id) диалога, в который отправлено сообщение</summary>
         */
        [DataMember] public int DialogId { get; set; }

        /**
         * <summary>Уникальный идентификатор (id) сообщения</summary>
         */
        [DataMember] public long MessageId { get; set; }

        /**
         * <summary>Новый текст сообщения</summary>
         */
        [DataMember] public string NewText { get; set; }
    }
}