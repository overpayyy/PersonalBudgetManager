using PersonalBudgetManager.Data;
using PersonalBudgetManager.Models;
using System;
using System.Linq;
using System.Windows;

namespace PersonalBudgetManager
{
    public partial class AddTransactionWindow : Window
    {
        public AddTransactionWindow()
        {
            InitializeComponent();
            LoadCategories();
            DatePicker.SelectedDate = DateTime.Today;
        }

        private void LoadCategories()
        {
            using (var db = new BudgetContext())
            {
                var categories = db.Categories.ToList();
                CategoryComboBox.ItemsSource = categories;
                CategoryComboBox.DisplayMemberPath = "Name";
                CategoryComboBox.SelectedIndex = 0;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem is Category selectedCategory &&
                decimal.TryParse(AmountTextBox.Text, out decimal amount) &&
                DatePicker.SelectedDate.HasValue)
            {
                var transaction = new Transaction
                {
                    CategoryId = selectedCategory.Id,
                    Amount = amount,
                    Date = DatePicker.SelectedDate.Value,
                    Description = DescriptionTextBox.Text
                };

                using (var db = new BudgetContext())
                {
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly.");
            }
        }
    }
}
