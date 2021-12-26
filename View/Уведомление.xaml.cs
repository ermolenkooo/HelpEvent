using System.Collections.Generic;
using System.Windows;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для Уведомление.xaml
    /// </summary>
    public partial class Уведомление : Window
    {
        public Уведомление(List<RemOutput> r)
        {
            InitializeComponent();
            DataContext = new RemViewModel(r);
        }
    }
}
