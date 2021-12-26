using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using HelpEvent.View;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    public class AutoViewModel : INotifyPropertyChanged
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

        UserList allUsers = new UserList();

        string login;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        ReminderList allReminders = new ReminderList();
        public List<ReminderModel> Reminders { get; set; }

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

        Window parentWindow = new Window();

        public AutoViewModel(Window w)
        {
            parentWindow = w;

            Events = new List<EventModel> { };
            foreach (EventModel ev in allEvents.AllEvents)
            {
                Events.Add(new EventModel() { Id = ev.Id, Description = ev.Description, Id_category = ev.Id_category, Id_organizer = ev.Id_organizer, Id_type = ev.Id_type, Id_venue = ev.Id_venue, Name = ev.Name, Poster = ev.Poster, Time = ev.Time });
            }
        }

        TimeSpan inter = new TimeSpan(24, 0, 0);
        TimeSpan inter1 = new TimeSpan(0, 0, 0);

        private RelayCommand logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return logInCommand ??
                  (logInCommand = new RelayCommand(obj =>
                  {
                      PasswordBox passwordBox = obj as PasswordBox;
                      string clearTextPassword = passwordBox.Password;

                      var u = allUsers.AllUsers
                      .Where(i => i.Login == Login && i.Password == clearTextPassword).FirstOrDefault();
                      if (u != null)
                      {
                          user = u;

                          MainWindow win = new MainWindow(user);
                          win.WindowState = parentWindow.WindowState;
                          win.Show();
                          parentWindow.Close();

                          var res = allReminders.AllReminders
                          .Join(Events, r => r.Id_event, e => e.Id, (r, e) => new { r.Id_user, e.Name, e.Time })
                          .Where(i => i.Id_user == User.Id_user && i.Time - DateTime.Now < inter && i.Time - DateTime.Now > inter1)
                          .Select(i => new RemOutput() { Name = i.Name, Time = i.Time })
                          .ToList();
                          if(res.Count != 0)
                          {
                              Уведомление alert = new Уведомление(res);
                              alert.Show();
                          }
                      }
                      else
                      {
                          ОшибкаВхода er = new ОшибкаВхода();
                          er.Show();
                      }
                  }));
            }
        }

        private RelayCommand registrCommand;
        public RelayCommand RegistrCommand
        {
            get
            {
                return registrCommand ??
                  (registrCommand = new RelayCommand(obj =>
                  {
                      Регистрация reg = new Регистрация();
                      reg.WindowState = parentWindow.WindowState;
                      reg.Show();
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
