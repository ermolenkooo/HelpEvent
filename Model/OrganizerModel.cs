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
    public class OrganizerModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private Organizer organizer = new Organizer();

        public OrganizerModel() { checkDB(db); }

        public OrganizerModel(Organizer o)
        {
            checkDB(db);
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

        private void DBException()
        {
            MessageBox.Show("Ошибка подключения к базе, приложение будет закрыто", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            Environment.Exit(0);
        }

        private void checkDB(EventDB db)
        {
            try
            {
                if (!db.Database.Exists())
                {
                    DBException();
                }
            }
            catch (System.InvalidOperationException)
            {
                DBException();
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
