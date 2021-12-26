using System.Windows;
using HelpEvent.ViewModel;

namespace HelpEvent
{
    /// <summary>
    /// Логика взаимодействия для Регистрация.xaml
    /// </summary>
    public partial class Регистрация : Window
    {
        public Регистрация()
        {
            InitializeComponent();
            DataContext = new RegViewModel(this);
        }
    }
}
