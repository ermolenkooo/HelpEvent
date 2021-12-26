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
    public class MesModel : INotifyPropertyChanged
    {
        int id_mes;
        string name_mes;

        public int Id_mes
        {
            get { return id_mes; }
            set
            {
                id_mes = value;
                OnPropertyChanged("Id_mes");
            }
        }

        public string Name_mes
        {
            get { return name_mes; }
            set
            {
                name_mes = value;
                OnPropertyChanged("Name_mes");
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
