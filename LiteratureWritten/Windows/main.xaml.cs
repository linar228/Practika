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
using System.Windows.Shapes;

namespace LiteratureWritten.Windows
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Window
    {
        public static Classes.User User;
        public main(Classes.User user)
        {
            User = user;
            InitializeComponent();
            PagesNavigation.Navigate(new Pages.SubscribedPage(User));
        }

        private void ListEdition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
