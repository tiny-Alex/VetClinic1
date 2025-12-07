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
    /// Логика взаимодействия для ServiceEditWindow.xaml
    /// </summary>
    public partial class ServiceEditWindow : Window
    {
        public Services Service { get; set; }
        public ServiceEditWindow(Services service = null)
        {
            InitializeComponent();
            if (service == null)
            {
                Service = new Services();
                TitleText.Text = "Новая услуга";
            }
            else
            {
                Service = service;
                NameBox.Text = service.ServiceName;
                DescriptionBox.Text = service.Description;
                PriceBox.Text = service.Price.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("Введите название услуги");
                return;
            }

            Service.ServiceName = NameBox.Text;
            Service.Description = DescriptionBox.Text;

            if (decimal.TryParse(PriceBox.Text, out decimal price))
                Service.Price = price;
            else
                Service.Price = 0;

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
