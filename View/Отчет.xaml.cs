using System.Windows;
using HelpEvent.ViewModel;
using HelpEvent.Model;

namespace HelpEvent.View
{
    /// <summary>
    /// Логика взаимодействия для Отчет.xaml
    /// </summary>
    public partial class Отчет : Window
    {
        public Отчет(UserModel user)
        {
            InitializeComponent();
            DataContext = new ReportViewModel(user, this);
        }
    }
}
