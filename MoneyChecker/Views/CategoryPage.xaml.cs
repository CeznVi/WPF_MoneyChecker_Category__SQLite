using MoneyChecker.Entities;
using System.Windows;
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
            ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;

            
        }

        private void ListBoxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {
                if (((Category)ListBoxCategories.SelectedItem).SubCategories.Count > 0)
                {
                    ListBoxSubCategories.ItemsSource =
                            ((Category)ListBoxCategories.SelectedItem).SubCategories;
                }
                else
                {
                    ListBoxSubCategories.ItemsSource = null;
                    ListBoxSubCategories.Items.Clear();

                    ListBoxSubSubCategories.ItemsSource = null;
                    ListBoxSubSubCategories.Items.Clear();
                }
            }
            
        }

        private void ListBoxSubCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxSubCategories.SelectedItem != null)
            {
                if (((Category)ListBoxSubCategories.SelectedItem).SubCategories.Count > 0)
                {
                    ListBoxSubSubCategories.ItemsSource =
                            ((Category)ListBoxSubCategories.SelectedItem).SubCategories;
                }
                else
                {
                    ListBoxSubSubCategories.ItemsSource = null;
                    ListBoxSubSubCategories.Items.Clear();
                }
            }
        }

        private void ListBoxSubSubCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
