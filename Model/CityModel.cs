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
    public class CityModel : INotifyPropertyChanged
    {
        private City city = new City();

        public CityModel() { }

        public CityModel(City c)
        {
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
