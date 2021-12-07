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
    public class CityList : INotifyPropertyChanged
    {
        private List<CityModel> allCities;
        private List<City> cities;
        private EventDB db = new EventDB();

        public CityList()
        {
            cities = db.City.ToList();
            allCities = db.City.ToList().Select(i => new CityModel(i)).ToList();
        }

        public List<CityModel> AllCities
        {
            get { return allCities; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
