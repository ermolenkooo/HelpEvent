using System.Windows;
using HelpEvent.ViewModel;

namespace HelpEvent
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Window
    {
        public Авторизация()
        {
            InitializeComponent();
            DataContext = new AutoViewModel(this);
        }
    }
}
