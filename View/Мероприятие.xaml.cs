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
//using DAL.entities;
using HelpEvent.ViewModel;
using HelpEvent.Model;

namespace HelpEvent.View
{
    /// <summary>
    /// Логика взаимодействия для Мероприятие.xaml
    /// </summary>
    public partial class Мероприятие : Window
    {
        public Мероприятие(EventModel ev, UserModel user)
        {
            InitializeComponent();
            DataContext = new EvViewModel(ev, user);
        }
    }
}
