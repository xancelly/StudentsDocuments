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
    /// Логика взаимодействия для EditGroupPage.xaml
    /// </summary>
    public partial class EditGroupPage : Page
    {
        Group CurrentGroup = null;
        Speciality CurrentSpeciality = null;
        public EditGroupPage(Group group)
        {
            InitializeComponent();
            SpecialityCodeComboBox.ItemsSource = AppData.Context.Speciality.ToList();
            CurrentGroup = group;
            if (CurrentGroup != null)
            {
                CurrentSpeciality = AppData.Context.Speciality.Where(c => c.Code == CurrentGroup.CodeSpeciality).FirstOrDefault();
                SaveButton.Content = "Сохранить";
                GroupTextBox.IsEnabled = false;
                GroupTextBox.Text = CurrentGroup.Id;
                CouseTextBox.Text = Convert.ToString(CurrentGroup.Course);
                DirectionTextBox.Text = CurrentSpeciality.Direction;
                SpecialityCodeComboBox.SelectedItem = CurrentSpeciality as Speciality;
            } else
            {
                this.Title = "Добавление учебной группы";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string crs = "12345";
            if (!String.IsNullOrWhiteSpace(GroupTextBox.Text) && !String.IsNullOrWhiteSpace(DirectionTextBox.Text) && SpecialityCodeComboBox.SelectedItem != null)
            {
                if (!GroupTextBox.Text.Contains('_'))
                {
                    if (!CouseTextBox.Text.Contains('_') && !(CouseTextBox.Text.IndexOfAny(crs.ToCharArray()) <= -1))
                    {
                        if (CurrentGroup == null)
                        {
                            if (AppData.Context.Group.Where(c => c.Id == GroupTextBox.Text).FirstOrDefault() == null)
                            {
                                CurrentGroup = new Group()
                                {
                                    Id = GroupTextBox.Text,
                                    Speciality = CurrentSpeciality,
                                    Course = Convert.ToInt32(CouseTextBox.Text),
                                };
                                AppData.Context.Group.Add(CurrentGroup);
                                AppData.Context.SaveChanges();
                                MessageBox.Show("Группа успешно добавлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                                NavigationService.GoBack();
                            }
                            else
                            {
                                MessageBox.Show("Группа с таким номером уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            CurrentGroup.Id = GroupTextBox.Text;
                            CurrentGroup.Speciality = CurrentSpeciality;
                            CurrentGroup.Course = Convert.ToInt32(CouseTextBox.Text);
                            MessageBox.Show("Информация обновлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppData.Context.SaveChanges();
                            NavigationService.GoBack();
                        }
                    } else
                    {
                        MessageBox.Show("Курс указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else
                {
                    MessageBox.Show("№ группы указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SpecialityCodeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentSpeciality = SpecialityCodeComboBox.SelectedItem as Speciality;
            DirectionTextBox.Text = CurrentSpeciality.Direction;
        }
    }
}
