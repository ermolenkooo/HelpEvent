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
    public class ReminderModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();

        private Reminder reminder = new Reminder();

        public ReminderModel() { }

        public ReminderModel(Reminder r)
        {
            reminder = r;
        }

        public int Id_reminder
        {
            get { return reminder.id_reminder; }
            set
            {
                reminder.id_reminder = value;
                OnPropertyChanged("Id_reminder");
            }
        }

        public int Id_event
        {
            get { return reminder.id_event; }
            set
            {
                reminder.id_event = value;
                OnPropertyChanged("Id_event");
            }
        }

        public int Id_user
        {
            get { return reminder.id_user; }
            set
            {
                reminder.id_user = value;
                OnPropertyChanged("Id_user");
            }
        }

        public void newReminder(ReminderModel r)
        {
            reminder.id_event = r.Id_event;
            reminder.id_user = r.Id_user;
            db.Reminder.Add(reminder);
            db.SaveChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
