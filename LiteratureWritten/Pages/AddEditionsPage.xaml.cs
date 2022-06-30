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
    /// Логика взаимодействия для AddEditionsPage.xaml
    /// </summary>
    public partial class AddEditionsPage : Page
    {
        public static Classes.User User;
        public AddEditionsPage(Classes.User user)
        {
            User = user;
            InitializeComponent();
            Model.SubscribedEditions SearchEditions = Model.BDConnection.bd.SubscribedEditions.FirstOrDefault(e=>e.UserID == User.Id);
            ListEdition.ItemsSource = Model.BDConnection.bd.Editions.Where(u=> u.Status == true).ToList();
            CBDeliveryMethod.ItemsSource = Model.BDConnection.bd.DeliveryMethod.ToList();
            CBTerm.ItemsSource = Model.BDConnection.bd.SubscriptionTerm.ToList();
        }

        private void ListEdition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = ListEdition.SelectedItem as Model.Editions;
            txtName.Text = select.Name;
            txtType.Text = select.EditionType1.Name;
            txtPrice.Text = select.Price;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CBDeliveryMethod.Text) && string.IsNullOrWhiteSpace(CBTerm.Text))
                {
                    return;
                }
                else
                {
                    var selectEdition = ListEdition.SelectedItem as Model.Editions;
                    var selectDelivery = CBDeliveryMethod.SelectedItem as Model.DeliveryMethod;
                    var selectTerm = CBTerm.SelectedItem as Model.SubscriptionTerm;
                    Model.SubscribedEditions editions = Model.BDConnection.bd.SubscribedEditions.FirstOrDefault(u=>u.UserID == User.Id && u.Editions.ID == selectEdition.ID);
                    if (editions == null)
                    {
                        var time = DateTime.Now.TimeOfDay;
                        Model.SubscribedEditions subscribed = new Model.SubscribedEditions
                        {
                            
                            Date = DateTime.Now.Date + time,
                            Edition = selectEdition.ID,
                            SubscriptionTerm = selectTerm.ID,
                            DeliveryMethod = selectDelivery.ID,
                            UserID = User.Id,
                            Status = true
                        };
                        Model.BDConnection.bd.SubscribedEditions.Add(subscribed);
                        MessageBox.Show("add");
                    }
                    else
                    {
                        var time = DateTime.Now.TimeOfDay;
                        editions.Date = DateTime.Now + time;
                        editions.DeliveryMethod = selectDelivery.ID;
                        editions.SubscriptionTerm = selectTerm.ID;
                        MessageBox.Show("re-recording");
                        
                    }  
                    Model.BDConnection.bd.SaveChanges();
                    
                }
                
            }
            catch(Exception)
            {
                return;
            }
            
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.SubscribedPage(User));
        }
    }
}
