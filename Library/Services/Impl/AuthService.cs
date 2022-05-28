using System;
using System.Linq;
using Library.Contracts;
using Library.Contracts.Auth.Events;
using Library.Contracts.Auth.Requests;
using Library.Contracts.Auth.Responses;
using Library.Data.Entities;

namespace Library.Services.Impl
{
    public partial class Service
    {
        /**
         * <summary>Вызывается после успешной авторизации пользователя, удаляет старое соединение и возвращает результат успешной авторизации</summary>
         * <param name="oldId">Старый уникальный идентификатор (id) пользователя</param>
         * <param name="user">Экземпляр авторизованного пользователя</param>
         * <returns></returns>
         */
        private AuthResponse CreateResponse(Guid oldId, User user)
        {
            connections.Add(user.Id, new Connection(user.Id, connections[oldId].Context));
            connections.Remove(oldId);
            SendBroadcastEvent(new UserConnectedEvent(user.Id, user.ToDto()));
            return new AuthResponse() { Result = Contracts.Result.Successfully, Id = user.Id };
        }

        /**
         * <summary>Регистрирует клиента как пользователя в базе данных и возвращает результат регистрации</summary>
         * <param name="request">Запрос на регистрацию</param>
         * <returns>Ответ на регистрацию</returns>
         */
        public AuthResponse Authorization(AuthRequest request)
        {
            return Perform(() =>
                {
                    var user = context.Users.SingleOrDefault(u => u.Login.ToLower() == request.Login.ToLower());
                    if (user == null)
                        return new AuthResponse() {Result = Result.WrongLogin};
                    if (user.Password != request.Password)
                        return new AuthResponse() {Result = Result.WrongPassword};
                    if (connections.ContainsKey(user.Id))
                        return new AuthResponse() {Result = Result.AlreadyLogged};
                    return CreateResponse(request.Id, user);
                }
            );
        }

        /**
         * <summary>Авторизовывает клиента, как пользователя и возвращает результат авторизации</summary>
         * <param name="request">Запрос на атворизацию</param>
         * <returns>Ответ на авторизацию</returns>
         */
        public AuthResponse Registration(AuthRequest request)
        {
            return Perform(() =>
                {
                    if (!CheckValidName(request.Login))
                        return new AuthResponse() { Result = Contracts.Result.InvalidName };
                    
                    if (!CheckValidPassword(request.Password))
                        return new AuthResponse() { Result = Contracts.Result.InvalidPassword };
                    
                    if (context.Users.Any(u => u.Login.ToLower() == request.Login.ToLower()))
                        return new AuthResponse() { Result = Contracts.Result.AlreadyRegister };
                    
                    User user = context.Users.Add(new User(request.Login, request.Password));
                    context.SaveChanges();
                    return CreateResponse(request.Id, user);
                }
            );
        }
        
    }
}