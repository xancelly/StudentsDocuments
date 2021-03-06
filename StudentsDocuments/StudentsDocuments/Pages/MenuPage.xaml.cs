﻿using System;
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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void GroupsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupsPage());
        }

        private void OrganizationsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrganizationPage());
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentsPage());
        }

        private void DocumentsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DocumentPage());
        }
    }
}
