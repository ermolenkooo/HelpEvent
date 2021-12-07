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
    public class RowModel : INotifyPropertyChanged
    {
        private List<TicketModel> places = new List<TicketModel>();

        private TicketModel selectedPlace = new TicketModel();

        public List<TicketModel> Places
        {
            get { return places; }
            set
            {
                places = value;
                OnPropertyChanged("Places");
            }
        }

        public TicketModel SelectedPlace
        {
            get { return selectedPlace; }
            set
            {
                selectedPlace = value;
                OnPropertyChanged("SelectedPlace");
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
