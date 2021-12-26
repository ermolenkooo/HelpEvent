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
    public class TicketList : INotifyPropertyChanged
    {
        private List<TicketModel> allTickets;
        private List<Ticket> tickets;
        private EventDB db = new EventDB();

        public TicketList()
        {
            checkDB(db);
            tickets = db.Ticket.ToList();
            allTickets = db.Ticket.ToList().Select(i => new TicketModel(i)).ToList();
        }

        public List<TicketModel> AllTickets
        {
            get { return allTickets; }
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
