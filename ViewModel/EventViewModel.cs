using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    class EventViewModel : INotifyPropertyChanged
    {
        private EventModel events;
        public EventViewModel(EventModel e)
        {
            events = e;
        }

        public string Name
        {
            get { return events.Name; }
            set
            {
                events.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return events.Description; }
            set
            {
                events.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public int Number_of_seats
        {
            get { return events.Number_of_seats; }
            set
            {
                events.Number_of_seats = value;
                OnPropertyChanged("Number_of_seats");
            }
        }

        public int Id_organizer
        {
            get { return events.Id_organizer; }
            set
            {
                events.Id_organizer = value;
                OnPropertyChanged("Id_organizer");
            }
        }

        public int Id_category
        {
            get { return events.Id_category; }
            set
            {
                events.Id_category = value;
                OnPropertyChanged("Id_category");
            }
        }

        public int Id_type
        {
            get { return events.Id_type; }
            set
            {
                events.Id_type = value;
                OnPropertyChanged("Id_type");
            }
        }

        public int Id_venue
        {
            get { return events.Id_venue; }
            set
            {
                events.Id_venue = value;
                OnPropertyChanged("Id_venue");
            }
        }

        public string Poster
        {
            get { return events.Poster; }
            set
            {
                events.Poster = value;
                OnPropertyChanged("Poster");
            }
        }

        public DateTime Time
        {
            get { return events.Time; }
            set
            {
                events.Time = value;
                OnPropertyChanged("Time");
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
