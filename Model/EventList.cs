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
    public class EventList : INotifyPropertyChanged
    {
        private List<EventModel> allEvents;
        private List<Event> events;
        private EventDB db = new EventDB();

        public EventList()
        {
            events = db.Event.ToList();
            allEvents = db.Event.ToList().Select(i => new EventModel(i)).ToList();
        }

        public List<EventModel> AllEvents
        {
            get { return allEvents; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
