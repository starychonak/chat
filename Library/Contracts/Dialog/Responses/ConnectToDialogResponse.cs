using System.Runtime.Serialization;
using Library.Contracts.DTO.Impl;

namespace Library.Contracts.Dialog.Responses
{
    [DataContract]
    public class ConnectToDialogResponse : Response
    {
        [DataMember]
        public DialogDTO DialogInfo { get; set; }
    }
}