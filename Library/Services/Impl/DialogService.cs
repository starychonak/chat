using System.Linq;
using Library.Contracts;
using Library.Contracts.Dialog.Events;
using Library.Contracts.Dialog.Requests;
using Library.Contracts.Dialog.Responses;
using Library.Contracts.DTO.Impl;
using Library.Data.Entities;

namespace Library.Services.Impl
{
    public partial class Service
    {
        /**
         * <summary>Создает диалог и возвращает информацию о нем в случае успеха</summary>
         * <param name="request">Запрос на создание диалога</param>
         * <returns>Результат выполнения операции</returns>
         */
        public CreateDialogResponse CreateDialog(CreateDialogRequest request)
        {
            return Perform(() =>
                {
                    if (request.Name == string.Empty || request.Name.All(c => char.IsWhiteSpace(c)))
                        return new CreateDialogResponse() { Result = Result.InvalidName };
                    
                    if (context.Dialogs.Any(d => d.Name == request.Name))
                        return new CreateDialogResponse() { Result = Result.DialogNameAlreadyTaken };

                    Dialog dialog = context.Dialogs.Add(new Dialog(context.Dialogs.Count(), request.Id, request.Name,
                        request.Password));
                    dialog.Users.Add(context.Users.Find(request.Id));
                    context.SaveChanges();
                    DialogDTO dialogDto = dialog.ToDto();
                    return new CreateDialogResponse() {Result = Result.Successfully, Dialog = dialogDto};
                }
            );
        }

        /**
         * <summary>Удаляет диалог и озвращает результат выполнения операции</summary>
         * <param name="request">Запрос на удаление диалога</param>
         * <returns>Результат выполнения операции</returns>
         */
        public Response RemoveDialog(RemoveDialogRequest request)
        {
            return Perform(() =>
                {
                    Dialog dialog = context.Dialogs.Find(request.DialogId);
                    if (dialog.OwnerId != request.Id)
                        return new Response() { Result = Result.NotPremissions };

                    if (dialog.Password != request.Password)
                        return new Response() { Result = Result.WrongPassword };
                    
                    context.Dialogs.Remove(dialog);
                    context.SaveChanges();
                    SendBroadcastEvent(new RemoveDialogEvent(request.Id, request.DialogId));
                    return new Response() {Result = Result.Successfully};
                }
            );
        }

        /**
         * <summary>Добавляет пользователя в диалог, указанный в запросе</summary>
         * <param name="request">Запрос на добавление</param>
         * <returns>Результат выполнения операции</returns>
         */
        public ConnectToDialogResponse ConnectToDialog(Connect2DialogRequest request)
        {
            return Perform(() =>
                {
                    User user = context.Users.Find(request.Id);
                    Dialog dialog = context.Dialogs.SingleOrDefault(d => d.Name == request.Name);
                    if (dialog == null)
                        return new ConnectToDialogResponse() { Result = Result.WrongLogin };

                    if (dialog.Password != request.Password)
                        return new ConnectToDialogResponse() { Result = Result.WrongPassword };

                    if (dialog.Users.Contains(user))
                        return new ConnectToDialogResponse() { Result = Result.UserAlreadyInDialog };
                    
                    dialog.Users.Add(user);
                    context.Entry(dialog).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    SendEvent(dialog.Users.Select(u => u.Id), new AddUser2DialogEvent(request.Id, dialog.Id, user.ToDto()));
                    return new ConnectToDialogResponse() {Result = Result.Successfully, DialogInfo = dialog.ToDto()};
                }
            );
        }

        /**
         * <summary>Удаляет пользователя из диалога, указанного в запросе</summary>
         * <param name="request">Запрос на выход из диалога</param>
         * <returns>Результат выполнения операции</returns>
         */
        public Response LeaveFromDialog(LeaveFromDialogRequest request)
        {
            return Perform(() =>
                {
                    User user = context.Users.Find(request.Id);
                    Dialog dialog = context.Dialogs.Find(request.DialogId);
                    if (!dialog.Users.Contains(user))
                        return new Response() { Result = Result.UserNotInDialog };
                    
                    dialog.Users.Remove(user);
                    context.Entry(dialog).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    SendEvent(dialog.Users.Select(u => u.Id), new UserLeaveFromDialogEvent(request.Id, dialog.Id));
                    return new Response() { Result = Result.Successfully };
                }
            );
        }

        /**
         * <summary>Изменяет название или пароль диалога и возвращает результат выполнения операции</summary>
         * <param name="request">Запрос на изменение диалога</param>
         * <returns>Результат выполнения операции</returns>
         */
        public Response ChangeDialog(ChangeDialogRequest request)
        {
            return Perform(() =>
                {
                    User user = context.Users.Find(request.Id);
                    Dialog dialog = context.Dialogs.Find(request.DialogId);
                    if (user.Id != dialog.OwnerId)
                        return new Response() { Result = Result.NotPremissions };

                    if (request.NewName != null)
                    {
                        if (context.Dialogs.Any(d => d.Name == request.NewName))
                            return new Response() { Result = Result.DialogNameAlreadyTaken };
                        dialog.Name = request.NewName;
                    }
                    if (request.NewPassword != null)
                        dialog.Password = request.NewPassword;
                    context.Entry(dialog).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    SendBroadcastEvent(new ChangeDialogEvent(request.Id, request));
                    return new Response() { Result = Result.Successfully };
                }
            );
        }
    }
}