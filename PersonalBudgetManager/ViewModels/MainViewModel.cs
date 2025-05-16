using PersonalBudgetManager.Data;
using PersonalBudgetManager.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PersonalBudgetManager.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; set; }

        public MainViewModel()
        {
            LoadTransactions();
        }

        public void LoadTransactions()
        {
            using (var db = new BudgetContext())
            {
                var transactionsFromDb = db.Transactions
                    .OrderByDescending(t => t.Date)
                    .ToList();

                Transactions = new ObservableCollection<Transaction>(transactionsFromDb);
            }
        }
    }
}