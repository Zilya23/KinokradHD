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
    /// Логика взаимодействия для ActorWindow.xaml
    /// </summary>
    public partial class ActorWindow : Window
    {
        public ActorWindow(Actor2 actor2)
        {
            InitializeComponent();
            var actor = bd_connection.connection.Actor.Where(x => x.ID_Actor == actor2.idActor2).FirstOrDefault();
            tb_NameA.Text = actor.Name + " " + actor.Surname;
            tb_BirthdayA.Text = (Convert.ToString(actor.Birthday).Split(' '))[0];
            img_PosterA.Source = new BitmapImage(new Uri(actor.Poster, UriKind.RelativeOrAbsolute));
        }

        private void Dbtn_back_Click(object sender, RoutedEventArgs e)
        {
            GlavnayaWindow glavnaya = new GlavnayaWindow();
            glavnaya.Show();
            this.Close();
        }
    }
}
