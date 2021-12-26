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
    public class TicketModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private Ticket ticket = new Ticket();

        public TicketModel() { checkDB(db); }

        public TicketModel(Ticket t)
        {
            checkDB(db);
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

        string name_event;
        public string Name_event
        {
            get { return name_event; }
            set
            {
                name_event = value;
                OnPropertyChanged("Name_event");
            }
        }

        DateTime time;
        public DateTime Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        public int? Id_booking
        {
            get { return ticket.id_booking; }
            set
            {
                ticket.id_booking = value;
                OnPropertyChanged("Id_booking");
            }
        }

        public int Status
        {
            get { return ticket.status; }
            set
            {
                ticket.status = value;
                OnPropertyChanged("Status");
            }
        }

        public void Selected()
        {
            db.Ticket.Where(i => i.id_ticket == ticket.id_ticket).FirstOrDefault().status = 2;
            db.SaveChanges();
        }

        public void set_id_book(int id)
        {
            db.Ticket.Where(i => i.id_ticket == ticket.id_ticket).FirstOrDefault().id_booking = id;
            db.SaveChanges();
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
