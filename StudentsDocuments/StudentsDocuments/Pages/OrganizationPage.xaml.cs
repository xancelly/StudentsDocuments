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
    /// Логика взаимодействия для OrganizationPage.xaml
    /// </summary>
    public partial class OrganizationPage : Page
    {
        public OrganizationPage()
        {
            InitializeComponent();
            OrganizationDataGrid.ItemsSource = AppData.Context.Organization.ToList();
        }

        public void UpdateOrganization()
        {
            var CurrentOrganization = AppData.Context.Organization.ToList();
            CurrentOrganization = CurrentOrganization.Where(c => c.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.LastName.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.FirstName.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.MiddleName.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.PhoneNumber.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Address.Region.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Address.City.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Address.Street.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            OrganizationDataGrid.ItemsSource = CurrentOrganization;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditOrganizationPage(null));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Organization CurrentOrganization = OrganizationDataGrid.SelectedItem as Organization;
            if (CurrentOrganization != null)
            {
                NavigationService.Navigate(new EditOrganizationPage(CurrentOrganization));
            }
            else
            {
                MessageBox.Show("Выберите организацию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Organization CurrentOrganization = OrganizationDataGrid.SelectedItem as Organization;
            if (CurrentOrganization != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить организацию?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    AppData.Context.Organization.Remove(CurrentOrganization);
                    AppData.Context.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Организация была удалена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите организацию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOrganization();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOrganization();
        }
    }
}
