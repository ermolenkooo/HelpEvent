using System.Windows;
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
            DataContext = new EvViewModel(ev, user, this);
        }
    }
}
