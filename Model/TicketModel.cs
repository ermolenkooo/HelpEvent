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
    public class TicketModel : INotifyPropertyChanged
    {
        private Ticket ticket = new Ticket();

        public TicketModel() { }

        public TicketModel(Ticket t)
        {
            ticket = t;
        }

        public int Id_ticket
        {
            get { return ticket.id_ticket; }
            set
            {
                ticket.id_ticket = value;
                OnPropertyChanged("Id_ticket");
            }
        }

        public int Row
        {
            get { return ticket.row; }
            set
            {
                ticket.row = value;
                OnPropertyChanged("Row");
            }
        }

        public int Place
        {
            get { return ticket.place; }
            set
            {
                ticket.place = value;
                OnPropertyChanged("Place");
            }
        }

        public decimal Price
        {
            get { return ticket.price; }
            set
            {
                ticket.price = value;
                OnPropertyChanged("Price");
            }
        }

        public int Id_event
        {
            get { return ticket.id_event; }
            set
            {
                ticket.id_event = value;
                OnPropertyChanged("Id_event");
            }
        }

        //public int Id_booking
        //{
        //    get { return (int)ticket.id_booking; }
        //    set
        //    {
        //        ticket.id_booking = value;
        //        OnPropertyChanged("Id_booking");
        //    }
        //}

        public int Status
        {
            get { return ticket.status; }
            set
            {
                ticket.status = value;
                OnPropertyChanged("Status");
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
