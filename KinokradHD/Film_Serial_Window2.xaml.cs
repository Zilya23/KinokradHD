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
    /// Логика взаимодействия для Film_Serial_Window2.xaml
    /// </summary>
    public partial class Film_Serial_Window2 : Window
    {
        public static ObservableCollection<Serias> serias { get; set; }

        public static ObservableCollection<Director> directorss { get; set; }
        public static ObservableCollection<Serias_Director> svazys { get; set; }

        public static ObservableCollection<Operator> operatorss { get; set; }
        public static ObservableCollection<Serias_Operator> svazys2 { get; set; }

        public static ObservableCollection<Screenwriter> screenwriterss { get; set; }
        public static ObservableCollection<Serias_Screenwriter> svazys3 { get; set; }

        public static ObservableCollection<Actor> actorss { get; set; }
        public static ObservableCollection<Serias_Actor> svazys4 { get; set; }

        public static ObservableCollection<Rating> ratingss { get; set; }

        public static ObservableCollection<Nomination> nominationss { get; set; }
        public static ObservableCollection<Serias_Nominat> svazys5 { get; set; }
        public static ObservableCollection<Awards> awardss { get; set; }

        public static ObservableCollection<Genre> genress { get; set; }
        public static ObservableCollection<Serias_Genre> svazy6 { get; set; }

        public static IEnumerable<Serial2> results { get; set; }
        public static IEnumerable<Director2> resultsDir { get; set; }

        public static IEnumerable<Serial2> resultsOper { get; set; }
        public static IEnumerable<Operator2> resultsOper2 { get; set; }

        public static IEnumerable<Serial2> resultsScr { get; set; }
        public static IEnumerable<ScreenWriter2> resultsScr2 { get; set; }

        public static IEnumerable<Serial2> resultsActr { get; set; }
        public static IEnumerable<Actor2> resultsActr2 { get; set; }

        public static IEnumerable<RatingS> resultsRat { get; set; }

        public static IEnumerable<AwardsS> resultsAward { get; set; }



        public Film_Serial_Window2(Serias h)
        {
            InitializeComponent();
            tb_NameS.Text = h.Title;
            tb_YearS.Text = (Convert.ToString(h.Year).Split(' '))[0];
            tb_CountryS.Text = h.Country;
            tb_BudgetS.Text = Convert.ToString(h.Budget);
            tb_DurationS.Text = Convert.ToString(h.Fees);
            tb_FeesS.Text = Convert.ToString(h.Duration) + "мин.";
            tb_Count_episods.Text = Convert.ToString(h.Count_episodes);

            img_PosterS.Source = new BitmapImage(new Uri(h.Poster, UriKind.RelativeOrAbsolute));

            serias = new ObservableCollection<Serias>(bd_connection.connection.Serias.ToList());

            directorss = new ObservableCollection<Director>(bd_connection.connection.Director.ToList());
            svazys = new ObservableCollection<Serias_Director>(bd_connection.connection.Serias_Director.ToList());

            operatorss = new ObservableCollection<Operator>(bd_connection.connection.Operator.ToList());
            svazys2 = new ObservableCollection<Serias_Operator>(bd_connection.connection.Serias_Operator.ToList());

            screenwriterss = new ObservableCollection<Screenwriter>(bd_connection.connection.Screenwriter.ToList());
            svazys3 = new ObservableCollection<Serias_Screenwriter>(bd_connection.connection.Serias_Screenwriter.ToList());

            actorss = new ObservableCollection<Actor>(bd_connection.connection.Actor.ToList());
            svazys4 = new ObservableCollection<Serias_Actor>(bd_connection.connection.Serias_Actor.ToList());

            ratingss = new ObservableCollection<Rating>(bd_connection.connection.Rating.ToList());

            nominationss = new ObservableCollection<Nomination>(bd_connection.connection.Nomination.ToList());
            svazys5 = new ObservableCollection<Serias_Nominat>(bd_connection.connection.Serias_Nominat.ToList());
            awardss = new ObservableCollection<Awards>(bd_connection.connection.Awards.ToList());

            genress = new ObservableCollection<Genre>(bd_connection.connection.Genre.ToList());
            svazy6 = new ObservableCollection<Serias_Genre>(bd_connection.connection.Serias_Genre.ToList());

            resultsDir = from s in serias
                         join r in svazys on s.ID_Serias equals r.ID_Serias
                         join t in directorss on r.ID_Director equals t.ID_Director
                         where h.ID_Serias == s.ID_Serias
                         select new Director2 { idDirector2 = t.ID_Director, nameDir = t.Name, surDir = t.Surname };

            foreach (var i in resultsDir)
                tb_DirectorS.Text += (i.nameDir + " " + i.surDir);

            resultsOper = from s in serias
                          join t in svazys2 on s.ID_Serias equals t.ID_Serias
                          where h.ID_Serias == s.ID_Serias
                          select new Serial2 { idOpers = t.ID_Operator, idSerias = s.ID_Serias };
            resultsOper2 = from o in operatorss
                           join t in resultsOper on o.ID_Operator equals t.idOpers
                           select new Operator2 { idOperator2 = o.ID_Operator, nameOper = o.Name, surOper = o.Surname };
            foreach (var i in resultsOper2)
                tb_OperatorS.Text += (i.nameOper + " " + i.surOper);

            resultsScr = from s in serias
                         join t in svazys3 on s.ID_Serias equals t.ID_Serias
                         where h.ID_Serias == s.ID_Serias
                         select new Serial2 { idScreWriters = t.ID_Screenwriter, idSerias = s.ID_Serias };
            resultsScr2 = from s in screenwriterss
                         join t in resultsScr on s.ID_Screenwriter equals t.idScreWriters
                         select new ScreenWriter2 { idScreenWriter2 = s.ID_Screenwriter, nameScr = s.Name, surScr = s.Surname };
            foreach (var i in resultsScr2)
                tb_ScreenwriterS.Text += (i.nameScr + " " + i.surScr + "  ");

            resultsActr = from s in serias
                          join t in svazys4 on s.ID_Serias equals t.ID_Serias
                          where h.ID_Serias == s.ID_Serias
                          select new Serial2 { idActors = t.ID_Actor, idSerias = s.ID_Serias };
            resultsActr2 = from a in actorss
                           join t in resultsActr on a.ID_Actor equals t.idActors
                           select new Actor2 { idActor2 = a.ID_Actor, nameActr = a.Name, surActor = a.Surname };
            foreach (var i in resultsActr2)
                tb_ActorS.Text += (i.nameActr + " " + i.surActor + "\n");

            resultsRat = from s in serias
                         join r in ratingss on s.ID_Rating equals r.ID_Rating
                         where h.ID_Rating == s.ID_Rating
                         where h.ID_Serias == s.ID_Serias
                         select new RatingS { idRatingS = r.ID_Rating, nameRatingS = r.Name };
            foreach (var i in resultsRat)
                tb_RatingS.Text += (i.nameRatingS);

            resultsAward = from s in serias
                           join t in svazys5 on s.ID_Serias equals t.ID_Serias
                           join o in nominationss on t.ID_Nomination equals o.ID_Nomination
                           join aw in awardss on o.ID_Awarts equals aw.ID_Awarts
                           where h.ID_Serias == s.ID_Serias
                           select new AwardsS { idAwardsS = aw.ID_Awarts, nameAwardsS = aw.Name, nameNominationS = o.Name };
            foreach (var i in resultsAward)
                tb_AwardsS.Text += (i.nameAwardsS + ":" + "\n" + i.nameNominationS);

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            GlavnayaWindow glavnaya = new GlavnayaWindow();
            glavnaya.Show();
            this.Close();
        }

        private void tb_FeedBackS_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FeedBackSerialWindow feedBackSerialWindow = new FeedBackSerialWindow();
            feedBackSerialWindow.Show();
        }

        private void tb_FeedBackS_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_FeedbackS.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_FeedBackS_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_FeedbackS.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void tb_DirectorS_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var d in resultsDir)
            {
                DirectorWindow directorWindow = new DirectorWindow(d);

                directorWindow.Show();
                this.Close();
            }
        }

        private void tb_DirectorS_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_DirectorS.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void tb_DirectorS_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_DirectorS.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_OperatorS_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var o in resultsOper2)
            {
                OperatorWindow operatorWindow = new OperatorWindow(o);

                operatorWindow.Show();
                this.Close();
            }
        }

        private void tb_OperatorS_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_OperatorS.Foreground = new SolidColorBrush(Colors.Blue);
        }
        
        private void tb_OperatorS_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_OperatorS.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_ScreenwriterS_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var s in resultsScr2)
            {
                ScreenWriterWindow screenWriterWindow = new ScreenWriterWindow(s);
                screenWriterWindow.Show();
                this.Close();
            }

        }

        private void tb_ScreenwriterS_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_ScreenwriterS.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void tb_ScreenwriterS_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_ScreenwriterS.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_ActorS_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var ac in resultsActr2)
            {
                ActorWindow actorWindow = new ActorWindow(ac);
                actorWindow.Show();
                this.Close();
            }

        }

        private void tb_ActorS_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_ActorS.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void tb_ActorS_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_ActorS.Foreground = new SolidColorBrush(Colors.White);
        }
    }
    public class Serial2
    {
        public int idSerias { get; set; }
        public int idDirs { get; set; }
        public int idOpers { get; set; }
        public int idScreWriters { get; set; }
        public int idActors { get; set; }
        public int idGenres { get; set; }
    }
    public class Director2
    {
        public string nameDir { get; set; }
        public string surDir { get; set; }
        public int idDirector2 { get; set; }
    }
 

    public class Operator2
    {
        public string nameOper { get; set; }
        public string surOper { get; set; }
        public int idOperator2 { get; set; }

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
    }
    public class RatingS
    {
        public string nameRatingS { get; set; }
        public int idRatingS { get; set; }
    }

    public class AwardsS
    {
        public string nameAwardsS { get; set; }
        public string nameNominationS { get; set; }
        public int idAwardsS { get; set; }
    }
}


