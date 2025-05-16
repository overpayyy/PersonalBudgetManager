﻿namespace PersonalBudgetManager.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}