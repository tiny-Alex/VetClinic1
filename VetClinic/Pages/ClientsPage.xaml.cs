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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            Refresh();
        }
      
        private void Refresh()
        {
            try
            {
                ClientsDataGrid.ItemsSource = DBconnection.vetEntities.Clients.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки клиентов: " + ex.Message);
            }
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newClient = new Clients
                {
                    FirstName = "Новый",
                    LastName = "Клиент",
                    PhoneNumber = "+79990000000",
                    Email = "new@example.com",
                    RegistrationDate = DateTime.Today
                };

                DBconnection.vetEntities.Clients.Add(newClient);
                DBconnection.vetEntities.SaveChanges();
                Refresh();
                MessageBox.Show("Клиент добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void EditClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem is Clients client)
            {
                var window = new ClientEditWindow(client);
                if (window.ShowDialog() == true)
                {
                    DBconnection.vetEntities.SaveChanges();
                    Refresh();
                    MessageBox.Show("Сохранено");
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента");
            }
        }

        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента для удаления");
                return;
            }

            try
            {
                var client = ClientsDataGrid.SelectedItem as Clients;
                DBconnection.vetEntities.Clients.Remove(client);
                DBconnection.vetEntities.SaveChanges();

                Refresh();
                MessageBox.Show("Клиент удален");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }
    }
}
