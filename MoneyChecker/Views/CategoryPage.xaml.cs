using MoneyChecker.Commands.CategoryEditor;
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

        private void Button_NewCat_Click(object sender, RoutedEventArgs e)
        {
            Editor _editor = new Editor();

            if(_editor.ShowDialog() == true)
            {
                Category category = _editor.category;

                MainWindow.MainViewModel.CategoryViewModel.CategoryModel.AddNewCategory(category);
                
                ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;


            }
        }

        private void Button_DellCat_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {
                MainWindow.MainViewModel.CategoryViewModel.CategoryModel.DeleteCategory(((Category)ListBoxCategories.SelectedItem));

                ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;

                ListBoxSubSubCategories.ItemsSource = null;

                ListBoxSubCategories.ItemsSource = null;

            }
        }

        private void Button_EdtCat_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {
                Editor _editor = new Editor(((Category)ListBoxCategories.SelectedItem));

                if (_editor.ShowDialog() == true)
                {
                    MainWindow.MainViewModel.CategoryViewModel.CategoryModel.EditCategory(_editor.category);

                    ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;
                }
            }
        }

        private void Button_NewSubCat_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {
                Editor _editor = new Editor(
                    new Category(), ((Category)ListBoxCategories.SelectedItem).Id);

                if (_editor.ShowDialog() == true)
                {
                    Category category = _editor.category;

                    MainWindow.MainViewModel.CategoryViewModel.CategoryModel.AddNewCategory(category);

                    var tmp = ((Category)ListBoxCategories.SelectedItem);


                    ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;

                    ListBoxCategories.SelectedItem = tmp;

                    ListBoxSubCategories.ItemsSource =
                            ((Category)ListBoxCategories.SelectedItem).SubCategories;

                }
            }
        }

        private void Button_DellSubCat_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {
                if(ListBoxSubCategories.SelectedItem != null)
                {

                    MainWindow.MainViewModel.CategoryViewModel.CategoryModel.DeleteCategory(((Category)ListBoxSubCategories.SelectedItem));

                    var tmp = ((Category)ListBoxCategories.SelectedItem);

                    ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;

                    ListBoxCategories.SelectedItem = tmp;

                    ListBoxSubCategories.ItemsSource =
                            ((Category)ListBoxCategories.SelectedItem).SubCategories;

                    ListBoxSubSubCategories.ItemsSource = null;
                }
            }
        }

        private void Button_EdtSubCat_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {
                if (ListBoxSubCategories.SelectedItem != null)
                {
                    Editor _editor = new Editor(((Category)ListBoxSubCategories.SelectedItem));

                    if (_editor.ShowDialog() == true)
                    {
                        var tmp = ((Category)ListBoxCategories.SelectedItem);

                        MainWindow.MainViewModel.CategoryViewModel.CategoryModel.EditCategory(_editor.category);
                        
                        ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;

                        ListBoxCategories.SelectedItem = tmp;

                        ListBoxSubCategories.ItemsSource =
                                ((Category)ListBoxCategories.SelectedItem).SubCategories;

                    }
                }
            }
        }

        private void Button_NewSubSubCat_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {
                if(ListBoxSubCategories.SelectedItem != null)
                {

                    Editor _editor = new Editor(
                        new Category(), ((Category)ListBoxSubCategories.SelectedItem).Id);

                    if (_editor.ShowDialog() == true)
                    {
                        Category category = _editor.category;

                        MainWindow.MainViewModel.CategoryViewModel.CategoryModel.AddNewCategory(category);

                        var tmp = ((Category)ListBoxCategories.SelectedItem);
                        var tmpSub = ((Category)ListBoxSubCategories.SelectedItem);

                        ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;

                        ListBoxCategories.SelectedItem = tmp;

                        ListBoxSubSubCategories.ItemsSource =
                                ((Category)ListBoxSubCategories.SelectedItem).SubCategories;

                        ListBoxSubCategories.SelectedItem = tmpSub;
                    }
                }
            }
        }

        private void Button_EdtSubSubCat_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {
                if (ListBoxSubCategories.SelectedItem != null)
                {
                    if (ListBoxSubSubCategories.SelectedItem != null)
                    {

                        Editor _editor = new Editor(((Category)ListBoxSubSubCategories.SelectedItem));

                        if (_editor.ShowDialog() == true)
                        {

                            MainWindow.MainViewModel.CategoryViewModel.CategoryModel.EditCategory(_editor.category);

                            var tmp = ((Category)ListBoxCategories.SelectedItem);
                            var tmpSub = ((Category)ListBoxSubCategories.SelectedItem);

                            ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;

                            ListBoxCategories.SelectedItem = tmp;

                            ListBoxSubSubCategories.ItemsSource =
                                    ((Category)ListBoxSubCategories.SelectedItem).SubCategories;

                            ListBoxSubCategories.SelectedItem = tmpSub;
                        }
                    }
                }
            }

        }

        private void Button_DellSubSubCat_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCategories.SelectedItem != null)
            {

                if (ListBoxSubCategories.SelectedItem != null)
                {
                    if (ListBoxSubSubCategories.SelectedItem != null)
                    {

                        MainWindow.MainViewModel.CategoryViewModel.CategoryModel.DeleteCategory(((Category)ListBoxSubSubCategories.SelectedItem));

                        var tmp = ((Category)ListBoxCategories.SelectedItem);
                        var tmpSub = ((Category)ListBoxSubCategories.SelectedItem);

                        ListBoxCategories.ItemsSource = MainWindow.MainViewModel.CategoryViewModel.GetOnlyCategories;

                        ListBoxCategories.SelectedItem = tmp;

                        ListBoxSubSubCategories.ItemsSource =
                                ((Category)ListBoxSubCategories.SelectedItem).SubCategories;

                        ListBoxSubCategories.SelectedItem = tmpSub;
                    }
                }
            }
        }
    }
}
