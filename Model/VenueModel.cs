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
    public class VenueModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private Venue venue = new Venue();

        public VenueModel() { checkDB(db); }

        public VenueModel(Venue v)
        {
            checkDB(db);
            venue = v;
        }

        public int Id_venue
        {
            get { return venue.id_venue; }
            set
            {
                venue.id_venue = value;
                OnPropertyChanged("Id_venue");
            }
        }

        public string Address
        {
            get { return venue.address; }
            set
            {
                venue.address = value;
                OnPropertyChanged("Address");
            }
        }

        public int Id_city
        {
            get { return venue.id_city; }
            set
            {
                venue.id_city = value;
                OnPropertyChanged("Id_city");
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
