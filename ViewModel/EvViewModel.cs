using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using DAL.entities;
using System.Data.SqlClient;
using System.Data.Entity;
using HelpEvent.View;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    public class EvViewModel : INotifyPropertyChanged
    {
        EventModel selectedEvent;
        OrganizerModel organizer;
        VenueModel venue;

        OrganizerList allOrganizers = new OrganizerList();
        public ObservableCollection<OrganizerModel> Organizers { get; set; }

        VenueList allVenues = new VenueList();
        public ObservableCollection<VenueModel> Venues { get; set; }

        ReminderList allReminders = new ReminderList();
        public List<ReminderModel> Reminders { get; set; }

        public EventModel SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }

        public OrganizerModel Organizer
        {
            get { return organizer; }
            set
            {
                organizer = value;
                OnPropertyChanged("Organizer");
            }
        }

        public VenueModel Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                OnPropertyChanged("Venue");
            }
        }

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

        public EvViewModel(EventModel ev, UserModel user)
        {
            this.User = user;

            SelectedEvent = ev;

            Organizers = new ObservableCollection<OrganizerModel> { };
            foreach (OrganizerModel or in allOrganizers.AllOrganizers)
            {
                Organizers.Add(new OrganizerModel() {Id_organizer = or.Id_organizer, Name_organizer=or.Name_organizer, Phone=or.Phone});
            }

            organizer = Organizers.Where(i => i.Id_organizer == selectedEvent.Id_organizer).FirstOrDefault();

            Venues = new ObservableCollection<VenueModel> { };
            foreach (VenueModel v in allVenues.AllVenues)
            {
                Venues.Add(new VenueModel() { Id_venue = v.Id_venue, Address= v.Address, Id_city=v.Id_city });
            }

            venue = Venues.Where(i => i.Id_venue == selectedEvent.Id_venue).FirstOrDefault();

            if (User != null)
            {
                Reminders = new List<ReminderModel> { };
                foreach (ReminderModel r in allReminders.AllReminders)
                {
                    Reminders.Add(new ReminderModel() { Id_reminder = r.Id_reminder, Id_event = r.Id_event, Id_user = r.Id_user });
                }

                Reminders = Reminders
                    .Where(i => i.Id_user == User.Id_user)
                    .ToList();
            }
        }

        private RelayCommand logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return logInCommand ??
                  (logInCommand = new RelayCommand(obj =>
                  {
                      Авторизация login = new Авторизация();
                      login.Show();
                  }));
            }
        }

        private RelayCommand remCommand;
        public RelayCommand RemCommand
        {
            get
            {
                return remCommand ??
                  (remCommand = new RelayCommand(obj =>
                  {
                      var res = Reminders
                      .Where(i => i.Id_event == selectedEvent.Id)
                      .ToList();

                      if(res.Count == 0)
                      {
                          ReminderModel reminder = new ReminderModel();
                          reminder.Id_user = User.Id_user;
                          reminder.Id_event = selectedEvent.Id;
                          reminder.newReminder(reminder);
                      }
                      //тут выводить что напоминание уже включалось ранее или что вот ура включилось
                  }));
            }
        }

        private RelayCommand bookingCommand;
        public RelayCommand BookingCommand
        {
            get
            {
                return bookingCommand ??
                  (bookingCommand = new RelayCommand(obj =>
                  {
                      var a = 0;
                      Бронирование book = new Бронирование(User, SelectedEvent);
                      book.Show();
                  }));
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
