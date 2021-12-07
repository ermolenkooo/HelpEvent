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
    public class BookingModel : INotifyPropertyChanged
    {
        private Booking book = new Booking();

        public BookingModel() { }

        public BookingModel(Booking b)
        {
            book = b;
        }

        public int Id_booking
        {
            get { return book.id_booking; }
            set
            {
                book.id_booking = value;
                OnPropertyChanged("Id_booking");
            }
        }

        public int Number_of_tickets
        {
            get { return book.number_of_tickets; }
            set
            {
                book.number_of_tickets = value;
                OnPropertyChanged("Number_of_tickets");
            }
        }

        public int Id_user
        {
            get { return book.id_user; }
            set
            {
                book.id_user = value;
                OnPropertyChanged("Id_user");
            }
        }

        public decimal Cost
        {
            get { return book.cost; }
            set
            {
                book.cost = value;
                OnPropertyChanged("Cost");
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
