using System.Runtime.Serialization;

namespace Library.Contracts
{
    [DataContract]
    public enum Result
    {
        /**
         * <summary>Операция выполнена успешно</summary>
         */
        [EnumMember]
        Successfully = 1,
        
        /**
         * <summary>Пользователя с таким именем уже зарегистрирован </summary>
         */
        [EnumMember]
        AlreadyRegister = 2,

        /**
         * <summary>Пользователь с таким именем уже авторизован</summary>
         */
        [EnumMember]
        AlreadyLogged = 4,
        
        /**
         * <summary> Неверное имя пользователя</summary>
         */
        [EnumMember]
        WrongLogin = 8,

        /**
         * <summary>Неверный пароль</summary>
         */
        [EnumMember]
        WrongPassword = 16,

        /**
         * <summary>Добавляемый пользователь уже есть в диалоге</summary>
         */
        [EnumMember]
        UserAlreadyInDialog = 32,
        
        /**
         * <summary>Недостаточно прав пользователя для выполнения запроса</summary>
         */
        [EnumMember]
        NotPremissions = 64,
        
        /**
         * <summary>Имя диалога уже занято</summary>
         */
        [EnumMember]
        DialogNameAlreadyTaken = 128,
        
        /**
         * <summary>Пользователя нет в диалоге</summary>
         */
        [EnumMember]
        UserNotInDialog = 256,

        /**
         * <summary>Отправлено пустое сообщение</summary>
         */
        [EnumMember]
        EmptyMessage = 512,

        /**
         * <summary>Заданное имя недействительно</summary>
         */
        [EnumMember]
        InvalidName = 1024,

        /**
         * <summary>Заданный пароль недействителен</summary>
         */
        [EnumMember]
        InvalidPassword = 2048,

        /**
         * <summary>Все сообщения или диалоги уже загружены</summary>
         */
        [EnumMember]
        AllLoad = 4096,

        /**
         * <summary>Во время выполнения операции произошла ошибка</summary>
         */
        [EnumMember]
        ServerException = -1,
    }
}