using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookRentalApp.Models;


namespace BookRentalApp.Data
{
    //trida pro pristup nasich entit do databaze
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = System.IO.Path.Combine(AppContext.BaseDirectory, "bookrental.db");
            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
