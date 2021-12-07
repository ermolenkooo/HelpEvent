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
    public class EventModel : INotifyPropertyChanged
    {
        private Event eve = new Event();

        public EventModel() { }

        public EventModel(Event ev)
        {
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

        public int Number_of_seats
        {
            get { return eve.number_of_seats; }
            set
            {
                eve.number_of_seats = value;
                OnPropertyChanged("Number_of_seats");
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

        //public Organizer Organizer
        //{
        //    get { return events.Organizer; }
        //    set
        //    {
        //        events.Organizer = value;
        //        OnPropertyChanged("Organizer");
        //    }
        //}

        //public Category Category
        //{
        //    get { return events.Category; }
        //    set
        //    {
        //        events.Category = value;
        //        OnPropertyChanged("Category");
        //    }
        //}

        //public DAL.entities.Type Type
        //{
        //    get { return events.Type; }
        //    set
        //    {
        //        events.Type = value;
        //        OnPropertyChanged("Type");
        //    }
        //}

        //public Venue Venue
        //{
        //    get { return events.Venue; }
        //    set
        //    {
        //        events.Venue = value;
        //        OnPropertyChanged("Venue");
        //    }
        //}

        //public ICollection<Booking> Booking
        //{
        //    get { return events.Booking; }
        //    set
        //    {
        //        events.Booking = value;
        //        OnPropertyChanged("Booking");
        //    }
        //}

        //public ICollection<Reminder> Reminder
        //{
        //    get { return events.Reminder; }
        //    set
        //    {
        //        events.Reminder = value;
        //        OnPropertyChanged("Reminder");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
