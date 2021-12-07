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
    public class TicketList : INotifyPropertyChanged
    {
        private List<TicketModel> allTickets;
        private List<Ticket> tickets;
        private EventDB db = new EventDB();

        public TicketList()
        {
            tickets = db.Ticket.ToList();
            allTickets = db.Ticket.ToList().Select(i => new TicketModel(i)).ToList();
        }

        public List<TicketModel> AllTickets
        {
            get { return allTickets; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
