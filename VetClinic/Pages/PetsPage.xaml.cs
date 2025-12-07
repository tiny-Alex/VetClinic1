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
    /// Логика взаимодействия для PetsPage.xaml
    /// </summary>
    public partial class PetsPage : Page
    {
        public PetsPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            try
            {
                PetsDataGrid.ItemsSource = DBconnection.vetEntities.Pets.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки питомцев: " + ex.Message);
            }
        }

        private void AddPetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newPet = new Pets
                {
                    Name = "Новый питомец",
                    Species = "Собака",
                    Breed = "Дворняжка",
                    DateOfBirth = DateTime.Today.AddYears(-2),
                    Gender = "М",
                    ClientID = 1
                };

                DBconnection.vetEntities.Pets.Add(newPet);
                DBconnection.vetEntities.SaveChanges();
                Refresh();
                MessageBox.Show("Питомец добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void EditPetButton_Click(object sender, RoutedEventArgs e)
        {
            if (PetsDataGrid.SelectedItem is Pets pet)
            {
                var window = new PetEditWindow(pet);
                if (window.ShowDialog() == true)
                {
                    DBconnection.vetEntities.SaveChanges();
                    Refresh();
                    MessageBox.Show("Сохранено");
                }
            }
            else
            {
                MessageBox.Show("Выберите питомца");
            }
        }

        private void DeletePetButton_Click(object sender, RoutedEventArgs e)
        {
            if (PetsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите питомца для удаления");
                return;
            }

            try
            {
                var pet = PetsDataGrid.SelectedItem as Pets;
                DBconnection.vetEntities.Pets.Remove(pet);
                DBconnection.vetEntities.SaveChanges();
                Refresh();
                MessageBox.Show("Питомец удален");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }
    }
}
