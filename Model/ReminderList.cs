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
    public class ReminderList : INotifyPropertyChanged
    {
        private List<ReminderModel> allReminders;
        private List<Reminder> reminders;
        private EventDB db = new EventDB();

        public ReminderList()
        {
            reminders = db.Reminder.ToList();
            allReminders = db.Reminder.ToList().Select(i => new ReminderModel(i)).ToList();
        }

        public List<ReminderModel> AllReminders
        {
            get { return allReminders; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
