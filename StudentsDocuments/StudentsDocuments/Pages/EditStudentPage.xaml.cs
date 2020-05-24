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
using StudentsDocuments.Entities;

namespace StudentsDocuments.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditStudentPage.xaml
    /// </summary>
    public partial class EditStudentPage : Page
    {
        Student CurrentStudent = null;
        Group CurrentGroup = null;
        BasicOfLearning CurrentBasicOfLearning = null;
        Education CurrentEducation = null;
        Passport CurrentPassport = null;
        Address CurrentAddress = null;
        public EditStudentPage(Student student)
        {
            InitializeComponent();
            CurrentStudent = student;
            GroupComboBox.ItemsSource = AppData.Context.Group.ToList();
            EducationComboBox.ItemsSource = AppData.Context.Education.ToList();
            BasicOfLearningComboBox.ItemsSource = AppData.Context.BasicOfLearning.ToList();
            if (CurrentStudent != null)
            {
                CurrentGroup = AppData.Context.Group.Where(c => c.Id == CurrentStudent.IdGroup).FirstOrDefault();
                CurrentEducation = AppData.Context.Education.Where(c => c.Id == CurrentStudent.IdEducation).FirstOrDefault();
                CurrentBasicOfLearning = AppData.Context.BasicOfLearning.Where(c => c.Id == CurrentStudent.IdBasicOfLearning).FirstOrDefault();
                CurrentAddress = AppData.Context.Address.Where(c => c.Id == CurrentStudent.IdAddress).FirstOrDefault();
                CurrentPassport = AppData.Context.Passport.Where(c => c.Id == CurrentStudent.IdPassport).FirstOrDefault();
                SaveButton.Content = "Сохранить";
                LastNameTextBox.Text = CurrentStudent.LastName;
                FirstNameTextBox.Text = CurrentStudent.FirstName;
                MiddleNameTextBox.Text = CurrentStudent.MiddleName;
                DateOfBirthDatePicker.SelectedDate = CurrentStudent.DateOfBirth;
                PhoneNumberTextBox.Text = CurrentStudent.PhoneNumber;
                GroupComboBox.SelectedItem = CurrentGroup as Group;
                EducationComboBox.SelectedItem = CurrentEducation as Education;
                PassportTextBox.Text = CurrentPassport.Serial + CurrentPassport.Number;
                DateOfIssueDatePicker.SelectedDate = CurrentPassport.DateOfIssue;
                IssuedByWhomTextBox.Text = CurrentPassport.IssuedByWhom;
                AreaTextBox.Text = CurrentAddress.Region;
                CityTextBox.Text = CurrentAddress.City;
                StreetTextBox.Text = CurrentAddress.Street;
                HouseTextBox.Text = CurrentAddress.House;
                ApartmentTextBox.Text = CurrentAddress.Apartment;
            } else {
                this.Title = "Добавление обучающегося";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string letterList = "ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnoprstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string numList = "1234567890";
            if (!String.IsNullOrWhiteSpace(LastNameTextBox.Text) && !String.IsNullOrWhiteSpace(FirstNameTextBox.Text) && !String.IsNullOrWhiteSpace(MiddleNameTextBox.Text) && !String.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) && !String.IsNullOrWhiteSpace(PassportTextBox.Text) && !String.IsNullOrWhiteSpace(IssuedByWhomTextBox.Text) && !String.IsNullOrWhiteSpace(AreaTextBox.Text) && !String.IsNullOrWhiteSpace(CityTextBox.Text) && !String.IsNullOrWhiteSpace(StreetTextBox.Text) && !String.IsNullOrWhiteSpace(HouseTextBox.Text) && DateOfBirthDatePicker.SelectedDate != null && GroupComboBox.SelectedItem != null && EducationComboBox.SelectedItem != null && DateOfIssueDatePicker.SelectedDate != null && BasicOfLearningComboBox.SelectedItem != null)
            {
                if (LastNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                {
                    if (FirstNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                    {
                        if (MiddleNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                        {
                            if (PhoneNumberTextBox.Text.Length == 18 && (PhoneNumberTextBox.Text.IndexOfAny(letterList.ToCharArray()) <= -1) && !PhoneNumberTextBox.Text.Contains('_'))
                            {
                                if (AreaTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                {
                                    if (CityTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                    {
                                        if (DateOfBirthDatePicker.SelectedDate < DateTime.Today)
                                        {
                                            if (!PassportTextBox.Text.Contains('_'))
                                            {
                                                if (DateOfIssueDatePicker.SelectedDate < DateTime.Today)
                                                {
                                                    if (CurrentStudent == null)
                                                    {
                                                        //if (AppData.Context.Passport.Where(c => c.Serial == PassportTextBox.Text.Remove(5, 7) && c.Number == PassportTextBox.Text.Remove(0, 6)).FirstOrDefault() == null)
                                                        //{
                                                            CurrentPassport = new Passport()
                                                            {
                                                                Serial = PassportTextBox.Text.Remove(5, 7).Replace(" ", ""),
                                                                Number = PassportTextBox.Text.Remove(0, 6),
                                                                DateOfIssue = DateOfIssueDatePicker.SelectedDate,
                                                                IssuedByWhom = IssuedByWhomTextBox.Text,
                                                            };
                                                            AppData.Context.Passport.Add(CurrentPassport);

                                                            CurrentAddress = new Address()
                                                            {
                                                                Region = AreaTextBox.Text,
                                                                City = CityTextBox.Text,
                                                                Street = StreetTextBox.Text,
                                                                House = HouseTextBox.Text,
                                                                Apartment = ApartmentTextBox.Text,
                                                            };
                                                            AppData.Context.Address.Add(CurrentAddress);

                                                            CurrentStudent = new Student()
                                                            {
                                                                LastName = LastNameTextBox.Text,
                                                                FirstName = FirstNameTextBox.Text,
                                                                MiddleName = MiddleNameTextBox.Text,
                                                                PhoneNumber = PhoneNumberTextBox.Text,
                                                                DateOfBirth = DateOfBirthDatePicker.SelectedDate,
                                                                Group = GroupComboBox.SelectedItem as Group,
                                                                Education = EducationComboBox.SelectedItem as Education,
                                                                IdPassport = CurrentPassport.Id,
                                                                IdAddress = CurrentAddress.Id,
                                                                BasicOfLearning = BasicOfLearningComboBox.SelectedItem as BasicOfLearning,
                                                            };
                                                            AppData.Context.Student.Add(CurrentStudent);
                                                            AppData.Context.SaveChanges();
                                                            MessageBox.Show("Обучающийся успешно добавлен!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                                                            NavigationService.GoBack();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        CurrentStudent.LastName = LastNameTextBox.Text;
                                                        CurrentStudent.FirstName = FirstNameTextBox.Text;
                                                        CurrentStudent.MiddleName = MiddleNameTextBox.Text;
                                                        CurrentStudent.PhoneNumber = PhoneNumberTextBox.Text;
                                                        CurrentStudent.DateOfBirth = DateOfBirthDatePicker.SelectedDate;
                                                        CurrentGroup = GroupComboBox.SelectedItem as Group;
                                                        CurrentBasicOfLearning = BasicOfLearningComboBox.SelectedItem as BasicOfLearning;
                                                        CurrentEducation = EducationComboBox.SelectedItem as Education;
                                                        CurrentPassport.Serial = PassportTextBox.Text.Remove(5, 7).Replace(" ", "");
                                                        CurrentPassport.Number = PassportTextBox.Text.Remove(0, 6);
                                                        CurrentPassport.DateOfIssue = DateOfIssueDatePicker.SelectedDate;
                                                        CurrentPassport.IssuedByWhom = IssuedByWhomTextBox.Text;
                                                        CurrentAddress.Region = AreaTextBox.Text;
                                                        CurrentAddress.City = CityTextBox.Text;
                                                        CurrentAddress.Street = StreetTextBox.Text;
                                                        CurrentAddress.House = HouseTextBox.Text;
                                                        CurrentAddress.Apartment = ApartmentTextBox.Text;
                                                        AppData.Context.SaveChanges();
                                                        MessageBox.Show("Информация обновлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                                                        NavigationService.GoBack();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Дата выдачи паспорта указаны некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                    DateOfIssueDatePicker.Focus();
                                                }
                                            //}
                                            //else
                                            //{
                                            //    MessageBox.Show("Серия и номер паспорта указаны некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                            //    PassportTextBox.Focus();
                                            //}
                                        }
                                        else
                                        {
                                            MessageBox.Show("Дата рождения указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                            DateOfBirthDatePicker.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Город указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                        CityTextBox.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Область указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    AreaTextBox.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Номер телефона указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                LastNameTextBox.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Отчество указано некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            MiddleNameTextBox.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Имя указано некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        FirstNameTextBox.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Фамилия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    LastNameTextBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
