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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.entities;
using System.Data.SqlClient;
using System.Data.Entity;
using HelpEvent.ViewModel;
using System.Windows.Interactivity;
using HelpEvent.Model;

namespace HelpEvent
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(null);
        }

        public MainWindow(UserModel user)
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(user);
        }
    }
}
