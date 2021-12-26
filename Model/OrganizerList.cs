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
    public class OrganizerList : INotifyPropertyChanged
    {
        private List<OrganizerModel> allOrganizers;
        private List<Organizer> organizers;
        private EventDB db = new EventDB();

        public OrganizerList()
        {
            checkDB(db);
            organizers = db.Organizer.ToList();
            allOrganizers = db.Organizer.ToList().Select(i => new OrganizerModel(i)).ToList();
        }

        public List<OrganizerModel> AllOrganizers
        {
            get { return allOrganizers; }
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
