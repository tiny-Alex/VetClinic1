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
using System.Windows.Shapes;
using VetClinic.db;

namespace VetClinic.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientEditWindow.xaml
    /// </summary>
    public partial class ClientEditWindow : Window
    {
        public Clients Client { get; set; }
        public ClientEditWindow(Clients client = null)
        {
            InitializeComponent();

            if (client == null)
            {
                Client = new Clients();
                TitleText.Text = "Новый клиент";
            }
            else
            {
                Client = client;
                FirstNameBox.Text = client.FirstName;
                LastNameBox.Text = client.LastName;
                PhoneBox.Text = client.PhoneNumber;
                EmailBox.Text = client.Email;
            }
        }

             private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameBox.Text))
            {
                MessageBox.Show("Введите имя");
                return;
            }

            Client.FirstName = FirstNameBox.Text;
            Client.LastName = LastNameBox.Text;
            Client.PhoneNumber = PhoneBox.Text;
            Client.Email = EmailBox.Text;

            if (Client.ClientID == 0)
                Client.RegistrationDate = DateTime.Now;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
    
}
