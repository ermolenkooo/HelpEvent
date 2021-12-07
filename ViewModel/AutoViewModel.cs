using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.entities;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data.Entity;
using HelpEvent.View;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    public class AutoViewModel : INotifyPropertyChanged
    {
        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
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

        UserList allUsers = new UserList();

        List<UserModel> users;
        public List<UserModel> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

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

        public AutoViewModel()
        {
            _viewId = Guid.NewGuid();

            Users = new List<UserModel> { };
            foreach (UserModel u in allUsers.AllUsers)
            {
                Users.Add(new UserModel() { Id_user = u.Id_user, Login = u.Login, Password = u.Password });
            }

            Reminders = new List<ReminderModel> { };
            foreach (ReminderModel r in allReminders.AllReminders)
            {
                Reminders.Add(new ReminderModel() { Id_reminder = r.Id_reminder, Id_event = r.Id_event, Id_user = r.Id_user });
            }

            Events = new List<EventModel> { };
            foreach (EventModel ev in allEvents.AllEvents)
            {
                Events.Add(new EventModel() { Id = ev.Id, Description = ev.Description, Id_category = ev.Id_category, Id_organizer = ev.Id_organizer, Id_type = ev.Id_type, Id_venue = ev.Id_venue, Name = ev.Name, Number_of_seats = ev.Number_of_seats, Poster = ev.Poster, Time = ev.Time });
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

                      var u = Users
                      .Where(i => i.Login == Login && i.Password == clearTextPassword).FirstOrDefault();
                      if (u != null)
                      {
                          user = u;

                          MainWindow win = new MainWindow(user);
                          win.Show();

                          var res = Reminders
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
                      WindowManager.CloseWindow(ViewID);
                      reg.Show();
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
