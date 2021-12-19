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
    /// Логика взаимодействия для New_FilmWindow.xaml
    /// </summary>
    public partial class New_FilmWindow : Window
    {
        public New_FilmWindow()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Film film = new Film();
            film.Title = tb_Name.Text;
            film.Year = Convert.ToDateTime(tb_Year.Text);
            film.Country = tb_Country.Text;
            film.Budget = Convert.ToInt32(tb_Budget.Text);
            film.Duration = Convert.ToInt32(tb_Duration.Text);
            bd_connection.connection.Film.Add(film);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("All OK");
            this.Close();


        }
    }
}
