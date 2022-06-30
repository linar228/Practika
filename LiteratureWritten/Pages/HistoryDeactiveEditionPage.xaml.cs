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

namespace LiteratureWritten.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryDeactiveEditionPage.xaml
    /// </summary>
    public partial class HistoryDeactiveEditionPage : Page
    {
        public static Classes.User User;
        public HistoryDeactiveEditionPage(Classes.User user)
        {
            User = user;
            InitializeComponent();
            Refresh();
            
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (User.Role == 1)
            {
                DGHistory.ItemsSource = Model.BDConnection.bd.SubscribedEditions.Where(u => u.Status == false && u.Editions.Name == txtSearch.Text || u.Status == false && u.Users.Login == txtSearch.Text || u.Status == false && u.Editions.Price == txtSearch.Text ).ToList();
            }
            else
            {
                DGHistory.ItemsSource = Model.BDConnection.bd.SubscribedEditions.Where(u => u.Users.ID == User.Id && u.Status == false && u.Editions.Name == txtSearch.Text).ToList();
            }
        }

        private void BtnActive_Click(object sender, RoutedEventArgs e)
        {
            var select = DGHistory.SelectedItem as Model.SubscribedEditions;
            if (select != null)
            {
                select.Status = true;
                Model.BDConnection.bd.SaveChanges();
                MessageBox.Show("active");
                Refresh();
            }
            else
            {
                MessageBox.Show("select item");
                return;
            }
            
            
        }

        private void BtnDeleted_Click(object sender, RoutedEventArgs e)
        {
            var select = DGHistory.SelectedItem as Model.SubscribedEditions;
            if (select != null)
            {
                Model.BDConnection.bd.SubscribedEditions.Remove((Model.SubscribedEditions)DGHistory.SelectedItem);
                Model.BDConnection.bd.SaveChanges();
                MessageBox.Show("deleted");
                Refresh();
            }
            else
            {
                MessageBox.Show("select item");
                return;
            }
            
        }
        public void Refresh()
        {
            if (User.Role == 1)
            {
                DGHistory.ItemsSource = Model.BDConnection.bd.SubscribedEditions.Where(u => u.Status == false).ToList();
            }
            else
            {
                DGHistory.ItemsSource = Model.BDConnection.bd.SubscribedEditions.Where(u => u.Users.ID == User.Id && u.Status == false).ToList();
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.SubscribedPage(User));
        }
    }
}
