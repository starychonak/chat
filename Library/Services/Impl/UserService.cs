using System.Linq;
using Library.Contracts;
using Library.Contracts.User.Events;
using Library.Contracts.User.Requests;

namespace Library.Services.Impl
{
    public partial class Service
    {
        /**
         * <summary>Изменяет пароль пользователя и возвращает результат выполнения операции</summary>
         * <param name="request">Запрос на изменение пароля</param>
         * <returns>Результат выполнения операции</returns>
         */
        public Response ChangePassword(ChangePasswordRequest request)
        {
            return Perform(() =>
            {
                if (!CheckValidPassword(request.NewPassword))
                    return new Response() { Result = Result.InvalidPassword };

                var user = context.Users.Find(request.Id);
                if (user.Password != request.OldPassword)
                    return new Response() { Result = Result.WrongPassword };
                user.Password = request.NewPassword;
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return new Response() { Result = Result.Successfully };
            });
        }
        
        /**
         * <summary>Изменяет имя пользователя и возвращает результат выполнения операции</summary>
         * <param name="request">Запрос на изменение имени пользователя</param>
         * <returns>Результат выполнения операции</returns>
         */
        public Response ChangeUsername(ChangeUsernameRequest request)
        {
            return Perform(() =>
            {
                if (!CheckValidName(request.NewName))
                    return new Response() { Result = Result.InvalidName };

                if (context.Users.Any(u => u.Login == request.NewName))
                    return new Response() { Result = Result.AlreadyRegister };
                var user = context.Users.Find(request.Id);
                user.Login = request.NewName;
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                SendBroadcastEvent(new ChangeUsernameEvent(request.Id, request.NewName));
                return new Response() { Result = Result.Successfully };
            });
        }
    }
}