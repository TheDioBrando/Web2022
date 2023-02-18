using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using WebApiLearning.Models;

namespace WebApiLearning.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=Library;Username=postgres;Password=poo");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Orders>()
                .HasOne(o => o.Book)
                .WithMany(o => o.Orders)
                .HasForeignKey(o=>o.BookId);

            builder.Entity<Orders>()
                .HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId);
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Books> Books { get; set; }

        public DbSet<Orders> Orders { get; set; }
    }
}
