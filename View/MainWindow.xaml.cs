using System.Windows;
using HelpEvent.ViewModel;
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
            DataContext = new ApplicationViewModel(null, this);
        }

        public MainWindow(UserModel user)
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(user, this);
        }
    }
}
