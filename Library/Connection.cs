using System;
using System.ServiceModel;

namespace Library
{
    /**
     * <summary>Класс, хранящий информацию о подключении клиента к сервису</summary>
     */
    public class Connection
    {
        public Guid Id { get; set; }

        public bool IsTemporary { get; set; }

        public OperationContext Context { get; set; }

        /**
         * <summary>Инициализирует подключение к сервису авторизованного клиента</summary>
         * <param name="id">Уникальный идентификатор (id) пользователя</param>
         * <param name="context">Контекст обратного вызова клиента</param>
         * <param name="isTemporary">Признак временного плодключения клиента к сервису</param>
         */
        public Connection(Guid id, OperationContext context, bool isTemporary = false)
        {
            Id = id;
            IsTemporary = isTemporary;
            Context = context;
        }
        
        /**
         * <summary>Инициализирует времненное подключение клиента к сервису </summary>
         */
        public Connection()
        {
            Id = Guid.NewGuid();
            IsTemporary = true;
            Context = OperationContext.Current;
        }
    }
}