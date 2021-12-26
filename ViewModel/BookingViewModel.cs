using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using HelpEvent.View;
using HelpEvent.Model;
using System.Windows;

namespace HelpEvent.ViewModel
{
    public class BookingViewModel : INotifyPropertyChanged
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

        TicketList allTickets = new TicketList();

        List<TicketModel> tickets;
        public List<TicketModel> Tickets
        {
            get { return tickets; }
            set
            {
                tickets = value;
                OnPropertyChanged("Tickets");
            }
        }

        EventModel selectedEvent;
        public EventModel SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }

        ObservableCollection<RowModel> rows;
        public ObservableCollection<RowModel> Rows
        {
            get { return rows; }
            set
            {
                rows = value;
                OnPropertyChanged("Rows");
            }
        }

        List<TicketModel> selectedTickets = new List<TicketModel> { };
        public List<TicketModel> SelectedTickets 
        {
            get { return selectedTickets; }
            set
            {
                selectedTickets = value;
                OnPropertyChanged("SelectedTickets");
            }
        }

        BookingModel newBook;
        public BookingModel NewBook
        {
            get { return newBook; }
            set
            {
                newBook = value;
                OnPropertyChanged("NewBook");
            }
        }

        decimal cost = 0;
        public decimal Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }

        Window parentWindow = new Window();

        public BookingViewModel(UserModel user, EventModel ev, Window w)
        {
            SelectedEvent = ev;

            parentWindow = w;

            this.User = user;

            Tickets = new List<TicketModel> { };
            foreach (TicketModel t in allTickets.AllTickets)
            {
                if(t.Id_event == SelectedEvent.Id)
                    Tickets.Add(new TicketModel() { Id_ticket = t.Id_ticket, Id_event = t.Id_event, Place = t.Place, Price = t.Price, Row = t.Row, Status = t.Status });
            }

            int row_number = 0;
            if(Tickets.Count != 0)
                row_number = Tickets.Max(i => i.Row);

            Rows = new ObservableCollection<RowModel> { };
            int j = 1;
            while(j <= row_number)
            {
                var res = Tickets.Where(i => i.Row == j).ToList();
                Rows.Add(new RowModel());
                Rows[j - 1].Places = res;
                j++;
            }
        }

        private RelayCommand placeCommand;
        public RelayCommand PlaceCommand
        {
            get
            {
                return placeCommand ??
                  (placeCommand = new RelayCommand(obj =>
                  {
                      SelectedTickets = new List<TicketModel>();
                      int i = 0;
                      int j = 0;
                      Cost = 0;
                      while (i < Rows.Count)
                      {
                          j = 0;
                          while (j < Rows[i].SelectedItems.Count)
                          {
                              SelectedTickets.Add(Rows[i].SelectedItems[j]);
                              Cost += Rows[i].SelectedItems[j].Price;
                              j++;
                          }
                          i++;
                      }
                  }));
            }
        }

        private RelayCommand newBookingCommand;
        public RelayCommand NewBookingCommand
        {
            get
            {
                return newBookingCommand ??
                  (newBookingCommand = new RelayCommand(obj =>
                  {
                      if (SelectedTickets.Count != 0)
                      {
                          int i = 0;
                          while (i < SelectedTickets.Count)
                          {
                              SelectedTickets[i].Selected();
                              i++;
                          }
                          NewBook = new BookingModel();
                          NewBook.Id_user = User.Id_user;
                          NewBook.Number_of_tickets = SelectedTickets.Count;
                          NewBook.Cost = Cost;
                          NewBook.Id_event = SelectedEvent.Id;
                          int id_book = NewBook.newBooking(NewBook);
                          i = 0;
                          while (i < SelectedTickets.Count)
                          {
                              SelectedTickets[i].set_id_book(id_book);
                              i++;
                          }
                          Бронь win = new Бронь();
                          win.ShowDialog();
                          Мероприятие w = new Мероприятие(SelectedEvent, User);
                          w.WindowState = parentWindow.WindowState;
                          w.Show();
                          parentWindow.Close();
                      }
                  }));
            }
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return backCommand ??
                  (backCommand = new RelayCommand(obj =>
                  {
                      Мероприятие m = new Мероприятие(SelectedEvent, User);
                      m.WindowState = parentWindow.WindowState;
                      m.Show();
                      parentWindow.Close();
                  }));
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
