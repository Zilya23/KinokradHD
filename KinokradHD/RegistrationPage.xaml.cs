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

namespace KinokradHD
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

        private void Btn_registration_Click(object sender, RoutedEventArgs e)
        {
            var a = new User();
            a.Name = name_txt.Text;
            a.Login = login_txt.Text;
            a.Password = password_txt.Text;
            bd_connection.connection.User.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("All OK");
            NavigationService.GoBack();
        }

        private void Btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
