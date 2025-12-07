using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VetClinic.Pages;

namespace VetClinic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AdminPageButton.Click += AdminPageButton_Click;
            VetPageButton.Click += VetPageButton_Click;
            ManagerPageButton.Click += ManagerPageButton_Click;
        }
        private void AdminPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentRoleText.Text = "Роль: Администратор";
            MainFrame.Navigate(new AdminMainPage());
        }

        private void VetPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentRoleText.Text = "Роль: Ветеринар";
            MainFrame.Navigate(new VetMainPage());
        }

        private void ManagerPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentRoleText.Text = "Роль: Менеджер";
            MainFrame.Navigate(new ManagerMainPage());
        }
    }
}
