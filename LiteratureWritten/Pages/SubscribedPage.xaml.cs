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
    /// Логика взаимодействия для SubscribedPage.xaml
    /// </summary>
    public partial class SubscribedPage : Page
    {
        public static Classes.User User;
        public SubscribedPage(Classes.User user)
        {
            User = user;
            InitializeComponent();
            if (User.Role == 2)
            {
                ListEdition.ItemsSource = Model.BDConnection.bd.SubscribedEditions.Where(u => u.UserID == User.Id && u.Editions.Status == true && u.Status == true).ToList();
                txtUserEdit.Visibility = Visibility.Hidden;
                txtNewEdition.Visibility = Visibility.Hidden;
            }
            else
            {
                ListEdition.ItemsSource = Model.BDConnection.bd.SubscribedEditions.Where(u=>u.Editions.Status == true && u.Status == true).ToList();
            }

            
        }

        private void ListEdition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectEdition = ListEdition.SelectedItem as Model.SubscribedEditions;
            txtCostEdit.Text = "price:" + selectEdition.Editions.Price;
            txtNameEdit.Text = "name:" + selectEdition.Editions.Name;
            txtUserEdit.Text = "user:" + selectEdition.Users.Login;
            txtTermEdit.Text = "term:" + selectEdition.SubscriptionTerm1.Term;
            txtPereodicityEdit.Text = "period:" + selectEdition.SubscriptionTerm1.Periodicity1.Name;
            txtDateEdit.Text = "date:" + selectEdition.Date.ToString();
            txtDelivery.Text = "delivery:" + selectEdition.DeliveryMethod1.Name;
            txtTypeEdit.Text = "type:" + selectEdition.Editions.EditionType1.Name;
        }
       
        public void Refresh()
        {
            txtCostEdit.Text = "";
            txtNameEdit.Text = "";
            txtUserEdit.Text = "";
            txtTermEdit.Text = "";
            txtPereodicityEdit.Text = "";
            txtDateEdit.Text = "";
            txtDelivery.Text = "";
            txtTypeEdit.Text = "";
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddEditionsPage(User));
        }

        

       
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            
            var selectEdition = ListEdition.SelectedItem as Model.SubscribedEditions;
            if (selectEdition == null)
            {
                MessageBox.Show("select item");
                return;
            }
            else
            {
                Classes.Edition edition = new Classes.Edition(selectEdition.ID, User, selectEdition.Editions.Name, selectEdition.Editions.EditionType1.Name);
                NavigationService.Navigate(new EditEditionPage(edition));
            }
            
        }

        private void BtnDeactive_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.HistoryDeactiveEditionPage(User));
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.NewEditionPage(User));
        }
    }
}
