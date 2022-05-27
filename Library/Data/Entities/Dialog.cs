using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Contracts.DTO;
using Library.Contracts.DTO.Impl;

namespace Library.Data.Entities
{
    /**
     * <summary>
     *  Таблица базы данных, хранящая информацию о диалогах
     * </summary>
     */
    public class Dialog : IDto<DialogDTO>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dialog()
        {
            Messages = new HashSet<Message>();
            Users = new HashSet<User>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public string Password { get; set; }

        public Guid OwnerId { get; set; }

        public virtual User Owner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
        
        /**
         *<summary>
         * Инициализация диалога 
         * </summary>
         * <param name="id">Уникальный идентфикатор диалога</param>
         * <param name="ownerId">GUID пользователя-владельца диалога</param>
         * <param name="name">Название диалога</param>
         * <param name="password">Пароль</param>
         */
        public Dialog(int id, Guid ownerId, string name, string password)
            : this()
        {
            Id = id;
            Name = name;
            OwnerId = ownerId;
            Password = password;
        }
        
        public DialogDTO ToDto()
        {
            throw new System.NotImplementedException();
        }
    }
}