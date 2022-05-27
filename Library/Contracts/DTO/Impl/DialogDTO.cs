using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Library.Contracts.DTO.Impl
{
    /**
     * <summary>
     * Класс, хранящий информацию о диалоге.
     * Служит для передачи этой информации клиентам сервиса
     * </summary>
     */
    [DataContract]
    public class DialogDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid OwnerId { get; set; }

        [DataMember]
        public IEnumerable<MessageDTO> Messages { get; set; }

        [DataMember]    
        public IEnumerable<UserDTO> Users { get; set; }
        
        public DialogDTO(Data.Entities.Dialog dialog)
        {
            Id = dialog.Id;
            Name = dialog.Name;
            OwnerId = dialog.OwnerId;
            Users = dialog.Users.Select(u => u.ToDto());
            Messages = dialog.Messages.Reverse().Take(50).Reverse().Select(m => m.ToDto());
        }
    }
}