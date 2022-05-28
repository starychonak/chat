using System;
using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Dialog
{
    /**
     * <summary>Содержит данные о событии добавдения пользователя в диалог</summary>
     */
    [DataContract]
    public class CreateDialogEvent : ServerEvent
    {
        [DataMember] public DialogDTO NewDialog { get; set; }

        public CreateDialogEvent(Guid id, DialogDTO newDialog) : base(id)
        {
            NewDialog = newDialog;
        }
    }
}