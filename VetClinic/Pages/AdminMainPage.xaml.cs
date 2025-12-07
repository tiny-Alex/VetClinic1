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

namespace VetClinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }
        private void AdminClientsButton_Click(object sender, RoutedEventArgs e)
        {
            AdminContentFrame.Navigate(new ClientsPage());
        }

        private void AdminPetsButton_Click(object sender, RoutedEventArgs e)
        {
            AdminContentFrame.Navigate(new PetsPage());
        }

        private void AdminVisitsButton_Click(object sender, RoutedEventArgs e)
        {
            AdminContentFrame.Navigate(new VisitsPage());
        }

        private void AdminUsersButton_Click(object sender, RoutedEventArgs e)
        {
            AdminContentFrame.Navigate(new UsersPage());
        }

        private void AdminServicesButton_Click(object sender, RoutedEventArgs e)
        {
            AdminContentFrame.Navigate(new ServicesPage());
        }

        private void AdminReportsButton_Click(object sender, RoutedEventArgs e)
        {
            AdminContentFrame.Navigate(new ReportsPage());
        }
    }
}
