using Microsoft.Win32;
using MoneyChecker.Entities;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Serialization;

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

            ImageBrowse.Source = new ImageSourceConverter().ConvertFromString(category.ImgSrc) as ImageSource;
        }

        public Editor(Category categori, int parentId)
        {
            InitializeComponent();
            category = categori;
            category.ParentId = parentId;

            TextBox_Name.Text = category.Title;
            TextBox_Discription.Text = category.Description;

            ImageBrowse.Source = new ImageSourceConverter().ConvertFromString(category.ImgSrc) as ImageSource;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            string filePath = AppDomain.CurrentDomain.BaseDirectory.Split("\\MoneyChecker\\bin\\Debug\\")[0] + "\\images";

            if (!Directory.Exists(filePath))
                filePath = AppDomain.CurrentDomain.BaseDirectory;

            openFileDialog.InitialDirectory = filePath;

            if (openFileDialog.ShowDialog() == true)
            {
                category.ImgSrc = openFileDialog.FileName;
                ImageBrowse.Source = new ImageSourceConverter().ConvertFromString(category.ImgSrc) as ImageSource;

            }

        }
    }
}
