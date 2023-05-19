using System.Windows.Controls;

namespace MoneyChecker.Views
{
    /// <summary>
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            InitializeComponent();
            ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.DataSource;
        }

    }
}
