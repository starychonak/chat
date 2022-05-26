using System;

namespace Library.Contracts.DTO.Impl
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastActivity { get; set; }
        
        public UserDTO(Data.Entities.User user)
        {
            Id = user.Id;
            Name = user.Login;
            IsOnline = false;
            LastActivity = user.LastActivity;
        }
    }
}