using System.Windows;
using HelpEvent.ViewModel;
using HelpEvent.Model;

namespace HelpEvent.View
{
    /// <summary>
    /// Логика взаимодействия для Бронирование.xaml
    /// </summary>
    public partial class Бронирование : Window
    {
        public Бронирование(UserModel user, EventModel ev)
        {
            InitializeComponent();
            DataContext = new BookingViewModel(user, ev, this);
        }
    }
}
