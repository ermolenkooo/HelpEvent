using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.entities;

namespace HelpEvent.Model
{
    public class TypeModel : INotifyPropertyChanged
    {
        private DAL.entities.Type typ = new DAL.entities.Type();

        public TypeModel() { }

        public TypeModel(DAL.entities.Type t)
        {
            typ = t;
        }

        public int Id_type
        {
            get { return typ.id_type; }
            set
            {
                typ.id_type = value;
                OnPropertyChanged("Id_type");
            }
        }

        public string Name_type
        {
            get { return typ.name_type; }
            set
            {
                typ.name_type = value;
                OnPropertyChanged("Name_type");
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
