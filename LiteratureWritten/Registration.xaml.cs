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
using System.Windows.Shapes;

namespace LiteratureWritten
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Users searchUser = Model.BDConnection.bd.Users.FirstOrDefault(u => u.Login == txtLogin.Text);
                if (string.IsNullOrWhiteSpace(txtLogin.Text) && string.IsNullOrWhiteSpace((txtPassword.Password)))
                {
                    MessageBox.Show("icorrect");
                    return;
                }
                else
                {
                    if (searchUser == null)
                    {
                        Model.Users users = new Model.Users()
                        {
                            Login = txtLogin.Text,
                            Password = txtPassword.Password,
                            RoleId = 2
                        };
                        Model.BDConnection.bd.Users.Add(users);
                        Model.BDConnection.bd.SaveChanges();
                        Classes.User user = new Classes.User(users.ID, users.Login, 2);
                        Windows.main main = new Windows.main(user);
                        main.Show();
                        this.Close();
                        MessageBox.Show("Welcome");
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
