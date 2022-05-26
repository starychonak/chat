using System.Data.Entity;

namespace Library.Data
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DBConnection")
        {
        }
        
        public virtual DbSet<Dialog> Dialogs { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}