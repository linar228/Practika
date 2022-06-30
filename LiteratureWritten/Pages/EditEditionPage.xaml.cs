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
    /// Логика взаимодействия для EditEditionPage.xaml
    /// </summary>
    public partial class EditEditionPage : Page
    {
        public static Classes.Edition Edition;
        public EditEditionPage(Classes.Edition edition)
        {
            Edition = edition;
            InitializeComponent();
            txtName.Text = edition.Name;
            txtType.Text = edition.Type;
            CBDelivery.ItemsSource = Model.BDConnection.bd.DeliveryMethod.ToList();
            CBPeriod.ItemsSource = Model.BDConnection.bd.SubscriptionTerm.ToList();
            Model.SubscribedEditions editions = Model.BDConnection.bd.SubscribedEditions.FirstOrDefault(e=>e.ID == Edition.Id);
            txtPeriod.Text = editions.SubscriptionTerm1.Periodicity1.Name;
            txtDelivery.Text = editions.DeliveryMethod1.Name;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectDelivery = CBDelivery.SelectedItem as Model.DeliveryMethod;
                var selectPeriod = CBPeriod.SelectedItem as Model.SubscriptionTerm;
                Model.SubscribedEditions subscribed = Model.BDConnection.bd.SubscribedEditions.FirstOrDefault(s => s.UserID == Edition.User.Id && s.ID == Edition.Id);
                if (CBDeactive.IsChecked == true && subscribed != null)
                {
                    subscribed.Status = false;
                    Model.BDConnection.bd.SaveChanges();
                    MessageBox.Show("edit");
                }
                else
                {

                    if (subscribed != null)
                    {
                        if (CBPeriod.SelectedItem == null)
                        {
                            subscribed.DeliveryMethod = selectDelivery.ID;
                        }
                        else if (CBDelivery.SelectedItem == null)
                        {
                            subscribed.SubscriptionTerm = selectPeriod.ID;
                        }
                        else if (CBPeriod != null && CBDelivery.SelectedItem != null)
                        {
                            subscribed.DeliveryMethod = selectDelivery.ID;
                            subscribed.SubscriptionTerm = selectPeriod.ID;
                        }
                        Model.BDConnection.bd.SaveChanges();
                        MessageBox.Show("edit");
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SubscribedPage(Edition.User));
        }
    }
}
