using MoneyChecker.Entities;
using System.Windows;

namespace MoneyChecker.Commands.CategoryEditor
{
    /// <summary>
    /// Логика взаимодействия для Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public Category category;

        public Editor()
        {
            InitializeComponent();
            category = new Category();
        }

        public Editor(Category categori)
        {
            InitializeComponent();
            category = categori;

            TextBox_Name.Text = category.Title;
            TextBox_Discription.Text = category.Description;

            ////////NEED FIX
            //_category.ImgSrc =
        }

        public Editor(Category categori, int parentId)
        {
            InitializeComponent();
            category = categori;
            category.ParentId = parentId;

            TextBox_Name.Text = category.Title;
            TextBox_Discription.Text = category.Description;

            ////////NEED FIX
            //_category.ImgSrc =
        }


        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox_Name.Text.Length > 4) 
            {
                category.Title = TextBox_Name.Text;
                category.Description = TextBox_Discription.Text;
                DialogResult = true;

                ////////NEED FIX
                //_category.ImgSrc =

                this.Close();
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
