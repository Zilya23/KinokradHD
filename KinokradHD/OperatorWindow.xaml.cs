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
    /// Логика взаимодействия для OperatorWindow.xaml
    /// </summary>
    public partial class OperatorWindow : Window
    {
        public OperatorWindow(Operator2 result2)
        {
            InitializeComponent();
            var operators = bd_connection.connection.Operator.Where(x => x.ID_Operator == result2.idOperator2).FirstOrDefault();
            tb_NameO.Text = operators.Name + " " + operators.Surname;
            tb_BirthdayO.Text = (Convert.ToString(operators.Birthday).Split(' '))[0];
        }
    }
}
