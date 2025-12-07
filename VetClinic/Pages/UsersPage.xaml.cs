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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            try
            {
                UsersDataGrid.ItemsSource = DBconnection.vetEntities.Users.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки пользователей: " + ex.Message);
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newUser = new Users
                {
                    Username = "Новый пользователь",
                    PasswordHash = "12345", // В реальном приложении здесь должен быть хэш пароля
                    Email = "user@example.com",
                    RoleID = 2 // ID обычного пользователя
                };

                DBconnection.vetEntities.Users.Add(newUser);
                DBconnection.vetEntities.SaveChanges();
                Refresh();
                MessageBox.Show("Пользователь добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {

            if (UsersDataGrid.SelectedItem is Users user)
            {
                var window = new UserEditWindow(user);
                if (window.ShowDialog() == true)
                {
                    DBconnection.vetEntities.SaveChanges();
                    Refresh();
                    MessageBox.Show("Пользователь сохранен");
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя");
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя для удаления");
                return;
            }

            try
            {
                var user = UsersDataGrid.SelectedItem as Users;
                DBconnection.vetEntities.Users.Remove(user);
                DBconnection.vetEntities.SaveChanges();
                Refresh();
                MessageBox.Show("Пользователь удален");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }

    }
}
