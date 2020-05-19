using StudentsDocuments.Entities;
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

namespace StudentsDocuments.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
            StudentsDataGrid.ItemsSource = AppData.Context.Student.ToList();
        }

        public void UpdateStudents()
        {
            var CurrentStudent = AppData.Context.Student.ToList();
            CurrentStudent = CurrentStudent.Where(c => c.LastName.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.FirstName.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.MiddleName.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.PhoneNumber.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Group.Id.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Group.Speciality.Code.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Group.Speciality.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Address.Region.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Address.City.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Address.Street.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            StudentsDataGrid.ItemsSource = CurrentStudent;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateStudents();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditStudentPage(null));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Student CurrentStudent = StudentsDataGrid.SelectedItem as Student;
            if (CurrentStudent != null)
            {
                NavigationService.Navigate(new EditStudentPage(CurrentStudent));
            }
            else
            {
                MessageBox.Show("Выберите обучающегося!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Student CurrentStudent = StudentsDataGrid.SelectedItem as Student;
            if (CurrentStudent != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить обучающегося?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    AppData.Context.Student.Remove(CurrentStudent);
                    AppData.Context.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Обучающийся был удален!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите обучающегося!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateStudents();
        }
    }
}
