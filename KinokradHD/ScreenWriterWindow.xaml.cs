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

namespace KinokradHD
{
    /// <summary>
    /// Логика взаимодействия для ScreenWriterWindow.xaml
    /// </summary>
    public partial class ScreenWriterWindow : Window
    {
        public ScreenWriterWindow(ScreenWriter2 resultScr2)
        {
            InitializeComponent();
            var screenwriters = bd_connection.connection.Screenwriter.Where(x => x.ID_Screenwriter == resultScr2.idScreenWriter2).FirstOrDefault();
            tb_NameS.Text = screenwriters.Name + " " + screenwriters.Surname;
            tb_BirthdayS.Text = (Convert.ToString(screenwriters.Birthday).Split(' '))[0];
        }

        private void Sbtn_back_Click(object sender, RoutedEventArgs e)
        {
            GlavnayaWindow glavnaya = new GlavnayaWindow();
            glavnaya.Show();
            this.Close();
        }
    }
}
