using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для GlavnayaWindow.xaml
    /// </summary>
    /// 
    public partial class GlavnayaWindow : Window
    {
        public static ObservableCollection<Film> films { get; set; }
        public static ObservableCollection<Serias> seriass { get; set; }
        public GlavnayaWindow()
        {
            InitializeComponent();
            films = new ObservableCollection<Film>(bd_connection.connection.Film.ToList());
            seriass = new ObservableCollection<Serias>(bd_connection.connection.Serias.ToList());

            var f = new Film();
            var s = new Serias();
            this.DataContext = this;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Film;

            Film_Serial_Window film_serial = new Film_Serial_Window(n);
            film_serial.Show();
            this.Close();
        }
    }
}
