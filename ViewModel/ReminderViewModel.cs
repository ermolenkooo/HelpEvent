using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.entities;
using System.Data.SqlClient;
using System.Data.Entity;
using HelpEvent.View;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    public class ReminderViewModel : INotifyPropertyChanged
    {
        UserModel user;
        public UserModel User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public List<RemOutput> rems = new List<RemOutput>();
        public List<RemOutput> Rems
        {
            get { return rems; }
            set
            {
                rems = value;
                OnPropertyChanged("Rems");
            }
        }

        EventList allEvents = new EventList();

        List<EventModel> events;
        public List<EventModel> Events
        {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }

        ReminderList allReminders = new ReminderList();

        List<ReminderModel> reminders;
        public List<ReminderModel> Reminders
        {
            get { return reminders; }
            set
            {
                reminders = value;
                OnPropertyChanged("Reminders");
            }
        }

        public ReminderViewModel(UserModel user)
        {
            this.User = user;

            Events = new List<EventModel> { };
            foreach (EventModel ev in allEvents.AllEvents)
            {
                Events.Add(new EventModel() { Id = ev.Id, Description = ev.Description, Id_category = ev.Id_category, Id_organizer = ev.Id_organizer, Id_type = ev.Id_type, Id_venue = ev.Id_venue, Name = ev.Name, Number_of_seats = ev.Number_of_seats, Poster = ev.Poster, Time = ev.Time });
            }

            Reminders = new List<ReminderModel> { };
            foreach (ReminderModel r in allReminders.AllReminders)
            {
                Reminders.Add(new ReminderModel() { Id_reminder = r.Id_reminder, Id_event = r.Id_event, Id_user = r.Id_user });
            }

            Rems = Reminders
                        .Join(Events, r => r.Id_event, e => e.Id, (r, e) => new { r.Id_user, e.Name, e.Time })
                        .Where(i => i.Id_user == User.Id_user)
                        .Select(i => new RemOutput() { Name = i.Name, Time = i.Time })
                        .ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class RemOutput : INotifyPropertyChanged
    {
        public string name;
        public DateTime time;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public DateTime Time
        {
            get { return time; }
            set
            {
                time = value;
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
