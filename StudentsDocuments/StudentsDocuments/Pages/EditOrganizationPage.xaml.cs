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

namespace StudentsDocuments.Entities
{
    /// <summary>
    /// Логика взаимодействия для EditOrganizationPage.xaml
    /// </summary>
    public partial class EditOrganizationPage : Page
    {
        Organization CurrentOrganization = null;
        Address CurrentAddress = null;
        BankDetail CurrentBankDetail = null;
        public EditOrganizationPage(Organization organization)
        {
            InitializeComponent();
            CurrentOrganization = organization;
            if (CurrentOrganization != null)
            {
                SaveButton.Content = "Сохранить";
                NameTextBox.Text = CurrentOrganization.Name;
                PhoneNumberTextBox.Text = CurrentOrganization.PhoneNumber;
                InnTextBox.Text = CurrentOrganization.INN;
                OgrnTextBox.Text = CurrentOrganization.OGRN;
                KPPTextBox.Text = CurrentOrganization.KPP;
                LastNameTextBox.Text = CurrentOrganization.LastName;
                FirstNameTextBox.Text = CurrentOrganization.FirstName;
                MiddleNameTextBox.Text = CurrentOrganization.MiddleName;
                AreaTextBox.Text = CurrentOrganization.Address.Region;
                CityTextBox.Text = CurrentOrganization.Address.City;
                StreetTextBox.Text = CurrentOrganization.Address.Street;
                HouseTextBox.Text = CurrentOrganization.Address.House;
                BankNameTextBox.Text = CurrentOrganization.BankDetail.BankName;
                PaymentAccountTextBox.Text = CurrentOrganization.BankDetail.PaymentAccount;
                CorrespondentAccountTextBox.Text = CurrentOrganization.BankDetail.CorrespondentAccount;
                BIKTextBox.Text = CurrentOrganization.BankDetail.BIK;
                CurrentAddress = CurrentOrganization.Address;
                CurrentBankDetail = CurrentOrganization.BankDetail;
            } else
            {
                this.Title = "Добавление организации";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string letterList = "ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnoprstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string numList = "1234567890";
            if (!String.IsNullOrWhiteSpace(NameTextBox.Text) && !String.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) && !String.IsNullOrWhiteSpace(InnTextBox.Text) && !String.IsNullOrWhiteSpace(OgrnTextBox.Text) && !String.IsNullOrWhiteSpace(KPPTextBox.Text) && !String.IsNullOrWhiteSpace(LastNameTextBox.Text) && !String.IsNullOrWhiteSpace(FirstNameTextBox.Text) && !String.IsNullOrWhiteSpace(MiddleNameTextBox.Text) && !String.IsNullOrWhiteSpace(AreaTextBox.Text) && !String.IsNullOrWhiteSpace(CityTextBox.Text) && !String.IsNullOrWhiteSpace(StreetTextBox.Text) && !String.IsNullOrWhiteSpace(HouseTextBox.Text) && !String.IsNullOrWhiteSpace(BankNameTextBox.Text) && !String.IsNullOrWhiteSpace(PaymentAccountTextBox.Text) && !String.IsNullOrWhiteSpace(CorrespondentAccountTextBox.Text) && !String.IsNullOrWhiteSpace(BIKTextBox.Text))
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
                                        if (!InnTextBox.Text.Contains('_'))
                                        {
                                            if (!OgrnTextBox.Text.Contains('_'))
                                            {
                                                if (!KPPTextBox.Text.Contains('_'))
                                                {
                                                    if (!PaymentAccountTextBox.Text.Contains('_'))
                                                    {
                                                        if (!CorrespondentAccountTextBox.Text.Contains('_'))
                                                        {
                                                            if (!BIKTextBox.Text.Contains('_'))
                                                            {
                                                                if (CurrentOrganization == null)
                                                                {
                                                                    if (AppData.Context.Organization.Where(c => c.Name == NameTextBox.Text).FirstOrDefault() == null)
                                                                    {
                                                                        Address CurrentAddress = new Address()
                                                                        {
                                                                            Region = AreaTextBox.Text,
                                                                            City = CityTextBox.Text,
                                                                            Street = StreetTextBox.Text,
                                                                            House = HouseTextBox.Text,
                                                                        };
                                                                        AppData.Context.Address.Add(CurrentAddress);
                                                                        BankDetail CurrentBankDetail = new BankDetail()
                                                                        {
                                                                            BankName = BankNameTextBox.Text,
                                                                            PaymentAccount = PaymentAccountTextBox.Text,
                                                                            CorrespondentAccount = CorrespondentAccountTextBox.Text,
                                                                            BIK = BIKTextBox.Text,
                                                                        };
                                                                        AppData.Context.BankDetail.Add(CurrentBankDetail);
                                                                        CurrentOrganization = new Organization()
                                                                        {
                                                                            Name = NameTextBox.Text,
                                                                            IdAddress = CurrentAddress.Id,
                                                                            OGRN = OgrnTextBox.Text,
                                                                            INN = InnTextBox.Text,
                                                                            KPP = KPPTextBox.Text,
                                                                            IdBankDetail = CurrentBankDetail.Id,
                                                                            PhoneNumber = PhoneNumberTextBox.Text,
                                                                            LastName = LastNameTextBox.Text,
                                                                            FirstName = FirstNameTextBox.Text,
                                                                            MiddleName = MiddleNameTextBox.Text,
                                                                        };
                                                                        AppData.Context.Organization.Add(CurrentOrganization);
                                                                        AppData.Context.SaveChanges();
                                                                        MessageBox.Show("Организация успешно добавлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                                                                        NavigationService.GoBack();
                                                                    } else
                                                                    {
                                                                        MessageBox.Show("Организация с таким названием уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                        NameTextBox.Focus();
                                                                    }
                                                                } else
                                                                {
                                                                    CurrentOrganization.Name = NameTextBox.Text;
                                                                    CurrentOrganization.OGRN = OgrnTextBox.Text;
                                                                    CurrentOrganization.INN = InnTextBox.Text;
                                                                    CurrentOrganization.KPP = KPPTextBox.Text;
                                                                    CurrentOrganization.PhoneNumber = PhoneNumberTextBox.Text;
                                                                    CurrentOrganization.LastName = LastNameTextBox.Text;
                                                                    CurrentOrganization.FirstName = FirstNameTextBox.Text;
                                                                    CurrentOrganization.MiddleName = MiddleNameTextBox.Text;

                                                                    CurrentAddress.Region = AreaTextBox.Text;
                                                                    CurrentAddress.City = CityTextBox.Text;
                                                                    CurrentAddress.Street = StreetTextBox.Text;
                                                                    CurrentAddress.House = HouseTextBox.Text;

                                                                    CurrentBankDetail.BankName = BankNameTextBox.Text;
                                                                    CurrentBankDetail.PaymentAccount = PaymentAccountTextBox.Text;
                                                                    CurrentBankDetail.CorrespondentAccount = CorrespondentAccountTextBox.Text;
                                                                    CurrentBankDetail.BIK = BIKTextBox.Text;

                                                                    AppData.Context.SaveChanges();
                                                                    MessageBox.Show("Информация обновлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                                                                    NavigationService.GoBack();

                                                                }
                                                            } else
                                                            {
                                                                MessageBox.Show("БИК указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                                BIKTextBox.Focus();
                                                            }
                                                        } else
                                                        {
                                                            MessageBox.Show("Корреспондентский счёт указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                            CorrespondentAccountTextBox.Focus();
                                                        }
                                                    } else
                                                    {
                                                        MessageBox.Show("Расчётный счёт указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                        PaymentAccountTextBox.Focus();
                                                    }
                                                } else
                                                {
                                                    MessageBox.Show("КПП указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                    KPPTextBox.Focus();
                                                }
                                            } else
                                            {
                                                MessageBox.Show("ОГРН указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                OgrnTextBox.Focus();
                                            }
                                        } else
                                        {
                                            MessageBox.Show("ИНН указан некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                            InnTextBox.Focus();
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
                                PhoneNumberTextBox.Focus();
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
