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
    /// Логика взаимодействия для VetMainPage.xaml
    /// </summary>
    public partial class VetMainPage : Page
    {
        public VetMainPage()
        {
            InitializeComponent();
        }
        private void VetVisitsButton_Click(object sender, RoutedEventArgs e)
        {
            VetContentFrame.Navigate(new VisitsPage());
        }

        private void VetPatientsButton_Click(object sender, RoutedEventArgs e)
        {
            VetContentFrame.Navigate(new PetsPage());
        }

        private void VetScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Расписание");
        }
    }
}
