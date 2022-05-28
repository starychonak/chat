using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Dialog.Responses
{
    [DataContract]
    public class CreateDialogResponse : Response
    {
        [DataMember]
        public DialogDTO Dialog { get; set; }
    }
}