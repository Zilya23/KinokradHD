﻿using System;
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
    /// Логика взаимодействия для Addindow.xaml
    /// </summary>
    public partial class Addindow : Window
    {
        public static Film film = new Film();
        public Addindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
