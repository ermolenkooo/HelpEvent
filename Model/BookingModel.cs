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
    public class BookingModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private Booking book = new Booking();

        public BookingModel() { checkDB(db); }

        public BookingModel(Booking b)
        {
            checkDB(db);
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

        public int Id_event
        {
            get { return book.id_event; }
            set
            {
                book.id_event = value;
                OnPropertyChanged("Id_event");
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

        public int newBooking(BookingModel b)
        {
            book.cost = b.Cost;
            book.id_event = b.Id_event;
            book.id_user = b.Id_user;
            book.number_of_tickets = b.Number_of_tickets;
            db.Booking.Add(book);
            db.SaveChanges();
            return book.id_booking;
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
