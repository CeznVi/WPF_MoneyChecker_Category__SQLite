using Microsoft.Win32;
using MoneyChecker.Entities;
using MoneyChecker.TabControls;
using MoneyChecker.Views;
using MoneyChecker.ViewsModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MoneyChecker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TabViewController _tabViewController;
        public static MainWindowViewModel MainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void InitUI()
        {
            _tabViewController = new TabViewController();

            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.calendar, "Календарь"), new CalendarPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.bagCalc, "Бюджет"), new BudgetPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.main, "Категории"), new CategoryPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.hand, "Валюты"), new CurencyPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.handmoney, "Дебит"), new DebitPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.arcStr, "Инвойсы"), new InvoicePage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.docs, "Отчеты"), new RepotsPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.search, "Обзор"), new SearchPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.shedule, "Задачи"), new SheullerPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.transaction, "Транзакции"), new TransactionPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.people, "Пользователи"), new UsersPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.option, "Настройки"), new RepotsPage()));

            MainWindowGrid.Children.Add(_tabViewController.Body);

            Grid.SetRow(_tabViewController.Body, 1);
            Grid.SetColumn(_tabViewController.Body, 0);

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DB Files|*.db;";

            string filePath = AppDomain.CurrentDomain.BaseDirectory.Split("\\MoneyChecker\\bin\\Debug\\")[0] + "\\DataBaseSQLite";

            if (!Directory.Exists(filePath))
                filePath = AppDomain.CurrentDomain.BaseDirectory;

            openFileDialog.InitialDirectory = filePath;

            if (openFileDialog.ShowDialog() == true)
            {
                MainViewModel = new MainWindowViewModel(new SQLiteDbContext(openFileDialog.FileName));
                if (_tabViewController != null)
                {
                    _tabViewController.Body.Children.Clear();
                }
                InitUI();
            }
        }
    }
}
