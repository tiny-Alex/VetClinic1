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
using VetClinic.db;
using VetClinic.Windows;

namespace VetClinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            try
            {
                ServicesDataGrid.ItemsSource = DBconnection.vetEntities.Services.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки услуг: " + ex.Message);
            }
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newService = new Services
                {
                    ServiceName = "Новая услуга",
                    Description = "Описание новой услуги",
                    Price = 1000
                };

                DBconnection.vetEntities.Services.Add(newService);
                DBconnection.vetEntities.SaveChanges();
                Refresh();
                MessageBox.Show("Услуга добавлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void EditServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem is Services service)
            {
                var window = new ServiceEditWindow(service);
                if (window.ShowDialog() == true)
                {
                    DBconnection.vetEntities.SaveChanges();
                    Refresh();
                    MessageBox.Show("Услуга сохранена");
                }
            }
            else
            {
                MessageBox.Show("Выберите услугу");
            }
        }

        private void DeleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите услугу для удаления");
                return;
            }

            try
            {
                var service = ServicesDataGrid.SelectedItem as Services;
                DBconnection.vetEntities.Services.Remove(service);
                DBconnection.vetEntities.SaveChanges();
                Refresh();
                MessageBox.Show("Услуга удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }
    }
}
