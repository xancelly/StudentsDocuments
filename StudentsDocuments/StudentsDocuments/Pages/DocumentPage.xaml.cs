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
    /// Логика взаимодействия для DocumentPage.xaml
    /// </summary>
    public partial class DocumentPage : Page
    {
        public DocumentPage()
        {
            InitializeComponent();
            FilterComboBox.SelectedIndex = 0;
            DocumentDataGrid.ItemsSource = AppData.Context.Document.ToList();
            TypeDocumentComboBox.ItemsSource = AppData.Context.TypeDocument.ToList();
            StatusComboBox.ItemsSource = AppData.Context.Status.ToList();
            BasicOfLearningComboBox.ItemsSource = AppData.Context.BasicOfLearning.ToList();
            GroupComboBox.ItemsSource = AppData.Context.Group.ToList();
            CourseComboBox.ItemsSource = AppData.Context.Group.ToList();
            SpecialityComboBox.ItemsSource = AppData.Context.Speciality.ToList();
        }

        public void UpdateDocument()
        {
            var CurrentDocument = AppData.Context.Document.ToList();
            CurrentDocument = CurrentDocument.Where(c => c.Student.LastName.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Student.FirstName.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Student.MiddleName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            DocumentDataGrid.ItemsSource = CurrentDocument;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDocument();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditDocumentPage(null));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Document CurrentDocument = DocumentDataGrid.SelectedItem as Document;
            if (CurrentDocument != null)
            {
                NavigationService.Navigate(new EditDocumentPage(CurrentDocument));
            }
            else
            {
                MessageBox.Show("Выберите договор!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Document CurrentDocument = DocumentDataGrid.SelectedItem as Document;
            if (CurrentDocument != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить договор?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    AppData.Context.Document.Remove(CurrentDocument);
                    AppData.Context.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Договор был удален!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите обучающегося!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterComboBox.SelectedIndex == 0)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 1)
            {
                DateDocumentDatePicker.Visibility = Visibility.Visible;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 2)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Visible;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 3)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Visible;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 4)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Visible;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 5)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Visible;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 6)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Visible;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 7)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Visible;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 8)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Visible;
                SpecialityComboBox.Visibility = Visibility.Hidden;
            } else if (FilterComboBox.SelectedIndex == 9)
            {
                DateDocumentDatePicker.Visibility = Visibility.Hidden;
                DateStartDocumentDatePicker.Visibility = Visibility.Hidden;
                TypeDocumentComboBox.Visibility = Visibility.Hidden;
                StatusComboBox.Visibility = Visibility.Hidden;
                AssistanceTextBox.Visibility = Visibility.Hidden;
                BasicOfLearningComboBox.Visibility = Visibility.Hidden;
                GroupComboBox.Visibility = Visibility.Hidden;
                CourseComboBox.Visibility = Visibility.Hidden;
                SpecialityComboBox.Visibility = Visibility.Visible;
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            string letterList = "ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnoprstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            var CurrentDocument = AppData.Context.Document.ToList();
            if (FilterComboBox.SelectedIndex == 1 && DateDocumentDatePicker.SelectedDate != null)
            {
                CurrentDocument = CurrentDocument.Where(c => c.Date == DateDocumentDatePicker.SelectedDate).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else if (FilterComboBox.SelectedIndex == 2 && DateStartDocumentDatePicker.SelectedDate != null) {
                CurrentDocument = CurrentDocument.Where(c => c.DateStart == DateStartDocumentDatePicker.SelectedDate).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else if (FilterComboBox.SelectedIndex == 3 && TypeDocumentComboBox.SelectedItem != null) {
                CurrentDocument = CurrentDocument.Where(c => c.TypeDocument == TypeDocumentComboBox.SelectedItem).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else if (FilterComboBox.SelectedIndex == 4 && StatusComboBox.SelectedItem != null)
            {
                CurrentDocument = CurrentDocument.Where(c => c.Status == StatusComboBox.SelectedItem).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else if ((FilterComboBox.SelectedIndex == 5 && !String.IsNullOrWhiteSpace(AssistanceTextBox.Text)) && AssistanceTextBox.Text.IndexOfAny(letterList.ToCharArray()) <= -1)
            {
                CurrentDocument = CurrentDocument.Where(c => c.Assistance == Convert.ToDecimal(AssistanceTextBox.Text)).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else if (FilterComboBox.SelectedIndex == 6 && BasicOfLearningComboBox.SelectedItem != null)
            {
                CurrentDocument = CurrentDocument.Where(c => c.Student.BasicOfLearning == TypeDocumentComboBox.SelectedItem).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else if (FilterComboBox.SelectedIndex == 7 && GroupComboBox.SelectedItem != null)
            {
                CurrentDocument = CurrentDocument.Where(c => c.Student.Group == GroupComboBox.SelectedItem).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else if (FilterComboBox.SelectedIndex == 8 && CourseComboBox.SelectedItem != null)
            {
                CurrentDocument = CurrentDocument.Where(c => c.Student.Group.Course == Convert.ToInt32(CourseComboBox.SelectedItem)).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else if (FilterComboBox.SelectedIndex == 9 && SpecialityComboBox.SelectedItem != null)
            {
                CurrentDocument = CurrentDocument.Where(c => c.Student.Group.Speciality == SpecialityComboBox.SelectedItem).ToList();
                DocumentDataGrid.ItemsSource = CurrentDocument;
            } else
            {
                MessageBox.Show("Ошибка при вводе параметра!\nПожалуйста введите корректные данные для параметра!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDocument();
        }
    }
}
