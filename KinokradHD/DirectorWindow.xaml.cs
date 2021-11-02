using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
       // public static ObservableCollection<Director> director { get; set; }
        public DirectorWindow(Director2 resultDir)
        {
            InitializeComponent();

          var director = bd_connection.connection.Director.Where(x => x.ID_Director == resultDir.idDirector2).FirstOrDefault();
            tb_NameD.Text = director.Name + " " + director.Surname;
            tb_BirthdayD.Text = (Convert.ToString(director.Birthday).Split(' '))[0];
        }
    }
}
