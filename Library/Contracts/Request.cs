using System;
using System.Runtime.Serialization;

namespace Library.Contracts
{
    /**
     * <summary>
     * Абстрактный класс запроса.
     * Используется для наследования классов, хранящих данные, передаваемые клиентом сервису
     * </summary>
     */
    [DataContract]
    public abstract class Request
    {
        [DataMember] public Guid Id { get; set; }
    }
}