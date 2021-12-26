using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.entities;
using System.Windows;

namespace HelpEvent.Model
{
    public class FormatModel : INotifyPropertyChanged
    {
        int id_format;
        string name_format;

        public int Id_format
        {
            get { return id_format; }
            set
            {
                id_format = value;
                OnPropertyChanged("Id_format");
            }
        }

        public string Name_format
        {
            get { return name_format; }
            set
            {
                name_format = value;
                OnPropertyChanged("Name_format");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
