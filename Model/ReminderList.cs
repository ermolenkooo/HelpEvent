using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.entities;
using System.Windows;

namespace HelpEvent.Model
{
    public class ReminderList : INotifyPropertyChanged
    {
        private List<ReminderModel> allReminders;
        private List<Reminder> reminders;
        private EventDB db = new EventDB();

        public ReminderList()
        {
            checkDB(db);
            reminders = db.Reminder.ToList();
            allReminders = db.Reminder.ToList().Select(i => new ReminderModel(i)).ToList();
        }

        public List<ReminderModel> AllReminders
        {
            get { return allReminders; }
        }

        private void DBException()
        {
            MessageBox.Show("Ошибка подключения к базе, приложение будет закрыто", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            Environment.Exit(0);
        }

        private void checkDB(EventDB db)
        {
            try
            {
                if (!db.Database.Exists())
                {
                    DBException();
                }
            }
            catch (System.InvalidOperationException)
            {
                DBException();
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
