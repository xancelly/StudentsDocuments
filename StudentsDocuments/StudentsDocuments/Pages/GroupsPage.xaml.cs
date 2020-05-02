using StudentsDocuments.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsDocuments.Pages
{
    /// <summary>
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        public GroupsPage()
        {
            InitializeComponent();
            GroupsDataGrid.ItemsSource = AppData.Context.Group.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGroups();
        }

        public void UpdateGroups()
        {
            var CurrentGroup = AppData.Context.Group.ToList();
            CurrentGroup = CurrentGroup.Where(c => c.Id.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Speciality.Code.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Speciality.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Speciality.Direction.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            GroupsDataGrid.ItemsSource = CurrentGroup;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateGroups();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditGroupPage(null));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Group CurrentGroup = GroupsDataGrid.SelectedItem as Group;
            if (CurrentGroup != null)
            {
                NavigationService.Navigate(new EditGroupPage(CurrentGroup));
            } else
            {
                MessageBox.Show("Выберите учебную группу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Group CurrentGroup = GroupsDataGrid.SelectedItem as Group;
            if (CurrentGroup != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить учебную группу?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    AppData.Context.Group.Remove(CurrentGroup);
                    AppData.Context.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Учебная группа была удалена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите учебную группу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
