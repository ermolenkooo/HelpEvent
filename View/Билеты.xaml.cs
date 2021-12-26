using System.Windows;
using HelpEvent.ViewModel;
using HelpEvent.Model;

namespace HelpEvent.View
{
    /// <summary>
    /// Логика взаимодействия для Билеты.xaml
    /// </summary>
    public partial class Билеты : Window
    {
        public Билеты(UserModel user)
        {
            InitializeComponent();
            DataContext = new TicketsViewModel(user);
        }
    }
}
