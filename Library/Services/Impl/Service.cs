using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using Library.Contracts;
using Library.Data;

namespace Library.Services.Impl
{
    /**
     * <summary>Сервис, принимающий запросы и возвращающий ответы клиентам этого сервиса</summary>
     */
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public partial class Service : IService
    {
        /**
         * <summary>Контекст базы данных</summary>
         */
        private readonly DBContext context;
        
        /**
         * <summary>Словарь, хранящий созданные и активные подключения в данный момент</summary>
         */
        private readonly Dictionary<Guid, Connection> connections;

        // private IService _serviceImplementation;

        public Service()
        {
            context = new DBContext();
            connections = new Dictionary<Guid, Connection>();
        }

        /**
         * <summary>Создает подключение нового временного клиента сервиса</summary>
         * <returns>Уникальный идентификатор (id)  пользователя</returns>
         */
        public Guid Connect()
        {
            Connection connection = new Connection();
            try
            {
                connections.Add(connection.Id, connection);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return connection.Id;
        }

        /**
         * <summary>Вызывается для обозначения, что клиент отключился от сервера</summary>
         * <param name="id">Уникальный идентификатор (id) пользователя</param>
         */
        public void Disconnect(Guid id)
        {
            SetActivity(id);
            connections.Remove(id);
        }

        /**
         * <summary>Вызывается для выхода пользователя с аккаунта</summary>
         * <param name="id">Уникальный идентификатор (id) пользователя</param>
         * <returns>Уникальный идентификатор (id) нового подключения</returns>
         */
        public Guid LogOut(Guid id)
        {
            Connection connection = new Connection(Guid.NewGuid(), connections[id].Context, true);
            connections.Add(connection.Id, connection);
            connections.Remove(id);
            return connection.Id;
        }

        /**
         * <summary>Выполняет операцию, передеваемую в метод и, в случае неудачного ее выполнения, возвращает ошибку операции</summary>
         * <typeparam name="T">Класс ответа</typeparam>
         * <param name="method">Операция, которую необходимо выполнить</param>
         * <returns>Результат выполнения операции</returns>
         */
        private T Perform<T>(Func<T> method)
            where T : Response, new()
        {
            try
            {
                return method();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new T() { Result = Result.ServerException };
            }
        }
        
        /**
         * <summary>Отправляет событие заданному клиенту сервиса</summary>
         * <typeparam name="T">Интерфейс обратного вызова</typeparam>
         * <param name="id">Уникальный идентификатор (id) пользователя, которому будет отправлено событие</param>
         * <param name="args">Аргументы события, передаваемые в один из методов интерфейса</param>
         */
        private void SendEvent(Guid id, ServerEvent args) {
            SetActivity(id);
            if (args.Id != id && connections.ContainsKey(id))
            {
                var service = connections[id].Context.GetCallbackChannel<IServiceCallback>();
                foreach (var methodInfo in service.GetType().GetMethods())
                {
                    methodInfo.Invoke(service, new[] {args});
                    return;
                }
            }
        }

        /**
         * <summary>Отправляет событие заданным клиентам сервиса</summary>
         * <typeparam name="T">Интерфейс обратного вызова</typeparam>
         * <param name="ids">Уникальные идентификаторы (id) пользователей, которым будет отправлено событие</param>
         * <param name="args">Аргументы события, передаваемые в один из методов интерфейса</param>
         */
        private void SendEvent(IEnumerable<Guid> ids, ServerEvent args)
        {
            foreach (var id in ids)
            {
                SendEvent(id, args);
            }
        }

        /**
         * <summary>Отправляет событие всем клиентам сервиса</summary>
         * <typeparam name="T">Интерфейс обратного вызова</typeparam>
         * <param name="args">Аргументы события, передаваемые в один из методов интерфейса</param>
         * <param name="isTemporary">Флаг, определяющий вызывать ли метод для неавторизованных клиентов</param>
         */
        private void SendBroadcastEvent(ServerEvent args, bool isTemporary = false)
        {
            SendEvent(connections
                .Where(k => isTemporary || k.Value.IsTemporary)
                .Select(k => k.Key)
            ,args
            );
        }
        
        /**
         * <summary>Проверяет, является ли имя действительным</summary>
         * <param name="name">Строка с именем для проверки</param>
         * <returns></returns>
         */
        private bool CheckValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length > 2 && name.Length <= 30;
        }
        
        /**
         * <summary>Проверяет, является ли пароль действительным</summary>
         * <param name="password">Строка с паролем для проверки</param>
         * <returns></returns>
         */
        private bool CheckValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length > 3;
        }
        
        /**
         * <summary>Устанавливает последнюю активность пользователю</summary>
         * <param name="id">Уникальный идентификатор (id) пользователя</param>
         */
        private void SetActivity(Guid id)
        {
            var user = context.Users.Find(id);
            user.LastActivity = DateTime.UtcNow;
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
            
    }
}