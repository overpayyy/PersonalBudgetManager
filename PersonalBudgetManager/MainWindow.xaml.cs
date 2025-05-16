using PersonalBudgetManager.ViewModels;
using System.Windows;

namespace PersonalBudgetManager
{
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            PersonalBudgetManager.Data.BudgetContext.InitializeDatabase();

            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        private void AddTransaction_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tu będzie formularz dodawania transakcji.");
        }
    }
}