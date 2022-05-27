using System;
using System.Runtime.Serialization;

namespace Library.Contracts.DTO.Impl
{
    /**
     * <summary>
     * Класс, хранящий информацию о сообщении.
     * Служит для передачи этой информации клиентам сервиса.
     * </summary>
     */
    [DataContract]
    public class MessageDTO
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public UserDTO Author { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int DialogId { get; set; }
        
        
        /**
         * <summary>
         * Инициализрует новый экземпляр сообщения для передачи клиентам сервиса
         * </summary>
         * <param name="id">Уникальный идентифицатор (id) сообщения</param>
         * <param name="author">Автор сообщния</param>
         * <param name="text">Текст сообщения</param>
         * <param name="date">Дата отправки сообщения</param>
         * <param name="dialogId">Уникальный идентификатор (id) сообщения</param>
         */
        public MessageDTO(long id, UserDTO author, string text, DateTime date, int dialogId)
        {
            Id = id;
            Author = author;
            Text = text;
            Date = date;
            DialogId = dialogId;
        }

        public MessageDTO(UserDTO author, string text)
        {
            Author = author;
            Text = text;
        }
    }
}