using Microsoft.EntityFrameworkCore;
using project1.Models;

namespace project1.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice", Password = "password123", Email = "alice@example.com" },
                new User { Id = 2, Name = "Bob", Password = "password456", Email = "bob@example.com" },
                new User { Id = 3, Name = "Ayesha", Password = "password789", Email = "ayesha2209b@aptechgdn.net" }
            );
        }
    }

}
