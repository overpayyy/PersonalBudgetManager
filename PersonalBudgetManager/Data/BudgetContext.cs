using Microsoft.EntityFrameworkCore;
using PersonalBudgetManager.Models;
using System.Collections.Generic;

namespace PersonalBudgetManager.Data
{
    public class BudgetContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=budget.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Foof", Type = "Expense" },
                new Category { Id = 2, Name = "Salary", Type = "Income" }
            );
        }
    }
}