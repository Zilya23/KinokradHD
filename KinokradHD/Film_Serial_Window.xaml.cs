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
    /// Логика взаимодействия для Film_Serial_Window.xaml
    /// </summary>
    public partial class Film_Serial_Window : Window
    {
         public string ActorId;
        public static ObservableCollection<Film> films { get; set; }

        public static ObservableCollection<Film_Operator> svazy { get; set; }
        public static ObservableCollection<Operator> operators { get; set; }

        public static ObservableCollection<Director> director { get; set; }
        public static ObservableCollection<Film_Director> svazy2 { get; set; }
        public static ObservableCollection<Screenwriter> screenwriters { get; set; }
        public static ObservableCollection<Film_Screenwriter> svazy3 { get; set; }
        public static ObservableCollection<Actor> actors { get; set; }
        public static ObservableCollection<Film_Actor> svazy4 { get; set; }
        public static ObservableCollection<Rating> ratings { get; set; }
        public static ObservableCollection<Nomination> nominations { get; set; }
        public static ObservableCollection<Film_Nomination> svazy5 { get; set; }
        public static ObservableCollection<Awards> awards { get; set; }


        public static IEnumerable<Film2> result { get; set; }
        public static IEnumerable<Operator2> result2 { get; set; }
        public static IEnumerable<Film2> resultDir { get; set; } 
        public static IEnumerable<Director2> resultDir2 { get; set; }
        public static IEnumerable<Film2> resultScr { get; set; }
        public static IEnumerable<ScreenWriter2> resultScr2 { get; set; }
        public static IEnumerable<Film2> resultActor { get; set; }
        public static IEnumerable<Actor2> resultActor2 { get; set; }
        public static IEnumerable<Rating2> resultRating { get; set; }
        public static IEnumerable<Awards2> resultAwards { get; set; }

        public Film_Serial_Window(Film n)
        {
            InitializeComponent();
            tb_Name.Text = n.Title;
            tb_Year.Text = (Convert.ToString(n.Year).Split(' '))[0];
            tb_Country.Text = n.Country;
            tb_Budget.Text = Convert.ToString(n.Budget);
            tb_Duration.Text = Convert.ToString(n.Fees);
            tb_Fees.Text = Convert.ToString(n.Duration) + "мин.";

            img_Poster.Source = new BitmapImage(new Uri(n.Poster, UriKind.RelativeOrAbsolute));

            films = new ObservableCollection<Film>(bd_connection.connection.Film.ToList());

            director = new ObservableCollection<Director>(bd_connection.connection.Director.ToList());
            svazy2 = new ObservableCollection<Film_Director>(bd_connection.connection.Film_Director.ToList());

            operators = new ObservableCollection<Operator>(bd_connection.connection.Operator.ToList());
            svazy = new ObservableCollection<Film_Operator>(bd_connection.connection.Film_Operator.ToList());

            screenwriters = new ObservableCollection<Screenwriter>(bd_connection.connection.Screenwriter.ToList());
            svazy3 = new ObservableCollection<Film_Screenwriter>(bd_connection.connection.Film_Screenwriter.ToList());

            actors = new ObservableCollection<Actor>(bd_connection.connection.Actor.ToList());
            svazy4 = new ObservableCollection<Film_Actor>(bd_connection.connection.Film_Actor.ToList());

            ratings = new ObservableCollection<Rating>(bd_connection.connection.Rating.ToList());

            nominations = new ObservableCollection<Nomination>(bd_connection.connection.Nomination.ToList());
            svazy5 = new ObservableCollection<Film_Nomination>(bd_connection.connection.Film_Nomination.ToList());
            awards = new ObservableCollection<Awards>(bd_connection.connection.Awards.ToList());

            result = from f in films
                     join t in svazy on f.ID_Film equals t.ID_Film
                     where n.ID_Film == f.ID_Film
                     select new Film2 { idOperator = t.ID_Operator, idFilm = f.ID_Film };

            result2 = from o in operators
                      join t in result on o.ID_Operator equals t.idOperator
                      select new Operator2 { idOperator2 = o.ID_Operator, nameOper = o.Name, surOper = o.Surname };

            foreach (var i in result2)
                tb_Operator.Text += (i.nameOper + " " + i.surOper);

            resultDir = from f in films
                        join t in svazy2 on f.ID_Film equals t.ID_Film
                        where n.ID_Film == f.ID_Film
                        select new Film2 { idDir = t.ID_Director, idFilm = f.ID_Film };
            resultDir2 = from d in director
                         join t in resultDir on d.ID_Director equals t.idDir
                         select new Director2 { idDirector2 = d.ID_Director, nameDir = d.Name, surDir = d.Surname };
            foreach (var i in resultDir2)
                tb_Director.Text += (i.nameDir + " " + i.surDir);

            resultScr = from f in films
                        join t in svazy3 on f.ID_Film equals t.ID_Film
                        where n.ID_Film == f.ID_Film
                        select new Film2 { idScreen = t.ID_Screenwriter, idFilm = f.ID_Film };
            resultScr2 = from s in screenwriters
                         join t in resultScr on s.ID_Screenwriter equals t.idScreen
                         select new ScreenWriter2 { idScreenWriter2 = s.ID_Screenwriter, nameScr = s.Name, surScr = s.Surname };
            foreach (var i in resultScr2)
                tb_Screenwriter.Text += (i.nameScr + " " + i.surScr + "\n");

            int por = 0;
            resultActor = from f in films
                          join t in svazy4 on f.ID_Film equals t.ID_Film
                          where n.ID_Film == f.ID_Film
                          select new Film2 { idActot = t.ID_Actor, idFilm = f.ID_Film };
            resultActor2 = from a in actors
                           join t in resultActor on a.ID_Actor equals t.idActot
                           select new Actor2 { idActor2 = a.ID_Actor, nameActr = a.Name, surActor = a.Surname, poryadok = por++};
            
            foreach (var i in resultActor2)
            { 
                tb_Actor.Text += (i.nameActr + " " + i.surActor + "\n");
                ActorId += Convert.ToString(i.idActor2) + " ";
            }

            string[] idAct = ActorId.Split(' ');
            int lenght = idAct.Length;

                

            resultRating = from f in films
                           join r in ratings on f.ID_Rating equals r.ID_Rating
                           where n.ID_Rating == f.ID_Rating
                           where n.ID_Film == f.ID_Film
                           select new Rating2 { idRating = r.ID_Rating, nameRating = r.Name };
            foreach (var i in resultRating)
                tb_Rating.Text += (i.nameRating);

            resultAwards = from f in films
                          join t in svazy5 on f.ID_Film equals t.ID_Film
                          join o in nominations on t.ID_Nomination equals o.ID_Nomination
                          join aw in awards on o.ID_Awarts equals aw.ID_Awarts
                          where n.ID_Film == f.ID_Film
                          select new Awards2 { idAwards = aw.ID_Awarts, nameAwards = aw.Name, nameNomination = o.Name};
            foreach (var i in resultAwards)
                tb_Awards.Text += (i.nameAwards +  ":" + "\n" + i.nameNomination);

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            GlavnayaWindow glavnaya = new GlavnayaWindow();
            glavnaya.Show();
            this.Close();
        }

        private void tb_Director_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var d in resultDir2)
            {
                DirectorWindow directorWindow = new DirectorWindow(d);

                directorWindow.Show();
                this.Close();
            }
            
        }

        private void tb_Director_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_Director.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void tb_Director_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_Director.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_Operator_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var o in result2)
            {
                OperatorWindow operatorWindow = new OperatorWindow(o);

                operatorWindow.Show();
                this.Close();
            }

        }

        private void tb_Operator_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_Operator.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void tb_Operator_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_Operator.Foreground =new SolidColorBrush(Colors.White);
        }
    }
    public class Film2
    {
        public int idFilm { get; set; }
        public int idOperator { get; set; }
        public int idDir { get; set; }
        public int idScreen { get; set; }
        public int idActot { get; set; }
    };
}

    public class Operator2
    {
        public string nameOper { get; set; }
        public string surOper { get; set; }
        public int idOperator2 { get; set; }

    }

    public class Director2 
    {
        public string nameDir { get; set; }
        public string surDir { get; set; }
        public int idDirector2 { get; set; }
    }

    public class ScreenWriter2 
    {
       public string nameScr { get; set; }
       public string surScr { get; set; }
       public int idScreenWriter2 { get; set; }
    }

    public class Actor2
    {
        public string nameActr { get; set; }
        public string surActor { get; set; }
        public int idActor2 { get; set; }
    public int poryadok = 0;
}
    public class Rating2
    {
        public string nameRating { get; set; }
        public int idRating { get; set; }
    }
    
    public  class Awards2
    {
        public string nameAwards { get; set; }
        public string nameNomination { get; set; }
        public int idAwards { get; set; }
    }


