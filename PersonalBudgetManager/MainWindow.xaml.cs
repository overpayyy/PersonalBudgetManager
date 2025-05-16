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
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }
    }
}