using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using HelpEvent.Model;

namespace HelpEvent.ViewModel 
{
    class TicketsViewModel : INotifyPropertyChanged
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

        public List<TicketModel> tickets = new List<TicketModel>();
        public List<TicketModel> Tickets
        {
            get { return tickets; }
            set
            {
                tickets = value;
                OnPropertyChanged("Tickets");
            }
        }

        EventList allEvents = new EventList();

        BookingList allBookings = new BookingList();

        List<BookingModel> bookings;
        public List<BookingModel> Bookings
        {
            get { return bookings; }
            set
            {
                bookings = value;
                OnPropertyChanged("Bookings");
            }
        }

        TicketList allTickets = new TicketList();

        public TicketsViewModel(UserModel user)
        {
            this.User = user;

            var books = allBookings.AllBookings.Where(i => i.Id_user == User.Id_user).ToList();

            Tickets = new List<TicketModel> { };
            foreach (TicketModel t in allTickets.AllTickets)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (t.Id_booking == books[i].Id_booking)
                        Tickets.Add(t);
                }
            }

            Tickets = Tickets
                .Join(allEvents.AllEvents, tick => tick.Id_event, e => e.Id, (t, e) => new { e.Name, e.Time, t.Id_event, t.Id_booking, t.Id_ticket, t.Place, t.Price, t.Row, t.Status })
                .Select(j => new TicketModel { Id_booking = j.Id_booking, Id_event = j.Id_event, Id_ticket = j.Id_ticket, Name_event = j.Name, Place = j.Place, Price = j.Price, Row = j.Row, Status = j.Status, Time = j.Time })
                .ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
