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
    public class CityModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private City city = new City();

        public CityModel() { checkDB(db); }

        public CityModel(City c)
        {
            checkDB(db);
            city = c;
        }

        public int Id_city
        {
            get { return city.id_city; }
            set
            {
                city.id_city = value;
                OnPropertyChanged("Id_city");
            }
        }

        public string Name_city
        {
            get { return city.name_city; }
            set
            {
                city.name_city = value;
                OnPropertyChanged("Name_city");
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
