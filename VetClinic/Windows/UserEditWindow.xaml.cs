using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VetClinic.db;

namespace VetClinic.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserEditWindow.xaml
    /// </summary>
    public partial class UserEditWindow : Window
    {
        public Users User { get; set; }
        public UserEditWindow(Users user = null)
        {
            InitializeComponent();
            var roles = DBconnection.vetEntities.Roles.ToList();
            RoleCombo.ItemsSource = roles;
            RoleCombo.DisplayMemberPath = "RoleName";
            RoleCombo.SelectedValuePath = "RoleID";

            if (user == null)
            {
                User = new Users();
                TitleText.Text = "Новый пользователь";
            }
            else
            {
                User = user;
                UsernameBox.Text = user.Username;
                EmailBox.Text = user.Email;

                if (user.RoleID != null)
                    RoleCombo.SelectedValue = user.RoleID;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }

            User.Username = UsernameBox.Text;
            User.Email = EmailBox.Text;

            if (!string.IsNullOrEmpty(PasswordBox.Password))
            {
                User.PasswordHash = HashPassword(PasswordBox.Password);
            }

            if (RoleCombo.SelectedValue is int roleId)
                User.RoleID = roleId;

            DialogResult = true;
            Close();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
