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
    public class OrganizerModel : INotifyPropertyChanged
    {
        private Organizer organizer = new Organizer();

        public OrganizerModel() { }

        public OrganizerModel(Organizer o)
        {
            organizer = o;
        }

        public int Id_organizer
        {
            get { return organizer.id_organizer; }
            set
            {
                organizer.id_organizer = value;
                OnPropertyChanged("Id_organizer");
            }
        }

        public string Name_organizer
        {
            get { return organizer.name_organizer; }
            set
            {
                organizer.name_organizer = value;
                OnPropertyChanged("Name_organizer");
            }
        }

        public string Phone
        {
            get { return organizer.phone; }
            set
            {
                organizer.phone = value;
                OnPropertyChanged("Phone");
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
