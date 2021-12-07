using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.entities;
using System.Data.SqlClient;
using System.Data.Entity;
using HelpEvent.View;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        public Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

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

        TicketModel selectedPlace;
        public TicketModel SelectedPlace
        {
            get { return selectedPlace; }
            set
            {
                selectedPlace = value;
                OnPropertyChanged("SelectedPlace");
            }
        }

        public BookingViewModel(UserModel user, EventModel ev)
        {
            SelectedEvent = ev;

            _viewId = Guid.NewGuid();

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
                      for (int i = 0; i < Rows.Count; i++)
                      {
                          TicketModel tr = SelectedTickets.Where(j => j.Id_ticket == Rows[i].SelectedPlace.Id_ticket).FirstOrDefault();
                          if (Rows[i].SelectedPlace.Id_event != 0)
                              if (SelectedTickets.Where(j => j.Id_ticket == Rows[i].SelectedPlace.Id_ticket).FirstOrDefault() == null)
                                  SelectedTickets.Add(Rows[i].SelectedPlace);
                              else SelectedTickets.Remove(tr);
                          Rows[i].SelectedPlace = new TicketModel();
                      }

                      //TicketModel t = (TicketModel)obj;
                      //var res = SelectedTickets.Where(i => i.Id_ticket == t.Id_ticket);
                      //if (res == null)
                      //    SelectedTickets.Add(t);
                      //else SelectedTickets.Remove(t);
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
