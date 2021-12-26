using System.Windows;
using HelpEvent.ViewModel;
using HelpEvent.Model;

namespace HelpEvent.View
{
    /// <summary>
    /// Логика взаимодействия для Напоминания.xaml
    /// </summary>
    public partial class Напоминания : Window
    {
        public Напоминания(UserModel user)
        {
            InitializeComponent();
            DataContext = new ReminderViewModel(user);
        }
    }
}
