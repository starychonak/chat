using System.Data.Entity;
using Library.Data.Entities;

namespace Library.Data
{
    /**
     * <summary>Контекст базы данных, служащий для обращения к ее таблицам</summary>
     */
    public class DBContext : DbContext
    {
        public DBContext() : base("ChatAppDBConnection")
        {
        }
        
        public virtual DbSet<Dialog> Dialogs { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dialog>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Dialog)
                .HasForeignKey(e => e.DialogId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dialog>()
                .HasMany(e => e.Users)
                .WithMany(e => e.OwnedDialogs)
                .Map(m => m.ToTable("UsersDialogs"));
            
            modelBuilder.Entity<User>()
                .HasMany(e => e.Dialogs)
                .WithRequired(e => e.Owner)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete();
            
            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete();
        }
    }
}