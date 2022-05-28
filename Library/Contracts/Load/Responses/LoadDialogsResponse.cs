using System.Collections.Generic;
using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Load.Responses
{
    /**
     * <summary>Класс, хранящий результат выполнения загрузки диалогов пользователя</summary>
     */
    [DataContract]
    public class LoadDialogsResponse : Response
    {
        /**
        * <summary>Загруженные диалоги</summary>
        */
        [DataMember]
        public IEnumerable<DialogDTO> Dialogs { get; set; }
    }
}