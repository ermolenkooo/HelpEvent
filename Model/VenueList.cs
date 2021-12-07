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
    public class VenueList : INotifyPropertyChanged
    {
        private List<VenueModel> allVenues;
        private List<Venue> venues;
        private EventDB db = new EventDB();

        public VenueList()
        {
            venues = db.Venue.ToList();
            allVenues = db.Venue.ToList().Select(i => new VenueModel(i)).ToList();
        }

        public List<VenueModel> AllVenues
        {
            get { return allVenues; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
