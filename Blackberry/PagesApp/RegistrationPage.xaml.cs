using Blackberry.ADOApp;
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
using Blackberry.ClassApp;

namespace Blackberry.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((TxtLogin.Text != "") && (TxtName.Text != "") && (TxtPassword.Text != ""))
                {
                    if (DbConnection.Connection.Autorization.Where(z => z.Login == TxtLogin.Text).FirstOrDefault() == null)
                    {
                        User NewUser = new User();
                        Autorization NewLogin = new Autorization()
                        {
                            Login = TxtLogin.Text,
                            Password = TxtPassword.Text
                        };
                        NewUser.Autorization.Add(NewLogin);
                        NewUser.Nickname = TxtName.Text;
                        NewUser.IdRole = 1;
                        DbConnection.Connection.User.Add(NewUser);
                        DbConnection.Connection.SaveChanges();
                        NavigationService.GoBack();
                        MessageBox.Show("Успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Такой логин уже существует!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
