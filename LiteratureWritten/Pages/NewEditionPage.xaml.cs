using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для NewEditionPage.xaml
    /// </summary>
    public partial class NewEditionPage : Page
    {
        public static Classes.User User;
        public NewEditionPage(Classes.User user)
        {
            User = user;
            InitializeComponent();
            if (User.Role == 1)
            {
                Refresh();
                CBType.ItemsSource = Model.BDConnection.bd.EditionType.ToList();
            }
           
        }

        private void price(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnWindraw_Click(object sender, RoutedEventArgs e)
        {
            var select = ListEdition.SelectedItem as Model.Editions;
            select.Status = false;
            Model.BDConnection.bd.SaveChanges();
            MessageBox.Show("deactive active");
            Refresh();
        }

        private void ListEdition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void Refresh()
        {
            ListEdition.ItemsSource = Model.BDConnection.bd.Editions.Where(s => s.Status == false).ToList();
        }

        private void BtnAddEdition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (User.Role == 1)
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrEmpty(txtPrice.Text))
                    {
                        MessageBox.Show("incorrect");
                        return;
                    }
                    var select = CBType.SelectedItem as Model.EditionType;
                    Model.Editions SearcEditions = Model.BDConnection.bd.Editions.FirstOrDefault(ed => ed.Name == txtName.Text);
                    if (SearcEditions == null)
                    {
                        Model.Editions editions = new Model.Editions
                        {
                            Price = txtPrice.Text,
                            Status = true,
                            EditionType = select.ID,
                            Name = txtName.Text
                        };
                        Model.BDConnection.bd.Editions.Add(editions);
                        Model.BDConnection.bd.SaveChanges();
                        MessageBox.Show("add");
                        Refresh();
                    }
                    else
                    {
                        MessageBox.Show("incorrect");
                        return;
                    }
                }
               
            }
            catch(Exception)
            {
                MessageBox.Show("incorrect");
                return;
            }
            
        }

        private void back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.SubscribedPage(User));
        }
        int count = 0;
        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {

            ListEdition.ItemsSource = Model.BDConnection.bd.Editions.ToList();

        }

        private void BtnShowFalse_Click(object sender, RoutedEventArgs e)
        {
            ListEdition.ItemsSource = Model.BDConnection.bd.Editions.Where(u => u.Status == false).ToList();
        }
    }
}
