using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.entities;
using System.Windows;

namespace HelpEvent.Model
{
    public class EventModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private Event eve = new Event();

        public EventModel() { checkDB(db); }

        public EventModel(Event ev)
        {
            checkDB(db);
            eve = ev;
        }

        public int Id
        {
            get { return eve.id; }
            set
            {
                eve.id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return eve.name; }
            set
            {
                eve.name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return eve.description; }
            set
            {
                eve.description = value;
                OnPropertyChanged("Description");
            }
        }

        public int Id_organizer
        {
            get { return eve.id_organizer; }
            set
            {
                eve.id_organizer = value;
                OnPropertyChanged("Id_organizer");
            }
        }

        public int Id_category
        {
            get { return eve.id_category; }
            set
            {
                eve.id_category = value;
                OnPropertyChanged("Id_category");
            }
        }

        public int Id_type
        {
            get { return eve.id_type; }
            set
            {
                eve.id_type = value;
                OnPropertyChanged("Id_type");
            }
        }

        public int Id_venue
        {
            get { return eve.id_venue; }
            set
            {
                eve.id_venue = value;
                OnPropertyChanged("Id_venue");
            }
        }

        public string Poster
        {
            get { return eve.poster; }
            set
            {
                eve.poster = value;
                OnPropertyChanged("Poster");
            }
        }

        public DateTime Time
        {
            get { return eve.time; }
            set
            {
                eve.time = value;
                OnPropertyChanged("Time");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
