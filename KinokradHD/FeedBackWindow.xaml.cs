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
    /// Логика взаимодействия для FeedBackWindow.xaml
    /// </summary>
    public partial class FeedBackWindow : Window
    {
        public static ObservableCollection<Feedback> feedbacks { get; set; }
        public static ObservableCollection<Film> films { get; set; }
        public static IEnumerable<Feedback2> resultsFeed { get; set; }

        public FeedBackWindow(int i)
        {
            InitializeComponent();
            feedbacks = new ObservableCollection<Feedback>(bd_connection.connection.Feedback.ToList());
            this.DataContext = this;
        }
    }

    public class Film2
    {
        public int idFilm { get; set; }
        public int idOperator { get; set; }
        public int idDir { get; set; }
        public int idScreen { get; set; }
        public int idActot { get; set; }
    }
}

public class Feedback2
{
    public int idFeed2 { get; set; }
    public string FeedName { get; set; }
    public string FeedFees { get; set; }
    public string FeedScore { get; set; }
}
