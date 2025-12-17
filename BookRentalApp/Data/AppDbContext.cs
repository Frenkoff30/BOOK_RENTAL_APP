using Microsoft.EntityFrameworkCore;
using BookRentalApp.Models;

namespace BookRentalApp.Data
{
    // třída pro přístup k databázi
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = System.IO.Path.Combine(AppContext.BaseDirectory, "bookrental.db");
            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
