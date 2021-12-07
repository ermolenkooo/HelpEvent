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
