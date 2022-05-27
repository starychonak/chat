using System;
using System.Runtime.Serialization;

namespace Library.Contracts.DTO.Impl
{
    /**
     * <summary>
     * Класс, хранящий информацию о пользователе.
     * Служит для передачи этой информации клиентам сервиса
     * </summary>
     */
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool IsOnline { get; set; }
        [DataMember]
        public DateTime LastActivity { get; set; }
        
        
        /**
         * <summary>
         * Инициализирует новый экземпляр класса данных о пользователе для передачи данных клиенту сервиса
         * </summary>
         * <param name="id">Уникальный идентификатор (id) пользователя</param>
         * <param name="name">Логин (имя) пользователя</param>
         */
        public UserDTO(Data.Entities.User user)
        {
            Id = user.Id;
            Name = user.Login;
            IsOnline = false;
            LastActivity = user.LastActivity;
        }
    }
}