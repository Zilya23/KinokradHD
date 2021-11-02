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
    /// Логика взаимодействия для Film_Serial_Window2.xaml
    /// </summary>
    public partial class Film_Serial_Window2 : Window
    {
        public Film_Serial_Window2(Serias h)
        {
            InitializeComponent();
            tb_NameS.Text = h.Title;
            tb_YearS.Text = Convert.ToString(h.Year);
            tb_CountryS.Text = h.Country;
            tb_BudgetS.Text = Convert.ToString(h.Budget);
            tb_DurationS.Text = Convert.ToString(h.Fees);
            tb_FeesS.Text = Convert.ToString(h.Duration) + "мин.";
            tb_Count_episods.Text = Convert.ToString(h.Count_episodes);

            img_PosterS.Source = new BitmapImage(new Uri(h.Poster, UriKind.RelativeOrAbsolute));
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            GlavnayaWindow glavnaya = new GlavnayaWindow();
            glavnaya.Show();
            this.Close();
        }
    }
}
