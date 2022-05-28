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
     *  Таблица базы данных, хранящая информацию о пользователе 
     * </summary>
     */
    public class User : IDto<UserDTO>
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime LastActivity { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dialog> Dialogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dialog> OwnedDialogs { get; set; }
        
        public User()
        {
            Id = Guid.NewGuid();
            Dialogs = new HashSet<Dialog>();
            Messages = new HashSet<Message>();
            OwnedDialogs = new HashSet<Dialog>();
        }
        
        /**
         *<summary>
         * Инициализация пользователя с заданным логином и паролем
         * </summary>
         * <param name="login">Логин пользователя</param>
         * <param name="password">Пароль пользователя</param>
         */
        public User(string login, string password) : this()
        {
            Login = login;
            Password = password;
            LastActivity = DateTime.UtcNow;
        }
        
        public UserDTO ToDto()
        {
            return new UserDTO(this);
        }
    }
}