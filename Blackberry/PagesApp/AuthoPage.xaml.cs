using Blackberry.ClassApp;
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

namespace Blackberry.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        public AuthoPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            EventLogin();
        }

        public void EventLogin()
        {
            try
            {
                if ((TxtLogin.Text != "") && (TxtPassword.Password != ""))
                {
                    var DataLogin = DbConnection.Connection.Autorization.Where(z => z.Login == TxtLogin.Text && z.Password == TxtPassword.Password).FirstOrDefault();
                    if (DataLogin != null)
                    {
                        MessageBox.Show(DataLogin.User.Nickname);
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля!");
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.ToString());
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                EventLogin();
        }
    }
}
