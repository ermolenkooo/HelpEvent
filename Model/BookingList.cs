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
    public class BookingList : INotifyPropertyChanged
    {
        private List<BookingModel> allBookings;
        private List<Booking> bookings;
        private EventDB db = new EventDB();

        public BookingList()
        {
            bookings = db.Booking.ToList();
            allBookings = db.Booking.ToList().Select(i => new BookingModel(i)).ToList();
        }

        public List<BookingModel> AllBookings
        {
            get { return allBookings; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
