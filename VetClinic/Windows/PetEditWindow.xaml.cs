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
    /// Логика взаимодействия для PetEditWindow.xaml
    /// </summary>
    public partial class PetEditWindow : Window
    {
        public Pets Pet { get; set; }
        public PetEditWindow(Pets pet = null)
        {
            InitializeComponent();
            var clients = DBconnection.vetEntities.Clients.ToList();
            OwnerCombo.ItemsSource = clients;
            OwnerCombo.DisplayMemberPath = "LastName";
            OwnerCombo.SelectedValuePath = "ClientID";

            if (pet == null)
            {
                Pet = new Pets();
                TitleText.Text = "Новый питомец";
            }
            else
            {
                Pet = pet;
                NameBox.Text = pet.Name;
                BreedBox.Text = pet.Breed;
                BirthDatePicker.SelectedDate = pet.DateOfBirth;

                if (pet.ClientID != null)
                    OwnerCombo.SelectedValue = pet.ClientID;
            }
        }
              private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("Введите имя питомца");
                return;
            }

            Pet.Name = NameBox.Text;
            Pet.Breed = BreedBox.Text;
            Pet.DateOfBirth = BirthDatePicker.SelectedDate;

            if (SpeciesCombo.SelectedItem is ComboBoxItem speciesItem)
                Pet.Species = speciesItem.Content.ToString();

            if (GenderCombo.SelectedItem is ComboBoxItem genderItem)
                Pet.Gender = genderItem.Content.ToString();

            if (OwnerCombo.SelectedValue is int ownerId)
                Pet.ClientID = ownerId;

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
