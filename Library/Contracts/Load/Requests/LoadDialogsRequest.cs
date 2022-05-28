using System.Runtime.Serialization;

namespace Library.Contracts.Load.Requests
{
    /**
     * <summary>Класс запроса для загрузки диалогов</summary>
     */
    [DataContract]
    public class LoadDialogsRequest : Request
    {
        /**
         * <summary>Уникальный идентификатор (id) последнего диалога</summary>
         */
        [DataMember] public int? LastDialogId { get; set; }
    }
}