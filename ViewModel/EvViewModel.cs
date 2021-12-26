using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using HelpEvent.View;
using HelpEvent.Model;
using System.Windows;

namespace HelpEvent.ViewModel
{
    public class EvViewModel : INotifyPropertyChanged
    {
        EventModel selectedEvent;
        OrganizerModel organizer;
        VenueModel venue;

        OrganizerList allOrganizers = new OrganizerList();

        VenueList allVenues = new VenueList();

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

        Window parentWindow = new Window();
        public EvViewModel(EventModel ev, UserModel user, Window w)
        {
            this.User = user;

            SelectedEvent = ev;

            parentWindow = w;

            venue = allVenues.AllVenues.Where(i => i.Id_venue == selectedEvent.Id_venue).FirstOrDefault();
            organizer = allOrganizers.AllOrganizers.Where(i => i.Id_organizer == SelectedEvent.Id_organizer).FirstOrDefault();

            if (User != null)
            {
                Reminders = allReminders.AllReminders
                    .Where(i => i.Id_user == User.Id_user)
                    .ToList();
            }
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return backCommand ??
                  (backCommand = new RelayCommand(obj =>
                  {
                      MainWindow m = new MainWindow(User);
                      m.WindowState = parentWindow.WindowState;
                      m.Show();
                      parentWindow.Close();
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
                          Увед2 w = new Увед2();
                          w.ShowDialog();
                          ReminderList allReminders = new ReminderList();
                          Reminders = allReminders.AllReminders
                            .Where(i => i.Id_user == User.Id_user)
                            .ToList();
                      }
                      else
                      {
                          Увед1 w = new Увед1();
                          w.ShowDialog();
                      }
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
                      Бронирование book = new Бронирование(User, SelectedEvent);
                      book.WindowState = parentWindow.WindowState;
                      book.Show();
                      parentWindow.Close();
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
