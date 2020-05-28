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
    /// Логика взаимодействия для EditDocumentPage.xaml
    /// </summary>
    public partial class EditDocumentPage : Page
    {
        Document CurrentDocument = null;
        Address CurrentAddressEmployee = null;
        Address CurrentAddressInstitution = null;
        Organization CurrentOrganizationEmloyee = null;
        Organization CurrentOrganizationInstitution = null;
        Student CurrentStudent = null;
        Address CurrentAddressStudent = null;
        BankDetail CurrentBankDetailEmployee = null;
        BankDetail CurrentBankDetailInstitution = null;
        Passport CurrentPassport = null;

        public EditDocumentPage(Document document)
        {
            InitializeComponent();
            CurrentDocument = document;
            GroupComboBox.ItemsSource = AppData.Context.Group.ToList();
            EducationComboBox.ItemsSource = AppData.Context.Education.ToList();
            BasicOfLearningComboBox.ItemsSource = AppData.Context.BasicOfLearning.ToList();
            StatusComboBox.ItemsSource = AppData.Context.Status.ToList();
            TypeDocumentComboBox.ItemsSource = AppData.Context.TypeDocument.ToList();

            if (CurrentDocument != null)
            {
                CurrentOrganizationEmloyee = AppData.Context.Organization.Where(c => c.Id == CurrentDocument.Organization.Id).FirstOrDefault();
                CurrentOrganizationInstitution = AppData.Context.Organization.Where(c => c.Id == CurrentDocument.Organization1.Id).FirstOrDefault();
                CurrentAddressEmployee = AppData.Context.Address.Where(c => c.Id == CurrentDocument.Organization.Address.Id).FirstOrDefault();
                CurrentAddressInstitution = AppData.Context.Address.Where(c => c.Id == CurrentDocument.Organization1.Address.Id).FirstOrDefault();
                CurrentBankDetailEmployee = AppData.Context.BankDetail.Where(c => c.Id == CurrentDocument.Organization.BankDetail.Id).FirstOrDefault();
                CurrentBankDetailInstitution = AppData.Context.BankDetail.Where(c => c.Id == CurrentDocument.Organization1.BankDetail.Id).FirstOrDefault();

                CurrentStudent = AppData.Context.Student.Where(c => c.Id == CurrentDocument.Student.Id).FirstOrDefault();
                CurrentAddressStudent = AppData.Context.Address.Where(c => c.Id == CurrentDocument.Student.Address.Id).FirstOrDefault();
                CurrentPassport = AppData.Context.Passport.Where(c => c.Id == CurrentDocument.Student.Passport.Id).FirstOrDefault();

                SaveButton.Content = "Сохранить";
                EmployeeNameTextBox.Text = CurrentDocument.Organization.Name;
                EmployeePhoneNumberTextBox.Text = CurrentDocument.Organization.PhoneNumber;
                EmployeeInnTextBox.Text = CurrentDocument.Organization.INN;
                EmployeeOgrnTextBox.Text = CurrentDocument.Organization.OGRN;
                EmployeeKPPTextBox.Text = CurrentDocument.Organization.KPP;
                EmployeeLastNameTextBox.Text = CurrentDocument.Organization.LastName;
                EmployeeFirstNameTextBox.Text = CurrentDocument.Organization.FirstName;
                EmployeeMiddleNameTextBox.Text = CurrentDocument.Organization.MiddleName;
                EmployeeAreaTextBox.Text = CurrentDocument.Organization.Address.Region;
                EmployeeCityTextBox.Text = CurrentDocument.Organization.Address.City;
                EmployeeStreetTextBox.Text = CurrentDocument.Organization.Address.Street;
                EmployeeHouseTextBox.Text = CurrentDocument.Organization.Address.House;
                EmployeeBankNameTextBox.Text = CurrentDocument.Organization.BankDetail.BankName;
                EmployeePaymentAccountTextBox.Text = CurrentDocument.Organization.BankDetail.PaymentAccount;
                EmployeeCorrespondentAccountTextBox.Text = CurrentDocument.Organization.BankDetail.CorrespondentAccount;
                EmployeeBIKTextBox.Text = CurrentDocument.Organization.BankDetail.BIK;

                InstitutionNameTextBox.Text = CurrentDocument.Organization1.Name;
                InstitutionPhoneNumberTextBox.Text = CurrentDocument.Organization1.PhoneNumber;
                InstitutionInnTextBox.Text = CurrentDocument.Organization1.INN;
                InstitutionOgrnTextBox.Text = CurrentDocument.Organization1.OGRN;
                InstitutionKPPTextBox.Text = CurrentDocument.Organization1.KPP;
                InstitutionLastNameTextBox.Text = CurrentDocument.Organization1.LastName;
                InstitutionFirstNameTextBox.Text = CurrentDocument.Organization1.FirstName;
                InstitutionMiddleNameTextBox.Text = CurrentDocument.Organization1.MiddleName;
                InstitutionAreaTextBox.Text = CurrentDocument.Organization1.Address.Region;
                InstitutionCityTextBox.Text = CurrentDocument.Organization1.Address.City;
                InstitutionStreetTextBox.Text = CurrentDocument.Organization1.Address.Street;
                InstitutionHouseTextBox.Text = CurrentDocument.Organization1.Address.House;
                InstitutionBankNameTextBox.Text = CurrentDocument.Organization1.BankDetail.BankName;
                InstitutionPaymentAccountTextBox.Text = CurrentDocument.Organization1.BankDetail.PaymentAccount;
                InstitutionPersonnalAccountTextBox.Text = CurrentDocument.Organization1.BankDetail.CorrespondentAccount;
                InstitutionBIKTextBox.Text = CurrentDocument.Organization1.BankDetail.BIK;

                LastNameTextBox.Text = CurrentDocument.Student.LastName;
                FirstNameTextBox.Text = CurrentDocument.Student.FirstName;
                MiddleNameTextBox.Text = CurrentDocument.Student.MiddleName;
                PhoneNumberTextBox.Text = CurrentDocument.Student.PhoneNumber;
                DateOfBirthDatePicker.SelectedDate = CurrentDocument.Student.DateOfBirth;
                PassportTextBox.Text = CurrentDocument.Student.Passport.Serial + CurrentDocument.Student.Passport.Number;
                DateOfIssueDatePicker.SelectedDate = CurrentDocument.Student.Passport.DateOfIssue;
                IssuedByWhomTextBox.Text = CurrentDocument.Student.Passport.IssuedByWhom;
                AreaTextBox.Text = CurrentDocument.Student.Address.Region;
                CityTextBox.Text = CurrentDocument.Student.Address.City;
                StreetTextBox.Text = CurrentDocument.Student.Address.Street;
                HouseTextBox.Text = CurrentDocument.Student.Address.House;
                ApartmentTextBox.Text = CurrentDocument.Student.Address.Apartment;
                GroupComboBox.SelectedItem = CurrentDocument.Student.Group as Group;
                EducationComboBox.SelectedItem = CurrentDocument.Student.Education as Education;
                BasicOfLearningComboBox.SelectedItem = CurrentDocument.Student.BasicOfLearning as BasicOfLearning;

                DateDatePicker.SelectedDate = CurrentDocument.Date;
                DateStartDatePicker.SelectedDate = CurrentDocument.DateStart;
                StatusComboBox.SelectedItem = CurrentDocument.Status as Status;
                TypeDocumentComboBox.SelectedItem = CurrentDocument.TypeDocument as TypeDocument;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string letterList = "ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnoprstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string numList = "1234567890";
            if (!String.IsNullOrWhiteSpace(EmployeeNameTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeePhoneNumberTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeInnTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeOgrnTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeKPPTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeLastNameTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeFirstNameTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeMiddleNameTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeAreaTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeCityTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeStreetTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeHouseTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeBankNameTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeePaymentAccountTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeCorrespondentAccountTextBox.Text) && !String.IsNullOrWhiteSpace(EmployeeBIKTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionNameTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionPhoneNumberTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionInnTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionOgrnTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionKPPTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionLastNameTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionFirstNameTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionMiddleNameTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionAreaTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionCityTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionStreetTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionHouseTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionBankNameTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionPaymentAccountTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionPersonnalAccountTextBox.Text) && !String.IsNullOrWhiteSpace(InstitutionBIKTextBox.Text) && !String.IsNullOrWhiteSpace(LastNameTextBox.Text) && !String.IsNullOrWhiteSpace(FirstNameTextBox.Text) && !String.IsNullOrWhiteSpace(MiddleNameTextBox.Text) && !String.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) && !String.IsNullOrWhiteSpace(PassportTextBox.Text) && !String.IsNullOrWhiteSpace(IssuedByWhomTextBox.Text) && !String.IsNullOrWhiteSpace(AreaTextBox.Text) && !String.IsNullOrWhiteSpace(CityTextBox.Text) && !String.IsNullOrWhiteSpace(StreetTextBox.Text) && !String.IsNullOrWhiteSpace(HouseTextBox.Text) && !String.IsNullOrWhiteSpace(ApartmentTextBox.Text) && DateOfBirthDatePicker.SelectedDate != null && DateOfIssueDatePicker.SelectedDate != null && GroupComboBox.SelectedItem != null && EducationComboBox.SelectedItem != null && BasicOfLearningComboBox.SelectedItem != null && DateDatePicker.SelectedDate != null && DateStartDatePicker.SelectedDate != null && StatusComboBox.SelectedItem != null && TypeDocumentComboBox.SelectedItem != null)
            {
                if (EmployeePhoneNumberTextBox.Text.Length == 18 && (EmployeePhoneNumberTextBox.Text.IndexOfAny(letterList.ToCharArray()) <= -1) && !EmployeePhoneNumberTextBox.Text.Contains('_'))
                {
                    if (!EmployeeInnTextBox.Text.Contains('_'))
                    {
                        if (!EmployeeOgrnTextBox.Text.Contains('_'))
                        {
                            if (!EmployeeKPPTextBox.Text.Contains('_'))
                            {
                                if (EmployeeLastNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                {
                                    if (EmployeeFirstNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                    {
                                        if (EmployeeMiddleNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                        {
                                            if (EmployeeAreaTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                            {
                                                if (EmployeeCityTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                {
                                                    if (!EmployeePaymentAccountTextBox.Text.Contains('_'))
                                                    {
                                                        if (!EmployeeCorrespondentAccountTextBox.Text.Contains('_'))
                                                        {
                                                            if (!EmployeeBIKTextBox.Text.Contains('_'))
                                                            {
                                                                if (InstitutionPhoneNumberTextBox.Text.Length == 18 && (InstitutionPhoneNumberTextBox.Text.IndexOfAny(letterList.ToCharArray()) <= -1) && !InstitutionPhoneNumberTextBox.Text.Contains('_'))
                                                                {
                                                                    if (!InstitutionInnTextBox.Text.Contains('_'))
                                                                    {
                                                                        if (!InstitutionOgrnTextBox.Text.Contains('_'))
                                                                        {
                                                                            if (!InstitutionKPPTextBox.Text.Contains('_'))
                                                                            {
                                                                                if (InstitutionLastNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                {
                                                                                    if (InstitutionFirstNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                    {
                                                                                        if (InstitutionMiddleNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                        {
                                                                                            if (InstitutionAreaTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                            {
                                                                                                if (InstitutionCityTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                                {
                                                                                                    if (!InstitutionPaymentAccountTextBox.Text.Contains('_'))
                                                                                                    {
                                                                                                        if (!InstitutionPersonnalAccountTextBox.Text.Contains('_'))
                                                                                                        {
                                                                                                            if (!InstitutionBIKTextBox.Text.Contains('_'))
                                                                                                            {
                                                                                                                if (LastNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                                                {
                                                                                                                    if (FirstNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                                                    {
                                                                                                                        if (MiddleNameTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                                                        {
                                                                                                                            if (AreaTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                                                            {
                                                                                                                                if (CityTextBox.Text.IndexOfAny(numList.ToCharArray()) <= -1)
                                                                                                                                {
                                                                                                                                    if (PhoneNumberTextBox.Text.Length == 18 && (PhoneNumberTextBox.Text.IndexOfAny(letterList.ToCharArray()) <= -1) && !PhoneNumberTextBox.Text.Contains('_'))
                                                                                                                                    {
                                                                                                                                        if (!PassportTextBox.Text.Contains('_'))
                                                                                                                                        {
                                                                                                                                            if (AssistanceTextBox.Text.IndexOfAny(letterList.ToCharArray()) <= -1)
                                                                                                                                            {

                                                                                                                                            } else
                                                                                                                                            {
                                                                                                                                                MessageBox.Show("Социальная помощь обучающегося указаны некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                                                PassportTextBox.Focus();
                                                                                                                                            }
                                                                                                                                        } else
                                                                                                                                        {
                                                                                                                                            MessageBox.Show("Серия и номер паспорт обучающегося указаны некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                                            PassportTextBox.Focus();
                                                                                                                                        }
                                                                                                                                    } else
                                                                                                                                    {
                                                                                                                                        MessageBox.Show("Номер телефона обучающегося указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                                        PhoneNumberTextBox.Focus();
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    MessageBox.Show("Город обучающегося указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                                    CityTextBox.Focus();
                                                                                                                                }
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                MessageBox.Show("Область обучающегося указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                                AreaTextBox.Focus(); 
                                                                                                                            }
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            MessageBox.Show("Отчество обучающегося указано некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                            MiddleNameTextBox.Focus();
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        MessageBox.Show("Имя обучающегося указано некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                        FirstNameTextBox.Focus();
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    MessageBox.Show("Фамилия обучающегося указано некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                    LastNameTextBox.Focus();
                                                                                                                }
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                MessageBox.Show("БИК учебного предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                                InstitutionBIKTextBox.Focus();
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            MessageBox.Show("Личный счёт учебного предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                            InstitutionPersonnalAccountTextBox.Focus();
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        MessageBox.Show("Расчётный счёт учебного предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                        InstitutionPaymentAccountTextBox.Focus();
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    MessageBox.Show("Город учебного предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                    InstitutionCityTextBox.Focus();
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                MessageBox.Show("Область владельца предприятия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                                InstitutionAreaTextBox.Focus();
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            MessageBox.Show("Отчество директора учебного предприятия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                            InstitutionMiddleNameTextBox.Focus();
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        MessageBox.Show("Имя директора учбного предприятия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                        InstitutionFirstNameTextBox.Focus();
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    MessageBox.Show("Фамилия директора учебного предприятия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                    InstitutionLastNameTextBox.Focus();
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("КПП учебного предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                                InstitutionKPPTextBox.Focus();
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show("ОГРН учебного предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                            InstitutionOgrnTextBox.Focus();
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("ИНН учебного предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                        InstitutionInnTextBox.Focus();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Номер телефона учебного предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                    InstitutionPhoneNumberTextBox.Focus();
                                                                }

                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("БИК предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                EmployeeBIKTextBox.Focus();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Корреспондентский счёт предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                            EmployeeCorrespondentAccountTextBox.Focus();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Расчётный счёт предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                        EmployeePaymentAccountTextBox.Focus();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Город владельца предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                    EmployeeCityTextBox.Focus();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Область владельца предприятия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                EmployeeAreaTextBox.Focus();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Отчество владельца предприятия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                            EmployeeMiddleNameTextBox.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Имя владельца предприятия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                        EmployeeFirstNameTextBox.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Фамилия владельца предприятия указана некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    EmployeeLastNameTextBox.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("КПП предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                EmployeeKPPTextBox.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("ОГРН предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            EmployeeOgrnTextBox.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ИНН предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        EmployeeInnTextBox.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Номер телефона предприятия указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    EmployeePhoneNumberTextBox.Focus();
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
