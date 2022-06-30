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

namespace LiteratureWritten
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLogin.Text) && string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("icorrect");
                    return;
                }
                else
                {
                    Model.Users users = Model.BDConnection.bd.Users.FirstOrDefault(u => u.Login == txtLogin.Text && u.Password == txtPassword.Password);
                    if (users != null)
                    {
                        MessageBox.Show("Welcome");
                        Classes.User user = new Classes.User(users.ID, users.Login, users.Roles.ID);
                        Windows.main windows = new Windows.main(user);
                        windows.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("icorrect");
                        return;
                    }

                }
            }
            catch(Exception)
            {
                MessageBox.Show("icorrect");
                return;
            }
        }
    }
}
