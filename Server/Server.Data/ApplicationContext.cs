using Microsoft.EntityFrameworkCore;
using Server.Data.Classes;

namespace Server.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .HasMany(t => t.Tags)
                .WithOne();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Todos)
                .WithOne();

            modelBuilder.Entity<User>()
                 .HasIndex(u => u.Login)
                 .IsUnique();
        }
    }
}
