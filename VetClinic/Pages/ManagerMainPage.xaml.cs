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
    /// Логика взаимодействия для ManagerMainPage.xaml
    /// </summary>
    public partial class ManagerMainPage : Page
    {
        public ManagerMainPage()
        {
            InitializeComponent();
        }

        private void ManagerClientsButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerContentFrame.Navigate(new ClientsPage());
        }

        private void ManagerVisitsButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerContentFrame.Navigate(new VisitsPage());
        }

        private void ManagerFinanceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Финансы");
        }

        private void ManagerReportsButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerContentFrame.Navigate(new ReportsPage());
        }
    }
}
