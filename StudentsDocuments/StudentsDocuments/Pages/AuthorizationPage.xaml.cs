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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Staff CurrentStaff = AppData.Context.Staff.Where(c => c.Login == LoginTextBox.Text && c.Password == PasswordBox.Password).FirstOrDefault(); 
            if (CurrentStaff != null)
            {
                NavigationService.Navigate(new MenuPage());
                MessageBox.Show(Application.Current.MainWindow, $"Вы успешно авторизовались!\nДобро пожаловать, {CurrentStaff.FullnameStaff}.", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Пользователя с такими данными не существует.\nПроверьте корректность ввода данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
