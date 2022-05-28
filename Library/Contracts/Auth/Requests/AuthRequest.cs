using System.Runtime.Serialization;

namespace Library.Contracts.Auth.Requests
{
    /**
     * <summary>Класс авторизационного запроса</summary>
     */
    [DataContract]
    public class AuthRequest : Request
    {
        /**
         * <summary>Имя пользователя</summary>
         */
        [DataMember]
        public string Login { get; set; }
        
        /**
         * <summary>Пароль пользователя</summary>
         */
        [DataMember]
        public string Password { get; set; }
    }
}