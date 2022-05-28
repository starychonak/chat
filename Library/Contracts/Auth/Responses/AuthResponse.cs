using System;
using System.Runtime.Serialization;

namespace Library.Contracts.Auth.Responses
{
    /**
     * <summary>Класс хранящий результат выполнения авторизации</summary>
     */
    [DataContract]
    public class AuthResponse : Response
    {
        [DataMember] public Guid Id { get; set; }
    }
}