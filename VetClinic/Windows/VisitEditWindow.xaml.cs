using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для VisitEditWindow.xaml
    /// </summary>
    public partial class VisitEditWindow : Window
    {
        public Visits Visit { get; set; }

        public VisitEditWindow(Visits visit = null)
        {
            InitializeComponent();
            LoadPets();

            if (visit == null)
            {
                Visit = new Visits();
                TitleText.Text = "Новый визит";
                VisitDatePicker.SelectedDate = DateTime.Now;
            }
            else
            {
                Visit = visit;
                TitleText.Text = "Изменить визит";
                ShowVisitData();
            }
        }

        private void LoadPets()
        {
            try
            {
                var petsList = DBconnection.vetEntities.Pets.ToList();

                PetCombo.ItemsSource = petsList;
                PetCombo.DisplayMemberPath = "Name";
                PetCombo.SelectedValuePath = "PetID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить питомцев: " + ex.Message);
            }
        }

        private void ShowVisitData()
        {
            // Загружаем питомцев (это уже делается в LoadPets, но на всякий случай)
            var pets = DBconnection.vetEntities.Pets.ToList();
            PetCombo.ItemsSource = pets;
            PetCombo.DisplayMemberPath = "Name";
            PetCombo.SelectedValuePath = "PetID";

            // Проверяем, что Visit не null
            if (Visit == null)
            {
                Visit = new Visits();
                TitleText.Text = "Новый визит";
                VisitDatePicker.SelectedDate = DateTime.Now;
            }
            else
            {
                // Используем свойство Visit, а не параметр visit
                SymptomsBox.Text = Visit.Symptoms;
                DiagnosisBox.Text = Visit.Diagnosis;
                PrescriptionBox.Text = Visit.Prescription;
                VisitDatePicker.SelectedDate = Visit.VisitDate;

                if (Visit.PetID != null)
                    PetCombo.SelectedValue = Visit.PetID;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (PetCombo.SelectedItem == null)
            {
                MessageBox.Show("Выберите питомца");
                return;
            }

            Visit.Symptoms = SymptomsBox.Text;
            Visit.Diagnosis = DiagnosisBox.Text;
            Visit.Prescription = PrescriptionBox.Text;
            Visit.VisitDate = VisitDatePicker.SelectedDate ?? DateTime.Now; // Используем SelectedDate

            if (PetCombo.SelectedValue is int petId)
                Visit.PetID = petId;

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