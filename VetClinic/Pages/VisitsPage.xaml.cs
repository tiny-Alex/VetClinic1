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
    /// Логика взаимодействия для VisitsPage.xaml
    /// </summary>
    public partial class VisitsPage : Page
    {

        public VisitsPage()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            try
            {
                VisitsDataGrid.ItemsSource = DBconnection.vetEntities.Visits.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBconnection.vetEntities.Visits.Add(new Visits
                {
                    PetID = 1,
                    VeterinarianUserID = 1,
                    VisitDate = DateTime.Today,
                    Symptoms = "Симптомы",
                    Diagnosis = "Диагноз",
                    Prescription = "Назначение"
                });

                DBconnection.vetEntities.SaveChanges();
                LoadData();
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (VisitsDataGrid.SelectedItem is Visits visit)
            {
                var window = new VisitEditWindow(visit);
                if (window.ShowDialog() == true)
                {
                    DBconnection.vetEntities.SaveChanges();
                    MessageBox.Show("Визит сохранен");
                }
            }
            else
            {
                MessageBox.Show("Выберите визит");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (VisitsDataGrid.SelectedItem is Visits visit)
            {
                DBconnection.vetEntities.Visits.Remove(visit);
                DBconnection.vetEntities.SaveChanges();
                LoadData();
                MessageBox.Show("Удалено");
            }
            else
            {
                MessageBox.Show("Выберите запись");
            }
        }
    }
}
