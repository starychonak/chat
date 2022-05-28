using System.Runtime.Serialization;

namespace Library.Contracts
{
    /**
     * <summary>Класс, хранящий результат выполнения запроса клиента</summary>
     */
    [DataContract]
    public class Response
    {
        [DataMember] public Result Result { get; set; }
    }
}